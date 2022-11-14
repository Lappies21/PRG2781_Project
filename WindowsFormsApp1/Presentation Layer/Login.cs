using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using WindowsFormsApp1.Business_logic;
using WindowsFormsApp1.Presentation_Layer;
using WindowsFormsApp1.Data_Access_Layer;

namespace WindowsFormsApp1.Presentation_Layer
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            FileHandler fh = new FileHandler();
            if (txtUsername.Text == string.Empty && txtPassword.Text == string.Empty && txtConfirmPassword.Text == string.Empty)
            {
                lblMessage.Show();
                lblMessage.Text = "Please Fill In the fields";
                lblMessage.ForeColor = Color.Red;
            }
            else if (txtPassword.Text != txtConfirmPassword.Text)
            {
                lblMessage.Show();
                lblMessage.Text = "Wrong Username or Password";
                lblMessage.ForeColor = Color.Red;
                txtUsername.ForeColor = Color.Red;
                txtPassword.ForeColor = Color.Red;
                txtConfirmPassword.ForeColor = Color.Red;
            }
            else
            {
                fh.Write(txtUsername.Text,txtPassword.Text);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            FileHandler fh = new FileHandler();
            fh.Read(txtUsername.Text,txtPassword.Text,lblMessage,txtUsername,txtPassword);
        }
    }
}
