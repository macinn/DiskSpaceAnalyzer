namespace WinFormsLab
{
    partial class DiskSpaceAnalyzer
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.selectButton = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.Details = new System.Windows.Forms.TabPage();
            this.detailsView = new System.Windows.Forms.ListView();
            this.col1 = new System.Windows.Forms.ColumnHeader();
            this.col2 = new System.Windows.Forms.ColumnHeader();
            this.Charts = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chartBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Canvas1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.menuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.Details.SuspendLayout();
            this.Charts.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.selectToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.menuStrip2.Size = new System.Drawing.Size(914, 30);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectToolStripMenuItem1,
            this.cancelToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // selectToolStripMenuItem1
            // 
            this.selectToolStripMenuItem1.Name = "selectToolStripMenuItem1";
            this.selectToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.selectToolStripMenuItem1.Size = new System.Drawing.Size(186, 26);
            this.selectToolStripMenuItem1.Text = "Select";
            this.selectToolStripMenuItem1.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // cancelToolStripMenuItem
            // 
            this.cancelToolStripMenuItem.Enabled = false;
            this.cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
            this.cancelToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.cancelToolStripMenuItem.Size = new System.Drawing.Size(186, 26);
            this.cancelToolStripMenuItem.Text = "Cancel";
            this.cancelToolStripMenuItem.Click += new System.EventHandler(this.cancelToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(186, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // selectToolStripMenuItem
            // 
            this.selectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.selectToolStripMenuItem.Name = "selectToolStripMenuItem";
            this.selectToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.selectToolStripMenuItem.Text = "Help";
            this.selectToolStripMenuItem.Click += new System.EventHandler(this.selectToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(133, 26);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 4);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(908, 533);
            this.splitContainer1.SplitterDistance = 300;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.selectButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.treeView1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(300, 533);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // selectButton
            // 
            this.selectButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.selectButton.Location = new System.Drawing.Point(211, 4);
            this.selectButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(86, 59);
            this.selectButton.TabIndex = 0;
            this.selectButton.Text = "Select";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(3, 71);
            this.treeView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(294, 458);
            this.treeView1.TabIndex = 1;
            this.treeView1.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeExpand);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.Details);
            this.tabControl.Controls.Add(this.Charts);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(603, 533);
            this.tabControl.TabIndex = 0;
            // 
            // Details
            // 
            this.Details.Controls.Add(this.detailsView);
            this.Details.Location = new System.Drawing.Point(4, 29);
            this.Details.Name = "Details";
            this.Details.Padding = new System.Windows.Forms.Padding(3);
            this.Details.Size = new System.Drawing.Size(595, 500);
            this.Details.TabIndex = 0;
            this.Details.Text = "Details";
            this.Details.UseVisualStyleBackColor = true;
            // 
            // detailsView
            // 
            this.detailsView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col1,
            this.col2});
            this.detailsView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detailsView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.detailsView.Location = new System.Drawing.Point(3, 3);
            this.detailsView.Name = "detailsView";
            this.detailsView.Size = new System.Drawing.Size(589, 494);
            this.detailsView.TabIndex = 0;
            this.detailsView.UseCompatibleStateImageBehavior = false;
            this.detailsView.View = System.Windows.Forms.View.Details;
            // 
            // col1
            // 
            this.col1.Text = "name";
            this.col1.Width = 150;
            // 
            // col2
            // 
            this.col2.Text = "val";
            this.col2.Width = 500;
            // 
            // Charts
            // 
            this.Charts.Controls.Add(this.tableLayoutPanel3);
            this.Charts.Location = new System.Drawing.Point(4, 29);
            this.Charts.Name = "Charts";
            this.Charts.Padding = new System.Windows.Forms.Padding(3);
            this.Charts.Size = new System.Drawing.Size(595, 500);
            this.Charts.TabIndex = 1;
            this.Charts.Text = "Charts";
            this.Charts.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.Canvas1, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(589, 494);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chartBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(583, 29);
            this.panel1.TabIndex = 2;
            // 
            // chartBox
            // 
            this.chartBox.DisplayMember = "Pie chart";
            this.chartBox.FormattingEnabled = true;
            this.chartBox.Items.AddRange(new object[] {
            "Pie chart",
            "Bar chart",
            "Log bar chart"});
            this.chartBox.Location = new System.Drawing.Point(137, 1);
            this.chartBox.Name = "chartBox";
            this.chartBox.Size = new System.Drawing.Size(151, 28);
            this.chartBox.TabIndex = 2;
            this.chartBox.ValueMember = "Pie chart";
            this.chartBox.SelectedIndexChanged += new System.EventHandler(this.chartBox_SelectedIndexChanged_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 4);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Chart type:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Canvas1
            // 
            this.Canvas1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Canvas1.Location = new System.Drawing.Point(3, 38);
            this.Canvas1.Name = "Canvas1";
            this.Canvas1.Size = new System.Drawing.Size(583, 453);
            this.Canvas1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Canvas1.TabIndex = 3;
            this.Canvas1.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.splitContainer1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.progressBar, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 30);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(914, 570);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(3, 544);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(125, 23);
            this.progressBar.TabIndex = 3;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // DiskSpaceAnalyzer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 600);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.menuStrip2);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(912, 582);
            this.Name = "DiskSpaceAnalyzer";
            this.Text = "DiskSpaceAnalyzer";
            this.Load += new System.EventHandler(this.DiskSpaceAnalyzer_Load);
            this.SizeChanged += new System.EventHandler(this.DiskSpaceAnalyzer_SizeChanged);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.Details.ResumeLayout(false);
            this.Charts.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MenuStrip menuStrip2;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem selectToolStripMenuItem1;
        private ToolStripMenuItem cancelToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem selectToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private SplitContainer splitContainer1;
        private TableLayoutPanel tableLayoutPanel1;
        private Button selectButton;
        private TreeView treeView1;
        private TableLayoutPanel tableLayoutPanel2;
        private TabControl tabControl;
        private TabPage Details;
        private ListView detailsView;
        private ColumnHeader col1;
        private ColumnHeader col2;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private ProgressBar progressBar;
        private TabPage Charts;
        private TableLayoutPanel tableLayoutPanel3;
        private Panel panel1;
        private ComboBox chartBox;
        private Label label1;
        private PictureBox Canvas1;
    }
}