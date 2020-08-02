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
    public partial class Form1 : Form
    {
        OpeningForm openingForm;
        public Form1()
        {
            InitializeComponent();
        }

    

        private void Form1_Load(object sender, EventArgs e)
        {
            openingForm = new OpeningForm();
            openingForm.MdiParent = this;
            openingForm.Show();

        }
    }
}
