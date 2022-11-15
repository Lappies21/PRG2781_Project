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
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-FPSAHJE;Initial Catalog=Students;Integrated Security=True");
        public DataTable ViewStudent()
        {
            using (con)
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM dbo.TableStudents", con);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;   
            }
        }

        public void SearchStudent(string studentNumber,DataGridView dgvDisplay)
        {
            using (con)
            {
                try
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM dbo.TableStudents where [StudentNumber] = {studentNumber}'", con);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvDisplay.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public void InsertStudent(int _studentNumber, string _studentName, string _studentSurname, string _studentImage, DateTime _dateOfBirth, string _gender, string _phone, string _address)
        {
            string insertStudent = @"INSERT INTO dbo.TableStudents SET StudentNumber=('" + _studentNumber + "'), StudentName=('" + _studentName + "'), StudentSurname=('" + _studentSurname + "'), StudentImage=('" + _studentImage + "'), DateOfBirth=('" + _dateOfBirth + "'), Gender=('" + _gender + "'), Phone=('" + _phone + "'), Address=('" + _address + "'), ";
            con.Open();
            SqlCommand cmd = new SqlCommand(insertStudent, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UpdateStudent(int _studentNumber, string _studentName, string _studentSurname, string _studentImage, DateTime _dateOfBirth, string _gender, string _phone, string _address)
        {
            string qryUpdate = @"UPDATE dbo.TableStudents SET StudentNumber=('" + _studentNumber + "'), StudentName=('" + _studentName + "'), StudentSurname=('" + _studentSurname + "'), StudentImage=('" + _studentImage + "'), DateOfBirth=('" + _dateOfBirth + "'), Gender=('" + _gender + "'), Phone=('" + _phone + "'), Address=('" + _address + "'), ";
            con.Open();
            SqlCommand cmd = new SqlCommand(qryUpdate, con);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update Successfull!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Unsuccessfull!" + ex);
            }
            finally
            {
                con.Close();
            }
        }

        public void DeleteStudent(int _studentNumber, string _studentName, string _studentSurname, string _studentImage, DateTime _dateOfBirth, string _gender, string _phone, string _address)
        {
            string DeleteStudent = @"DELETE FROM dbo.TableStudents WHERE StudentNumber=('" + _studentNumber + "'), StudentName=('" + _studentName + "'), StudentSurname=('" + _studentSurname + "'), StudentImage=('" + _studentImage + "'), DateOfBirth=('" + _dateOfBirth + "'), Gender=('" + _gender + "'), Phone=('" + _phone + "'), Address=('" + _address + "'),";
            con.Open();
            SqlCommand cmd = new SqlCommand(DeleteStudent, con);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted Successfully!");
            }
            catch (Exception)
            {
                MessageBox.Show("Delete unsuccessfull");
            }
            finally
            {
                con.Close();

            }


        }
        //Module Forms Functions
        public void CreateModule(string ModuleCode,string ModuleName,string ModuleDescription,string ResourceLinks)
        {
            using (con)
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand($"Insert Into dbo.Module (ModuleCode,ModuleName,ModuleDescription,ResourceLinks) Values('{ModuleCode}','{ModuleName}','{ModuleDescription}','{ResourceLinks}')", con);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    MessageBox.Show("Module Creation Unsuccessfull");
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public void UpdateModule(string ModuleCode,string ModuleName, string ModuleDescription, string ResourceLinks)
        {
            using (con)
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand($"insert into dbo.Module set ModuleName='{ModuleName}',ModuleDescription ='{ModuleDescription}',ResourceLinks='{ResourceLinks}' where ModuleCode = '{ModuleCode}'", con);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    MessageBox.Show("Module Deletion Unsuccessfull");
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public void DeleteModule(string ModuleCode)
        {
            using (con)
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand($"delete from dbo.Module where ModuleCode = '{ModuleCode}'", con);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    MessageBox.Show("Module Deletion Unsuccessfull");
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public void SearchModule(string ModuleCode,DataGridView dgvModules)
        {
                using (con)
                {
                    try
                    {
                        con.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM dbo.Module where [ModuleCode] = {ModuleCode}'", con);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvModules.DataSource = dt;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            
        }

        public DataTable ViewModule()
        {
            using (con)
            {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM dbo.Module", con);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                
            }
        }
    }
}
