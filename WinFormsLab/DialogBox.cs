using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsLab
{
    public partial class DialogBox : Form
    {
        public List<string> paths = new List<string>();
        public DialogBox()
        {
            //Application.EnableVisualStyles();
            InitializeComponent();
            textBox1.AutoCompleteSource = AutoCompleteSource.FileSystemDirectories;
            DriveInfo[] array = DriveInfo.GetDrives();
            for (int i = 0; i < array.Length; i++)
            {
                DriveInfo? drive = array[i];
                float totalSpace = drive.TotalSize;
                double percentFree = 100 - (drive.TotalFreeSpace/ totalSpace) * 100;
                float num = (float)percentFree;
                listView1.Items.Add(new ListViewItem(new[] { drive.Name, FormatBytes(drive.TotalSize), FormatBytes(drive.TotalFreeSpace), percentFree.ToString(), num.ToString("F") + "%" }));

            }
        }

        private void listView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
        }

        //https://stackoverflow.com/questions/1242266/converting-bytes-to-gb-in-c
        private static string FormatBytes(long bytes)
        {
            string[] Suffix = { "B", "KB", "MB", "GB", "TB" };
            int i;
            double dblSByte = bytes;
            for (i = 0; i < Suffix.Length && bytes >= 1024; i++, bytes /= 1024)
            {
                dblSByte = bytes / 1024.0;
            }

            return String.Format("{0:0.##} {1}", dblSByte, Suffix[i]);
        }
        private void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                // ChatGPT generated
                int progress = (int)(double.Parse(e.SubItem.Text));
                int progressBarWidth = e.SubItem.Bounds.Width - 4;
                int progressBarHeight = e.SubItem.Bounds.Height - 4;
                int progressBarX = e.SubItem.Bounds.X + 2;
                int progressBarY = e.SubItem.Bounds.Y + 2;

                Brush brushP = new SolidBrush(Color.Purple);
                Brush brushG = new SolidBrush(Color.LightGray);
                int fillWidth = (int)Math.Round((double)progress / 100 * progressBarWidth);
                e.Graphics.FillRectangle(brushG, progressBarX, progressBarY, progressBarWidth, progressBarHeight);
                e.Graphics.FillRectangle(brushP, progressBarX, progressBarY, fillWidth, progressBarHeight);
                brushG.Dispose();
                brushP.Dispose();
            }
            else
            {
                e.DrawDefault = true;
            }
        }

        //}
        private void DialogBox_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(folderButotn.Checked)
            {
                if (this.ValidateChildren()) return;
            }
            this.Close();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            paths.Clear();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var okienko = new FolderBrowserDialog();
            okienko.ShowDialog();
            textBox1.Text = okienko.SelectedPath;
            paths.Clear();
            paths.Add(okienko.SelectedPath);

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            paths.Clear();
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                paths.Add(item.Text);
            }
            inidButton.Checked = true;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.ValidateChildren();
            folderButotn.Checked = true;
        }

        private void allButton_CheckedChanged(object sender, EventArgs e)
        {
            paths.Clear();
            paths.Add("all");
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if(!Directory.Exists(textBox1.Text) && folderButotn.Checked)
            {
                textBox1.ForeColor = Color.Red;
                e.Cancel = false;
            }
            else
            {
                textBox1.ForeColor = Color.Black;
                e.Cancel = true;
            }
            
        }

        private void folderButotn_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void DialogBox_KeyDown(object sender, KeyEventArgs e)
        {
        }
    }
}
