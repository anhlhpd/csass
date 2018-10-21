using System;
using Exam.controller;

namespace Exam.view
{
    public class MainView
    {
        public static ProductController controller = new ProductController();
        
        public static void GenerateMenu()
        {
            
            while (true)
            {
                Console.WriteLine("--------- STORE MANAGEMENT ---------");
                Console.WriteLine("1. Add product records.");
                Console.WriteLine("2. Display product records.");
                Console.WriteLine("3. Delete product by Id.");
                Console.WriteLine("4. Exit.");
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("Please enter your choice (1|2|3|4): ");
                var choice = GetInt32Number();
                switch (choice)
                {
                    case 1:
                        controller.Add();
                        break;
                    case 2:
                        controller.Display();
                        break;
                    case 3:
                        controller.Delete();
                        break;
                    case 4:
                        Console.WriteLine("See you later.");
                        Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
        
        public static int GetInt32Number()
        {
            var choice = 0;
            while (true)
            {
                try
                {
                    var strChoice = Console.ReadLine();
                    choice = Int32.Parse(strChoice);
                    break;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Please enter a number.");
                }
            }

            return choice;
        }
    }
}