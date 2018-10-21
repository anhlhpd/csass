using System;
using System.Collections.Generic;

namespace Delegate
{
    class Program
    {
        delegate bool FilterDelegate(Student student);
        delegate void DemoDelegate();

        static void Main(string[] args)
        {
//            Console.WriteLine("Nhập số thứ nhất:");
//            int a = Console.Read();
//            Console.WriteLine("Nhập số thứ hai:");
//            int b = Console.Read();
//            Console.WriteLine("Phép tính (+ | - | * | / ):");
//            string choice = Console.ReadLine();
//            
//            
//            if (choice == "+")
//            {
//                
//            }
            CallBack(SayGoodbye);
            
            List<Student> list = new List<Student>()
            {
                new Student("Xuan Hung", "A0001", 1, 20),
                new Student("Xuan", "A0001", 1, 20),
                new Student("Hung", "A0001", 1, 20),
                new Student("Xuan Hung", "A0001", 1, 20)
            };
            Display(list, CheckMale);
        }

        static void Display(List<Student> listStudent, FilterDelegate filter)
        {
            foreach (var student in listStudent)
            {
                if (filter(student))
                {
                    Console.WriteLine(student.Name + " - " + student.Age);
                }
            }
        }

        static bool CheckMale(Student student)
        {
            if (student.Gender == 1)
            {
                return true; 
            }
            return false;
        }

        static void CallBack(DemoDelegate demoDelegate)
        {
            demoDelegate();
        }

        static void SayGoodbye()
        {
            Console.WriteLine("Say Goodbye!");
        }

        static void Add(int a, int b)
        {
            Console.WriteLine("Tổng hai số là " + (a + b));
        }
        static void Minus(int a, int b)
        {
            Console.WriteLine("Hiệu hai số là " + (a - b));
        }

        static void Multiple(int a, int b)
        {
            Console.WriteLine("Tích hai số là " + (a * b));
        }
        static void Divide(int a, int b)
        {
            if (b == 0)
            {
                Console.WriteLine("Số bị chia không thể bằng 0.");
            }
            Console.WriteLine("Thương hai số là " + (a / b));
        }
    }
}