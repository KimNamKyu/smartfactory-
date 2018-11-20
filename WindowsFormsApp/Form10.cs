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


namespace WindowsFormsApp
{
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
            Load += Form10_Load;
        }
        //MSSQL - root계정으로 접속하는 방법
        //MySQL과 Mariadb는 연결문자열의 차이만 존재
        private void Form10_Load(object sender, EventArgs e)
        {
            //계정으로 접속하는 방법
            string host = "(localdb)\\ProjectsV13";   //접속시 서버이름 DataSource
            string user = "root";   //userID
            string password = "1234";   //Password
            string db = "gdc"; //Catalog

            //접속시 사용할 전체의 정보    //@ : mysql 접속시 필요
            string connStr = string.Format("Data Source={0};Initial Catalog={3};Persist Security Info=False;User ID={1};" +
                "Password={2};Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=True"
                , host, user, password, db);
            SqlConnection conn = new SqlConnection(connStr);

            try
            {
                conn.Open();
                MessageBox.Show("MS-SQL 연결 성공");
            }
            catch
            {
                conn.Close();
                MessageBox.Show("MS-SQL 연결 실패");
            }
        }
    }
}
