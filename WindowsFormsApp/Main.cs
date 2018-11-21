using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Db;

namespace WindowsFormsApp
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            Load += Main_Load;
        }
        ListView lv;
        private void Main_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            this.Size = new Size(500, 400);

            Panel headPanel = new Panel();
            headPanel.Size = new Size(500, 100);
            headPanel.Location = new Point(0, 0);
            headPanel.BackColor = Color.Silver;
            Controls.Add(headPanel);

            Panel contentsPanel = new Panel();
            contentsPanel.Size = new Size(500, 300);
            contentsPanel.Location = new Point(0, 100);
            contentsPanel.BackColor = Color.White;
            Controls.Add(contentsPanel);

            Button btn1 = new Button();
            btn1.Size = new Size(100, 60);
            btn1.Location = new Point(75, 20);
            btn1.BackColor = Color.White;
            btn1.Cursor = Cursors.Hand;
            btn1.Text = "MySQL";
            btn1.Name = "btn1";
            btn1.MouseHover += Btn_MouseHover;
            btn1.MouseLeave += Btn_MouseLeave;
            btn1.Click += Btn_Click;
            headPanel.Controls.Add(btn1);

            Button btn2 = new Button();
            btn2.Size = new Size(100, 60);
            btn2.Location = new Point((250 + 75), 20);
            btn2.BackColor = Color.White;
            btn2.Cursor = Cursors.Hand;
            btn2.Text = "MSSQL";
            btn2.Name = "btn2";
            btn2.MouseHover += Btn_MouseHover;
            btn2.MouseLeave += Btn_MouseLeave;
            btn2.Click += Btn_Click;
            headPanel.Controls.Add(btn2);

            lv = new ListView();
            lv.Dock = DockStyle.Fill;
            lv.GridLines = true;
            lv.View = View.Details;

            //lv.BackColor = Color.Red;
            contentsPanel.Controls.Add(lv);
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            //MessageBox.Show(string.Format("Click {0}", btn.Name));
            switch (btn.Name)
            {
                case "btn1":
                    MYsql my = new MYsql();
                    my.Exec();
                    break;

                case "btn2":
                    MSsql ms = new MSsql();
                    //ms.Exec();  //생성자를 이용해서 접속하게 만듬

                    /*
                    ArrayList resultListy = ms.Select();    //메소드를 이용 

                    bool answer = true; //일회전
                    foreach (Hashtable row in resultListy)
                    {
                        IDictionaryEnumerator de = row.GetEnumerator();    //객체그대로 가져온다. reader.GetName ~
                        ListViewItem item = null;
                        
                        while (de.MoveNext()) //다음 요소로 이동
                        {
                            string col = de.Key.ToString(); //Hachtable에서 가져올때
                            string value = de.Value.ToString();

                            //헤더 생성
                            if (answer) lv.Columns.Add(col);

                            //그리드 데이터 생성
                            if (item == null) item = new ListViewItem(value);  
                            else item.SubItems.Add(value);
                        }
                        answer = false;
                        lv.Items.Add(item);
                    }*/

                    //Sql에있는 데이터베이스 그대로 가져오기
                    bool circle = true; //일회전
                    SqlDataReader Sdr = ms.Select("select name as tableName from gdc.sys.tables;");
                    while (Sdr.Read())
                    {
                        ListViewItem item = null;   //하나의 행에 대해 만들어짐.

                        for (int i  = 0; i<Sdr.FieldCount; i++)
                        {
                            //헤더 생성
                            if (circle) lv.Columns.Add(Sdr.GetName(i));

                            //그리드 데이터 생성
                            string value = Sdr.GetValue(i).ToString();
                            if (item == null) item = new ListViewItem(value);
                            else item.SubItems.Add(value);
                        }
                        circle = false;
                        lv.Items.Add(item);
                    }
                    break;
                default:
                    break;
            }
        }

        private void Btn_MouseHover(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.Yellow;
        }

        private void Btn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.White;
        }

    }
}
