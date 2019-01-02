using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swPackage
{
    public class Database
    {
        private string server, uid, password, database;

        //DB정보를 알고있어야 할때
        public Database(string server, string uid, string password,string database)
        {
            this.server = server;
            this.uid = uid;
            this.password = password;
            this.database = database;
        }

        //DB정보를 몰라도 사용하고싶을때
        public Database(Hashtable db)
        {
            this.server = db["server"].ToString();
            this.uid = db["uid"].ToString();
            this.password = db["password"].ToString();
            this.database = db["database"].ToString();
        }

        public SqlConnection Open()
        {
            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = string.Format("server = {0}; uid = {1}; password = {2}; database = {3};", server, uid, password, database);
                conn.Open();
                return conn;
            }
            catch
            {
                return null;
            }
        }

        public Hashtable GetReader( string sql)
        {
            SqlConnection conn = Open();
            Hashtable resultMap = new Hashtable();
            ArrayList resultList = new ArrayList();
            try
            {
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = sql;
               SqlDataReader Sdr = comm.ExecuteReader();

                while (Sdr.Read())
                {
                    Hashtable row = new Hashtable();
                    for(int i = 0; i< Sdr.FieldCount; i++)
                    {
                        row.Add(Sdr.GetName(i), Sdr.GetValue(i));
                    }
                    resultList.Add(row);
                }

                resultMap.Add("MsgCode", 1);
                resultMap.Add("Data", resultList);
                Sdr.Close();
                conn.Close();
                return resultMap;
            }
            catch 
            {
                resultMap.Add("MsgCode", -1);
                resultMap.Add("Msg", "읽어 오는 중 오류 발생");
                conn.Close();
                return resultMap;
            }
        }
    }
}
