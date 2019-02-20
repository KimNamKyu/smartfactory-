using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
        }

        /// <summary>
        /// 폼 로드 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            #region + 코드 설명
            /* + 코드 리뷰
            try
            {
                // 리스트뷰에 사용할 데이터 요청 주소
            string url = "http://192.168.3.10:5000/api/Views";
            // WebAPI 연결 하기 위하여 사용 될 객체 생성
            WebClient webClient = new WebClient();
            // 요청 주소를 이용하여 응답 정보 받기
            Stream stream = webClient.OpenRead(url);
            // 응답 받은 데이터를 읽어 오기
            StreamReader streamReader = new StreamReader(stream);
            // 응답 데이터를 문자열로 형변환 하기
            string stringResponse = streamReader.ReadToEnd();
            // 문자열로 되어 있는 데이터를 사용하기 편하게 데이터 객체로 만들기
            ArrayList jsonList = JsonConvert.DeserializeObject<ArrayList>(stringResponse);
            // 응답 받은 데이터를 사용하기 위하여 반복문 실행 하기
            foreach (JArray rowData in jsonList)
            {
                // 리스트뷰에 표현하기 위하여 문자열 배열 선언하기
                string[] stringArray = new string[rowData.Count];
                // 배열에 들어 있는 데이터를 사용하기 위하여 반복문 실행 하기
                for (int i = 0; i < rowData.Count; i++)
                {
                    // 위에서 선언한 문자열 배열에 순차적으로 데이터 넣기
                    stringArray[i] = rowData[i].ToString();
                }
                // 문자열 배열를 하나씩 리스트뷰에 추가 하기
                listView1.Items.Add(new ListViewItem(stringArray));
            }
            */
            #endregion

            using (WebClient webClient = new WebClient())
            {
                string url = "http://gdc3.gudi.kr:41001/api/Views";
                using (StreamReader StrReder = new StreamReader(webClient.OpenRead(url)))
                {
                    ArrayList JList = JsonConvert.DeserializeObject<ArrayList>(StrReder.ReadToEnd());
                    foreach (JArray row in JList)
                    {
                        listView1.Items.Add(new ListViewItem(row.ToObject<string[]>()));
                    }
                }
            }
        }
    }
}
