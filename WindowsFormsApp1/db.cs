using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class MYsql
    {
        private MySqlConnection conn;
        public bool status;

        public MYsql()
        {
            status = Connection();
        }

        private bool Connection()
        {
            string host = "gudi.kr";
            string Port = "5002";
            string user = "gdc3";
            string pwd = "gdc3";
            string db = "gdc3_1";

            string connStr = string.Format(@"server={0}; Port={1}; user={2};password={3};database={4}", host, Port, user, pwd, db);
            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                conn.Open();
                this.conn = conn;
                //MessageBox.Show("MS-SQL 연결 성공!");
                return true;
            }
            catch
            {
                conn.Close();
                this.conn = null;
                //MessageBox.Show("MS-SQL 연결 실패!");
                return false;
            }
        }

        public bool ConnectionClose()
        {
            try
            {
                conn.Close();
                //MessageBox.Show("MS-SQL 연결끊기 성공!");
                return true;
            }
            catch
            {
                //MessageBox.Show("MS-SQL 연결끊기 실패!");
                return false;
            }
        }

        public bool NonQuery(string sql)
        {
            try
            {
                if (status)
                {
                    MySqlCommand comm = new MySqlCommand(sql, conn);
                    comm.ExecuteNonQuery();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public MySqlDataReader Reader(string sql)
        {
            try
            {
                if (status)
                {
                    MySqlCommand comm = new MySqlCommand(sql, conn);
                    return comm.ExecuteReader();
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public void ReaderClose(MySqlDataReader reader)
        {
            reader.Close();
        }
    }
}
