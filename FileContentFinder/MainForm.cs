using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileContentFinder
{
    public partial class MainForm : Form
    {
        // Context menu for the results ListBox
        private ContextMenuStrip listBoxContextMenu;

        public MainForm()
        {
            InitializeComponent();
            InitializeContextMenu();
        }

        /// <summary>
        /// Initializes the context menu with "Open File" and "Open Directory" options,
        /// and assigns it to the listBoxResults.
        /// </summary>
        private void InitializeContextMenu()
        {
            // Create a new ContextMenuStrip
            listBoxContextMenu = new ContextMenuStrip();

            // Create menu items
            ToolStripMenuItem openFileMenuItem = new ToolStripMenuItem("Open File");
            ToolStripMenuItem openDirectoryMenuItem = new ToolStripMenuItem("Open Directory");

            // Attach event handlers for each menu item
            openFileMenuItem.Click += OpenFileMenuItem_Click;
            openDirectoryMenuItem.Click += OpenDirectoryMenuItem_Click;

            // Add the menu items to the context menu
            listBoxContextMenu.Items.AddRange(new ToolStripItem[] { openFileMenuItem, openDirectoryMenuItem });

            // Assign the context menu to the listBoxResults
            listBoxResults.ContextMenuStrip = listBoxContextMenu;
        }

        /// <summary>
        /// Event handler for the "Open File" menu item.
        /// Opens the selected file with the default associated application.
        /// </summary>
        private void OpenFileMenuItem_Click(object sender, EventArgs e)
        {
            if (listBoxResults.SelectedItem != null)
            {
                string filePath = listBoxResults.SelectedItem.ToString();
                try
                {
                    // Open the file using the default application.
                    Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error opening file: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Event handler for the "Open Directory" menu item.
        /// Opens the directory containing the selected file in File Explorer.
        /// </summary>
        private void OpenDirectoryMenuItem_Click(object sender, EventArgs e)
        {
            if (listBoxResults.SelectedItem != null)
            {
                string filePath = listBoxResults.SelectedItem.ToString();
                try
                {
                    // Get the directory path from the selected file
                    string directoryPath = Path.GetDirectoryName(filePath);

                    // Open the directory in File Explorer.
                    Process.Start(new ProcessStartInfo("explorer.exe", directoryPath) { UseShellExecute = true });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error opening directory: {ex.Message}");
                }
            }
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

            listBoxResults.Items.Clear();
            btnSearch.Enabled = false;
            lblStatus.Text = "Searching...";
            lblProcessed.Text = "Files scanned: 0";

            // Create a progress reporter to update the label for processed files
            var progress = new Progress<int>(count =>
            {
                lblProcessed.Text = $"Files scanned: {count}";
            });

            // Run the file search
            List<string> foundFiles = await Task.Run(() => SearchFiles(directory, searchText, filter, progress));


            listBoxResults.Items.AddRange(foundFiles.ToArray());
            lblStatus.Text = $"Files found: {foundFiles.Count}";
            btnSearch.Enabled = true;
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

                    if(processedFiles % 100 == 0)
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
    }
}
