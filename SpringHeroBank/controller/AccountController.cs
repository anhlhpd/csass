using System;
using System.Collections.Generic;
using SpringHeroBank.entity;
using SpringHeroBank.model;
using SpringHeroBank.utility;
using Transaction = System.Transactions.Transaction;

namespace SpringHeroBank.controller
{
    public class AccountController
    {
        private static List<Account> list = new List<Account>();
        
        public void Register()
        {
            AccountModel model = new AccountModel();
            Console.WriteLine("Please enter your account information:");
            Console.WriteLine("Enter username");
            var username = Console.ReadLine();
            Console.WriteLine("Enter password:");
            var password = Console.ReadLine();
            Console.WriteLine("Confirm password:");
            var cpassword = Console.ReadLine();
            Console.WriteLine("Enter identity card:");
            var identityCard = Console.ReadLine();
            Console.WriteLine("Enter full name:");
            var fullName = Console.ReadLine();
            Console.WriteLine("Enter email:");
            var email = Console.ReadLine();
            Console.WriteLine("Enter phone:");
            var phone = Console.ReadLine();
            Account account = new Account(username, password,cpassword,identityCard, phone, email, fullName);
            var errors = account.CheckValid();
            if (errors.Count == 0)
            {
                model.Save(account);
            }
            else
            {
                Console.WriteLine("Please fix the following errors and try again.");
                foreach (var messageErrorsValue in errors.Values)
                {
                    Console.WriteLine(messageErrorsValue);
                }
                Console.ReadLine();
            }
        }

        public Boolean DoLogin()
        {
            AccountModel model = new AccountModel();
            Console.WriteLine("Please enter your account information:");
            Console.WriteLine("Username:");
            var username = Console.ReadLine();
            Console.WriteLine("Password:");
            var password = Console.ReadLine();
            Account acc = new Account(username, password);
            
            var errors = acc.CheckValidLogin();
            
            if(errors.Count > 0)
            {
                Console.WriteLine("Please fix the following errors and try again.");
                foreach (var messageErrorsValue in errors.Values)
                {
                    Console.WriteLine(messageErrorsValue);
                }
                Console.ReadLine();
                return true;
            }
            
            Account account = model.GetAccountByUserName(username);

            if (account == null)
            {
                Console.WriteLine("Invalid information. Please try again!");
                return false;
            }
            if (account.Password != Hash.GenerateSaltedSHA1(password, account.Salt))
            {
                Console.Error.WriteLine("Invalid login information!");
                return false;
            }           
            Program.currentLoggedIn = account;
            return true;
        }
        
        
        public void CheckBalance()
        {
            AccountModel model = new AccountModel();
            Program.currentLoggedIn = model.GetAccountByUserName(Program.currentLoggedIn.Username);
            Console.WriteLine("Account information");
            Console.WriteLine("Full name: " + Program.currentLoggedIn.FullName);
            Console.WriteLine("Account: " + Program.currentLoggedIn.AccountNumber);
            Console.WriteLine("Balance: " + Program.currentLoggedIn.Balance);
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        }

        public void Withdraw()
        {
            
        }

        public void Deposit()
        {
            AccountModel model = new AccountModel();
            Console.WriteLine("Deposit");
            Console.WriteLine("----------------");
            Console.WriteLine("Please enter amount to deposit:");
            var amount = Utility.GetUnsignNumber();
            Program.currentLoggedIn = model.GetAccountByUserName(Program.currentLoggedIn.Username);
            if (model.UpdateBalance(Program.currentLoggedIn, amount, entity.Transaction.TransactionType.DEPOSIT))
            {
                Console.WriteLine("Transaction success!");
            }
            else
            {
                Console.WriteLine("Transaction fails, please try again!");
            }

            Console.WriteLine("Current balance: " + Program.currentLoggedIn.Balance);
            Console.WriteLine("Press enter to continue...");

        }
    }
}