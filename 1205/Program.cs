using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace _1205
{
    class Program
    {
         static void Main(string[] args)
        {
            WebClient client = new WebClient(); // 웹 접속 객체생성
            NameValueCollection data = new NameValueCollection();  //key / value 형식으로 받음 객체 생성
           
            //헤더에 담아서 추가.(웹 규약)
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            client.Encoding = Encoding.UTF8;    //한글처리

            string url = "http://192.168.0.2:5000/api/Insert"; //웹 호출 주소 정의 
            string method = "POST"; //웹 호출시 통신 방식 정의 (POST 방식(Form Date)은 Headers안에 데이터를 넣고 보내는 방식 ) Get(문자열 Query)
            
            data.Add("id", "1");    //파라미터 값 정의 (Key, Value) 형식
            data.Add("name", "테스트");
            data.Add("passwd", "1234");

            byte[] result = client.UploadValues(url, method, data); // 데이터 호출 후 Byte[] 값 받기
            string strResult = Encoding.UTF8.GetString(result); // 리턴 받은 Byte[] 값를 문자열로 형변환 하기
            //Console.WriteLine(strResult); // 문자열 데이터 확인하기.

            ArrayList jList = JsonConvert.DeserializeObject<ArrayList>(strResult); // JSON 데이터 변경   문자열 데이터를 ArrayList객체로 변환
            ArrayList list = new ArrayList(); // JSON 에서 LIST로 담을 객체 생성            
            foreach (JObject row in jList) // JSON 데이터에서 key : value 형식으로 분리하기
            {
                Hashtable ht = new Hashtable(); // Key : Value 형식으로 데이터 담을 객체 생성
                foreach (JProperty col in row.Properties()) // JSON 속성 가져오기
                {
                    Console.Write("{0} :\t{1}\t", col.Name, col.Value); // Key : Value 형식으로 출력하기
                    ht.Add(col.Name, col.Value); // Key : Value 형식으로 데이터 담기
                }
                Console.WriteLine(); // Console 출력 보기 좋게 줄변경하기
                list.Add(ht); // JSON 에서 LIST 로 데이터 담기
            }
            //Console.WriteLine("총 데이터 : {0}", list.Count); // JSON >> LIST 변경 후 데이터 확인하기
        }
    }
}
