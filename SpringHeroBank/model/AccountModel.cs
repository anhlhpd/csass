using System;
using System.Data;
using System.Security.Cryptography;
using System.Transactions;
using MySql.Data.MySqlClient;
using SpringHeroBank.entity;
using SpringHeroBank.utility;
using Transaction = SpringHeroBank.entity.Transaction;

namespace SpringHeroBank.model
{
    public class AccountModel
    {
        public Boolean Save(Account account)
        {
            DbConnection.Instance().OpenConnection(); // đảm bảo rằng đã kết nối đến db thành công.
            var salt = Hash.RandomString(7); // sinh ra chuỗi salt random
            account.Salt = salt; // đưa muối vào thuoojcj tính của account để lưu vào db
            account.Password = Hash.GenerateSaltedSHA1(account.Password, account.Salt); // mã hóa password của người dùng kèm theo muối
            var sqlQuery = "insert into `accounts` " +
                           "(`username`, `password`, `accountNumber`, `identityCard`, `balance`, `phone`, `email`, `fullName`, `salt`) values" +
                           "(@username, @password, @accountNumber, @identityCard, @balance, @phone, @email, @fullName, @salt)";
            var cmd = new MySqlCommand(sqlQuery, DbConnection.Instance().Connection);
            cmd.Parameters.AddWithValue("@username", account.Username);
            cmd.Parameters.AddWithValue("@password", account.Password);
            cmd.Parameters.AddWithValue("@salt", account.Salt);
            cmd.Parameters.AddWithValue("@accountNumber", account.AccountNumber);
            cmd.Parameters.AddWithValue("@identityCard", account.IdentityCard);
            cmd.Parameters.AddWithValue("@balance", account.Balance);
            cmd.Parameters.AddWithValue("@phone", account.Phone);
            cmd.Parameters.AddWithValue("@email", account.Email);
            cmd.Parameters.AddWithValue("@fullName", account.FullName);            
            var result = cmd.ExecuteNonQuery();  // trà về int là số lượng bản ghi được thay đổi khi lưu vào db       
            DbConnection.Instance().CloseConnection();
            return result == 1;
        }

        public bool UpdateBalance(Account account, decimal amount, Transaction.TransactionType transactionType)
        {
            DbConnection.Instance().OpenConnection(); // đảm bảo rằng đã kết nối đến db thành công.
            var transaction = DbConnection.Instance().Connection.BeginTransaction();
            
            // Lấy thông tin số dư mới nhất
            var queryBalance = "select balance from `accounts` where username = @username and status = @status";
            MySqlCommand queryBalanceCommand = new MySqlCommand(queryBalance, DbConnection.Instance().Connection);
            queryBalanceCommand.Parameters.AddWithValue("@username", account.Username);
            queryBalanceCommand.Parameters.AddWithValue("@status", 1);
            var balanceReader = queryBalanceCommand.ExecuteReader();
            
            if (!balanceReader.Read())
            {
                // Không tồn tại bản ghi thì transaction rollback và hàm dừng tại đây
                transaction.Rollback();
                return false;
            }
            
            // Đảm bảo có bản ghi
            var currentBalance = balanceReader.GetDecimal("balance");
            if (transactionType == Transaction.TransactionType.DEPOSIT)
            {
                currentBalance += amount;
            }
            else if (transactionType == Transaction.TransactionType.WITHDRAW)
            {
                if (amount > currentBalance)
                {
                    transaction.Rollback();
                    return false;
                }
                currentBalance -= amount;
            }
            else
            {
                transaction.Rollback();
                return false;
            }
            
            var result = 0;
            try
            {
                var sqlQuery = "update `accounts` set balance = @balance)";
                MySqlCommand cmd = new MySqlCommand(sqlQuery, DbConnection.Instance().Connection);

                cmd.Parameters.AddWithValue("@username", account.Username);
                cmd.Parameters.AddWithValue("@balance", currentBalance);          
                result = cmd.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw;
            }
            DbConnection.Instance().CloseConnection();
            return result == 1;
        }

        public Boolean Update(Account account)
        {
            return false;
        }

        public Boolean CheckExistUserName(string username)
        {
            DbConnection.Instance().OpenConnection();
            return false;
        }

        public Account GetAccountByUserName(string username)
        {
            DbConnection.Instance().OpenConnection();
            var sqlQuery = "SELECT * FROM `accounts` WHERE username = @username AND status = 1";
            MySqlCommand cmd = new MySqlCommand(sqlQuery, DbConnection.Instance().Connection);
            cmd.Parameters.AddWithValue("@username", username);
            MySqlDataReader reader = cmd.ExecuteReader();
            var account = new Account();
            if (reader.Read())
            {
                var _username = reader.GetString("username");
                var password = reader.GetString("password");
                var salt = reader.GetString("salt");
                var accountNumber = reader.GetString("accountNumber");
                var identityCard = reader.GetString("identityCard");
                var balance = reader.GetDecimal("balance");
                var phone = reader.GetString("phone");
                var email = reader.GetString("email");
                var fullName = reader.GetString("fullName");
                var createdAt = reader.GetString("createdAt");
                var updatedAt = reader.GetString("updatedAt");
                var status = reader.GetInt32("status");
                account = new Account(_username, password, salt, accountNumber, identityCard, balance,
                    phone, email, fullName, createdAt, updatedAt, (Account.ActiveStatus) status);
                return account;
            }
            DbConnection.Instance().CloseConnection();
            return null;
        }
    }
}