using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1214
{
    public partial class Form1 : Form
    {
        private SqlConnection conn;
        private string no;
        private string name;
        private string age;

        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
            button1.Click += btn1;
            button2.Click += btn2;
            button3.Click += btn3;
            button4.Click += btn4;
            listView1.MouseClick += lv1;
            listView1.FullRowSelect = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection();
            string server = "(localdb)\\ProjectsV13";
            string uid = "root";
            string password = "1234";
            string database = "Tes2";
            conn.ConnectionString = string.Format("server = {0}; uid = {1}; password = {2}; database = {3}", server, uid, password, database);
        }

        private void lv1(object sender, EventArgs e)
        {
            ListView lv = (ListView)sender;
            lv.FullRowSelect = true; //리스트 items 전체 클릭
            ListView.SelectedListViewItemCollection itemGroup = lv.SelectedItems;
            //ListViewItem item = itemGroup[0];
            
            for(int i = 0; i<itemGroup.Count; i++)
            {
                ListViewItem item = itemGroup[i];
                //MessageBox.Show(item.SubItems[0].Text);
                no = item.SubItems[0].Text;
                //MessageBox.Show(no);
                textBox1.Text = item.SubItems[1].Text;
                textBox2.Text = item.SubItems[2].Text;
            }
        }
        //select
        private void btn1(object o, EventArgs e)
        {
            R();
        }
        //delete
        private void btn2(object sender, EventArgs e)
        {
            CUD("sp_delete", true, false);
            R();
        }
        //Insert
        private void btn3(object o, EventArgs e)
        {
             CUD("sp_Insert", false,true);
             R();
        }
        //update
        private void btn4(object o, EventArgs e)
        {
            
            CUD("sp_update", true,true);
            R();
        }

        private void R()    //읽기
        {
            try
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.CommandText = "sp_select";
                comm.Connection = conn;
                comm.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = comm.ExecuteReader();
                //string result = "";
                listView1.Items.Clear();    //items만 초기화
                while (sdr.Read())
                {
                    //컬럼 꺼내오기
                    //행부분
                    string[] arr = new string[sdr.FieldCount];
                    for (int i = 0; i < sdr.FieldCount; i++)
                    {
                        //result += string.Format("{0} : {1}\t",sdr.GetName(i),sdr.GetValue(i));
                        arr[i] = sdr.GetValue(i).ToString();
                    }
                    //result += "\n";
                    listView1.Items.Add(new ListViewItem(arr));
                }
                sdr.Close();
                conn.Close();
            }
            catch
            {
                MessageBox.Show("연결실패");
            }
        }
        private void CUD(string proc, bool key1, bool key2)  //추가(name,age)/수정(no,name,age)/삭제(no)
        {
            name = textBox1.Text;
            age = textBox2.Text;
            try
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.CommandText = proc;
                comm.Connection = conn;
                comm.CommandType = CommandType.StoredProcedure;

                //파라미터 키 : 값 으로 보내기
                if (key1)
                {
                    comm.Parameters.AddWithValue("@no", no);
                }
                if (key2)
                {
                    comm.Parameters.AddWithValue("@name", name);
                    comm.Parameters.AddWithValue("@age", age);
                }
                comm.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                MessageBox.Show("연결 실패");
            }
        }
    }
}
