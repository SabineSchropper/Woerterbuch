using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography;
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
        public List<string> GetDataList(string language1)
        {
            ///important to clear this dataList for filling it new
            dataList.Clear();
            string databaseUrl = "" + connectionString + "";
            connection = new MySqlConnection(databaseUrl);
            string sql = "SELECT dictOne.word as language1, dictTwo.word as language2, dictOne.country_code as code1, dictTwo.country_code as code2, " +
                "dictOne.id as id1, dictTwo.id as id2 FROM `relation` inner join dictionary as dictOne on relation.id_one = " +
                "dictOne.id inner join dictionary as dictTwo on relation.id_two = dictTwo.id " +
                "where dictOne.country_code = '"+language1+"' OR dictTwo.country_code = '"+language1+"'";
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
                data = data + data1;
                dataList.Add(data);

            }
            connection.Close();
            reader.Close();
            return dataList;

        }
        public void AddDataToDatabase(Dictionary<Word, List<Word>> dict)
        {
            int id = 0;
            string databaseUrl = "" + connectionString + "";
            connection = new MySqlConnection(databaseUrl);
            connection.Open();
            MySqlCommand command1 = new MySqlCommand();
            foreach (KeyValuePair<Word, List<Word>> item in dict)
            {
                if (item.Key.IsNew)
                {

                    string sql = "INSERT INTO `dictionary`(`word`, `country_code`) VALUES ('" + item.Key.Name + "','" + item.Key.CountryCode + "')";
                    command1.Connection = connection;
                    command1.CommandText = sql;
                    command1.ExecuteNonQuery();
                    ///get the id from Database
                    sql = "SELECT id FROM dictionary WHERE word = '" + item.Key.Name + "'";
                    command1.CommandText = sql;
                    MySqlDataReader reader = command1.ExecuteReader();
                    
                    while (reader.Read())
                    {
                        id = reader.GetInt32("id");
                    }
                    item.Key.Id = id;
                    reader.Close();
                    connection.Close();

                    for (int i = 0; i < item.Value.Count; i++)
                    {
                        sql = "INSERT INTO `dictionary`(`word`, `country_code`) VALUES ('" + item.Value[i].Name + "','" + item.Value[i].CountryCode + "')";
                        command1 = new MySqlCommand(sql);
                        connection.Open();
                        command1.Connection = connection;
                        command1.ExecuteNonQuery();
                        ///get the id from Database
                        sql = "SELECT id FROM dictionary WHERE word = '" + item.Value[i].Name + "'";
                        command1 = new MySqlCommand(sql);
                        command1.Connection = connection;
                        reader = command1.ExecuteReader();

                        while (reader.Read())
                        {
                            id = reader.GetInt32("id");
                        }
                        item.Value[i].Id = id;
                        reader.Close();
                        connection.Close();
                        
                    }
         
                    CreateRelation(item.Key, item.Value);
                }
                else
                {

                    for (int i = 0; i < item.Value.Count; i++)
                    {
                        if (item.Value[i].IsNew)
                        {
                            string sql = "INSERT INTO `dictionary`(`word`, `country_code`) VALUES ('" + item.Value[i].Name + "','" + item.Value[i].CountryCode + "')";
                            MySqlCommand command = new MySqlCommand(sql);
                            command.Connection = connection;
                            command.ExecuteNonQuery();
                            ///get the id from Database
                            sql = "SELECT id FROM dictionary WHERE word = '" + item.Value[i].Name + "'";
                            command1 = new MySqlCommand(sql);
                            command1.Connection = connection;
                            MySqlDataReader reader = command1.ExecuteReader();

                            while (reader.Read())
                            {
                                id = reader.GetInt32("id");
                            }
                            item.Value[i].Id = id;
                            reader.Close();
                            CreateOneRelation(item.Key, item.Value[i]);
                        }
                    }
                }
            }
        }
        public void CreateRelation(Word word, List<Word> list)
        {
            string databaseUrl = "" + connectionString + "";
            connection = new MySqlConnection(databaseUrl);
            connection.Open();
            for (int i = 0; i < list.Count; i++)
            {
                string sql = "INSERT INTO `relation`(`id_one`, `id_two`) VALUES ('" + word.Id + "','" + list[i].Id + "')";
                MySqlCommand command1 = new MySqlCommand(sql);
                command1.Connection = connection;
                command1.ExecuteNonQuery();
            }
            connection.Close();
        }
        public void CreateOneRelation(Word word, Word newWord)
        {

            string databaseUrl = "" + connectionString + "";
            connection = new MySqlConnection(databaseUrl);
            connection.Open();
            string sql = "INSERT INTO `relation`(`id_one`, `id_two`) VALUES ('" + word.Id + "','" + newWord.Id + "')";
            MySqlCommand command1 = new MySqlCommand(sql);
            command1.Connection = connection;
            command1.ExecuteNonQuery();
            connection.Close();
        }
    }
}