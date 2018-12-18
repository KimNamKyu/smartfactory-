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

namespace _1214
{
    public partial class Form2 : Form
    {
        Database db;
        private string no;
        public Form2()
        {
            InitializeComponent();
            Load += Form2_Load;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Select.Click += button;
            Delete.Click += button;
            Insert.Click += button;
            Update.Click += button;
            listView1.MouseClick += lv1;
            listView1.FullRowSelect = true;

            db = new Database();
        }

        private void lv1(object sender, EventArgs e)
        {
            //MessageBox.Show("리스트뷰 클릭");
            ListView lv = (ListView)sender;
            ListView.SelectedListViewItemCollection slv = lv.SelectedItems;
            for(int i = 0; i<slv.Count; i++)
            {
                ListViewItem item = slv[i];
                no = item.SubItems[0].Text;
                textBox1.Text = item.SubItems[1].Text;
                textBox2.Text = item.SubItems[2].Text;
            }
        }
        // + select
        //private void Select(object o, EventArgs e)
        //{
        //    //MessageBox.Show("select");
        //    Common(1);
        //    /*
        //    Hashtable ht = new Hashtable();
        //    ht.Add("no", 1);
        //    foreach(DictionaryEntry key in ht)  //Hashtable DictionaryEntry 사용 : 키/값 
        //    {
        //        MessageBox.Show(key.Key.ToString());
        //    }
        //    */
        //}
        ////delete
        //private void Delete(object sender, EventArgs e)
        //{
        //    //MessageBox.Show("Delete");
        //    Common(4);
           
        //}
        ////Insert
        //private void Insert(object o, EventArgs e)
        //{
        //    //MessageBox.Show("Insert");
        //    Common(2);
            
        //}
        ////update
        //private void Update(object o, EventArgs e)
        //{
        //    //MessageBox.Show("Update");
        //    Common(3);
        //}

        /// <summary>
        /// 버튼 하나로 바꿈
        /// </summary>
        private void ApiCommon(string type)
        {
            WebAPI api = new WebAPI();
            Hashtable ht = new Hashtable();
            switch (type)
            {
                case "Select":
                    api.SelectListView("http://localhost:5000/select", listView1);
                    break;
                case "Insert":
                    ht.Add("name",textBox1.Text);
                    ht.Add("age",textBox2.Text);
                    api.Post("http://localhost:5000/insert",ht);
                    ApiCommon("Select");
                    break;
                case "Update":
                    ht.Add("no", no);
                    ht.Add("name", textBox1.Text);
                    ht.Add("age", textBox2.Text);
                    api.Post("http://localhost:5000/update", ht);
                    ApiCommon("Select");
                    break;
                case "Delete":
                    ht.Add("no", no);
                    api.Post("http://localhost:5000/delete", ht);
                    ApiCommon("Select");
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        ///  화면 관리 Common
        /// </summary>
        private void Common(string type)
        {
            Hashtable ht = new Hashtable();
            switch (type)
            {
                case "Select": //Select
                    if (!db.ListView(listView1, "sp_select"))
                    {
                        MessageBox.Show("데이터 가져오는 중 오류가 발생하였습니다.");
                    }
                    break;

                case "Insert": //Insert
                    ht.Add("@name", textBox1.Text);
                    ht.Add("@age", textBox2.Text);

                    if (db.NonQuery("sp_Insert", ht))
                    {
                        MessageBox.Show("추가가 정상");
                        if (!db.ListView(listView1, "sp_select"))
                        {
                            MessageBox.Show("데이터 추가 중 오류가 발생하였습니다.");
                            Common("Select");
                        }
                    }
                    else
                    {
                        MessageBox.Show("입력 오류!!!");
                    }
                    break;
                
                    //update
                case "Update":
                    ht.Add("@name", textBox1.Text);
                    ht.Add("@age", textBox2.Text);
                    ht.Add("@no", no);

                    if (db.NonQuery("sp_update", ht))
                    {
                        MessageBox.Show("수정이 정상");
                        if (!db.ListView(listView1, "sp_select"))
                        {
                            MessageBox.Show("데이터 수정 중 오류가 발생하였습니다.");
                            Common("Select");
                        }
                    }
                    else
                    {
                        MessageBox.Show("입력 오류!!!");
                    }
                    break;

                //Delete
                case "Delete":
                    ht.Add("@no", no);

                    if (db.NonQuery("sp_delete", ht))
                    {
                        MessageBox.Show("삭제가 정상");
                        if (!db.ListView(listView1, "sp_select"))
                        {
                            MessageBox.Show("데이터 삭제 중 오류가 발생하였습니다.");
                            Common("Select");
                        }
                    }
                    else
                    {
                        MessageBox.Show("입력 오류!!!");
                    }
                    break;
                default:
                    break;
            }
        }

        private void button(object o, EventArgs e)
        {
            Button btn = (Button)o;
            ApiCommon(btn.Name);
            //Common(btn.Name);
        }

    }
}
