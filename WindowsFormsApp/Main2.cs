using Db;
using MySql.Data.MySqlClient;
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
    public partial class Main2 : Form
    {
        public Main2()
        {
            InitializeComponent();
            Load += Main2_Load;
        }
        ListView lv1;
        ListView lv2;
        bool 분류;
        private void Main2_Load(object sender, EventArgs e)
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

            lv1 = new ListView();
            lv1.Size = new Size(100,300);
            lv1.Location = new Point(0, 0);
            lv1.GridLines = true;
            lv1.View = View.Details;
            //lv1.BackColor = Color.Green;
            lv1.MouseClick += Lv1_MouseClick;
            contentsPanel.Controls.Add(lv1);

            lv2 = new ListView();
            lv2.Size = new Size(400, 300);
            lv2.Location = new Point(100, 0);
            lv2.GridLines = true;
            lv2.View = View.Details;
            //lv2.BackColor = Color.Red;
            contentsPanel.Controls.Add(lv2);
        }

        private void Lv1_MouseClick(object sender, MouseEventArgs e)
        {
            ListView lv = (ListView)sender;
            ListView.SelectedListViewItemCollection itemGroup = lv.SelectedItems;
            ListViewItem item = itemGroup[0];
            //MessageBox.Show(item.SubItems[0].Text);
            switch (분류)
            {
                case true:
                    string sql2 = string.Format("select * from {0}", item.SubItems[0].Text);
                    MYsql my = new MYsql();
                    MySqlDataReader Sdrr = my.Select(sql2);
                    lv2.Clear();
                    bool circle2 = true; //일회전
                    while (Sdrr.Read())
                    {
                        ListViewItem row = null;   //하나의 행에 대해 만들어짐.

                        for (int i = 0; i < Sdrr.FieldCount; i++)
                        {
                            //헤더 생성
                            if (circle2) lv2.Columns.Add(Sdrr.GetName(i));

                            //그리드 데이터 생성
                            string value = Sdrr.GetValue(i).ToString();
                            if (row == null) row = new ListViewItem(value);
                            else row.SubItems.Add(value);
                        }
                        circle2 = false;
                        lv2.Items.Add(row);
                    }
                    break;
                case false:
                    string sql = string.Format("select * from {0}", item.SubItems[0].Text);
                    MSsql ms = new MSsql();
                    SqlDataReader Sdr = ms.Select(sql);
                    lv2.Clear();
                    bool circle = true; //일회전
                    while (Sdr.Read())
                    {
                        ListViewItem row = null;   //하나의 행에 대해 만들어짐.

                        for (int i = 0; i < Sdr.FieldCount; i++)
                        {
                            //헤더 생성
                            if (circle) lv2.Columns.Add(Sdr.GetName(i));

                            //그리드 데이터 생성
                            string value = Sdr.GetValue(i).ToString();
                            if (row == null) row = new ListViewItem(value);
                            else row.SubItems.Add(value);
                        }
                        circle = false;
                        lv2.Items.Add(row);
                    }
                    break;
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            switch (btn.Name)
            {
                case "btn1":
                    분류 = true;
                    lv1.Clear();
                    MYsql my = new MYsql();
                    //my.Exec();
                    MySqlDataReader Sdrr = my.Select("show tables;");
                    bool circle1 = true;
                    while (Sdrr.Read())
                    {
                        ListViewItem item = null;

                        for(int i = 0; i <Sdrr.FieldCount; i++)
                        {
                            if (circle1) lv1.Columns.Add(Sdrr.GetName(i));

                            string value = Sdrr.GetValue(i).ToString();
                            if (item == null) item = new ListViewItem(value);
                            else item.SubItems.Add(value);
                        }
                        circle1 = false;
                        lv1.Items.Add(item);
                    }
                    break;
                case "btn2":
                    분류 = false;
                    lv1.Clear();
                    MSsql ms = new MSsql();
                    SqlDataReader Sdr = ms.Select("select name as tableName from gdc.sys.tables;");
                    bool circle = true; //일회전
                    while (Sdr.Read())
                    {
                        ListViewItem item = null;   //하나의 행에 대해 만들어짐.

                        for (int i = 0; i < Sdr.FieldCount; i++)
                        {
                            //헤더 생성
                            if (circle) lv1.Columns.Add(Sdr.GetName(i));

                            //그리드 데이터 생성
                            string value = Sdr.GetValue(i).ToString();
                            if (item == null) item = new ListViewItem(value);
                            else item.SubItems.Add(value);
                        }
                        circle = false;
                        lv1.Items.Add(item);
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
