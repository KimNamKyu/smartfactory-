using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
        }
        private ListView lv;
        private string test;
        public Button btn;

        public Form1(Button btn)
        {
            this.btn = btn;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            test = "버튼이름 변경";
            IsMdiContainer = true;
            ClientSize = new Size(700, 500);
            lv = new ListView();
            lv.View = View.Details;
            lv.GridLines = true;
            lv.FullRowSelect = true;
            lv.Size = new Size(500, 500);
            lv.Location = new Point(0, 0);
            lv.Columns.Add("No", 40, HorizontalAlignment.Center);
            lv.Columns.Add("메뉴명", 160, HorizontalAlignment.Center);
            lv.Columns.Add("단가", 100, HorizontalAlignment.Center);
            lv.Columns.Add("수량", 100, HorizontalAlignment.Center);
            lv.Columns.Add("금액", 100, HorizontalAlignment.Center);
            Controls.Add(lv);

            Panel panel = new Panel();
            panel.Size = new Size(200, 500);
            panel.Location = new Point(500, 0);
            panel.BackColor = Color.Beige;
            Controls.Add(panel);

            btn = new Button();
            btn.Size = new Size(200, 200);
            btn.Location = new Point(0, 0);
            btn.BackColor = Color.Gainsboro;
            btn.Text = "버튼 클릭";
            btn.Click += Btn_Click;
            panel.Controls.Add(btn);

            Form2 f2 = new Form2(lv,test);
            f2.MdiParent = this;
            f2.WindowState = FormWindowState.Maximized;
            f2.FormBorderStyle = FormBorderStyle.None;
            panel.Controls.Add(f2);
            f2.Show();

            
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        /*
private void Btn_Click(object sender, EventArgs e)
{
   WebClient client = new WebClient();
   //NameValueCollection data = new NameValueCollection();
   client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
   client.Encoding = Encoding.UTF8;    //한글처리

   string url = "http://192.168.3.10:5000/api/Select";
   Stream result = client.OpenRead(url);

   StreamReader sr = new StreamReader(result);
   string str = sr.ReadToEnd();

   ArrayList jList = JsonConvert.DeserializeObject<ArrayList>(str);
   ArrayList list = new ArrayList();
   foreach (JObject row in jList)
   {
       Hashtable ht = new Hashtable();
       foreach (JProperty col in row.Properties())
       {
           ht.Add(col.Name, col.Value);
       }
       list.Add(ht);
   }

   foreach (Hashtable ht in list)
   {
       //    f1.lv.Items.Add(new ListViewItem(new string[] { ht["nNo"].ToString(), ht["nTitle"].ToString(), ht["nContents"].ToString(), ht["mName"].ToString(), ht["regDate"].ToString(), ht["modDate"].ToString() }));
       //MessageBox.Show( ht["m_Name"].ToString());
       lv.Items.Add(new ListViewItem(new string[] { ht["m_No"].ToString(), ht["m_Name"].ToString(), ht["m_Price"].ToString(), "1" }));
   }
}*/
    }
}
