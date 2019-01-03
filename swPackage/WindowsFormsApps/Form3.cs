using swPackage;
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

namespace WindowsFormsApps
{
    public partial class Form3 : Form
    {
        private ListView lv;
        private TextBox  Title, Content;
        private Database db;
        private string no;

        public Form3()
        {
            InitializeComponent();
            Load += Form3_Load;
        }

        private void Form3_Load(object sender, EventArgs e)
        {   
            if (FormLoad.GetLoad(this, "SDI"))
            {
                GetView();
                ListViewSelect();
            }
        }

        private void GetView()
        {
            lv = new ListView();
            lv.GridLines = true;
            lv.Size = new Size(780, 300);
            lv.Location = new Point(10, 60);
            lv.View = View.Details;
            lv.FullRowSelect = true;
            lv.Click += Lv_Click;
            lv.Columns.Add("번호", 50, HorizontalAlignment.Center);
            lv.Columns.Add("제목", 100, HorizontalAlignment.Center);
            lv.Columns.Add("내용", 150, HorizontalAlignment.Center);
            lv.Columns.Add("삭제여부", 75, HorizontalAlignment.Center);
            lv.Columns.Add("생성날짜", 200, HorizontalAlignment.Center);
            lv.Columns.Add("수정날짜", 200, HorizontalAlignment.Center);
            Controls.Add(lv);

            Title = new TextBox();
            Title.Size = new Size(150, 30);
            Title.Location = new Point(30, 370);
            Controls.Add(Title);

            Content = new TextBox();
            Content.Size = new Size(150, 30);
            Content.Location = new Point(30, 410);
            Controls.Add(Content);

            Button insert = new Button();
            insert.Size = new Size(200, 60);
            insert.Location = new Point(190, 370);
            insert.Text = "추가";
            insert.Name = "insert";
            insert.BackColor = Color.Gainsboro;
            insert.Click += btn_Click;
            Controls.Add(insert);

            Button update = new Button();
            update.Size = new Size(200, 60);
            update.Location = new Point(390, 370);
            update.Text = "수정";
            update.Name = "update";
            update.BackColor = Color.Gainsboro;
            update.Click += btn_Click;
            Controls.Add(update);

            Button delete = new Button();
            delete.Size = new Size(200, 60);
            delete.Location = new Point(590, 370);
            delete.Text = "삭제";
            delete.Name = "delete";
            delete.BackColor = Color.Gainsboro;
            delete.Click += btn_Click;
            Controls.Add(delete);
        }

        private void Lv_Click(object sender, EventArgs e)
        {
            ListView lv = (ListView)sender;
            ListView.SelectedListViewItemCollection slv = lv.SelectedItems;
            for (int i = 0; i < slv.Count; i++)
            {
                ListViewItem item = slv[i];
                no = item.SubItems[0].Text;
                Title.Text = item.SubItems[1].Text;
                Content.Text = item.SubItems[2].Text;
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            switch (btn.Name)
            {
                case "insert":
                    ListViewInsert();
                    ListViewSelect();
                    break;
                case "update":
                    ListViewUpdate();
                    ListViewSelect();
                    break;
                case "delete":
                    ListViewDelete();
                    ListViewSelect();
                    break;
                default:
                    break;
            }
        }

        private void ListViewSelect()
        {
            lv.Items.Clear();
            db = new Database(Test.RealDBInfo());
            Hashtable resultMap = db.GetReader("select * from [Notice];");
            
            if (Convert.ToInt32(resultMap["MsgCode"]) == -1)
            {
                MessageBox.Show(resultMap["Msg"].ToString());
            }
            else
            {
                ArrayList resultList = (ArrayList)resultMap["Data"];
                //string result = "";
                ArrayList list = new ArrayList();
                foreach (Hashtable row in resultList)
                {
                    //result += string.Format("rNo : {0}, rName : {1}, rDesc : {2}", row["rNo"], row["rName"], row["rDesc"]);

                    lv.Items.Add(new ListViewItem(new string[] { row["nNo"].ToString(), row["nTitle"].ToString(), row["nContent"].ToString(), row["delYn"].ToString(), row["regDate"].ToString(), row["modDate"].ToString() }));
                }
            }
        }

        private void ListViewInsert()
        {
            db = new Database(Test.RealDBInfo());
            string sql = string.Format("insert into Notice (nTitle,nContent) values ('{0}','{1}');", Title.Text,Content.Text);
            if (db.NonQuery(sql)) MessageBox.Show("추가성공");
            else MessageBox.Show("추가 실패");
        }

        private void ListViewUpdate()
        {
            db = new Database(Test.RealDBInfo());
            string sql = string.Format("update Notice set nTitle = '{0}', nContent = '{1}' where nNo = '{2}' and delYn = 'N';",Title.Text,Content.Text,no);
            if (db.NonQuery(sql)) MessageBox.Show("수정성공");
            else MessageBox.Show("수정 실패");
        }
        private void ListViewDelete()
        {
            db = new Database(Test.RealDBInfo());
            string sql = string.Format("update Notice set delYn = 'Y' where nNo = {0};",no);
            if (db.NonQuery(sql)) MessageBox.Show("삭제성공");
            else MessageBox.Show("삭제 실패");
        }
    }
}
