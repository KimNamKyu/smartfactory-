using System;
using System.Collections;
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
                string sql = "select ml.ml_No, m.m_Name, m.m_Price, ml.ml_Count, ml.ml_TotalCount from Menulist as ml inner join Menu as m on(ml.ml_mNo = m.m_No); ";
                MySqlCommand comm = new MySqlCommand(sql,conn);
                MySqlDataReader sdr = comm.ExecuteReader();
 
            }
            catch 
            {
                Console.WriteLine("연결실패");
            }
        }
    }
}
