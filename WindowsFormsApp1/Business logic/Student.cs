using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Business_logic
{
    class Student
    {
        private int studentNumber;
        private string studentName;
        private string studentSurname;
        private string studentImage;
        private DateTime dob;
        private string gender;
        private string phone;
        private string address;
        private string moduleCodes;

        public Student(int studentNumber, string studentName, string studentSurname, string studentImage, DateTime dob, string gender, string phone, string address, string moduleCodes)
        {
            this.studentNumber = studentNumber;
            this.studentName = studentName;
            this.studentSurname = studentSurname;
            this.studentImage = studentImage;
            this.dob = dob;
            this.gender = gender;
            this.phone = phone;
            this.address = address;
            this.moduleCodes = moduleCodes;
        }

        public int StudentNumber
        {
            get { return studentNumber; }
            set { studentNumber = value; }
        }
        public string StudentName 
        {
            get { return studentName; }
            set { studentName = value; }
        }
        public string StudentSurname 
        {
            get { return studentSurname; }
            set { studentSurname = value; }
        }
        public string StudentImage 
        {
            get { return studentImage; }
            set { studentImage = value; }
        }
        public DateTime Dob 
        {
            get { return dob; }
            set { dob = value; }
        }
        public string Gender 
        {
            get { return gender; }
            set { gender = value; }
        }
        public string Phone 
        {
            get { return phone; }
            set { phone = value; }
        }
        public string Address 
        {
            get { return address; }
            set { address = value; }
        }
        public string ModuleCodes 
        {
            get { return moduleCodes; }
            set { moduleCodes = value; }
        }
    }
}
