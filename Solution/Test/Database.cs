using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class Database
    {
        private string ConnectionString;

        public Database(string server, string uid, string password, string database)
        {
            this.ConnectionString = string.Format("server={0};uid={1};password={2};database={3};", server, uid, password, database);
        }

        public Database(Hashtable db)
        {
            this.ConnectionString = string.Format("server={0};uid={1};password={2};database={3};", db["server"], db["uid"], db["password"], db["database"]);
        }

        public Database(string ConnectionString)
        {
            this.ConnectionString = ConnectionString;
        }

        private SqlConnection Open()
        {
            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = ConnectionString;
                conn.Open();
                return conn;
            }
            catch
            {
                return null;
            }
        }

        public Hashtable GetReader(string sql)
        {
            SqlConnection conn = Open();
            Hashtable resultMap = new Hashtable();
            ArrayList resultList = new ArrayList();
            try
            {
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = sql;
                SqlDataReader sdr = comm.ExecuteReader();
                while (sdr.Read())
                {
                    string[] row = new string[sdr.FieldCount];
                    //Hashtable row = new Hashtable();
                    for(int i = 0; i < sdr.FieldCount; i++)
                    {
                        row[i] = sdr.GetValue(i).ToString();
                        //row.Add(sdr.GetName(i), sdr.GetValue(i));
                    }
                    resultList.Add(row);

                }
                resultMap.Add("MsgCode", 1);
                resultMap.Add("Data", resultList);
                sdr.Close();
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
