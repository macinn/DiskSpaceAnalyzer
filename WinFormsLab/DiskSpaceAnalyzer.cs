using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WinFormsLab
{
    public partial class DiskSpaceAnalyzer : Form
    {
        List<string> paths = new List<string>();
        long size = 0;
        int items = 0;
        int files = 0;
        int subdirs = 0;
        Dictionary<string, long> typesCounter = new Dictionary<string, long>();
        Dictionary<string, long> typesSizeCum = new Dictionary<string, long>();
        public DiskSpaceAnalyzer()
        {
            InitializeComponent();
            paths.Add("all");
            UpdateTree();
            chartBox.SelectedIndex = 0;

            Pen p = new Pen(Color.Black, 2);
        }


        private void InitAllDrivers()
        {
            treeView1.Nodes.Clear();
            foreach (var drive in DriveInfo.GetDrives())
            {
                TreeNode node = new TreeNode(drive.Name);
                node.Tag = drive;
                if (drive.IsReady == true)
                    node.Nodes.Add("...");

                treeView1.Nodes.Add(node);
            }
        }

        DialogBox dialogBox;
        private void selectToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            dialogBox = new DialogBox();
            dialogBox.ShowDialog();
            paths = new List<string>(dialogBox.paths);
            UpdateTree();
        }

        private void UpdateTree()
        {
            foreach (string path in paths)
            {
                switch (path)
                {
                    case "":
                        break;
                    case "all":
                        {
                            InitAllDrivers();
                            break;
                        }
                    default:
                        InitPath(path);
                        break;
                }
            }
        }

        private void InitPath(string path)
        {
            treeView1.Nodes.Clear();
            DirectoryInfo di = new DirectoryInfo(path);
            TreeNode node = new TreeNode(di.Name, 0, 1);
            node.Tag = path;
            treeView1.Nodes.Add(node);
            if (di.GetDirectories().Count() > 0)
                node.Nodes.Add(null, "...", 0, 0);
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Canvas1.Image = null;
            backgroundWorker.CancelAsync();
            detailsView.Items.Clear();
            if (e.Node.Text.Equals("<File>")) return;
            if (File.Exists(e.Node.Tag.ToString()))
            {
                FileInfo fi = new FileInfo(e.Node.Tag.ToString());
                detailsView.Items.Add(new ListViewItem(new[] { "Full path:", fi.FullName }));
                detailsView.Items.Add(new ListViewItem(new[] { "Size:", FormatBytes(fi.Length) }));
                detailsView.Items.Add(new ListViewItem(new[] { "Items:", "0" }));
                detailsView.Items.Add(new ListViewItem(new[] { "Files:", "0" }));
                detailsView.Items.Add(new ListViewItem(new[] { "Subdirs:", "0" }));
                detailsView.Items.Add(new ListViewItem(new[] { "Last change:", fi.LastWriteTimeUtc.ToString() }));
            }
            else
            {
                DirectoryInfo di = new DirectoryInfo(e.Node.Tag.ToString());
                detailsView.Items.Add(new ListViewItem(new[] { "Full path:", di.FullName }));
                detailsView.Items.Add(new ListViewItem(new[] { "Size:", "0" }));
                detailsView.Items.Add(new ListViewItem(new[] { "Items:", "0" }));
                detailsView.Items.Add(new ListViewItem(new[] { "Files:", "0" }));
                detailsView.Items.Add(new ListViewItem(new[] { "Subdirs:", "0" }));
                detailsView.Items.Add(new ListViewItem(new[] { "Last change:", di.LastWriteTimeUtc.ToString() }));
                progressBar.Maximum = int.MaxValue;
                progressBar.Minimum = 0;
                progressBar.Value = 0;
                cancelToolStripMenuItem.Enabled = true;
                size = 0; items = 0; files = 0; subdirs = 0; typesCounter.Clear(); typesSizeCum.Clear();
                while (backgroundWorker.IsBusy) Application.DoEvents();
                backgroundWorker.RunWorkerAsync(di);
            }
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

        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            // https://stackoverflow.com/questions/35159549/how-to-display-all-files-under-folders-in-treeview
            if (e.Node.Nodes.Count > 0)
            {
                if (e.Node.Nodes[0].Text == "..." && e.Node.Nodes[0].Tag == null)
                {

                    //get the list of sub direcotires
                    string[] dirs = Directory.GetDirectories(e.Node.Tag.ToString());

                    e.Node.Nodes.Clear();
                    TreeNode fNode = e.Node;
                    DirectoryInfo dd = new DirectoryInfo(e.Node.Tag.ToString());
                    if (dd.GetFiles().Count() > 3)
                    {
                        fNode = new TreeNode("<File>", 0, 1);
                        e.Node.Nodes.Add(fNode);
                    }
                    foreach (var f in dd.GetFiles())
                    {
                        TreeNode file = new TreeNode(f.Name, 0, 0);
                        file.Tag = f.FullName;
                        fNode.Nodes.Add(file);
                    }

                    foreach (string dir in dirs)
                    {
                        DirectoryInfo di = new DirectoryInfo(dir);
                        TreeNode node = new TreeNode(di.Name, 0, 1);
                        try
                        {
                            //keep the directory's full path in the tag for use later
                            node.Tag = dir;

                            //if the directory has sub directories add the place holder
                            if (di.GetDirectories().Count() > 0)
                                node.Nodes.Add(null, "...", 0, 0);
                        }
                        catch (UnauthorizedAccessException)
                        {
                            //display a locked folder icon
                            node.ImageIndex = 12;
                            node.SelectedImageIndex = 12;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "DirectoryLister",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            e.Node.Nodes.Add(node);
                        }
                    }
                }
            }
        }

        private void statusStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void DiskSpaceAnalyzer_Load(object sender, EventArgs e)
        {

        }

        private void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            DirectoryInfo di = e.Argument as DirectoryInfo;
            int dirs = 1;
            DirSize(di, dirs);
            if (backgroundWorker.CancellationPending) e.Cancel = true;
        }

        // https://stackoverflow.com/questions/468119/whats-the-best-way-to-calculate-the-size-of-a-directory-in-net
        private void DirSize(DirectoryInfo d, int dirs)
        {
            if (backgroundWorker.CancellationPending) return;
            FileInfo[] fis = new FileInfo[0];
            try { fis = d.GetFiles(); }
            catch { }
            foreach (FileInfo fi in fis)
            {
                if (backgroundWorker.CancellationPending) return;
                size += fi.Length;
                files++;
                if (typesCounter.ContainsKey(fi.Extension)) typesCounter[fi.Extension]++;
                else typesCounter.Add(fi.Extension, 1);
                if (typesSizeCum.ContainsKey(fi.Extension)) typesSizeCum[fi.Extension] += fi.Length;
                else typesSizeCum.Add(fi.Extension, fi.Length);
            }
            DirectoryInfo[] dis = new DirectoryInfo[0];
            try { dis = d.GetDirectories(); }
            catch { }
            if (dis.Length == 0) backgroundWorker.ReportProgress(int.MaxValue / dirs);
            else dirs *= dis.Length;
            foreach (DirectoryInfo di in dis)
            {
                if (backgroundWorker.CancellationPending) return;
                subdirs++;
                DirSize(di, dirs);
            }
            return;
        }
        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value += e.ProgressPercentage;
        }

        // https://www.codeproject.com/Questions/70200/Draw-a-pie-chart-in-C-net-win-forms
        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                progressBar.Value = int.MaxValue;
                items = files + subdirs;
                detailsView.Items[1].SubItems[1].Text = FormatBytes(size);
                detailsView.Items[2].SubItems[1].Text = items.ToString();
                detailsView.Items[3].SubItems[1].Text = files.ToString();
                detailsView.Items[4].SubItems[1].Text = subdirs.ToString();
                chartBoxEvent();
                progressBar.Value = 0;
            }
            else progressBar.Value = 0;

            cancelToolStripMenuItem.Enabled = false;
        }


        //https://stackoverflow.com/questions/1335426/is-there-a-built-in-c-net-system-api-for-hsv-to-rgb
        public static Color ColorFromHSV(double hue, double saturation, double value)
        {
            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);

            value = value * 255;
            int v = Convert.ToInt32(value);
            int p = Convert.ToInt32(value * (1 - saturation));
            int q = Convert.ToInt32(value * (1 - f * saturation));
            int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

            if (hi == 0)
                return Color.FromArgb(255, v, t, p);
            else if (hi == 1)
                return Color.FromArgb(255, q, v, p);
            else if (hi == 2)
                return Color.FromArgb(255, p, v, t);
            else if (hi == 3)
                return Color.FromArgb(255, p, q, v);
            else if (hi == 4)
                return Color.FromArgb(255, t, p, v);
            else
                return Color.FromArgb(255, v, p, q);
        }
        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeView1.SelectedNode = null;
            backgroundWorker.CancelAsync();
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chartBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void chartBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            chartBoxEvent();
        }

        private void chartBoxEvent()
        {
            Color[] colors = new Color[10];
            for(int i=0; i<10; i++)
            {
                colors[i] = ColorFromHSV(30 * (i + 1), 1, 1);
            }
            if (typesCounter.Count > 0 && typesSizeCum.Count > 0)
                switch (chartBox.SelectedIndex)
                {
                    case 0:
                        {
                            Bitmap drawArea = new Bitmap(Canvas1.Size.Width, Canvas1.Size.Height);
                            Canvas1.Image = drawArea;
                            Graphics g = Graphics.FromImage(drawArea);
                            List<KeyValuePair<string, long>> l = typesCounter.OrderByDescending(a => a.Value).ToList();
                            long suma = typesCounter.Sum(a => a.Value);

                            if (l.Count > 10)
                            {
                                l = l.Take(9).ToList();
                                long sum9 = l.Sum(a => a.Value);
                                l.Add((new KeyValuePair<string, long>("Other", suma - sum9)));
                            }
                            Pen p = new Pen(Color.Black, 2);

                            Rectangle rec = new Rectangle(Canvas1.Location.X + 0 * Canvas1.Size.Width * 2 / 3 * 1 / 2, 0, Canvas1.Size.Width * 2 / 3 * 1 / 2, Canvas1.Size.Width * 2 / 3 * 1 / 2);
                            SolidBrush bBrush = new SolidBrush(Color.Black);
                            float startAngle = 0;
                            int i = 1;
                            foreach (var item in l)
                            {
                                float angle = item.Value / (float)suma * 360;
                                Brush brush = new SolidBrush(colors[i-1]);
                                g.FillPie(brush, rec, startAngle, angle);
                                g.DrawPie(p, rec, startAngle, angle);

                                Rectangle rec2 = new Rectangle(Canvas1.Location.X + 0 * Canvas1.Size.Width * 2 / 3 * 1 / 2, Canvas1.Size.Width * 2 / 3 * 1 / 2 + i * 20, 15, 15);
                                g.FillRectangle(brush, rec2);
                                g.DrawRectangle(p, rec2);

                                // https://learn.microsoft.com/en-us/dotnet/desktop/winforms/advanced/how-to-use-antialiasing-with-text?view=netframeworkdesktop-4.8&redirectedfrom=MSDN
                                var fontFamily = new FontFamily("Times New Roman");
                                var font = new Font(fontFamily, 15, FontStyle.Regular, GraphicsUnit.Pixel);

                                g.TextRenderingHint = TextRenderingHint.AntiAlias;
                                g.DrawString(item.Key + " - " + item.Value.ToString(), font, bBrush, new PointF(Canvas1.Location.X + 17, Canvas1.Size.Width * 2 / 6 + i * 20));

                                i++;
                                startAngle += angle;
                                brush.Dispose();
                            }
                            l = typesSizeCum.OrderByDescending(a => a.Value).ToList();
                            suma = typesSizeCum.Sum(a => a.Value);

                            if (l.Count > 10)
                            {
                                l = l.Take(9).ToList();
                                long sum9 = l.Sum(a => a.Value);
                                l.Add((new KeyValuePair<string, long>("Other", suma - sum9)));
                            }
                            rec = new Rectangle(Canvas1.Location.X + Canvas1.Size.Width * 1 / 2, 0, Canvas1.Size.Width * 2 / 3 * 1 / 2, Canvas1.Size.Width * 2 / 3 * 1 / 2);
                            bBrush.Dispose();
                            bBrush = new SolidBrush(Color.Black);
                            startAngle = 0;
                            i = 1;
                            foreach (var item in l)
                            {
                                float angle = item.Value / (float)suma * 360;
                                Brush brush = new SolidBrush(colors[i - 1]);
                                g.FillPie(brush, rec, startAngle, angle);
                                g.DrawPie(p, rec, startAngle, angle);

                                Rectangle rec2 = new Rectangle(Canvas1.Location.X + 1 * Canvas1.Size.Width * 1 / 2, Canvas1.Size.Width * 2 / 3 * 1 / 2 + i * 20, 15, 15);
                                g.FillRectangle(brush, rec2);
                                g.DrawRectangle(p, rec2);

                                // https://learn.microsoft.com/en-us/dotnet/desktop/winforms/advanced/how-to-use-antialiasing-with-text?view=netframeworkdesktop-4.8&redirectedfrom=MSDN
                                var fontFamily = new FontFamily("Times New Roman");
                                var font = new Font(fontFamily, 15, FontStyle.Regular, GraphicsUnit.Pixel);

                                g.TextRenderingHint = TextRenderingHint.AntiAlias;
                                g.DrawString(item.Key + " - " + FormatBytes(item.Value), font, bBrush, new PointF(Canvas1.Location.X + Canvas1.Size.Width * 1 / 2 + 17, Canvas1.Size.Width * 2 / 6 + i * 20));

                                i++;
                                startAngle += angle;
                                brush.Dispose();
                            }
                            //Canvas1.Update();
                            bBrush.Dispose();
                            p.Dispose();
                            g.Dispose();
                            break;
                        }
                    case 1:
                        {
                            Bitmap drawArea = new Bitmap(Canvas1.Size.Width, Canvas1.Size.Height);
                            Canvas1.Image = drawArea;
                            Graphics g = Graphics.FromImage(drawArea);
                            List<KeyValuePair<string, long>> l = typesCounter.OrderByDescending(a => a.Value).ToList();
                            long suma = typesCounter.Sum(a => a.Value);

                            if (l.Count > 10)
                            {
                                l = l.Take(9).ToList();
                                long sum9 = l.Sum(a => a.Value);
                                l.Add((new KeyValuePair<string, long>("Other", suma - sum9)));
                            }
                            long max = typesCounter.Max(a => a.Value);
                            Pen p = new Pen(Color.Black, 2);

                            Rectangle rec = new Rectangle(Canvas1.Location.X + 0 * Canvas1.Size.Width * 2 / 3 * 1 / 2, 0, Canvas1.Size.Width * 2 / 3 * 1 / 2, Canvas1.Size.Height * 7 / 8);
                            SolidBrush bBrush = new SolidBrush(Color.Black);
                            SolidBrush gbrush = new SolidBrush(Color.LightGray);

                            g.FillRectangle(gbrush, rec);
                            int power = (int)Math.Log10(max);
                            int lines = (int)(max / Math.Pow(10, power));
                            for (int q = 1; q * (int)((float)Math.Pow(10, power) / (float)max * Canvas1.Size.Height * 7 / 8) < Canvas1.Size.Height * 7 / 8; q++)
                            {
                                int height = q * (int)((float)Math.Pow(10, power) / (float)max * Canvas1.Size.Height * 7 / 8);
                                g.DrawLine(p, new Point(Canvas1.Location.X, Canvas1.Size.Height * 7 / 8 - height), new Point(Canvas1.Location.X + Canvas1.Size.Width / 3, Canvas1.Size.Height * 7 / 8 - height));

                                // https://learn.microsoft.com/en-us/dotnet/desktop/winforms/advanced/how-to-use-antialiasing-with-text?view=netframeworkdesktop-4.8&redirectedfrom=MSDN
                                var fontFamily = new FontFamily("Times New Roman");
                                var font = new Font(fontFamily, 10, FontStyle.Regular, GraphicsUnit.Pixel);

                                g.TextRenderingHint = TextRenderingHint.AntiAlias;
                                g.DrawString(((int)(Math.Pow(10, power) * q)).ToString(), font, bBrush, new PointF(Canvas1.Location.X + Canvas1.Size.Width / 3, Canvas1.Size.Height * 7 / 8 - height));
                            }
                            int i = 1;
                            int width = Canvas1.Size.Width / (3 * (2 * l.Count + 1));

                            foreach (var item in l)
                            {
                                int height = (int)(item.Value / (float)max * Canvas1.Size.Height * 7 / 8);
                                float angle = item.Value / (float)suma * 360;
                                Brush brush = new SolidBrush(colors[i - 1]);
                                Rectangle rec1 = new Rectangle(Canvas1.Location.X + (2 * i - 1) * width, Canvas1.Size.Height * 7 / 8 - height, width, height);
                                // Rectangle rec2 = new Rectangle(Canvas1.Location.X + 0 * Canvas1.Size.Width * 2 / 3 * 1 / 2, Canvas1.Size.Width * 2 / 3 * 1 / 2 + i * 20, 15, 15);
                                //g.FillRectangle(brush, rec2);
                                g.FillRectangle(brush, rec1);
                                g.DrawRectangle(p, rec1);
                                //g.DrawRectangle(p, rec2);

                                // https://learn.microsoft.com/en-us/dotnet/desktop/winforms/advanced/how-to-use-antialiasing-with-text?view=netframeworkdesktop-4.8&redirectedfrom=MSDN
                                var fontFamily = new FontFamily("Times New Roman");
                                var font = new Font(fontFamily, 10, FontStyle.Regular, GraphicsUnit.Pixel);

                                g.TextRenderingHint = TextRenderingHint.AntiAlias;
                                g.DrawString(item.Key, font, bBrush, new PointF(Canvas1.Location.X + (2 * i - 1) * width, Canvas1.Size.Height * 7 / 8));

                                i++;
                                brush.Dispose();
                            }
                            l = typesSizeCum.OrderByDescending(a => a.Value).ToList();
                            suma = typesSizeCum.Sum(a => a.Value);

                            if (l.Count > 10)
                            {
                                l = l.Take(9).ToList();
                                long sum9 = l.Sum(a => a.Value);
                                l.Add((new KeyValuePair<string, long>("Other", suma - sum9)));
                            }
                            max = typesSizeCum.Max(a => a.Value);
                            p.Dispose();
                            p = new Pen(Color.Black, 2);

                            rec = new Rectangle(Canvas1.Location.X + Canvas1.Size.Width * 1 / 2, 0, Canvas1.Size.Width * 2 / 3 * 1 / 2, Canvas1.Size.Height * 7 / 8);


                            g.FillRectangle(gbrush, rec);
                            i = 1;
                            width = Canvas1.Size.Width / (3 * (2 * l.Count + 1));
                            power = (int)Math.Log10(max);
                            lines = (int)(max / Math.Pow(10, power));
                            for (int q = 1; q * (int)((float)Math.Pow(10, power) / (float)max * Canvas1.Size.Height * 7 / 8) < Canvas1.Size.Height * 7 / 8; q++)
                            {
                                int height = q * (int)((float)Math.Pow(10, power) / (float)max * Canvas1.Size.Height * 7 / 8);
                                g.DrawLine(p, new Point(Canvas1.Location.X + Canvas1.Size.Width * 1 / 2, Canvas1.Size.Height * 7 / 8 - height), new Point(Canvas1.Location.X + Canvas1.Size.Width * 1 / 2 + Canvas1.Size.Width / 3, Canvas1.Size.Height * 7 / 8 - height));

                                // https://learn.microsoft.com/en-us/dotnet/desktop/winforms/advanced/how-to-use-antialiasing-with-text?view=netframeworkdesktop-4.8&redirectedfrom=MSDN
                                var fontFamily = new FontFamily("Times New Roman");
                                var font = new Font(fontFamily, 10, FontStyle.Regular, GraphicsUnit.Pixel);

                                g.TextRenderingHint = TextRenderingHint.AntiAlias;
                                g.DrawString(FormatBytes( (long)Math.Pow(10, power) * q), font, bBrush, new PointF(Canvas1.Location.X + Canvas1.Size.Width / 3 + Canvas1.Size.Width * 1 / 2, Canvas1.Size.Height * 7 / 8 - height));
                            }
                            foreach (var item in l)
                            {
                                int height = (int)(item.Value / (float)max * Canvas1.Size.Height * 7 / 8);
                                float angle = item.Value / (float)suma * 360;
                                Brush brush = new SolidBrush(colors[i - 1]);
                                Rectangle rec1 = new Rectangle(Canvas1.Location.X + (2 * i - 1) * width + Canvas1.Size.Width * 1 / 2, Canvas1.Size.Height * 7 / 8 - height, width, height);
                                //Rectangle rec2 = new Rectangle(Canvas1.Location.X + Canvas1.Size.Width * 1 / 2, Canvas1.Size.Width * 2 / 3 * 1 / 2 + i * 20, 15, 15);
                                //g.FillRectangle(brush, rec2);
                                g.FillRectangle(brush, rec1);
                                g.DrawRectangle(p, rec1);
                                //g.DrawRectangle(p, rec2);

                                // https://learn.microsoft.com/en-us/dotnet/desktop/winforms/advanced/how-to-use-antialiasing-with-text?view=netframeworkdesktop-4.8&redirectedfrom=MSDN
                                var fontFamily = new FontFamily("Times New Roman");
                                var font = new Font(fontFamily, 10, FontStyle.Regular, GraphicsUnit.Pixel);

                                g.TextRenderingHint = TextRenderingHint.AntiAlias;
                                g.DrawString(item.Key, font, bBrush, new PointF(Canvas1.Location.X + (2 * i - 1) * width + Canvas1.Size.Width * 1 / 2, Canvas1.Size.Height * 7 / 8));

                                i++;
                                brush.Dispose();
                            }
                            //Canvas1.Update();
                            bBrush.Dispose();
                            p.Dispose();
                            g.Dispose();
                            gbrush.Dispose();
                            break;
                        }
                    case 2:
                        {
                            Bitmap drawArea = new Bitmap(Canvas1.Size.Width, Canvas1.Size.Height);
                            Canvas1.Image = drawArea;
                            Graphics g = Graphics.FromImage(drawArea);
                            List<KeyValuePair<string, long>> l = typesCounter.OrderByDescending(a => a.Value).ToList();
                            long suma = typesCounter.Sum(a => a.Value);

                            if (l.Count > 10)
                            {
                                l = l.Take(9).ToList();
                                long sum9 = l.Sum(a => a.Value);
                                l.Add((new KeyValuePair<string, long>("Other", suma - sum9)));
                            }

                            List<KeyValuePair<string, double>> newL = new List<KeyValuePair<string, double>>();
                            foreach (var item in l)
                            {
                                newL.Add(new KeyValuePair<string, double>(item.Key, Math.Log10(item.Value)));
                            }
                            double sumL = newL.Sum(a => a.Value);
                            double max = newL.Max(a => a.Value);

                            Pen p = new Pen(Color.Black, 2);

                            Rectangle rec = new Rectangle(Canvas1.Location.X + 0 * Canvas1.Size.Width * 2 / 3 * 1 / 2, 0, Canvas1.Size.Width * 2 / 3 * 1 / 2, Canvas1.Size.Height * 7 / 8);
                            
                            SolidBrush bBrush = new SolidBrush(Color.Black);
                            SolidBrush gbrush = new SolidBrush(Color.LightGray);

                            g.FillRectangle(gbrush, rec);
                            int[] nums = new int[] {1,2,5 };
                            for (int q = 0; Math.Log10(Math.Pow(10,q/3)*nums[q%3]) / (float)max * Canvas1.Size.Height * 7 / 8 < Canvas1.Size.Height * 7 / 8; q++)
                            {
                                int height = (int)(Math.Log10(Math.Pow(10, q / 3) * nums[q % 3]) / (float)max * Canvas1.Size.Height * 7 / 8);
                                g.DrawLine(p, new Point(Canvas1.Location.X, Canvas1.Size.Height * 7 / 8 - height), new Point(Canvas1.Location.X + Canvas1.Size.Width / 3, Canvas1.Size.Height * 7 / 8 - height));

                                // https://learn.microsoft.com/en-us/dotnet/desktop/winforms/advanced/how-to-use-antialiasing-with-text?view=netframeworkdesktop-4.8&redirectedfrom=MSDN
                                var fontFamily = new FontFamily("Times New Roman");
                                var font = new Font(fontFamily, 10, FontStyle.Regular, GraphicsUnit.Pixel);

                                g.TextRenderingHint = TextRenderingHint.AntiAlias;
                                g.DrawString((Math.Pow(10, q / 3) * nums[q % 3]).ToString(), font, bBrush, new PointF(Canvas1.Location.X + Canvas1.Size.Width / 3, Canvas1.Size.Height * 7 / 8 - height));
                            }
                            int i = 1;
                            int width = Canvas1.Size.Width / (3 * (2 * newL.Count + 1));

                            foreach (var item in newL)
                            {
                                int height = (int)(item.Value / (float)max * Canvas1.Size.Height * 7 / 8);
                                float angle;
                                if (sumL != 0) angle = (float)item.Value / (float)sumL * 360;
                                else angle = 350;
                                Brush brush = new SolidBrush(colors[i - 1]);
                                Rectangle rec1 = new Rectangle(Canvas1.Location.X + (2 * i - 1) * width, Canvas1.Size.Height * 7 / 8 - height, width, height);
                                g.FillRectangle(brush, rec1);
                                g.DrawRectangle(p, rec1);

                                // https://learn.microsoft.com/en-us/dotnet/desktop/winforms/advanced/how-to-use-antialiasing-with-text?view=netframeworkdesktop-4.8&redirectedfrom=MSDN
                                var fontFamily = new FontFamily("Times New Roman");
                                var font = new Font(fontFamily, 10, FontStyle.Regular, GraphicsUnit.Pixel);

                                g.TextRenderingHint = TextRenderingHint.AntiAlias;
                                g.DrawString(item.Key, font, bBrush, new PointF(Canvas1.Location.X + (2 * i - 1) * width, Canvas1.Size.Height * 7 / 8));

                                i++;
                                brush.Dispose();
                            }
                            l = typesSizeCum.OrderByDescending(a => a.Value).ToList();
                            suma = typesSizeCum.Sum(a => a.Value);

                            if (l.Count > 10)
                            {
                                l = l.Take(9).ToList();
                                long sum9 = l.Sum(a => a.Value);
                                l.Add((new KeyValuePair<string, long>("Other", suma - sum9)));
                            }
                            newL.Clear();
                            newL = new List<KeyValuePair<string, double>>();
                            foreach (var item in l)
                            {
                                newL.Add(new KeyValuePair<string, double>(item.Key, Math.Log10(item.Value)));
                            }
                            max = newL.Max(a => a.Value);
                            p.Dispose();
                            p = new Pen(Color.Black, 2);

                            rec = new Rectangle(Canvas1.Location.X + Canvas1.Size.Width * 1 / 2, 0, Canvas1.Size.Width * 2 / 3 * 1 / 2, Canvas1.Size.Height * 7 / 8);

                            g.FillRectangle(gbrush, rec);
                            int power = (int)max;
                            for (int q = 1; (int)((float)q/ (float)max * Canvas1.Size.Height * 7 / 8) < Canvas1.Size.Height * 7 / 8; q++)
                            {
                                int height = (int)((float)q / (float)max * Canvas1.Size.Height * 7 / 8);
                                g.DrawLine(p, new Point(Canvas1.Location.X + Canvas1.Size.Width * 1 / 2, Canvas1.Size.Height * 7 / 8 - height), new Point(Canvas1.Location.X + Canvas1.Size.Width * 1 / 2 + Canvas1.Size.Width / 3, Canvas1.Size.Height * 7 / 8 - height));

                                // https://learn.microsoft.com/en-us/dotnet/desktop/winforms/advanced/how-to-use-antialiasing-with-text?view=netframeworkdesktop-4.8&redirectedfrom=MSDN
                                var fontFamily = new FontFamily("Times New Roman");
                                var font = new Font(fontFamily, 10, FontStyle.Regular, GraphicsUnit.Pixel);

                                g.TextRenderingHint = TextRenderingHint.AntiAlias;
                                g.DrawString("10^" + q.ToString(), font, bBrush, new PointF(Canvas1.Location.X + Canvas1.Size.Width / 3 + Canvas1.Size.Width * 1 / 2, Canvas1.Size.Height * 7 / 8 - height));
                            }
                            i = 1;
                            width = Canvas1.Size.Width / (3 * (2 * l.Count + 1));

                            foreach (var item in newL)
                            {
                                int height = (int)((float)item.Value / (float)max * Canvas1.Size.Height * 7 / 8);
                                float angle = (float)item.Value / (float)sumL * 360;
                                Brush brush = new SolidBrush(colors[i - 1]);
                                Rectangle rec1 = new Rectangle(Canvas1.Location.X + (2 * i - 1) * width + Canvas1.Size.Width * 1 / 2, Canvas1.Size.Height * 7 / 8 - height, width, height);
                                g.FillRectangle(brush, rec1);
                                g.DrawRectangle(p, rec1);

                                // https://learn.microsoft.com/en-us/dotnet/desktop/winforms/advanced/how-to-use-antialiasing-with-text?view=netframeworkdesktop-4.8&redirectedfrom=MSDN
                                var fontFamily = new FontFamily("Times New Roman");
                                var font = new Font(fontFamily, 10, FontStyle.Regular, GraphicsUnit.Pixel);

                                g.TextRenderingHint = TextRenderingHint.AntiAlias;
                                g.DrawString(item.Key, font, bBrush, new PointF(Canvas1.Location.X + (2 * i - 1) * width + Canvas1.Size.Width * 1 / 2, Canvas1.Size.Height * 7 / 8));

                                i++;
                                brush.Dispose();
                            }
                            //Canvas1.Update();
                            
                            bBrush.Dispose();
                            p.Dispose();
                            g.Dispose();
                            gbrush.Dispose();
                            break;  
                        }
                }
        }

        private void DiskSpaceAnalyzer_SizeChanged(object sender, EventArgs e)
        {
            chartBoxEvent();
        }
    }
}