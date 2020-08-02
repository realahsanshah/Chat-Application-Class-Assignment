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
    public partial class OpeningForm : Form
    {
        public OpeningForm()
        {
            InitializeComponent();
        }

        private void OpeningForm_Load(object sender, EventArgs e)
        {
            
        }

        private void signInBtn_Click(object sender, EventArgs e)
        {
            SignIn signIn = new SignIn();
            Program.SwitchWindows(signIn, this, Form1.ActiveForm);

          
        }

        private void signUpBtn_Click(object sender, EventArgs e)
        {
            SignUp signUp = new SignUp();
            Program.SwitchWindows(signUp, this, Form1.ActiveForm);
        }
    }
}
