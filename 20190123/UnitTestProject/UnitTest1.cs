using System;
using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;

namespace UnitTestProject
{
    [TestClass]     //=> DI (테스트하기위한 클래스)
    public class UnitTest1
    {
        [TestMethod]    // => DI (의존성 주입)  (=테스트하기위한 메소드)
        public void TestMethod1()
        {
            Class1 c1 = new Class1();
            int a = 1;
            int b = 3;

            // 내가 알고잇는 값과 / 메소드를 갓다온 값을 비교 하는 것 == UnitTest
            int c = (a + b);
            int d = c1.Add(a, b);
            Assert.AreEqual(c, d);    // AreEqual(예상값, 실제값)

        }

        [TestMethod]
        public void TestMethod2()
        {
            DataBase db = new DataBase();

            //테이블 데이터 확인 부분
            string sql = "select * from Notice;";
            MySqlDataReader sdr = db.Reader(sql);

            int cnt = 0;
            while (sdr.Read())
            {
                cnt++;
            }
            sdr.Close();
            Console.WriteLine("총 데이터 수 : {0}", cnt);

            //입력 처리 부분
            sql = "insert into Notice (nTitle, nContents) values ('test', '내용')";
            bool status = db.NonQuery(sql);
            Console.WriteLine("데이터 삽입 : {0}", status);

            //데이터 건수 확인
            sql = "select count(*) as cnt from Notice";
            sdr = db.Reader(sql);
            while (sdr.Read())
            {
                Assert.AreEqual(cnt + 1, Convert.ToInt32(sdr["cnt"]));
            }
            sdr.Close();

            //입력한 데이터 PK 가져오기
            sql = "select max(nNo) as nNo from Notice";
            sdr = db.Reader(sql);
            int nNo = 0;
            while (sdr.Read())
            {
                nNo = Convert.ToInt32(sdr["nNo"]);
            }
            sdr.Close();
            Console.WriteLine("nNo = {0}", nNo);

            //수정 처리 부분
            sql = string.Format("update Notice set nTitle = '테스트', nContents = '테스트' where nNo = {0};", nNo);
            status = db.NonQuery(sql);
            Console.WriteLine("데이터 수정 결과 : {0}", status);

            //수정 확인
            Assert.AreEqual(true, status);

            //삭제 처리 부분
            sql = string.Format("update Notice set delYn = 'Y' where nNo = {0};", nNo);
            status = db.NonQuery(sql);
            Console.WriteLine("데이터 삭제 결과 : {0}", status);

            //삭제확인
            Assert.AreEqual(true, status);
        }
    }
}
