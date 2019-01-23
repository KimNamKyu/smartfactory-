using ClassLibrary;
using MySql.Data.MySqlClient;
using System;

namespace ConsoleApp
{
    class Program
    {
         void Main(string[] args)
        {
            string sql = "";
            string nTitle = "";
            string nContents = "";
            string nNo = "";
            Class1 c1 = new Class1();
            Console.WriteLine(c1.Add(1,3));

            DataBase db = new DataBase();
            MySqlConnection conn = db.GetConnection();

            if(conn == null)
            {
                Console.WriteLine("접속 오류");
            }
            else
            {
                Console.WriteLine("접속 성공");
                while (true)
                {
                    Console.WriteLine("1번 : Select      2번 : Insert     3번 : Update     4번 : Delete     5번 : 종료");
                 
                    switch (Console.ReadLine())
                    {
                        case "1":
                            Console.WriteLine("1번선택");
                            sql = string.Format("select * from Notice;");
                            MySqlDataReader sdr = db.Reader(sql);
                            while (sdr.Read())
                            {
                                for (int i = 0; i < sdr.FieldCount; i++)
                                {
                                    Console.Write(sdr.GetValue(i) + "     \t");
                                    if (i == 5)
                                    {
                                        Console.WriteLine();
                                    }
                                }
                            }
                            sdr.Close();
                            break;
                        case "2":
                            Console.Write("제목을 입력하세요 : ");
                            nTitle = Console.ReadLine();
                            Console.Write("내용을 입력하세요 : ");
                            nContents = Console.ReadLine();
                            sql = string.Format("insert into Notice (nTitle, nContents) values ('{0}', '{1}');",nTitle,nContents);
                            db.NonQuery(sql);
                            break;
                        case "3":
                            Console.WriteLine("수정할 대상을 입력하세요");
                            nNo = Console.ReadLine();
                            Console.Write("제목을 입력하세요 : ");
                            nTitle = Console.ReadLine();
                            Console.Write("내용을 입력하세요 : ");
                            nContents = Console.ReadLine();
                            sql = string.Format("update Notice set nTitle = '{1}', nContents = '{2}' where nNo = {0};",nNo,nTitle,nContents);
                            db.NonQuery(sql);
                            break;
                        case "4":
                            Console.WriteLine("삭제할 대상을 입력하세요");
                            nNo = Console.ReadLine();
                            sql = string.Format("update Notice set delYn = 'Y' where nNo = {0};", nNo);
                            db.NonQuery(sql);
                            break;
                        case "5":
                            return;
                    }
                    Console.WriteLine();
                }
            }
            
        }
    }
}
