using System;
using MySql.Data.MySqlClient;

namespace ConsoleApp1
{
    public class Student
    {
        private string _rollNumber;
        private string _name;
        private string _email;
        private string _phone;

        public override string ToString()
        {
            return "Name: " + this.Name + " Email: " + this.Email;
        }

        public Student(string rollNumber, string name, string email, string phone)
        {
            this._rollNumber = rollNumber;
            this._name = name;
            this._email = email;
            this._phone = phone;
        }

        public Student()
        {
        }

        public string RollNumber
        {
            get => _rollNumber;
            set => _rollNumber = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string Email
        {
            get => _email;
            set => _email = value;
        }

        public string Phone
        {
            get => _phone;
            set => _phone = value;
        }

//        static void Main(string[] args)
//        {
//            var dbCon = DBConnection.Instance();
//            dbCon.DatabaseName = "student_manager";
//            if (dbCon.IsConnect())
//            {
//                //suppose col0 and col1 are defined as VARCHAR in the DB
//                string query = "SELECT * FROM product";
//                var cmd = new MySqlCommand(query, dbCon.Connection);
//                var reader = cmd.ExecuteReader();
//                while(reader.Read())
//                {
//                    string someStringFromColumnZero = reader.GetString(0);
//                    string someStringFromColumnOne = reader.GetString(1);
//                    Console.WriteLine(someStringFromColumnZero + "," + someStringFromColumnOne);
//                }
//                dbCon.Close();
//            }
//        }
        
    }
}