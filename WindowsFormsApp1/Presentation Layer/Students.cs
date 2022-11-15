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
        public string Filename;
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
                lblFileName.Text = row.Cells[3].Value.ToString();
                dtpDoB.Text = row.Cells[4].Value.ToString();
                cmbGender.SelectedItem = row.Cells[5].Value.ToString();
                txtPhone.Text = row.Cells[6].Value.ToString();
                txtAddress.Text = row.Cells[7].Value.ToString();
                txtModuleCode.Text = row.Cells[8].Value.ToString();
            }
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            Student student = new Student(int.Parse(txtSearch.Text), txtName.Text,txtSurname.Text, Filename, DateTime.Parse(dtpDoB.Text),cmbGender.Text,txtPhone.Text,txtAddress.Text,txtModuleCode.Text);
            DataHandler dh = new DataHandler();
            dh.InsertStudent(student.StudentNumber, student.StudentName, student.StudentSurname, student.StudentImage, student.Dob, student.Gender, student.Phone, student.Address);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            Student student = new Student(int.Parse(txtSearch.Text), txtName.Text, txtSurname.Text, Filename, DateTime.Parse(dtpDoB.Text), cmbGender.Text, txtPhone.Text, txtAddress.Text, txtModuleCode.Text);
            DataHandler dh = new DataHandler();
            dgvStudents.DataSource = dh.ViewStudent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Student student = new Student(int.Parse(txtSearch.Text), txtName.Text, txtSurname.Text, Filename, DateTime.Parse(dtpDoB.Text), cmbGender.Text, txtPhone.Text, txtAddress.Text, txtModuleCode.Text);
            DataHandler dh = new DataHandler();
            dh.UpdateStudent(student.StudentNumber, student.StudentName, student.StudentSurname, student.StudentImage, student.Dob, student.Gender, student.Phone, student.Address);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Student student = new Student(int.Parse(txtSearch.Text), txtName.Text, txtSurname.Text, Filename, DateTime.Parse(dtpDoB.Text), cmbGender.Text, txtPhone.Text, txtAddress.Text, txtModuleCode.Text);
            DataHandler dh = new DataHandler();
            dh.DeleteStudent(student.StudentNumber, student.StudentName, student.StudentSurname, student.StudentImage, student.Dob, student.Gender, student.Phone, student.Address);
        }

       
        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataHandler dh = new DataHandler();
            dh.SearchStudent(txtSearch.Text,dgvStudents);

        }

        private void pbSutdentImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                pbSutdentImage.Image = new Bitmap(open.FileName);
                Filename = open.FileName;
                lblFileName.Text = open.FileName;
            }
        }

        private void btnModules_Click(object sender, EventArgs e)
        {
            Module module = new Module();
            this.Hide();
            module.Show();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.Show();
        }
    }
}
