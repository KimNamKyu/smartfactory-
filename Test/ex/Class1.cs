using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ex
{
    public class Class1
    {
        private string strConnection = string.Format("server={0}; uid={1}; password={2}; database={3};", "192.168.3.115", "root", "1234", "test");
        private string strConnection2 = string.Format("server={0}; uid={1}; password={2}; database={3};", "192.168.3.146", "root", "1234", "test");

        public MySqlConnection GetConnection()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection();
                IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
                for(int i = 0; i<host.AddressList.Length; i++)
                {
                    if(host.AddressList[i].AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        string ip = host.AddressList[i].ToString();
                    }
                }
                return conn;
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public void File()
        {

        }
    }
}
