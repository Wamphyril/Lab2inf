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
    public partial class AddEvent : Form
    {
        private OrganizerForm of;
        public AddEvent(OrganizerForm organizerForm)
        {
            of = organizerForm;
            InitializeComponent();
            this.monthCalendar1.MinDate = monthCalendar1.TodayDate;
            //this.metroDateTime1.MinDate = DateTime.Now;
            this.metroDateTime1.ShowUpDown = true;
            metroDateTime1.Format = DateTimePickerFormat.Custom;
            metroDateTime1.CustomFormat = "HH:mm";
            metroTextBox1.Text = "Event";
            this.metroComboBox1.Text = "Memo";
        }
        private void AddEvent_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Hide();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            if (monthCalendar1.SelectionStart == DateTime.Today && metroDateTime1.Value.AddMinutes(1) < DateTime.Now)
                MessageBox.Show("You cannot select a date that is in the past!");
            else
            {
                of.addEvent(monthCalendar1.SelectionStart, metroDateTime1.Value, metroTextBox1.Text, metroComboBox1.Text, metroComboBox1.SelectedIndex);
                this.Dispose();
            }
                
        }

        private void metroButton1_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Dispose();
        }
    }
}
