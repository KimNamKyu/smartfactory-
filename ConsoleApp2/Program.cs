using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("저장 프로시저 활용");

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
                Console.WriteLine("연결 성공");
            }
            catch 
            {
                Console.WriteLine("연결실패");
            }
        }
    }
}
