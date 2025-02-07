namespace FileContentFinder
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtDirectory = new System.Windows.Forms.TextBox();
            this.txtSearchText = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.lblVersionInfo = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblProcessed = new System.Windows.Forms.Label();
            this.treeViewResults = new System.Windows.Forms.TreeView();
            this.splitContainerResults = new System.Windows.Forms.SplitContainer();
            this.listBoxResults = new System.Windows.Forms.ListBox();
            this.richTextBoxContents = new System.Windows.Forms.RichTextBox();
            this.cbTreeView = new System.Windows.Forms.CheckBox();
            this.bExpandAll = new System.Windows.Forms.Button();
            this.bCollapseAll = new System.Windows.Forms.Button();
            this.bFindNext = new System.Windows.Forms.Button();
            this.bFindPrev = new System.Windows.Forms.Button();
            this.lblFoundInFile = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerResults)).BeginInit();
            this.splitContainerResults.Panel1.SuspendLayout();
            this.splitContainerResults.Panel2.SuspendLayout();
            this.splitContainerResults.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(758, 39);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(95, 22);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtDirectory
            // 
            this.txtDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDirectory.Location = new System.Drawing.Point(12, 39);
            this.txtDirectory.Name = "txtDirectory";
            this.txtDirectory.Size = new System.Drawing.Size(740, 20);
            this.txtDirectory.TabIndex = 1;
            // 
            // txtSearchText
            // 
            this.txtSearchText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchText.Location = new System.Drawing.Point(12, 125);
            this.txtSearchText.Multiline = true;
            this.txtSearchText.Name = "txtSearchText";
            this.txtSearchText.Size = new System.Drawing.Size(740, 85);
            this.txtSearchText.TabIndex = 2;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(758, 125);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(95, 85);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_ClickAsync);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Search in Directory:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Search in formats:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Text to find:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 226);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Results:";
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 544);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(54, 13);
            this.lblStatus.TabIndex = 12;
            this.lblStatus.Text = "Results: 0";
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(111, 72);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(58, 20);
            this.txtFilter.TabIndex = 13;
            this.txtFilter.Text = "*cfg;*lua";
            // 
            // lblVersionInfo
            // 
            this.lblVersionInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVersionInfo.AutoSize = true;
            this.lblVersionInfo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblVersionInfo.Location = new System.Drawing.Point(662, 544);
            this.lblVersionInfo.Name = "lblVersionInfo";
            this.lblVersionInfo.Size = new System.Drawing.Size(69, 13);
            this.lblVersionInfo.TabIndex = 14;
            this.lblVersionInfo.Text = "by Assembler";
            this.lblVersionInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(175, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Separated by \' ; \'";
            // 
            // lblProcessed
            // 
            this.lblProcessed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblProcessed.AutoSize = true;
            this.lblProcessed.Location = new System.Drawing.Point(148, 544);
            this.lblProcessed.Name = "lblProcessed";
            this.lblProcessed.Size = new System.Drawing.Size(84, 13);
            this.lblProcessed.TabIndex = 16;
            this.lblProcessed.Text = "Files scanned: 0";
            // 
            // treeViewResults
            // 
            this.treeViewResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewResults.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeViewResults.Location = new System.Drawing.Point(3, 1);
            this.treeViewResults.Name = "treeViewResults";
            this.treeViewResults.Size = new System.Drawing.Size(397, 291);
            this.treeViewResults.TabIndex = 17;
            this.treeViewResults.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewResults_AfterSelect);
            this.treeViewResults.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewResults_NodeMouseClick);
            // 
            // splitContainerResults
            // 
            this.splitContainerResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerResults.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainerResults.Location = new System.Drawing.Point(12, 248);
            this.splitContainerResults.Name = "splitContainerResults";
            // 
            // splitContainerResults.Panel1
            // 
            this.splitContainerResults.Panel1.BackColor = System.Drawing.SystemColors.Window;
            this.splitContainerResults.Panel1.Controls.Add(this.listBoxResults);
            this.splitContainerResults.Panel1.Controls.Add(this.treeViewResults);
            // 
            // splitContainerResults.Panel2
            // 
            this.splitContainerResults.Panel2.BackColor = System.Drawing.SystemColors.Window;
            this.splitContainerResults.Panel2.Controls.Add(this.richTextBoxContents);
            this.splitContainerResults.Size = new System.Drawing.Size(841, 293);
            this.splitContainerResults.SplitterDistance = 405;
            this.splitContainerResults.TabIndex = 18;
            this.splitContainerResults.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainerResults_SplitterMoved);
            // 
            // listBoxResults
            // 
            this.listBoxResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxResults.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxResults.FormattingEnabled = true;
            this.listBoxResults.Location = new System.Drawing.Point(7, 3);
            this.listBoxResults.Name = "listBoxResults";
            this.listBoxResults.Size = new System.Drawing.Size(393, 286);
            this.listBoxResults.TabIndex = 18;
            this.listBoxResults.SelectedIndexChanged += new System.EventHandler(this.listBoxResults_SelectedIndexChanged);
            // 
            // richTextBoxContents
            // 
            this.richTextBoxContents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxContents.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxContents.Location = new System.Drawing.Point(3, 3);
            this.richTextBoxContents.Name = "richTextBoxContents";
            this.richTextBoxContents.Size = new System.Drawing.Size(424, 285);
            this.richTextBoxContents.TabIndex = 0;
            this.richTextBoxContents.Text = "";
            // 
            // cbTreeView
            // 
            this.cbTreeView.AutoSize = true;
            this.cbTreeView.Location = new System.Drawing.Point(63, 225);
            this.cbTreeView.Name = "cbTreeView";
            this.cbTreeView.Size = new System.Drawing.Size(74, 17);
            this.cbTreeView.TabIndex = 19;
            this.cbTreeView.Text = "Tree View";
            this.cbTreeView.UseVisualStyleBackColor = true;
            this.cbTreeView.CheckedChanged += new System.EventHandler(this.cbTreeView_CheckedChanged);
            // 
            // bExpandAll
            // 
            this.bExpandAll.Enabled = false;
            this.bExpandAll.Location = new System.Drawing.Point(143, 221);
            this.bExpandAll.Name = "bExpandAll";
            this.bExpandAll.Size = new System.Drawing.Size(75, 23);
            this.bExpandAll.TabIndex = 20;
            this.bExpandAll.Text = "Expand all";
            this.bExpandAll.UseVisualStyleBackColor = true;
            this.bExpandAll.Visible = false;
            this.bExpandAll.Click += new System.EventHandler(this.bExpandAll_Click);
            // 
            // bCollapseAll
            // 
            this.bCollapseAll.Enabled = false;
            this.bCollapseAll.Location = new System.Drawing.Point(224, 221);
            this.bCollapseAll.Name = "bCollapseAll";
            this.bCollapseAll.Size = new System.Drawing.Size(75, 23);
            this.bCollapseAll.TabIndex = 21;
            this.bCollapseAll.Text = "Collapse all";
            this.bCollapseAll.UseVisualStyleBackColor = true;
            this.bCollapseAll.Visible = false;
            this.bCollapseAll.Click += new System.EventHandler(this.bCollapseAll_Click);
            // 
            // bFindNext
            // 
            this.bFindNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bFindNext.Location = new System.Drawing.Point(778, 221);
            this.bFindNext.Name = "bFindNext";
            this.bFindNext.Size = new System.Drawing.Size(75, 23);
            this.bFindNext.TabIndex = 23;
            this.bFindNext.Text = "Find Next";
            this.bFindNext.UseVisualStyleBackColor = true;
            this.bFindNext.Visible = false;
            this.bFindNext.Click += new System.EventHandler(this.bFindNext_Click);
            // 
            // bFindPrev
            // 
            this.bFindPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bFindPrev.Location = new System.Drawing.Point(697, 221);
            this.bFindPrev.Name = "bFindPrev";
            this.bFindPrev.Size = new System.Drawing.Size(75, 23);
            this.bFindPrev.TabIndex = 24;
            this.bFindPrev.Text = "Find Prev";
            this.bFindPrev.UseVisualStyleBackColor = true;
            this.bFindPrev.Visible = false;
            this.bFindPrev.Click += new System.EventHandler(this.bFindPrev_Click);
            // 
            // lblFoundInFile
            // 
            this.lblFoundInFile.AutoSize = true;
            this.lblFoundInFile.Location = new System.Drawing.Point(422, 226);
            this.lblFoundInFile.Name = "lblFoundInFile";
            this.lblFoundInFile.Size = new System.Drawing.Size(120, 13);
            this.lblFoundInFile.TabIndex = 25;
            this.lblFoundInFile.Text = "Matches found in File: 0";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 566);
            this.Controls.Add(this.lblFoundInFile);
            this.Controls.Add(this.bFindPrev);
            this.Controls.Add(this.bFindNext);
            this.Controls.Add(this.bCollapseAll);
            this.Controls.Add(this.bExpandAll);
            this.Controls.Add(this.cbTreeView);
            this.Controls.Add(this.splitContainerResults);
            this.Controls.Add(this.lblProcessed);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblVersionInfo);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearchText);
            this.Controls.Add(this.txtDirectory);
            this.Controls.Add(this.btnBrowse);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Files Content Finder";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.splitContainerResults.Panel1.ResumeLayout(false);
            this.splitContainerResults.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerResults)).EndInit();
            this.splitContainerResults.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtDirectory;
        private System.Windows.Forms.TextBox txtSearchText;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label lblVersionInfo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblProcessed;
        private System.Windows.Forms.TreeView treeViewResults;
        private System.Windows.Forms.SplitContainer splitContainerResults;
        private System.Windows.Forms.RichTextBox richTextBoxContents;
        private System.Windows.Forms.CheckBox cbTreeView;
        private System.Windows.Forms.Button bExpandAll;
        private System.Windows.Forms.Button bCollapseAll;
        private System.Windows.Forms.ListBox listBoxResults;
        private System.Windows.Forms.Button bFindNext;
        private System.Windows.Forms.Button bFindPrev;
        private System.Windows.Forms.Label lblFoundInFile;
    }
}

