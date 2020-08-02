using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat_Application_Client
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            OpeningForm openingForm = new OpeningForm();
            Program.SwitchWindows(openingForm, this, Form1.ActiveForm);
        }

        private void signUpBtn_Click(object sender, EventArgs e)
        {
            if (usernameError.Visible)
            {
                MessageBox.Show("Username not available", "Error");
                return;
            }

            if(usernameText.Text==""|| 
                nameText.Text == "" || 
                passwordText.Text == "" || 
                emailText.Text == "" )
            {
                MessageBox.Show("Fill all the values", "Error");
                return;
            }

            Program.SignUp(usernameText.Text, passwordText.Text, nameText.Text, emailText.Text);
        }

        private void usernameText_Leave(object sender, EventArgs e)
        {
            Console.WriteLine("Inside Leave");
            if (usernameText.Text == "")
                return;

            if (Program.CheckUsernameAvailable(usernameText.Text))
            {
                usernameError.Visible = false;
            }
            else
            {
                usernameError.Visible = true;
            }
        }
    }
}
