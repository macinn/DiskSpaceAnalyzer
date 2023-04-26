namespace WinFormsLab
{
    partial class DialogBox
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
            this.components = new System.ComponentModel.Container();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.folderButotn = new System.Windows.Forms.RadioButton();
            this.allButton = new System.Windows.Forms.RadioButton();
            this.inidButton = new System.Windows.Forms.RadioButton();
            this.listView1 = new System.Windows.Forms.ListView();
            this.NameColumn = new System.Windows.Forms.ColumnHeader();
            this.Total = new System.Windows.Forms.ColumnHeader();
            this.Free = new System.Windows.Forms.ColumnHeader();
            this.UsedToTotalBar = new System.Windows.Forms.ColumnHeader();
            this.UsedToTotal = new System.Windows.Forms.ColumnHeader();
            this.button1 = new System.Windows.Forms.Button();
            this.pathErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pathErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(460, 301);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 31);
            this.button2.TabIndex = 5;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(367, 301);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(86, 31);
            this.button3.TabIndex = 6;
            this.button3.Text = "OK";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBox1.Location = new System.Drawing.Point(24, 264);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(428, 27);
            this.textBox1.TabIndex = 7;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.Validating += new System.ComponentModel.CancelEventHandler(this.textBox1_Validating);
            // 
            // folderButotn
            // 
            this.folderButotn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.folderButotn.AutoSize = true;
            this.folderButotn.Location = new System.Drawing.Point(24, 230);
            this.folderButotn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.folderButotn.Name = "folderButotn";
            this.folderButotn.Size = new System.Drawing.Size(86, 24);
            this.folderButotn.TabIndex = 8;
            this.folderButotn.TabStop = true;
            this.folderButotn.Text = "A &Folder";
            this.folderButotn.UseVisualStyleBackColor = true;
            this.folderButotn.CheckedChanged += new System.EventHandler(this.folderButotn_CheckedChanged);
            // 
            // allButton
            // 
            this.allButton.AutoSize = true;
            this.allButton.Location = new System.Drawing.Point(26, 10);
            this.allButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.allButton.Name = "allButton";
            this.allButton.Size = new System.Drawing.Size(132, 24);
            this.allButton.TabIndex = 9;
            this.allButton.TabStop = true;
            this.allButton.Text = "&All Local Drives";
            this.allButton.UseVisualStyleBackColor = true;
            this.allButton.CheckedChanged += new System.EventHandler(this.allButton_CheckedChanged);
            // 
            // inidButton
            // 
            this.inidButton.AutoSize = true;
            this.inidButton.Location = new System.Drawing.Point(26, 43);
            this.inidButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.inidButton.Name = "inidButton";
            this.inidButton.Size = new System.Drawing.Size(144, 24);
            this.inidButton.TabIndex = 10;
            this.inidButton.TabStop = true;
            this.inidButton.Text = "&Inidividual Drives";
            this.inidButton.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameColumn,
            this.Total,
            this.Free,
            this.UsedToTotalBar,
            this.UsedToTotal});
            this.listView1.Location = new System.Drawing.Point(26, 81);
            this.listView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listView1.Name = "listView1";
            this.listView1.OwnerDraw = true;
            this.listView1.Size = new System.Drawing.Size(499, 140);
            this.listView1.TabIndex = 11;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.listView1_DrawColumnHeader);
            this.listView1.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.listView1_DrawSubItem);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // NameColumn
            // 
            this.NameColumn.Text = "Name";
            // 
            // Total
            // 
            this.Total.Text = "Total";
            this.Total.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Total.Width = 90;
            // 
            // Free
            // 
            this.Free.Text = "Free";
            this.Free.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Free.Width = 90;
            // 
            // UsedToTotalBar
            // 
            this.UsedToTotalBar.Text = "Used/Total";
            this.UsedToTotalBar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.UsedToTotalBar.Width = 90;
            // 
            // UsedToTotal
            // 
            this.UsedToTotal.Text = "Used/Total";
            this.UsedToTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.UsedToTotal.Width = 90;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(460, 262);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button1.Size = new System.Drawing.Size(86, 31);
            this.button1.TabIndex = 4;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pathErrorProvider
            // 
            this.pathErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.pathErrorProvider.ContainerControl = this;
            // 
            // DialogBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(551, 337);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.inidButton);
            this.Controls.Add(this.allButton);
            this.Controls.Add(this.folderButotn);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "DialogBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Disk or Folder";
            this.Load += new System.EventHandler(this.DialogBox_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DialogBox_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pathErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button button2;
        private Button button3;
        private TextBox textBox1;
        private RadioButton folderButotn;
        private RadioButton allButton;
        private RadioButton inidButton;
        private ListView listView1;
        private ColumnHeader NameColumn;
        private ColumnHeader Total;
        private ColumnHeader Free;
        private ColumnHeader UsedToTotalBar;
        private Button button1;
        private ColumnHeader UsedToTotal;
        private ErrorProvider pathErrorProvider;
    }
}