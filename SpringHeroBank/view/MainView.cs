using System;
using SpringHeroBank.controller;
using SpringHeroBank.entity;
using SpringHeroBank.utility;

namespace SpringHeroBank.view
{
    public class MainView
    {
        public static Account currentLoggedIn;

        public static void GenerateMenu()
        {
            if (currentLoggedIn == null)
            {
                GenerateGeneralMenu();
            }

            if (currentLoggedIn != null)
            {
                GenerateCustomerMenu();
            }
        }
        
        public static void GenerateGeneralMenu()
        {
            AccountController controller = new AccountController();
            while (true)
            {
                Console.WriteLine("---------WELCOME TO SPRING HERO BANK---------");
                Console.WriteLine("1. Register for free.");
                Console.WriteLine("2. Login.");
                Console.WriteLine("3. Exit.");
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("Please enter your choice (1|2|3): ");
                var choice = Utility.GetInt32Number();
                switch (choice)
                {
                    case 1:
                        controller.Register();
                        break;
                    case 2:
                        if (controller.DoLogin())
                        {
                            Console.WriteLine("Login successfully!");
                        };
                        break;
                    case 3:
                        Console.WriteLine("See you later.");
                        Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

                if (Program.currentLoggedIn != null)
                {
                    break;
                }
            }
        }

        

        public static void GenerateCustomerMenu()
        {
            AccountController controller = new AccountController();
            while (true)
            {
                Console.WriteLine("---------WELCOME BACK---------");
                Console.WriteLine("1. Check balance");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Deposit");
                Console.WriteLine("4. Transfer");
                Console.WriteLine("5. Exit.");
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("Please enter your choice (1|2|3): ");
                var choice = Utility.GetInt32Number();
                switch (choice)
                {
                    case 1:
                        controller.CheckBalance();
                        break;
                    case 2:
                        controller.Withdraw();
                        break;
                    case 3:
                        controller.Deposit();
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        
    }
}