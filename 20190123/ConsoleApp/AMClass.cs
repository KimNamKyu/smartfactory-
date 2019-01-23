using ClassLibrary;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class AMClass
    {
        static void Main(string[] args)
        {
            DataBase db = new DataBase();

            string sql = "select * from Notice;";
            MySqlDataReader sdr = db.Reader(sql);

            int cnt = 0;
            while (sdr.Read())
            {
                cnt++;
            }
            sdr.Close();
            Console.WriteLine("총 데이터 수 : {0}", cnt);

            sql = "insert into Notice (nTitle, nContents) values ('test', '내용')";
            bool status = db.NonQuery(sql);
            Console.WriteLine("데이터 삽입 : {0}",status);

            sql = "select max(nNo) as nNo from Notice";
            sdr = db.Reader(sql);
            int nNo = 0;
            while (sdr.Read())
            {
                nNo = Convert.ToInt32(sdr["nNo"]);
            }
            sdr.Close();
            Console.WriteLine("nNo = {0}",nNo);

            sql = string.Format("update Notice set nTitle = '테스트', nContents = '테스트' where nNo = {0};",nNo);
            status = db.NonQuery(sql);
            Console.WriteLine("데이터 수정 결과 : {0}" , status);

            sql = string.Format("update Notice set delYn = 'Y' where nNo = {0};", nNo);
            status = db.NonQuery(sql);
            Console.WriteLine("데이터 삭제 결과 : {0}", status);
        }
    }
}
