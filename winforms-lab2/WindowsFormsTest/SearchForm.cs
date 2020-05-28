using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsTest
{
    public partial class SearchForm : Form
    {
        OrganizerForm of;
        public SearchForm(OrganizerForm organizerForm)
        {
            of = organizerForm; 
            InitializeComponent();
            metroLabel1.Location = new Point((metroPanel1.Width - metroLabel1.Width) / 2, metroPanel1.Height/3);
            metroTextBox1.Location = new Point((metroPanel1.Width - metroLabel1.Width) / 2, metroPanel1.Height/3 +metroLabel1.Height*2);
            metroButton1.Location = new Point((metroPanel1.Width - metroLabel1.Width) / 2, metroPanel1.Height/2 +metroTextBox1.Height*2);
        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            of.Search(metroTextBox1.Text);
            this.Dispose();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Dispose();
        }
    }
}
