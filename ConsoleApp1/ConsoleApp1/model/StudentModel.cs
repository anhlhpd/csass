using System.Collections.Generic;
using System.ComponentModel;
using MySql.Data.MySqlClient;

namespace ConsoleApp1
{
    public class StudentModel
    {
        public void Save(Student student)
        {
            if (DBConnect.Instance().IsConnect())
            {
                var sqlQuery = "insert into students (rollNumber, name, email, phone) values {"
                               + student.RollNumber + ", "
                               + student.Name + ", "
                               + student.Email + ", "
                               + student.Phone + "}";
                MySqlCommand cmd = new MySqlCommand(sqlQuery, DBConnect.Instance().Connection());
                cmd.ExecuteNonQuery();
                DBConnect.Instance().Connection().Close();
            }
        }

        public void GetList()
        {
            List<Student> list = new List<Student>();
            if (!DBConnect.Instance().IsConnect())
            {
                return list;
            }
            var query = "SELECT * FROM students";
            var name = 
        }
    }
}