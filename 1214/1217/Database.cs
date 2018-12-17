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

namespace _1214
{
    class Database
    {
        private SqlConnection conn;
        private bool status;

        /// <summary>
        /// Create DataBase 생성자
        /// </summary>
        public Database()
        {
            status = Connection();
        }

        /// <summary>
        /// MS SQL Connetion OPEN Method
        /// </summary>
        /// <returns></returns>
        private bool Connection()
        {
            try
            {
                conn = new SqlConnection();
                string server = "(localdb)\\ProjectsV13";
                string uid = "root";
                string password = "1234";
                string database = "Tes2";
                conn.ConnectionString = string.Format("server = {0}; uid = {1}; password = {2}; database = {3}", server, uid, password, database);
                conn.Open();
                //MessageBox.Show("연결 성공");
                return true;
            }
            catch 
            {
                return false;
            }
        }

        /// <summary>
        /// MS SQL Connetion CLOSE Method
        /// </summary>
        public void Close()
        {
            if(status == true) conn.Close();
        }

        /// <summary>
        /// MS SQL Reader Open Method
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public SqlDataReader Reader(string sql)
        {
            if(status)  //연결된 상태일 때만
            {
                try
                {
                    SqlCommand comm = new SqlCommand();
                    comm.CommandText = sql;
                    comm.Connection = conn;
                    comm.CommandType = CommandType.StoredProcedure;
                    return comm.ExecuteReader();
                }
                catch
                {
                    return null;   
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// MS SQL Reader Close Method
        /// </summary>
        /// <param name="sdr"></param>
        /// <returns></returns>
        public bool ReaderClose(SqlDataReader sdr)
        {
            try
            {
                sdr.Close();
                return true;
            }
            catch 
            {
                return false;
            }
        }

        /// <summary>
        /// MS SQL Insert, Update, Delete Method
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="ht"></param>
        /// <returns></returns>
        public bool NonQuery(string sql, Hashtable ht)    //NonQuery는 파라미터가 필요
        {
            if (status)  //연결된 상태일 때만
            {
                try
                {
                    SqlCommand comm = new SqlCommand();
                    comm.CommandText = sql;
                    comm.Connection = conn;
                    comm.CommandType = CommandType.StoredProcedure;
                    
                    //반복적이므로 for문사용
                    foreach (DictionaryEntry data in ht)
                    {
                        // Key : Value 형식 Hashtable or 멤버 객체
                        // 1) Hashtable 방식
                        // 키 와 값 형식으로 가져옴 ( DictionaryEntry )
                        comm.Parameters.AddWithValue(data.Key.ToString(), data.Value);
                    }
                  
                    comm.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        ///  ListView Commons Modules
        /// </summary>
        /// <param name="listView"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public bool ListView(ListView listView, string sql)
        {
            try
            {
                SqlDataReader sdr = Reader(sql);
                listView.Items.Clear();
                while (sdr.Read())
                {
                    string[] arr = new string[6];
                    for (int i = 0; i < sdr.FieldCount; i++)
                    {
                        arr[i] = sdr.GetValue(i).ToString();
                    }
                    listView.Items.Add(new ListViewItem(arr));
                }
                ReaderClose(sdr);
                return true;
            }
            catch 
            {
                return false;
            }
        }
      
    }
    
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
                    string[] arr = new string[list.Count];
                    for(int j = 0; j<ja.Count; j++) //순서대로 넘어온것을 확인
                    {
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
