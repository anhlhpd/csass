namespace Delegate
{
    public class Student
    {
        private string name;
        private string rollNumber;
        private int gender;
        private int age;

        public Student()
        {
        }

        public Student(string name, string rollNumber, int gender, int age)
        {
            this.name = name;
            this.rollNumber = rollNumber;
            this.gender = gender;
            this.age = age;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string RollNumber
        {
            get => rollNumber;
            set => rollNumber = value;
        }

        public int Gender
        {
            get => gender;
            set => gender = value;
        }

        public int Age
        {
            get => age;
            set => age = value;
        }
    }
}