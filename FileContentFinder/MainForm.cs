using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileContentFinder
{
    public partial class MainForm : Form
    {
        private ContextMenuStrip contextMenu;
        private string baseDirectory;
        // Stores the search text for highlighting matching lines in the file content
        private string lastSearchText;

        // List of starting indices for all occurrences of the search text.
        private List<int> matchIndices = new List<int>();
        // The current match index in the list of occurrences.
        private int currentMatchIndex = -1;

        public MainForm()
        {
            InitializeComponent();
            InitializeContextMenu();
            treeViewResults.Visible = false; // initially listBox is default
        }

        /// <summary>
        /// Initializes the context menu for the treeViewResults with options:
        /// "Open File" and "Open Directory".
        /// </summary>
        private void InitializeContextMenu()
        {
            contextMenu = new ContextMenuStrip();

            ToolStripMenuItem openFileMenuItem = new ToolStripMenuItem("Open File");
            ToolStripMenuItem openDirectoryMenuItem = new ToolStripMenuItem("Open Directory");

            openFileMenuItem.Click += OpenFileMenuItem_Click;
            openDirectoryMenuItem.Click += OpenDirectoryMenuItem_Click;

            contextMenu.Items.AddRange(new ToolStripItem[] { openFileMenuItem, openDirectoryMenuItem });

            // Associate the context menu with the TreeView and ListBox
            treeViewResults.ContextMenuStrip = contextMenu;
            listBoxResults.ContextMenuStrip = contextMenu;
        }

        private void treeViewResults_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                treeViewResults.SelectedNode = e.Node;
            }
        }
        // When a node is selected in the TreeView (left click), display file content
        private void treeViewResults_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null && e.Node.Tag != null)
            {
                string filePath = e.Node.Tag.ToString();
                try
                {
                    // Read the entire content of the file
                    string content = File.ReadAllText(filePath);
                    // Clear the RichTextBox and set the file content
                    richTextBoxContents.Clear();
                    richTextBoxContents.Text = content;
                    // Highlight all occurrences of the search text in the RichTextBox
                    HighlightSearchText(richTextBoxContents, lastSearchText);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error reading file: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Highlights all occurrences of searchText in the provided RichTextBox.
        /// Uses SelectionBackColor to apply a highlight color.
        /// </summary>
        private void HighlightSearchText(RichTextBox rtb, string searchText)
        {
            // Clear any previous match information.
            matchIndices.Clear();
            currentMatchIndex = -1;

            if (string.IsNullOrEmpty(searchText))
                return;

            int startIndex = 0;
            // Reset selection to ensure the entire text is unformatted initially.
            rtb.SelectionStart = 0;
            rtb.SelectionLength = 0;

            // Loop through the text and find each occurrence of the search text.
            while (startIndex < rtb.TextLength)
            {
                // Use Find() method with case-insensitive search (omit MatchCase flag for case-insensitive)
                int wordStartIndex = rtb.Find(searchText, startIndex, RichTextBoxFinds.None);
                if (wordStartIndex != -1)
                {
                    matchIndices.Add(wordStartIndex);
                    // Select the found text
                    rtb.Select(wordStartIndex, searchText.Length);
                    // Apply the highlight color
                    rtb.SelectionBackColor = Color.GreenYellow;
                    // Move startIndex beyond the current found instance
                    startIndex = wordStartIndex + searchText.Length;
                }
                else break;
            }
            // Reset selection to the beginning.
            rtb.SelectionStart = 0;
            rtb.SelectionLength = 0;

            // if any matches were found, set the first one as current.
            if (matchIndices.Count > 0)
            {
                currentMatchIndex = 0;
                rtb.Select(matchIndices[currentMatchIndex], searchText.Length);
                rtb.SelectionBackColor = Color.Orange; // Highlight current match
                rtb.SelectionStart = 0;
                rtb.SelectionLength = 0;
                bFindNext.Visible = true;
                bFindPrev.Visible = true;
            }

            // Update the label with match count and current index.
            lblFoundInFile.Text = matchIndices.Count > 0
                ? $"Matches found in File: {matchIndices.Count} (Current: {currentMatchIndex + 1})"
                : "No matches found";

        }

        /// <summary>
        /// Opens the file associated with the selected node (if any).
        /// </summary>
        private void OpenFileMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = string.Empty;

            // get filepath from active results renderer
            if (treeViewResults.Visible && treeViewResults.SelectedNode != null && treeViewResults.SelectedNode.Tag != null)
                filePath = treeViewResults.SelectedNode.Tag.ToString();
            else if (listBoxResults.SelectedItem != null)
                filePath = listBoxResults.SelectedItem.ToString();

            if (!string.IsNullOrEmpty(filePath))
            {
                try
                {
                    Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error opening file: {ex.Message}");
                }
            }
            else MessageBox.Show($"Error opening file: name is empty!");
        }

        /// <summary>
        /// Opens the directory associated with the selected item on Results Renderer.
        /// In TreeView case, if the node represents a file, its containing folder is opened.
        /// If it represents a folder, the folder is opened.
        /// </summary>
        private void OpenDirectoryMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = string.Empty;

            if (treeViewResults.Visible && treeViewResults.SelectedNode != null)
            {
                if (treeViewResults.SelectedNode.Tag != null)
                {
                    // Node represents a file; get its directory.
                    string path = treeViewResults.SelectedNode.Tag.ToString();
                    filePath = Path.GetDirectoryName(path);
                }
                else
                {
                    // Node represents a folder.
                    filePath = GetFullPathFromNode(treeViewResults.SelectedNode);
                }
            }
            else if (listBoxResults.SelectedItem != null) // listBox case
            {
                string path = listBoxResults.SelectedItem.ToString();
                filePath = Path.GetDirectoryName(path);
            }

            if (!string.IsNullOrEmpty(filePath) && Directory.Exists(filePath))
            {
                try
                {
                    Process.Start(new ProcessStartInfo("explorer.exe", filePath) { UseShellExecute = true });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error opening directory: {ex.Message}");
                }
            }
            else MessageBox.Show($"Error opening file: Directory {filePath} do not exists!");
        }

        /// <summary>
        /// Constructs the full directory path from a TreeNode.
        /// The TreeView's FullPath (with the default '\' separator) is appended to the baseDirectory.
        /// </summary>
        private string GetFullPathFromNode(TreeNode node)
        {
            string pattern = @"^(?:[A-Za-z]:|[^\\]+)";
            string fullPath = baseDirectory + Regex.Replace(node.FullPath, pattern, "");

            return fullPath;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    txtDirectory.Text = folderDialog.SelectedPath;
                }
            }
        }

        private async void btnSearch_ClickAsync(object sender, EventArgs e)
        {
            string directory = txtDirectory.Text;
            string searchText = txtSearchText.Text;
            string filter = txtFilter.Text;

            if (string.IsNullOrEmpty(directory) || !Directory.Exists(directory))
            {
                MessageBox.Show("Please select a valid directory.");
                return;
            }

            if (string.IsNullOrEmpty(searchText))
            {
                MessageBox.Show("Please enter the text to search for.");
                return;
            }

            if (string.IsNullOrEmpty(filter))
            {
                filter = "*.cfg";
            }

            // Save the base directory for later use in building the TreeView.
            baseDirectory = directory;
            lastSearchText = searchText; // Save search text for highlighting in file content

            treeViewResults.Nodes.Clear();
            listBoxResults.Items.Clear();
            richTextBoxContents.Clear();

            btnSearch.Enabled = false;
            lblStatus.Text = "Searching...";
            lblProcessed.Text = "Files scanned: 0";
            lblFoundInFile.Text = "Matches found in File: 0";
            bFindNext.Visible = false;
            bFindPrev.Visible = false;

            // Create a progress reporter to update the label for processed files
            var progress = new Progress<int>(count =>
            {
                lblProcessed.Text = $"Files scanned: {count}";
            });

            // Run the file search
            List<string> foundFiles = await Task.Run(() => SearchFiles(directory, searchText, filter, progress));

            // Build the TreeView to group results by folder structure.
            BuildTreeView(foundFiles, directory);
            listBoxResults.Items.AddRange(foundFiles.ToArray());
            
            bExpandAll.Enabled = true;
            bCollapseAll.Enabled = true;
            btnSearch.Enabled = true;

            lblStatus.Text = $"Files found: {foundFiles.Count}";

        }

        /// <summary>
        /// Recursively searches through the specified directory (and all subdirectories)
        /// for files that match the given filter and contain the specified search text.
        /// </summary>
        /// <param name="directory">The path of the directory to search in.</param>
        /// <param name="searchText">The text to search for within the files.</param>
        /// <param name="filter">File filter pattern (e.g., "*.cfg" or "*.cfg;*.txt").</param>
        /// <param name="progress">Progress reporter to update the number of files processed.</param>
        /// <returns>A list of file paths where the search text was found.</returns>
        private List<string> SearchFiles(string directory, string searchText, string filter, IProgress<int> progress)
        {
            List<string> foundFiles = new List<string>();
            int processedFiles = 0;

            // If the filter contains multiple patterns, split them by semicolon
            string[] filters = filter.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string pattern in filters)
            {
                // Get files matching the current pattern, including subdirectories
                string[] files = Directory.GetFiles(directory, pattern, SearchOption.AllDirectories);
                foreach (string file in files)
                {
                    processedFiles++;

                    if (processedFiles % 100 == 0)
                        progress?.Report(processedFiles);

                    try
                    {
                        // Read the content of the file.
                        // For very large files, consider reading line by line to optimize performance.
                        string fileContent = File.ReadAllText(file);

                        // Check if the file contains the search text
                        if (fileContent.Contains(searchText))
                        {
                            foundFiles.Add(file);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Log the exception or simply skip problematic files
                        // Example: Debug.WriteLine($"Error reading file {file}: {ex.Message}");
                    }
                }
            }
            progress?.Report(processedFiles);
            return foundFiles;
        }

        /// <summary>
        /// Builds the TreeView by grouping found files into categories based on their folder structure.
        /// For each file, its relative path (from the base directory) is used to create nodes.
        /// </summary>
        private void BuildTreeView(List<string> foundFiles, string baseDirectory)
        {
            treeViewResults.BeginUpdate();
            treeViewResults.Nodes.Clear();

            foreach (string file in foundFiles)
            {
                // Get the relative path of the file from the base directory
                string relativePath = GetRelativePath(baseDirectory, file);
                // Split the relative path into parts (folders and the file name)
                string[] parts = relativePath.Split(Path.DirectorySeparatorChar);

                TreeNodeCollection currentNodes = treeViewResults.Nodes;
                TreeNode currentNode = null;

                for (int i = 0; i < parts.Length; i++)
                {
                    string part = parts[i];
                    // Attempt to find an existing node with the current part as key.
                    TreeNode[] nodes = currentNodes.Find(part, false);
                    if (nodes.Length == 0)
                    {
                        currentNode = new TreeNode(part);
                        currentNode.Name = part; // Set key for the current node.
                        // If this is the last part, it represents a file.
                        if (i == parts.Length - 1)
                        {
                            // Store the full file path in the Tag property.
                            currentNode.Tag = file;
                        }
                        currentNodes.Add(currentNode);
                    }
                    else
                    {
                        currentNode = nodes[0];
                        // If it's the last part, update Tag (in case of duplicate file names, adjust as needed).
                        if (i == parts.Length - 1)
                        {
                            currentNode.Tag = file;
                        }
                    }
                    // Move to the next level of nodes.
                    currentNodes = currentNode.Nodes;
                }
            }

            treeViewResults.EndUpdate();
        }
        public string GetRelativePath(string relativeTo, string path)
        {
            var uri = new Uri(relativeTo);
            var rel = Uri.UnescapeDataString(uri.MakeRelativeUri(new Uri(path)).ToString()).Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
            if (rel.Contains(Path.DirectorySeparatorChar.ToString()) == false)
            {
                rel = $".{Path.DirectorySeparatorChar}{rel}";
            }
            return rel;
        }
        private void listBoxResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxResults.SelectedItem != null)
            {
                // Retrieve the file path from the selected ListBox item.
                string filePath = listBoxResults.SelectedItem.ToString();
                try
                {
                    // Read the entire file content.
                    string content = File.ReadAllText(filePath);

                    // Clear the content panel (RichTextBox) and display the file content.
                    richTextBoxContents.Clear();
                    richTextBoxContents.Text = content;

                    // Highlight occurrences of the search text.
                    HighlightSearchText(richTextBoxContents, lastSearchText);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error reading file: {ex.Message}");
                }
            }
        }
        
        

        private void cbTreeView_CheckedChanged(object sender, EventArgs e)
        {
            // switch between TreeView and ListBox view
            bExpandAll.Visible = cbTreeView.Checked;
            bCollapseAll.Visible = cbTreeView.Checked;
            treeViewResults.Visible = cbTreeView.Checked;
            listBoxResults.Visible = !cbTreeView.Checked;
            listBoxResults.ClearSelected();
        }

        private void bExpandAll_Click(object sender, EventArgs e)
        {
            if(treeViewResults.Nodes.Count== 0) return;

            treeViewResults.ExpandAll();
            treeViewResults.SelectedNode = treeViewResults.Nodes[0];
            treeViewResults.Select();
        }

        private void bCollapseAll_Click(object sender, EventArgs e)
        {
            treeViewResults.CollapseAll();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Version version = assembly.GetName().Version;

            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            string fileVersion = fileVersionInfo.FileVersion;

            // Set the label text with version and build info
            lblVersionInfo.Text = $"Version: {version} by Assembler";
        }

        private void splitContainerResults_SplitterMoved(object sender, SplitterEventArgs e)
        {
            lblFoundInFile.Left = e.SplitX+20;
        }

        /// <summary>
        /// Event handler for the "Next" button.
        /// Navigates to the next occurrence of the search text.
        /// </summary>
        private void bFindNext_Click(object sender, EventArgs e)
        {
            if (matchIndices.Count == 0)
                return;

            // Revert the current match highlight back to the base color.
            richTextBoxContents.Select(matchIndices[currentMatchIndex], lastSearchText.Length);
            richTextBoxContents.SelectionBackColor = Color.GreenYellow;

            // Move to the next match; wrap around if at the end.
            currentMatchIndex++;
            if (currentMatchIndex >= matchIndices.Count)
                currentMatchIndex = 0;

            // Highlight the new current match with a distinct color.
            richTextBoxContents.Select(matchIndices[currentMatchIndex], lastSearchText.Length);
            richTextBoxContents.SelectionBackColor = Color.Orange;
            richTextBoxContents.ScrollToCaret();
            richTextBoxContents.SelectionStart = 0;
            richTextBoxContents.SelectionLength = 0;

            // Update label with current match info.
            lblFoundInFile.Text = $"Matches found in File: {matchIndices.Count} (Current: {currentMatchIndex + 1})";
        }

        /// <summary>
        /// Event handler for the "Previous" button.
        /// Navigates to the previous occurrence of the search text.
        /// </summary>
        private void bFindPrev_Click(object sender, EventArgs e)
        {
            if (matchIndices.Count == 0)
                return;

            // Revert the current match highlight back to the base color.
            richTextBoxContents.Select(matchIndices[currentMatchIndex], lastSearchText.Length);
            richTextBoxContents.SelectionBackColor = Color.GreenYellow;

            // Move to the previous match; wrap around if at the beginning.
            currentMatchIndex--;
            if (currentMatchIndex < 0)
                currentMatchIndex = matchIndices.Count - 1;

            // Highlight the new current match with a distinct color.
            richTextBoxContents.Select(matchIndices[currentMatchIndex], lastSearchText.Length);
            richTextBoxContents.SelectionBackColor = Color.Orange;
            richTextBoxContents.ScrollToCaret();
            richTextBoxContents.SelectionStart = 0;
            richTextBoxContents.SelectionLength = 0;

            // Update label with current match info.
            lblFoundInFile.Text = $"Matches found in File: {matchIndices.Count} (Current: {currentMatchIndex + 1})";
        }
    }
}
