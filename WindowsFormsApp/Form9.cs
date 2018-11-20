using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient; //client 프로그램 사용

//11월 20일 수업 데이터베이스 연동
namespace WindowsFormsApp
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
            Load += Form9_Load;
        }
        MySqlConnection conn;
        //관리측면에서 메소드로 관리
        private void Form9_Load(object sender, EventArgs e)
        {
            //DB에 접속하기   
            string host = "myDB";
            string user = "root";
            string password = "1234";
            string db = "gdc";

            //접속시 사용할 전체의 정보    //@ : mysql 접속시 필요
            string connStr = string.Format(@"server={0};user={1};password={2};database={3}", host, user, password, db);
            conn = new MySqlConnection(connStr);    //데이터베이스 접속정보 생성
            button1.Click += btn_Event;
        }

        private void btn_Event(object s, EventArgs args)
        {
            try
            {
                conn.Open();    //데이터베이스 연결
                string sql = textBox1.Text; //텍스트받스에서 쿼리 입력
                MySqlCommand comm = new MySqlCommand(sql, conn);
                MySqlDataReader reader = comm.ExecuteReader();  //reader에 결과받기(데이터 읽어오기)

                ArrayList arr = new ArrayList();    //열을 담을 그릇
                //select 했을때 갯수 만큼 read //데이터를 읽는다 끝날때 까지
                while (reader.Read())
                {
                    //Hashtable을 사용하면 컬럼 타입을 알 필요가없다 reader에 칼럼수를 알면 반복문을 돌려서 가져올수 있음
                    //키와 값 형식으로 받기위함 
                    Hashtable ht = new Hashtable(); // item(행)을 담는다.
                    // 요소를 컬렉션에 담는다.
                    ht.Add("no", reader[0]);
                    ht.Add("name", reader[1]);
                    //배열에 담는다.
                    arr.Add(ht); 
                    /*
                    ListViewItem item = new ListViewItem(reader.GetInt32(0).ToString());
                    item.SubItems.Add(reader.GetString(1));
                    listView1.Items.Add(item);
                    */
                }   
                foreach(Hashtable row in arr)
                {
                    ListViewItem item = new ListViewItem(row["name"].ToString());  //키값을 넣으면 value가나옴.
                    item.SubItems.Add(row["no"].ToString()); 
                    listView1.Items.Add(item);
                }
            }
            catch
            {
                conn.Close();
                MessageBox.Show("Mysql 연결 실패");
            }
        }
    }
}
