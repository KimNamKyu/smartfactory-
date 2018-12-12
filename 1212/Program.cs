using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1212
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("저장 프로시저 활용");

            string host = "(localdb)\\ProjectsV13";
            string id = "root";
            string passwd = "1234";
            string database = "gdc";

            string queryString = string.Format("server = {0}; uid = {1}; password = {2}; database = {3}", host, id, passwd, database);
            SqlConnection conn = new SqlConnection(queryString);

            try
            {
                conn.Open();
                Console.WriteLine("오픈 성공");

                string spName = "sp_Notice";     //프로시저 Name
                SqlCommand comm = new SqlCommand(spName, conn);
                
                comm.CommandType = System.Data.CommandType.StoredProcedure; //스토어프로시저 타입으로 실행하도록 설정
                //파라미터 값 설정
                comm.Parameters.AddWithValue("@nTitle", "테스트");
                comm.Parameters.AddWithValue("@nContents", "내용");
                comm.Parameters.AddWithValue("@mName", "구디");

                /******************************************************************************************************************************/
                SqlParameter outparam = new SqlParameter();   //객체만들기
                outparam.ParameterName = "@mNo"; //파라미터 out 사용 가능
                outparam.SqlDbType = System.Data.SqlDbType.Int; //데이터 타입정의
                outparam.Direction = System.Data.ParameterDirection.Output; //input or output 정의 

                comm.Parameters.Add(outparam);

                /******************************************************************************************************************************/

                int status =  comm.ExecuteNonQuery(); //실행 NonQuery 는 int 값이 반환됨. 성공여부판단 가능 성공: 1 실패 : -1
                if (status > 0)
                {
                    Console.WriteLine("실행 성공 : 1");
                    Console.WriteLine("mNo : {0} ", outparam.Value); //proc 실행 후 전달 받은 @mNo 값 확인
                }
                else Console.WriteLine("실행 실패 : 1");

            }
            catch
            {
                //conn.Close();
                Console.WriteLine("오픈 실패");
            }
        }
    }
}
