using MySql.Data.MySqlClient;

namespace ConsoleApp1
{
    public class DBConnect
    {
        private MySqlConnection _connection;
        private string _server;
        private string _database;
        private string _uid;
        private string _password;

        //Constructor
        public DBConnect()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            _server = "localhost";
            _database = "connectcsharptomysql";
            _uid = "username";
            _password = "password";
            string connectionString = "SERVER=" + _server + ";" + "DATABASE=" + 
                               _database + ";" + "UID=" + _uid + ";" + "PASSWORD=" + _password + ";";

            _connection = new MySqlConnection(connectionString);
        }
        
        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                _connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
//                switch (ex.Number)
//                {
//                    case 0:
//                        MessageBox.Show("Cannot connect to server.  Contact administrator");
//                        break;
//
//                    case 1045:
//                        MessageBox.Show("Invalid username/password, please try again");
//                        break;
//                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                _connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
//                MessageBox.Show(ex.Message);
                return false;
            }
        }
        
        //Insert statement
        public void Insert()
        {
            string query = "INSERT INTO tableinfo (name, age) VALUES('John Smith', '33')";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, _connection);
        
                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Update statement
        public void Update()
        {
            string query = "UPDATE tableinfo SET name='Joe', age='22' WHERE name='John Smith'";

            //Open connection
            if (this.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = _connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

//Delete statement
        public void Delete()
        {
            string query = "DELETE FROM tableinfo WHERE name='John Smith'";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, _connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }
    }
}