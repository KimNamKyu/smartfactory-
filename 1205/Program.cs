using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace _1205
{
    class Program
    {
        static void Main(string[] args)
        {
            WebClient client = new WebClient(); //객체생성
            NameValueCollection data = new NameValueCollection();  //key / value 형식으로 받음
            //헤더에 담아서 추가.(웹 규약)
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            client.Encoding = Encoding.UTF8;    //한글

            string url = "http://192.168.3.10:5000/api/Insert";
            string method = "POST";
            
            data.Add("id", "1");
            data.Add("name", "테스트");
            data.Add("passwd", "1234");

            byte[] result = client.UploadValues(url,method,data);
            string strResult = Encoding.UTF8.GetString(result);
            //Console.WriteLine(strResult);
            //List<object> list = new List<object>();
            //list.Add();
            //Console.WriteLine(list);
              
            //string 을 ArrayList로 변환 해줘야함 > ArrayList list = (ArrayList)result; string을 ArrayList로 담는건 불가능!

            ArrayList list = new ArrayList(result);
            list.Add(strResult[0]);
            
            
        }
    }
}
