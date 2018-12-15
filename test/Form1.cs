using MySql.Data.MySqlClient;
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

namespace test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetConnection();
            Select();
        }

        private MySqlConnection GetConnection()
        {
            string host = "192.168.0.8";
            string user = "root";
            string pwd = "1234";
            string db = "test";

            string connStr = string.Format(@"server={0};user={1};password={2};database={3}", host, user, pwd, db);
            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                conn.Open();
                MessageBox.Show("연결 성공");
            }
            catch (System.Exception)
            {
                conn.Close();
                MessageBox.Show("연결 실패");
            }
            return conn;
        }
        public void Select()
        {
            string sql = "select * from test;";
            MySqlCommand comm = new MySqlCommand(sql);
            MySqlDataReader reader = comm.ExecuteReader();
            ArrayList list = new ArrayList();
            while (reader.Read())
            {
                Hashtable ht = new Hashtable();
                for(int i = 0; i< reader.FieldCount; i++)
                {
                    ht.Add(reader.GetName(i), reader.GetValue(i));
                    MessageBox.Show(ht.ToString());
                }
                list.Add(ht);
            }
        }
    }
}

