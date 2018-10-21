using System;
using System.Collections.Generic;
using SpringHeroBank.entity;
using SpringHeroBank.model;
using SpringHeroBank.utility;
using SpringHeroBank.view;

namespace SpringHeroBank
{
    partial class Program
    {
//        public static Account currentLoggedIn;
        static void Main(string[] args)
        {
            MainView.GenerateGeneralMenu();
//            AccountModel model = new AccountModel();
//            string username = "xuanhung2401";
//            string password = "123456";
//            Account account = model.GetAccountByUserName(username);
//            if (account == null)
//            {
//                Console.WriteLine("Sai thông tin tài khoản");
//                return;
//            }
//
//            string hashPassword = Hash.GenerateSaltedSHA1(password, account.Salt);
//            if (hashPassword != account.Password)
//            {
//                Console.WriteLine("Sai thông tin đăng nhập.");
//                return;
//            }
//            Console.WriteLine("Đăng nhập thành công.");
//            loggedInAccount = account;

//            Account account = new Account();
//            account.Username = "xuanhung2401";
//            account.Password = "123456";
//            account.GenerateAccountNumber();
//            account.Balance = 100000;
//            account.Email = "xuanhung2401@gmail.com";
//            account.FullName = "Dao Hong Luyen";
//            account.IdentityCard = "0121324234234";
//            account.Phone = "0923456234";
//            account.Status = Account.ActiveStatus.INACTIVE;
//            Console.WriteLine(model.Save(account));
            
            
//            Dictionary<int, string> dictionary = new Dictionary<int, string>();
//            dictionary.Add(23, "Xuân Hùng");
//            dictionary.Add(24, "Hùng");
//            Console.WriteLine(dictionary[23]);
//            Console.WriteLine(dictionary.Count);
//            Console.WriteLine(dictionary.ContainsKey(24));
//            Console.WriteLine(dictionary.ContainsValue("Xuân"));
//            // Mỗi obj là một cặp key-value
//            foreach (var obj in dictionary)
//            {
//                Console.WriteLine(obj.Key);
//                Console.WriteLine(obj.Value);
//            }
        }
    }
}