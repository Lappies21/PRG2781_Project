using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace WindowsFormsApp1.Data_Access_Layer
{
    class DataHandler
    {
        public DataTable ViewStudent()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-FPSAHJE;Initial Catalog=Students;Integrated Security=True"))
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM dbo.Students", con);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;   
            }
        }

        public void CreateStudent()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-FPSAHJE;Initial Catalog=Students;Integrated Security=True"))
            {

            }
        }

        public void UpdateStudent()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-FPSAHJE;Initial Catalog=Students;Integrated Security=True"))
            {

            }
        }

        public void DeleteStudent()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-FPSAHJE;Initial Catalog=Students;Integrated Security=True"))
            {

            }
        }

        public DataTable SearchStudent(string studentNumber)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-FPSAHJE;Initial Catalog=Students;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand($"SELECT * FROM dbo.Students where [StudentNumber] = {studentNumber}",con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                
                while (dr.Read())
                {
                    if (dr.HasRows == false)
                    {
                        MessageBox.Show($"student number: {studentNumber} could not be found");
                        break;
                    }
                    else if(dr.HasRows == true)
                    {
                        MessageBox.Show($"Student Number: {studentNumber} found.");
                        break;
                    }
                }
                SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM dbo.Students where [StudentNumber] = {studentNumber}", con);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public void CreateModule()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-FPSAHJE;Initial Catalog=Students;Integrated Security=True"))
            {

            }
        }
    }
}
