using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;

namespace Db
{
    class MSsql
    {
        SqlConnection conn;
        public MSsql()  //생성자로 Connection 정보를 가져온다.
        {
            conn = Connection();
        }
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
               // MessageBox.Show("MS-SQL 연결 성공!");
            }
            catch
            {
                conn.Close();
                MessageBox.Show("MS-SQL 연결 실패!");
            }

            return conn;
        }

        public SqlDataReader Select(string sql)
        {
            //reader를 바로 담기
            //string sql = "select name as tableName from gdc.sys.tables;";
            SqlCommand comm = new SqlCommand(sql, conn);
            SqlDataReader reader = comm.ExecuteReader();    //reader에 col row모두담겨있음.
            return reader;
            /* ArrayList 에 담기
            ArrayList list = new ArrayList();   //행부분이 책임
            while (reader.Read())   //한 행에 열드의 정보를 담음
            {
                Hashtable ht = new Hashtable(); // KEY값과 Value 값으로 사용하기위해 Hachtable 
                for(int i =0; i<reader.FieldCount; i++) //column수 반복
                {
                    //ht.Add(i,reader[i]);    //키 : 컬럼명 ,
                    ht.Add(reader.GetName(i), reader.GetValue(i)); //키 = colum명 , 열의 값
                }
                //string result = string.Format("no={0},name={1}", reader[0], reader[1]);
                list.Add(ht);
            }
            return list;
            */
        }
    }

    class MYsql
    {
        MySqlConnection conn;
        public MYsql()
        {
            conn = MySqlConnection();
        } 
        public void Excu()
        {
            MySqlConnection conn = MySqlConnection();
        }
        public MySqlConnection MySqlConnection()
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
                //MessageBox.Show("연결 성공");
            }
            catch
            {
                conn.Close();
                //MessageBox.Show("연결 실패");
            }
            return conn;
        }
        public MySqlDataReader Select(string sql)
        {
            MySqlCommand comm = new MySqlCommand(sql,conn);
            MySqlDataReader reader = comm.ExecuteReader();
            return reader;
        }
    }
}
