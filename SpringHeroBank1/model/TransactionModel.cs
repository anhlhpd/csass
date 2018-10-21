
using System;
using ConsoleApp3.model;
using MySql.Data.MySqlClient;
using SpringHeroBank.entity;
using SpringHeroBank.utility;

namespace SpringHeroBank.model
{
    public class TransactionModel
    {
        public bool Insert(Transaction transaction)
        {
            DbConnection.Instance().OpenConnection();
            var sqlQuery = "insert into `transactions` " +
                           "(`type`, `amount`, `content`, `senderAccountNumber`, `@receiverAccountNumber`, `status`)" +
                           "values (@type, @amount, @content, @senderAccountNumber, @receiverAccountNumber, @status)";
            var cmd = new MySqlCommand(sqlQuery, DbConnection.Instance().Connection);
            cmd.Parameters.AddWithValue("@type", transaction.Type);
            cmd.Parameters.AddWithValue("@amount", transaction.Amount);
            cmd.Parameters.AddWithValue("@content", transaction.Content);
            cmd.Parameters.AddWithValue("@senderAccountNumber", transaction.SenderAccountNumber);
            cmd.Parameters.AddWithValue("@receiverAccountNumber", transaction.ReceiverAccountNumber);
            cmd.Parameters.AddWithValue("@status", transaction.Status);
            var result = cmd.ExecuteNonQuery();
            DbConnection.Instance().CloseConnection();
            return result == 1;
        }

        public void getTransactionList()
        {
            DbConnection.Instance().OpenConnection();
            var sqlQuery = "select * from transactions";
            var cmd = new MySqlCommand(sqlQuery, DbConnection.Instance().Connection);
            var reader = cmd.ExecuteReader();
            Console.WriteLine(String.Format("{0,15}|{1,15}|{2,15}|{3,15}|{4,15}|{5,15}",
                "Transaction ID", "Thời gian", "Transaction Type", "Receiver", "Content", "Amount"));
            while (reader.Read())
            {
                Console.WriteLine(String.Format("{0,15}|{1,15}|{2,15}|{3,15}|{4,15}|{5,15}",
                    "Transaction ID", "Thời gian", "Transaction Type", "Receiver", "Content", "Amount"));
            }
            DbConnection.Instance().CloseConnection();
        }
    }
}