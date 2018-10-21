namespace ConsoleApp1
{
    public class Student
    {
        private string _rollNumber;
        private string _name;
        private string _email;
        private string _phone;
        
        public Student()
        {
        }

        public Student(string rollNumber, string name, string email, string phone)
        {
            this._rollNumber = rollNumber;
            this._name = name;
            this._email = email;
            this._phone = phone;
        }

        public override string ToString()
        {
            return "Name: " + this._name + ", Rollnumber: " + this._rollNumber;
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
    }
}