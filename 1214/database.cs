using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1214
{
    class database
    {
        private SqlConnection conn;
        private string no;
        private string name;
        private string age;
        private TextBox textBox1;
        private TextBox textBox2;

        public void MYsql()
        {
            conn = new SqlConnection();
            string server = "(localdb)\\ProjectsV13";
            string uid = "root";
            string password = "1234";
            string database = "Tes2";
            conn.ConnectionString = string.Format("server = {0}; uid = {1}; password = {2}; database = {3}", server, uid, password, database);
        }

        public void Read(ListView listView1)
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
        
        public void CUD(string proc, bool key1, bool key2)
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
