using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ConsoleApp1
{
    class Program
    {
        private static List<Student> list = new List<Student>();

        static void Main(string[] args)
        {
            GenerateMenu();
        }
        
        private static void SearchByName()
        {
            Console.WriteLine("Please enter name to search: ");
            var searchKey = Console.ReadLine();
            for (int i = 0; i < list.Count; i++)
            {
                Student student = list[i];
                if (student.Name == searchKey)
                {
                    Console.WriteLine("Found: ");
                    Console.WriteLine(student.RollNumber + " - " + student.Name);                    
                }
            }
        }

        private static void AddStudent()
        {
            var student = new Student();
            Console.WriteLine("Please enter student rollnumber: ");
            student.RollNumber = Console.ReadLine();
            Console.WriteLine("Please enter student name: ");
            student.Name = Console.ReadLine();
            Console.WriteLine("Please enter student email: ");
            student.Email = Console.ReadLine();
            Console.WriteLine("Please enter student phone: ");
            student.Phone = Console.ReadLine();
            list.Add(student);
        }

        private static void DisplayStudent()
        {
            foreach (var student in list)
            {
                Console.WriteLine(student.Name);
            }
        }

        private static void GenerateMenu()
        {
            while (true)
            {
                Console.WriteLine("----------Quản lý sinh viên---------");
                Console.WriteLine("1. Thêm mới sinh viên.");
                Console.WriteLine("2. Hiển thị danh sách.");
                Console.WriteLine("3. Tìm kiếm theo tên.");
                Console.WriteLine("4. Thoát.");
                Console.WriteLine("------------------------------------");
                Console.WriteLine("Nhập lựa chọn của bạn: ");
                var choice = Int32.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddStudent();
                        break;
                    case 2:
                        DisplayStudent();
                        break;
                    case 3:
                        SearchByName();
                        break;
                    case 4:
                        Environment.Exit(1);
                        break;
                }
            }
        }

        
    }
}