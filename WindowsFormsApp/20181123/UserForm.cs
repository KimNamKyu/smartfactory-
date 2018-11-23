using DB;
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

namespace _20181123
{
    public partial class UserForm : Form
    {
        private MSsql db;
        ListView lv;
        Panel panel1, panel2;
        MSsql msSql;
        TextBox tb1, tb2, tb3, tb4, tb5, tb6,tb7;
        Button btn1, btn2, btn3, btn4;

        public UserForm(Object oDB) //메소드 사용하지않고 객체 받아오는 방법
        {
            InitializeComponent();
            this.db = (MSsql) oDB;
            Load += UserForm_Load;
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            panel1 = new Panel();
            panel1.Size = new Size(1000, 500);
            panel1.Location = new Point(0, 0);
            panel1.BackColor = Color.White;
            Controls.Add(panel1);

            panel2 = new Panel();
            panel2.Size = new Size(1000, 100);
            panel2.Location = new Point(0, 500);
            panel2.BackColor = Color.Gainsboro;
            Controls.Add(panel2);

            // 수정 부분
            tb1 = new TextBox();
            tb1.Width = 50;
            tb1.Location = new Point(0, 0);
            tb1.BackColor = Color.White;
            tb1.Enabled = false;
            panel2.Controls.Add(tb1);

            tb2 = new TextBox();
            tb2.Width = 150;
            tb2.Location = new Point(50, 0);
            tb2.BackColor = Color.White;
            panel2.Controls.Add(tb2);

            tb3 = new TextBox();
            tb3.Width = 100;
            tb3.Location = new Point(200, 0);
            tb3.BackColor = Color.White;
            panel2.Controls.Add(tb3);

            tb4 = new TextBox();
            tb4.Width = 100;
            tb4.Location = new Point(300, 0);
            tb4.BackColor = Color.White;
            panel2.Controls.Add(tb4);

            tb5 = new TextBox();
            tb5.Width = 200;
            tb5.Location = new Point(400, 0);
            tb5.BackColor = Color.White;
            tb5.Enabled = false;
            panel2.Controls.Add(tb5);

            tb6 = new TextBox();
            tb6.Width = 200;
            tb6.Location = new Point(600, 0);
            tb6.BackColor = Color.White;
            tb6.Enabled = false;
            panel2.Controls.Add(tb6);

            tb7 = new TextBox();
            tb7.Width = 200;
            tb7.Location = new Point(800, 0);
            tb7.BackColor = Color.White;
            tb7.Enabled = false;
            panel2.Controls.Add(tb7);

            btn1 = new Button();
            btn1.DialogResult = DialogResult.OK;
            btn1.Name = "추가";
            btn1.Text = "추가";
            btn1.Size = new Size(120, 40);
            btn1.Location = new Point(0, 21);
            btn1.BackColor = Color.Gainsboro;
            btn1.Click += Btn1_Click;
            panel2.Controls.Add(btn1);

            btn2 = new Button();
            btn2.DialogResult = DialogResult.OK;
            btn2.Name = "수정";
            btn2.Text = "수정";
            btn2.Size = new Size(120, 40);
            btn2.Location = new Point(120, 21);
            btn2.BackColor = Color.Gainsboro;
            btn2.Click += Btn2_Click;
            panel2.Controls.Add(btn2);

            btn3 = new Button();
            btn3.DialogResult = DialogResult.OK;
            btn3.Name = "삭제";
            btn3.Text = "삭제";
            btn3.Size = new Size(120, 40);
            btn3.Location = new Point(240, 21);
            btn3.BackColor = Color.Gainsboro;
            btn3.Click += Btn3_Click;
            panel2.Controls.Add(btn3);

            btn4 = new Button();
            btn4.DialogResult = DialogResult.OK;
            btn4.Name = "초기화";
            btn4.Text = "초기화";
            btn4.Size = new Size(120, 40);
            btn4.Location = new Point(360, 21);
            btn4.BackColor = Color.Gainsboro;
            btn4.Click += Btn4_Click;
            panel2.Controls.Add(btn4);


            lv = new ListView();
            lv.Dock = DockStyle.Fill;
            lv.View = View.Details;
            lv.GridLines = true;
            lv.MouseClick += Lv_MouseClick;
            panel1.Controls.Add(lv);

            create_list();
        }

        private void create_list()
        {
            tb1.Text = "";
            tb2.Text = "";
            tb3.Text = "";
            tb4.Text = "";
            tb5.Text = "";
            tb6.Text = "";
            tb7.Text = "";

            msSql = new MSsql();
            string sql = "select * from [Member];";
            SqlDataReader sdr = msSql.Reader(sql);

            lv.Clear();
            lv.Columns.Add("mNo", 50);
            lv.Columns.Add("mID", 150);
            lv.Columns.Add("mPass", 100);
            lv.Columns.Add("mName", 100);
            lv.Columns.Add("delYn", 200);
            lv.Columns.Add("regDate", 200);
            lv.Columns.Add("modDate", 200);

            while (sdr.Read())  //행 한줄씩 가져오기
            {
                string[] arr = new string[sdr.FieldCount];  //데이터타입이 항상 string 이라는 단점
                for (int i = 0; i < sdr.FieldCount; i++)    //열의 갯수만큼 반복
                {
                    arr[i] = sdr.GetValue(i).ToString();
                }
                lv.Items.Add(new ListViewItem(arr));
            }
            msSql.ReaderClose(sdr);
        }

        private void Lv_MouseClick(object sender, MouseEventArgs e)
        {
            ListView lv = (ListView)sender;
            ListView.SelectedListViewItemCollection itemGroup = lv.SelectedItems;
            ListViewItem item = itemGroup[0];

            string mNo = item.SubItems[0].Text;
            string mID = item.SubItems[1].Text;
            string mPass = item.SubItems[2].Text;
            string mName = item.SubItems[3].Text;
            string delYn = item.SubItems[4].Text;
            string regDate = item.SubItems[5].Text;
            string modDate = item.SubItems[6].Text;

            tb1.Text = mNo;
            tb2.Text = mID;
            tb3.Text = mPass;
            tb4.Text = mName;
            tb5.Text = delYn;
            tb6.Text = regDate;
            tb7.Text = modDate;
        }
        //추가
        private void Btn1_Click(object sender, EventArgs e)
        {
            string sql = string.Format("insert into [Member] (mID,mPass,mName) values ('{0}','{1}','{2}');", tb2.Text, tb3.Text, tb4.Text);

            if (msSql.NonQuery(sql))
            {
                MessageBox.Show("저장을 성공하였습니다.");
            }
            else
            {
                MessageBox.Show("저장 중 오류가 발생하였습니다.");
            }
            create_list();
        }
        //수정
        private void Btn2_Click(object sender, EventArgs e)
        {
            string sql = string.Format("update Member set mID = '{1}', mPass = '{2}', mName = '{3}', modDate = getDate()  where mNo = {0};", tb1.Text, tb2.Text,  tb3.Text, tb4.Text);
           
            if (msSql.NonQuery(sql))
            {
                MessageBox.Show("저장을 성공하였습니다.");
            }
            else
            {
                MessageBox.Show("저장 중 오류가 발생하였습니다.");
            }
            create_list();
        }
        //삭제
        private void Btn3_Click(object sender, EventArgs e)
        {
            string sql = string.Format("update Member set delYn = 'Y' where mNo = {0};", tb1.Text);
           
            if (msSql.NonQuery(sql))
            {
                MessageBox.Show("저장을 성공하였습니다.");
            }
            else
            {
                MessageBox.Show("저장 중 오류가 발생하였습니다.");
            }
            create_list();
        }

        private void Btn4_Click(object sender, EventArgs e)
        {
            create_list();
        }

       
    }
}
