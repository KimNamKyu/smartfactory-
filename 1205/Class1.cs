using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace _1205
{
    class Class1
    {
        public  void Main()
        {
            //JSON 읽어오기
            WebClient client = new WebClient(); // 웹 접속 객체생성
            
            //헤더에 담아서 추가.(웹 규약)
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            client.Encoding = Encoding.UTF8;    //한글처리

            string url = "http://192.168.0.2:5000/api/Select";

            Stream result = client.OpenRead(url);

            StreamReader sr = new StreamReader(result);
            string str = sr.ReadToEnd();    //json 데이터 읽어오기
            Console.WriteLine(str);
            Console.WriteLine("===================================================");

            string strJ = JsonConvert.SerializeObject(str); //출력한 내용그대로 문자열로 출력 가능
            Console.WriteLine(strJ);
            Console.WriteLine("===================================================");

            ArrayList strJs = JsonConvert.DeserializeObject<ArrayList>(str);    //데이터 타입 정의 해쥼
            Console.WriteLine(strJs.Count); //배열이므로 Count 할수 있다.
            Console.WriteLine("===================================================");
            for (int i = 0; i<strJs.Count; i++)
            {
                Console.WriteLine(strJs[i]);
                JObject jo = (JObject)strJs[i];
                //Console.WriteLine(jo.Property());   //Property 는 작성할때 쓰는걱 Value값을 넣어달라한다.
                //Console.WriteLine(jo.Properties()); //Properties 는 IEnumerable은 배열을 받으므로 이녀석을 가지고 반복문가능
            
                foreach (JProperty jp in jo.Properties())
                {
                    //Console.WriteLine("{0} : {1}",jp.Name, jp.Value);
                }
                Console.WriteLine("===================================================");
            }
        }
    }
}
