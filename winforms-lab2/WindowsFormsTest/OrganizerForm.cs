using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Properties;
using static System.Windows.Forms.ListView;

namespace WindowsFormsTest
{
    public partial class OrganizerForm : Form
    {
        string filter = String.Empty;
        string filterType = String.Empty;
        public OrganizerForm()
        { 
            InitializeComponent();
            listView1.SmallImageList = imageList1;
            metroComboBox1.Visible = false;
            metroComboBox1.Text = "Memo";
            metroRadioButton1.Checked = true;
        }
        #region Style
        public class FluentDesignRenderer : ToolStripProfessionalRenderer
        {
            public FluentDesignRenderer()
                : base(new MyColorTable())
            {
            }
            protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                var r = new Rectangle(e.ArrowRectangle.Location, e.ArrowRectangle.Size);
                r.Inflate(-2, -6);
                e.Graphics.DrawLines(Pens.Black, new Point[]{
        new Point(r.Left, r.Top),
        new Point(r.Right, r.Top + r.Height /2),
        new Point(r.Left, r.Top+ r.Height)});
            }

            protected override void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e)
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                var r = new Rectangle(e.ImageRectangle.Location, e.ImageRectangle.Size);
                r.Inflate(-4, -6);
                e.Graphics.DrawLines(Pens.Black, new Point[]{
        new Point(r.Left, r.Bottom - r.Height /2),
        new Point(r.Left + r.Width /3,  r.Bottom),
        new Point(r.Right, r.Top)});
            }
        }
        public class MyColorTable : ProfessionalColorTable
        {
            public new bool UseSystemColors = true;
            /*public override Color MenuItem
            {
                get { return Color.White; }
            }*/
            public override Color StatusStripGradientBegin
            {
                get { return Color.White; }
            }
            public override Color StatusStripGradientEnd
            {
                get { return Color.White; }
            }
            public override Color ToolStripDropDownBackground
            {
                get { return Color.WhiteSmoke; }
            }
            public override Color ButtonSelectedBorder
            {
                get { return Color.WhiteSmoke; }
            }
            public override Color ButtonSelectedGradientBegin
            {
                get { return Color.White; }
            }
            public override Color ButtonSelectedGradientEnd
            {
                get { return Color.White; }
            }
            public override Color MenuItemSelectedGradientBegin
            {
                get { return Color.White; }
            }
            public override Color MenuItemSelectedGradientEnd
            {
                get { return Color.White; }
            }
            public override Color MenuItemBorder
            {
                get { return Color.WhiteSmoke; }
            }
            public override Color MenuItemSelected
            {
                get { return Color.WhiteSmoke; }
            }
            public override Color ImageMarginGradientBegin
            {
                get { return Color.White; }
            }
            public override Color ImageMarginGradientMiddle
            {
                get { return Color.White; }
            }
            public override Color ImageMarginGradientEnd
            {
                get { return Color.White; }
            }
            public override Color ToolStripGradientBegin
            {
                get { return Color.White; }
            }
            public override Color ToolStripGradientMiddle
            {
                get { return Color.White; }
            }
            public override Color ToolStripGradientEnd
            {
                get { return Color.White; }
            }
            public override Color ToolStripBorder
            {
                get { return Color.WhiteSmoke; }
            }
        }
        #endregion

        private void OrganizerForm_Load(object sender, EventArgs e)
        {
            foreach (ColumnHeader ch in this.listView1.Columns)
            {
                ch.Width = this.listView1.Width / 4;
            }
        }
        protected override void OnSizeChanged(EventArgs e)
        {
           foreach (ColumnHeader ch in this.listView1.Columns)
           {
                ch.Width = this.listView1.Width / 4;
           }
        }

        private void tableLayout_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddEvent addEvent = new AddEvent(this);
            addEvent.Closed += (s, args) => this.Close();
            addEvent.Show();
            //this.listView1.Items.Add("test");
        }

        public void addEvent(DateTime date, DateTime time, string text, string type, int image)
        {
            ListViewItem lvi = new ListViewItem(date.ToString("dd/MM/yyyy"));
            lvi.SubItems.Add(time.ToString("HH:mm"));
            lvi.SubItems.Add(text);
            lvi.SubItems.Add(type);
            lvi.ImageIndex = image;
            this.listView1.Items.Add(lvi);
            ListViewItem lvi2 = (ListViewItem)(lvi.Clone());
            this.listView2.Items.Add(lvi2);
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listView1.FocusedItem.Bounds.Contains(e.Location))
                {
                    MessageBox.Show(listView1.FocusedItem.Text);
                }
            }
        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void metroRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.metroComboBox1.Visible = metroRadioButton2.Checked;
            if (metroRadioButton2.Checked)
                filterItemsByType(metroComboBox1.Text);
        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (metroRadioButton2.Checked)
                filterItemsByType(metroComboBox1.Text);
        }

        private void metroRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(metroRadioButton1.Checked)
             removefilters();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(button2.BackColor == Color.CornflowerBlue)
            {
                removefilters();
                button2.BackColor = Color.LightSteelBlue;
            }
            else
            {
                SearchForm sf = new SearchForm(this);
                sf.Closed += (s, args) => this.Close();
                sf.Show();
            }
        }

        private void filterItemsByType(String type)
        {
            filterType = type;
            listView1.Items.Clear();
            foreach (ListViewItem item in listView2.Items)
            {
                if(button2.BackColor == Color.CornflowerBlue)
                {
                    if (item.SubItems[3].Text.Equals(type) && item.SubItems[2].Text.ToLower().Contains(filter.ToLower()))
                    {
                        ListViewItem lvi = (ListViewItem)(item.Clone());
                        this.listView1.Items.Add(lvi);
                    }
                    if (metroRadioButton2.Checked)
                    {
                        filterItemsByType(filterType);
                    }
                }
                else
                {
                    if (item.SubItems[3].Text.Equals(type))
                    {
                        ListViewItem lvi = (ListViewItem)(item.Clone());
                        this.listView1.Items.Add(lvi);
                    }
                }
                
            }
        }
        private void removefilters()
        {
            listView1.Items.Clear();
            foreach(ListViewItem item in listView2.Items)
            {
                ListViewItem lvi = (ListViewItem)(item.Clone());
                this.listView1.Items.Add(lvi);
            }
        }
        public void Search(String searchFor)
        {
            filter = searchFor;
            button2.BackColor = Color.CornflowerBlue;
            listView1.Items.Clear();
            foreach (ListViewItem item in listView2.Items)
            {
                if (item.SubItems[2].Text.ToLower().Contains(searchFor.ToLower()))
                {
                    ListViewItem lvi = (ListViewItem)(item.Clone());
                    this.listView1.Items.Add(lvi);
                }
            }
            if (metroRadioButton2.Checked)
            {
                filterItemsByType(filterType);
            }
        }
        private void OrganizerForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S)
            {
                SaveToFile();
            }else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.O)
            {
                OpenFile();
            }else if (e.KeyCode == Keys.Delete)
            {
                foreach (ListViewItem  item in listView1.SelectedItems)
                {
                    listView1.Items.Remove(item);
                    foreach (ListViewItem item2 in listView2.Items)
                    {
                        if(item2.Tag == item.Tag)
                        listView2.Items.Remove(item2);
                        break;
                    }
                } 
            }
        }
        private void SaveToFile()
        {
            String toFile = String.Empty;
            foreach (ListViewItem item in listView2.Items)
            {
                toFile += item.SubItems[0].Text + ',' + item.SubItems[1].Text + ',' + item.SubItems[2].Text + ',' + item.SubItems[3].Text + ',' + item.ImageIndex.ToString() + '\n';
            }
            toFile = toFile.Trim();
            if (this.saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create);
                byte[] save = Encoding.ASCII.GetBytes(toFile);
                fs.Write(save, 0, save.Length);
            }
        }
        private void OpenFile()
        {
            if (this.openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                LoadFromText(File.ReadAllText(openFileDialog1.FileName));
            }
        }
        private void LoadFromText(string Text)
        {
            listView1.Items.Clear();
            listView2.Items.Clear();
            foreach (String line in Text.Split('\n'))
            {
                String[] entries = line.Split(',');
                ListViewItem lvi = new ListViewItem(entries[0]);
                lvi.SubItems.Add(entries[1]);
                lvi.SubItems.Add(entries[2]);
                lvi.SubItems.Add(entries[3]);
                lvi.ImageIndex = int.Parse(entries[4]);
                this.listView1.Items.Add(lvi);
                ListViewItem lvi2 = (ListViewItem)(lvi.Clone());
                this.listView2.Items.Add(lvi2);
            }
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
