using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace API.Data
{
    public class Database
    {
        public string ConnString { get; set; }
        public MySqlConnection Conn { get; set; }

        public Database()
        {
            string server = "sql5.freemysqlhosting.net";
            string user="sql5453134";
            string database="sql5453134";
            string port="3306";
            string password="dAJNxRiMz5";
            
            Console.WriteLine("got the datbase " + server);

            this.ConnString = $@"server = {server};user={user};database={database};port={port};password={password};AllowLoadLocalInfile=true";
            this.Conn = new MySqlConnection(this.ConnString);
        }

        public void Open()
        {
            this.Conn.Open();
        }

        public void Close()
        {
            this.Conn.Close();
        }

        public List<ExpandoObject> Select(string query)
        {
            List<ExpandoObject> results = new();
            try
            {
                using var cmd = new MySqlCommand(query, this.Conn);
                using var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var temp = new ExpandoObject() as IDictionary<string, Object>;
                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        temp.TryAdd(rdr.GetName(i), rdr.GetValue(i));
                    }

                    results.Add((ExpandoObject)temp);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Select Query Error");
                Console.WriteLine(e.Message);
            }

            return results;
        }

        public void Insert(string query, Dictionary<string, object> values)
        {
            QueryWithData(query, values);
        }

        public void Update(string query, Dictionary<string, object> values)
        {
            QueryWithData(query, values);
        }

        private void QueryWithData(string query, Dictionary<string, object> values)
        {
            try
            {
                using var cmd = new MySqlCommand(query, this.Conn);
                foreach (var p in values)
                {
                    cmd.Parameters.AddWithValue(p.Key, p.Value);
                }

                cmd.Prepare();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error Inserting Data");
                Console.WriteLine(e.Message);
            }
        }
    }
}
