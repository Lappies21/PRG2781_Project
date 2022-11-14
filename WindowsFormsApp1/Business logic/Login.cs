using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Presentation_Layer;


namespace WindowsFormsApp1.Business_logic
{
    class Login
    {
        private string username;
        private string password;
        private string confirmPassword;

        public Login(string username, string password, string confirmPassword)
        {
            this.username = username;
            this.password = password;
            this.confirmPassword = confirmPassword;
        }

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string ConfirmPassword { get => confirmPassword; set => confirmPassword = value; }

        
    }
}
