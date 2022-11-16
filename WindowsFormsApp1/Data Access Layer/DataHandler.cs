using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Drawing.Imaging;
using System.IO;
using System.Drawing;

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

        public void ViewImage(PictureBox pbStudentImage)
        {
            using (con)
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT Image FROM dbo.TableStudents ORDER BY StudentNumber ", con);
                    SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapt.Fill(ds, "TableStudents");
                    int count = ds.Tables["TableStudents"].Rows.Count;

                    if (count > 0)
                    {
                        Byte[] bytedata = new byte[0];
                        bytedata = (Byte[])(ds.Tables["TableStudents"].Rows[count - 1]["Image"]);
                        MemoryStream ms = new MemoryStream(bytedata);
                        pbStudentImage.Image = Image.FromStream(ms);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Image not found");
                }
                con.Close();
            }
        }

        public void SearchStudent(string studentNumber,DataGridView dgvDisplay)
        {
            using (con)
            {
                try
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM dbo.TableStudents where [StudentNumber] = '{studentNumber}'", con);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvDisplay.DataSource = dt;
                }
                catch (Exception)
                {
                    MessageBox.Show($"Student Number: {studentNumber} not found!");
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public void InsertStudent(int _studentNumber, string _studentName, string _studentSurname, string _studentImage, DateTime _dateOfBirth, string _gender, string _phone, string _address, string _modulecode,PictureBox pbStudentImage)
        {
            using (con)
            {
                try
                {
                    string insertStudent = @"INSERT INTO dbo.TableStudents (StudentNumber,Name,Surname,Image,DoB,Gender,Phone,Address,ModuleCode) Values('" + _studentNumber + "','" + _studentName + "','" + _studentSurname + "',@Image,'" + _dateOfBirth + "','" + _gender + "','" + _phone + "','" + _address + "','" + _modulecode + "')";
                    string studnetIMGPath = $"@{_studentImage}";

                    MemoryStream ms = new MemoryStream();
                    pbStudentImage.Image.Save(ms,ImageFormat.Png);

                    Byte[] bytData = new byte[ms.Length];
                    ms.Position = 0;
                    ms.Read(bytData,0,Convert.ToInt32(ms.Length));
                    SqlParameter par = new SqlParameter("@Image",SqlDbType.VarBinary,bytData.Length,ParameterDirection.Input,false,0,0,null,DataRowVersion.Current,bytData);

                    SqlCommand cmd = new SqlCommand(insertStudent, con);
                    cmd.Parameters.Add(par);

                    
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show($"Student {_studentName} Added");
                }
                catch (Exception)
                {
                    MessageBox.Show("Can't Insert Duplicate Student");
                }
                finally 
                {
                    con.Close();
                }
                
            }
        }

        public void UpdateStudent(int _studentNumber, string _studentName, string _studentSurname, string _studentImage, DateTime _dateOfBirth, string _gender, string _phone, string _address, string _modulecode, PictureBox pbStudentImage)
        {
            string qryUpdate = @"UPDATE dbo.TableStudents SET StudentNumber=('" + _studentNumber + "'), Name=('" + _studentName + "'), Surname=('" + _studentSurname + "'), Image= @Image, DoB=('" + _dateOfBirth + "'), Gender=('" + _gender + "'), Phone=('" + _phone + "'), Address=('" + _address + "'), ModuleCode=('" + _modulecode + "') ";
            string studnetIMGPath = $"@{_studentImage}"; 

            MemoryStream ms = new MemoryStream();
            pbStudentImage.Image.Save(ms, ImageFormat.Png);

            Byte[] bytData = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(bytData, 0, Convert.ToInt32(ms.Length));
            SqlParameter par = new SqlParameter("@Image", SqlDbType.VarBinary, bytData.Length, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, bytData);

            con.Open();
            SqlCommand cmd = new SqlCommand(qryUpdate, con);
            cmd.Parameters.Add(par);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show($" {_studentName} Updated Successfull!");
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

        public void DeleteStudent(int _studentNumber, string _studentName)
        {
            string DeleteStudent = @"DELETE FROM dbo.TableStudents WHERE StudentNumber=('" + _studentNumber + "')";
            con.Open();
            SqlCommand cmd = new SqlCommand(DeleteStudent, con);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show($"Deleted Student {_studentName} Successfully!");
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
                    MessageBox.Show($"{ModuleCode} Created");
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
                    SqlCommand cmd = new SqlCommand($"update dbo.Module set ModuleName='{ModuleName}',ModuleDescription ='{ModuleDescription}',ResourceLinks='{ResourceLinks}' where ModuleCode = '{ModuleCode}'", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show($"Module {ModuleCode} Updated");
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
                    MessageBox.Show($"Module {ModuleCode} Deleted");
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
                        SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM dbo.Module where [ModuleCode] = '{ModuleCode}'", con);
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
