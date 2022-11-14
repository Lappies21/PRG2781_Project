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
    public partial class Students : Form
    {
        public Students()
        {
            InitializeComponent();
            dtpDoB.Format = DateTimePickerFormat.Custom;
            dtpDoB.CustomFormat = "dd/MM/yyyy";
            DataHandler dh = new DataHandler();
            dgvStudents.DataSource = dh.ViewStudent();
        }

        private void Students_Load(object sender, EventArgs e)
        {

        }

        private void dgvStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvStudents.Rows[e.RowIndex];

                txtSearch.Text = row.Cells[0].Value.ToString();
                txtName.Text = row.Cells[1].Value.ToString();
                txtSurname.Text = row.Cells[2].Value.ToString();
                txtAddress.Text = row.Cells[3].Value.ToString();
                txtPhone.Text = row.Cells[4].Value.ToString();
                txtModuleCode.Text = row.Cells[5].Value.ToString();
            }
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            
            Student student = new Student(StudentNumber(txtName.Text,txtSurname.Text,txtPhone.Text),txtName.Text,txtSurname.Text,pbSutdentImage.ImageLocation,dtpDoB.Text,cmbGender.Text,txtPhone.Text,txtAddress.Text,txtModuleCode.Text);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            Student student = new Student(StudentNumber(txtName.Text, txtSurname.Text, txtPhone.Text), txtName.Text, txtSurname.Text, pbSutdentImage.ImageLocation, dtpDoB.Text, cmbGender.Text, txtPhone.Text, txtAddress.Text, txtModuleCode.Text);

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Student student = new Student(StudentNumber(txtName.Text, txtSurname.Text, txtPhone.Text), txtName.Text, txtSurname.Text, pbSutdentImage.ImageLocation, dtpDoB.Text, cmbGender.Text, txtPhone.Text, txtAddress.Text, txtModuleCode.Text);

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Student student = new Student(StudentNumber(txtName.Text, txtSurname.Text, txtPhone.Text), txtName.Text, txtSurname.Text, pbSutdentImage.ImageLocation, dtpDoB.Text, cmbGender.Text, txtPhone.Text, txtAddress.Text, txtModuleCode.Text);

        }

        public string StudentNumber(string name, string surname, string phone)
        {
            string studentNumber = string.Concat(name.Substring(0, 3), surname.Substring(0, 3), phone.Substring(phone.Length - 4));
            return studentNumber;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataHandler dh = new DataHandler();
            dgvStudents.DataSource = dh.SearchStudent(txtSearch.Text);

        }
    }
}
