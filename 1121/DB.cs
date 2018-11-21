using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Db
{
    class MSsql
    {
        public void Exec()
        {
            SqlConnection conn = Connection();
        }

        private SqlConnection Connection()
        {
            string host = "(localdb)\\ProjectsV13";
            string user = "root";
            string password = "1234";
            string db = "gdc";

            string connStr = string.Format("server={0};uid={1};password={2};database={3}", host, user, password, db);
            SqlConnection conn = new SqlConnection(connStr);

            try
            {
                conn.Open();
                MessageBox.Show("MS-SQL 연결 성공!");
            }
            catch
            {
                conn.Close();
                MessageBox.Show("MS-SQL 연결 실패!");
            }

            return conn;
        }
    }

    class MYsql
    {
        public void Exec()
        {
            string host = "myDB";
            string user = "root";
            string password = "1234";
            string db = "gdc";

            string connStr = string.Format(@"server={0};user={1};password={2};database={3}", host, user, password, db);
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                MessageBox.Show("연결 성공");
            }
            catch
            {
                conn.Close();
                MessageBox.Show("연결 실패");
            }
            conn.Close();
        }
    }
}
