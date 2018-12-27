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
    class Commons
    {
        private SqlConnection conn;
        private Form1 form;

        public Commons(Form form)
        {
            this.form = (Form1) form;

            conn = new SqlConnection();
            string server = "(localdb)\\ProjectsV13";
            string uid = "root";
            string password = "1234";
            string database = "Tes2";
            conn.ConnectionString = string.Format("server = {0}; uid = {1}; password = {2}; database = {3}", server, uid, password, database);

            try
            {
                MessageBox.Show("연결 성공");
                conn.Open();
            }
            catch
            {
                MessageBox.Show("연결 실패");
            }
        }

        public void R()    //읽기
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                comm.CommandText = "sp_select";
                comm.Connection = conn;
                comm.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = comm.ExecuteReader();
                //string result = "";
                form.listView1.Items.Clear();    //items만 초기화
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
                    form.listView1.Items.Add(new ListViewItem(arr));
                }
                sdr.Close();
            }
            catch
            {
                MessageBox.Show("연결실패");
            }
        }


        public void CUD(string proc, bool key1, bool key2, string no)  //추가(name,age)/수정(no,name,age)/삭제(no)
        {
            try
            {
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
                    string name = form.textBox1.Text;
                    string age = form.textBox2.Text;

                    comm.Parameters.AddWithValue("@name", name);
                    comm.Parameters.AddWithValue("@age", age);
                }
                comm.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("연결 실패");
            }
        }
    }
}
