using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace WoerterbuchData
{
    public class Repository
    {
        public string connectionString = "server=localhost;database=dictionary;uid=root;";
        public MySqlConnection connection;
        public MySqlCommand command;
        public List<string> dataList = new List<string>();


        public void InsertData(string sql)
        {
           
        }
        public List<string> GetDataList()
        {
            string databaseUrl = "" + connectionString + "";
            connection = new MySqlConnection(databaseUrl);
            string sql = "SELECT dictOne.word as language1, dictTwo.word as language2, dictOne.country_code as code1, dictTwo.country_code as code2, " +
                "dictOne.id as id1, dictTwo.id as id2 FROM `relation` inner join dictionary as dictOne on relation.id_one = " +
                "dictOne.id inner join dictionary as dictTwo on relation.id_two = dictTwo.id";
            MySqlCommand command = new MySqlCommand(sql);
            command.Connection = connection;
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string word = reader.GetString("language1");
                string countyCode = reader.GetString("code1");
                int id = reader.GetInt32("id1");
                string word1 = reader.GetString("language2");
                string countyCode1 = reader.GetString("code2");
                int id1 = reader.GetInt32("id2");

                string data = word + ";" + countyCode + ";" + id + ";";
                string data1 = word1 + ";" + countyCode1 + ";" + id1 + ";";
                dataList.Add(data);
                dataList.Add(data1);

            }
            return dataList;

        }
    }
}