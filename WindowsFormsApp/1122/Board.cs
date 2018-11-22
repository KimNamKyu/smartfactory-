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

namespace _20181122
{
    public partial class Board : Form
    {
        Panel panel1, panel2;
        ListView lv;
        SqlConnection conn;
        TextBox tb1;
        TextBox tb2;
        TextBox tb3;
        TextBox tb4;
        Button btn1, btn2, btn3, btn4;
        MSsql msSql;

        public Board()
        {
            InitializeComponent();
            Load += Board_Load;
        }

        public Board(SqlConnection conn)
        {
            // Main에서 받아 온 데이터베이스 연결 정보 전역 변수로 설정
            this.conn = conn;

            InitializeComponent();
            Load += Board_Load;
        }

        private void Board_Load(object sender, EventArgs e)
        {
            this.Size = new Size(500, 500);

            panel1 = new Panel();
            panel1.Size = new Size(500, 400);
            panel1.Location = new Point(0, 0);
            panel1.BackColor = Color.White;
            Controls.Add(panel1);

            panel2 = new Panel();
            panel2.Size = new Size(500, 100);
            panel2.Location = new Point(0, 400);
            panel2.BackColor = Color.Blue;
            Controls.Add(panel2);

            // 수정 부분
            tb1 = new TextBox();
            tb1.Width = 50;
            tb1.Location = new Point(0, 0);
            tb1.BackColor = Color.Red;
            tb1.Enabled = false;
            panel2.Controls.Add(tb1);

            tb2 = new TextBox();
            tb2.Width = 100;
            tb2.Location = new Point(50, 0);
            tb2.BackColor = Color.Green;
            panel2.Controls.Add(tb2);

            tb3 = new TextBox();
            tb3.Width = 250;
            tb3.Location = new Point(150, 0);
            tb3.BackColor = Color.Yellow;
            panel2.Controls.Add(tb3);

            tb4 = new TextBox();
            tb4.Width = 100;
            tb4.Location = new Point(400, 0);
            tb4.BackColor = Color.Orange;
            tb4.Enabled = false;
            panel2.Controls.Add(tb4);

            lv = new ListView();
            lv.Dock = DockStyle.Fill;
            lv.View = View.Details;
            lv.GridLines = true;
            lv.MouseClick += Lv_MouseClick;
            panel1.Controls.Add(lv);

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

            create_list();

            /*
            while (sdr.Read())
            {
                int boardNo = Convert.ToInt32(sdr["boardNo"].ToString());
                string boardTitle = sdr["boardTitle"].ToString();
                string boardContents = sdr["boardContents"].ToString();
                string delYn = sdr["delYn"].ToString();

                MessageBox.Show(boardNo + ", " + boardTitle + ", " + boardContents + ", " + delYn);
            }
            */
        }

        private void create_list()
        {
            tb1.Text = "";
            tb2.Text = "";
            tb3.Text = "";
            tb4.Text = "";

            //리스트가 다시 불러져 올때는 다시 활성화 시켜주어야 함
            //tb1.Enabled = true;
            //tb4.Enabled = true;

            // 데이터베이스 읽어 오기
            msSql = new MSsql();
            string sql = "select boardNo, boardTitle, boardContents, delYn from board;";
            SqlDataReader sdr = msSql.Select(conn, sql);    //전역변수 conn정보 사용, 쿼리

            lv.Clear();
            //column 헤더 고정값 지정
            lv.Columns.Add("번호", 50);
            lv.Columns.Add("제목", 100);
            lv.Columns.Add("내용", 250);
            lv.Columns.Add("삭제여부", 90);
            while (sdr.Read())  //행 한줄씩 가져오기
            {
                string[] arr = new string[sdr.FieldCount];  //데이터타입이 항상 string 이라는 단점
                for (int i = 0; i < sdr.FieldCount; i++)    //열의 갯수만큼 반복
                {
                    arr[i] = sdr.GetValue(i).ToString();
                }
                lv.Items.Add(new ListViewItem(arr));
            }
            msSql.SelectClose(sdr);
        }

        private void Lv_MouseClick(object sender, MouseEventArgs e)
        {
            ListView lv = (ListView)sender;
            ListView.SelectedListViewItemCollection itemGroup = lv.SelectedItems;
            ListViewItem item = itemGroup[0];
            //MessageBox.Show(item.SubItems[0].Text);

            string boardNo = item.SubItems[0].Text;
            string boardTitle = item.SubItems[1].Text;
            string boardContents = item.SubItems[2].Text;
            string delYn = item.SubItems[3].Text;

            tb1.Text = boardNo;
            tb2.Text = boardTitle;
            tb3.Text = boardContents;
            tb4.Text = delYn;

            //수정하면 안되므로 비활성화(키값이으로)
            //tb1.Enabled = false;    mssql 에서 설정
            //tb4.Enabled = false;
        }

        private void Btn1_Click(object sender, EventArgs e) //추가
        {
            /*
            if (tb1.Text == "" || tb2.Text == "" || tb3.Text == "")
            {
                MessageBox.Show("번호 입력 요망");
                return;
            }
            */
            string sql = string.Format("insert into board (boardTitle, boardContents) values('{0}','{1}');", tb2.Text, tb3.Text);
            //MessageBox.Show(sql);
            bool check = msSql.Insert(conn, sql);

            if (check)
            {
                MessageBox.Show("저장을 성공하였습니다.");
            }
            else
            {
                MessageBox.Show("저장 중 오류가 발생하였습니다.");
            }
            create_list();
        }

        private void Btn2_Click(object sender, EventArgs e) //수정
        {
            if (tb1.Text == "" || tb2.Text == "" || tb3.Text == "")
            {
                MessageBox.Show("번호,제목,내용 입력 확인");
                return;
            }
            string sql = string.Format("update board set boardTitle = '{1}', boardContents = '{2}' where boardNo = {0};", tb1.Text, tb2.Text, tb3.Text);
            bool check = msSql.Insert(conn, sql);

            if (check)
            {
                MessageBox.Show("수정이 성공하였습니다.");
            }
            else
            {
                MessageBox.Show("수정 중 오류가 발생하였습니다.");
            }
            create_list();
        }

        private void Btn3_Click(object sender, EventArgs e) //삭제
        {
            string sql = string.Format("update board set delYn = 'Y' where boardNo = {0};", tb1.Text);
            bool check = msSql.Insert(conn, sql);

            if (check)
            {
                MessageBox.Show("삭제가 성공하였습니다.");
            }
            else
            {
                MessageBox.Show("삭제 중 오류가 발생하였습니다.");
            }
            create_list();
        }
        private void Btn4_Click(object sender, EventArgs e) //초기화
        {
            create_list();
        }
    }
}
