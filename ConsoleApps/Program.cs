using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using swPackage;

namespace ConsoleApps
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Test test = new Test();
            int result = test.Add(4, 5);
            Console.WriteLine("4 + 5 = {0} ",result );
            */
            try
            {
                DBInfo dbi = new DBInfo();
                //Database db = new Database(dbi.server, dbi.uid, dbi.password, dbi.database);

                
                Database db = new Database(dbi.GetDB());
                /**객체화******************************************************
                SqlConnection conn = db.Open();
                Console.WriteLine("접속");
                SqlDataReader sdr = db.GetReader(conn, "select * from [Notice]");

                while (sdr.Read())
                {
                    Console.WriteLine(sdr.GetValue(1));
                }
                sdr.Close();
                conn.Close();
                Console.WriteLine("디비종료");
                */
                db = new Database(dbi.GetDB());
                Hashtable resultMap = db.GetReader("select * from [Notice]");
                
                if(Convert.ToInt32(resultMap["MsgCode"]) == -1)
                {
                    Console.WriteLine(resultMap["Msg"]);
                }
                else
                {
                    ArrayList resultList = (ArrayList)resultMap["Data"];
                    foreach(Hashtable row in resultList)
                    {
                        Console.WriteLine("nNo : {0}, uName : {1}", row["nNo"], row["uName"]);
                    }
                }
            }
            catch 
            {
                Console.WriteLine("오류");
            }
        }
    }
}
