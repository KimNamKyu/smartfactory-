using MySql.Data.MySqlClient;
using System;

namespace ClassLibrary
{
    public class Class1
    {
        public int Add(int a, int b)
        {
            return (a + b);
        }
    }

    public class DataBase
    {
        private MySqlConnection conn;
        public DataBase()
        {
            this.conn = GetConnection();
        }
        public MySqlConnection GetConnection()
        {
            try
            {
                string strConnetction = string.Format("server={0}; user={1}; password={2}; database={3};","192.168.3.115","root","1234","test");
                conn = new MySqlConnection();
                conn.ConnectionString = strConnetction;
                conn.Open();
                return conn;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public MySqlDataReader Reader(string sql)
        {
            try
            {
                if(conn == null)
                {
                    Console.WriteLine("DB 오류");
                    return null;
                }
                else
                {
                    MySqlCommand comm = new MySqlCommand(sql, conn);
                    return comm.ExecuteReader();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool NonQuery(string sql)
        {
            try
            {
                MySqlCommand comm = new MySqlCommand(sql, conn);
                comm.ExecuteNonQuery();
                return true;
            }
            catch 
            {
                return false;
            }
        }
    }
}
