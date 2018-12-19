using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1219
{
    /// <summary>
    ///  WebAPI 클래스 생성
    /// </summary>
    class WebAPI
    {
        /// <summary>
        /// Select API 작성
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public bool SelectListView(string url,ListView listView)
        {
            try
            {
                WebClient wc = new WebClient();
                Stream stream = wc.OpenRead(url);
                //출력
                StreamReader sr = new StreamReader(stream);
                string result = sr.ReadToEnd(); //string 배열 값으로 들어옴!  값을 그대로 사용할수 X
                ArrayList list = JsonConvert.DeserializeObject<ArrayList>(result);  // Json 형식으로 바뀜
                listView.Items.Clear();
                // 하나의 String 배열이 넘어옴
                for(int i = 0; i < list.Count; i++)
                {
                    JArray ja = (JArray)list[i]; // Json을 ArrayList 에 담았기 때문에 데이터 타입을 맞춰줘야함.
                    string[] arr = new string[ja.Count];
                    for(int j = 0; j<ja.Count; j++) //순서대로 넘어온것을 확인
                    {
                        //MessageBox.Show(list.Count.ToString());
                        //MessageBox.Show(ja[j].ToString());
                        arr[j] = ja[j].ToString();
                    }
                    listView.Items.Add(new ListViewItem(arr));
                }
                 return true;
            }
            catch 
            {
                return false;
            }
        }

        /// <summary>
        ///  NonQuery는 2가지의 파라미터가 존재
        /// </summary>
        /// <returns></returns>
        public bool Post(string url, Hashtable ht)
        {
            MessageBox.Show(url);
            try
            {
                WebClient wc = new WebClient();
                NameValueCollection param = new NameValueCollection();  // Key : Value 형식
                
                foreach(DictionaryEntry data in ht)
                {
                    MessageBox.Show(string.Format("{0},{1}", data.Key.ToString(), data.Value.ToString()));
                    param.Add(data.Key.ToString(), data.Value.ToString());
                }

                //byte로 반환
                byte[] result = wc.UploadValues(url, "POST", param);
                string resultStr = Encoding.UTF8.GetString(result);
                MessageBox.Show(resultStr);
                if ("1" == resultStr)
                {
                    MessageBox.Show("성공");
                }
                else
                {
                    MessageBox.Show("실패");
                }

                return true;
            }
            catch 
            {
                return false;
            }
        }
    }
}
