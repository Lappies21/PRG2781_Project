using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Business_logic;
using WindowsFormsApp1.Presentation_Layer;
using WindowsFormsApp1.Data_Access_Layer;

namespace WindowsFormsApp1.Presentation_Layer
{
    public partial class Module : Form
    {
        public Module()
        {
            InitializeComponent();
            DataHandler dh = new DataHandler();
            dgvModule.DataSource = dh.ViewModule();
        }

        private void Module_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Modules modules = new Modules(txtModuleCode.Text,txtModuleName.Text,txtModuleDescription.Text,txtLinks.Text);
            DataHandler dh = new DataHandler();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Modules modules = new Modules(txtModuleCode.Text, txtModuleName.Text, txtModuleDescription.Text, txtLinks.Text);
            DataHandler dh = new DataHandler();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Modules modules = new Modules(txtModuleCode.Text, txtModuleName.Text, txtModuleDescription.Text, txtLinks.Text);
            DataHandler dh = new DataHandler();
            dh.UpdateModule(modules.ModuleCode, modules.ModuleName, modules.ModuleDescription, modules.ResourceLinks);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Modules modules = new Modules(txtModuleCode.Text, txtModuleName.Text, txtModuleDescription.Text, txtLinks.Text);
            DataHandler dh = new DataHandler();
            dh.DeleteModule(modules.ModuleCode);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            DataHandler dh = new DataHandler();
            dgvModule.DataSource = dh.ViewModule();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Students students = new Students();
            this.Hide();
            students.Show();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.Show();
        }
    }
}
