using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DbConnection

{
    class DB_Connection_class : DB_Connection_classBase
    {
        string myconnectionstring = "server=localhost;user id=root;database=restaurant";
        MySqlConnection con;
        MySqlCommand cmd;

        public void OpenConnection()
        {
            con = new MySqlConnection(myconnectionstring);
            con.Open();
        }
        public void ExecuteQueries(string query)
        {  
            cmd = new MySqlCommand(query,con);
            cmd.ExecuteNonQuery();
        }
        public MySqlDataReader DataReader(string query)
        {
            cmd = new MySqlCommand(query, con);
            MySqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }

        public object ShowDataInGridView(string query)
        {
            MySqlDataAdapter dr = new MySqlDataAdapter(query, myconnectionstring);
            DataTable ds = new DataTable();
            
            dr.Fill(ds);
            return ds;
        }
        public int CountData(string query)
        {
            int count = 0;
            cmd = new MySqlCommand(query, con);
            count = Convert.ToInt32(cmd.ExecuteScalar());

            return count;

        }
        public string Max_No(string query)
        {
            OpenConnection();
            string max = null;
            cmd = new MySqlCommand(query, con);
            max = (string)cmd.ExecuteScalar();
            CloseConnection();
            return max;
        }
        public bool checkExistence(string query)
        {
            bool exists = false;
            OpenConnection();
            cmd = new MySqlCommand(query, con);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                exists = true;
            }
            CloseConnection();

                return exists;
        }
        public void CloseConnection()
        {
            con.Close();
        }

        
    }
}

