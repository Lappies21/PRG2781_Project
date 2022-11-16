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
            try
            {
                if (txtModuleCode.Text == string.Empty && txtModuleName.Text == string.Empty && txtModuleDescription.Text == string.Empty && txtLinks.Text == string.Empty)
                {
                    MessageBox.Show("Could not Create Module Please enter fields");
                }
                else
                {
                    Modules modules = new Modules(txtModuleCode.Text, txtModuleName.Text, txtModuleDescription.Text, txtLinks.Text);
                    DataHandler dh = new DataHandler();
                    dh.CreateModule(modules.ModuleCode, modules.ModuleName, modules.ModuleDescription, modules.ResourceLinks);
                    clear();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Could not Create Module Please enter fields");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Modules modules = new Modules(txtModuleCode.Text, txtModuleName.Text, txtModuleDescription.Text, txtLinks.Text);
                DataHandler dh = new DataHandler();
                dh.SearchModule(modules.ModuleCode, dgvModule);
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter Valid Module code to search");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtModuleCode.Text == string.Empty && txtModuleName.Text == string.Empty && txtModuleDescription.Text == string.Empty && txtLinks.Text == string.Empty)
                {
                    MessageBox.Show("Please enter Fields");
                }
                else
                {
                    Modules modules = new Modules(txtModuleCode.Text, txtModuleName.Text, txtModuleDescription.Text, txtLinks.Text);
                    DataHandler dh = new DataHandler();
                    dh.UpdateModule(modules.ModuleCode, modules.ModuleName, modules.ModuleDescription, modules.ResourceLinks);
                    clear();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter Fields");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtModuleCode.Text == string.Empty && txtModuleName.Text == string.Empty && txtModuleDescription.Text == string.Empty && txtLinks.Text == string.Empty)
                {
                    MessageBox.Show("Please enter detials to delete");
                }
                else
                {
                    Modules modules = new Modules(txtModuleCode.Text, txtModuleName.Text, txtModuleDescription.Text, txtLinks.Text);
                    DataHandler dh = new DataHandler();
                    dh.DeleteModule(modules.ModuleCode);
                    clear();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter detials to delete");
            }
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

        private void dgvModule_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvModule.Rows[e.RowIndex];

                txtModuleCode.Text = row.Cells[0].Value.ToString();
                txtModuleName.Text = row.Cells[1].Value.ToString();
                txtModuleDescription.Text = row.Cells[2].Value.ToString();
                txtLinks.Text = row.Cells[3].Value.ToString();

            }
        }
        public void clear()
        {
            txtModuleCode.Text = "";
            txtModuleName.Text = "";
            txtModuleDescription.Text = "";
            txtLinks.Text = "";
        }

        private void dgvModule_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvModule.Rows[e.RowIndex];

                txtModuleCode.Text = row.Cells[0].Value.ToString();
                txtModuleName.Text = row.Cells[1].Value.ToString();
                txtModuleDescription.Text = row.Cells[2].Value.ToString();
                txtLinks.Text = row.Cells[3].Value.ToString();

            }
        }
    }
}
