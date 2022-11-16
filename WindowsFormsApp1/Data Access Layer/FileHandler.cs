using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using WindowsFormsApp1.Presentation_Layer;

namespace WindowsFormsApp1.Data_Access_Layer
{
    class FileHandler
    {
        string filepath = "D:Login.txt";
       
        public void Write(string Username, string Password)
        {
            if (File.Exists(filepath))
            {
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    sw.WriteLine($"{Username},{Password}");
                }
            }
            else
            {
                FileStream fs = new FileStream("D://Login.txt", FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine($"{Username},{Password}");
                sw.Close();
                fs.Close();
                MessageBox.Show($"User {Username} Registered");
            }
        }

        public void Read(string username, string password,Label msg,TextBox Username,TextBox Password,TextBox ConfirmPassword)
        {
            if (File.Exists(filepath))
            {
                FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate);
                StreamReader sr = new StreamReader(fs);
                string[] text = sr.ReadToEnd().Split(',');
                if (username != text[0] && password != text[1])
                {
                   
                    msg.Visible = true;
                    msg.Text = "Wrong Username Or Password";
                    msg.ForeColor = System.Drawing.Color.Red;
                    Username.ForeColor = System.Drawing.Color.Red;
                    Password.ForeColor = System.Drawing.Color.Red;
                    ConfirmPassword.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    MessageBox.Show($"Welcome {username}");
                    Login login = new Login();
                    Students students = new Students();
                    login.Hide();
                    students.Show();
                }
                sr.Close();
                fs.Close();
            }
        }
    }
}
