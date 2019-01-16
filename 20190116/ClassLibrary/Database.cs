using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Database
    {
        //private string strConnection = string.Format("server={0}; uid={1}; password={2}; database={3};", "192.168.3.115", "root", "1234", "test");
        //private string strConnection2 = string.Format("server={0}; uid={1}; password={2}; database={3};", "192.168.3.146", "root", "1234", "test");

        public MySqlConnection GetConnection()
        {
            try
            {
                #region +개발 (192.168.3.113) /  운영 (192.168.3.114)
                //IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
                //for (int i = 0; i < host.AddressList.Length; i++)
                //{
                //    if (host.AddressList[i].AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                //    {
                //        string targetip = host.AddressList[i].ToString();
                //        if (targetip == "192.168.3.113")
                //        {
                //            Console.WriteLine("운영 데이터베이스 접속");
                //            conn.ConnectionString = strConnection2;
                //        }
                //        else
                //        {
                //            Console.WriteLine("개발 데이터베이스 접속");
                //            conn.ConnectionString = strConnection;
                //        }
                //        break;
                //    }
                //}
                #endregion
                MySqlConnection conn = new MySqlConnection();

                string path = "D:\\DBInfo.json";
                string result = new StreamReader(File.OpenRead(path)).ReadToEnd();

                #region +파일 읽기
                //FileStream fs = File.OpenRead(path);
                //byte[] b = new byte[1024];

                //UTF8Encoding temp = new UTF8Encoding(true);
                //while (fs.Read(b, 0, b.Length) > 0)    // File을 순차적으로 읽기
                //{
                //    result = temp.GetString(b);
                //}
                //Console.WriteLine("result = {0}", result);
                //fs.Close();
                // IO(input/ Output)이기 때문에 열고 닫아야함.
                #endregion

                JObject jo = JsonConvert.DeserializeObject<JObject>(result);
                Hashtable map = new Hashtable();
                foreach (JProperty col in jo.Properties())
                {
                    Console.WriteLine("{0} : {1}", col.Name, col.Value);
                    map.Add(col.Name, col.Value);
                }

                string strConnection = string.Format("server={0}; uid={1}; password={2}; database={3};", map["server"], map["user"], map["password"], map["database"]);
                conn.ConnectionString = strConnection;
                conn.Open();
                return conn;
            }
            catch
            {
                return null;
            }
        }
    }
}