using System;

namespace SpringHeroBank.utility
{
    public class Utility
    {
    // Đảm bảo người dùng nhập số
        public static decimal GetUnsignNumber()
        {
            decimal choice;
            while (true)
            {
                try
                {
                    var strChoice = Console.ReadLine();
                    choice = Int32.Parse(strChoice);
                    if (choice <= 0)
                    {
                        throw new FormatException();
                    }
                    else
                    {
                        break;
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Please enter a number.");
                }
            }
            return choice;
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