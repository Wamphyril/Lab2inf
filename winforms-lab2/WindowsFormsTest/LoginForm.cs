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
    public partial class LoginForm : System.Windows.Forms.Form
    {
        private string login = "login", password= "password";
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBoxLogin_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            if(textBoxPassword.Text != "Please enter your password" && textBoxPassword.Text != String.Empty && textBoxPassword.Text != "")
                buttonLogIn.Visible = true;
        }
        private void textBoxLogin_Enter(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
        if (e.KeyChar == (char)Keys.Return)
                textBoxPassword.Select();
        }
        private void textBoxPassword_Clicked(object sender, EventArgs e)
        {
            if (textBoxPassword.Text == "Please enter your password")
                textBoxPassword.ResetText();
            if (showPassword.Checked)
                textBoxPassword.PasswordChar = '\0';
            else
                textBoxPassword.PasswordChar = '*';
        }
        private void textBoxPassword_Enter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
                buttonLogIn.PerformClick();
        }

        private void textBoxLogin_Clicked(object sender, EventArgs e)
        {
            if(textBoxLogin.Text== "Please enter your login")
             textBoxLogin.Text = String.Empty;
        }

        private void showPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (showPassword.Checked)
                textBoxPassword.PasswordChar = '\0';
            else
                textBoxPassword.PasswordChar = '*';
        }

        private void tableLayoutForm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            if (this.textBoxLogin.Text.ToLower().Equals(login))
            {
                if (this.textBoxPassword.Text.Equals(password))
                {
                    this.Hide();
                    OrganizerForm organizerForm = new OrganizerForm();
                    organizerForm.Closed += (s, args) => this.Close();
                    organizerForm.Show();
                }
                else
                {
                    MessageBox.Show("Incorrect password!");
                }
            }
            else
            {
                MessageBox.Show("Incorrect login!");
            }
        }
    }
}
