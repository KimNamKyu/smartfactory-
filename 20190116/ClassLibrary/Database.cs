using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Database
    {
        private string strConnection = string.Format("server={0}; uid={1}; password={2}; database={3};", "192.168.3.115", "root", "1234", "test");
        private string strConnection2 = string.Format("server={0}; uid={1}; password={2}; database={3};", "192.168.3.146", "root", "1234", "test");

        public MySqlConnection GetConnection()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection();

               #region 개발 (192.168.3.113) /  운영 (192.168.3.114)
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
