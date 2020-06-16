using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MySql;
using MySql.Data.MySqlClient;

namespace WoerterbuchData
{
    public class DatabaseConnector
    {
        private MySqlConnection connection = null;
        private MySqlCommand statement = null;
        private string url;

        public DatabaseConnector(string Url)
        {
            url = Url;
        }

        public void BuildConnection()
        {

            string databaseUrl = "" + url + "";
            connection = new MySqlConnection(databaseUrl);
            statement = connection.CreateCommand();

        }
        public void InsertData(String sql)
        {
            BuildConnection();

            MySqlCommand command = new MySqlCommand(sql);
            command.Connection = connection;
            connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();

        }

    }
}
