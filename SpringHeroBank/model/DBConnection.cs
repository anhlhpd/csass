using System;
using System.Data;
using System.Reflection;
using System.Security.Cryptography;
using System.Xml;
using MySql.Data.MySqlClient;

namespace SpringHeroBank.model
{
    public class DbConnection
    {
        private DbConnection()
        {
        }

        private string ServerName = "localhost";
        private const string DatabaseName = "springherobank";
        private string Uid = "root";
        private string Password = "";
        private string PersistSecurityInfo = "True";
        private string ServerPort = "3306";
        private string SslMode = "none";

        private MySqlConnection _connection = null;

        public MySqlConnection Connection
        {
            get { return _connection; }
        }

        private static DbConnection _instance = null;

        public static DbConnection Instance()
        {
            return _instance != null ? _instance : (_instance = new DbConnection());
        }

        public void OpenConnection()
        {
            if (_connection == null)
            {
                var connstring =
                    string.Format(
                        "Server={0}; database={1}; UID={2}; password={3}; persistsecurityinfo={4};port={5}; SslMode={6}",
                        ServerName, DatabaseName, Uid, Password, PersistSecurityInfo, ServerPort, SslMode);
                _connection = new MySqlConnection(connstring);
                _connection.Open();
            }
            else if (Connection.State == ConnectionState.Closed)
            {
                Connection.Open();
            }
        }

        public void CloseConnection()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
                _connection.Close();
        }
    }
}