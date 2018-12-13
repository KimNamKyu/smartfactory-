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
    public partial class Form2 : Form
    {
        private ListView lv;
        private string test;
        public Form2(ListView lv,string test)
        {
            InitializeComponent();
            Load += Form2_Load;

            this.test = test;
            this.lv = lv;
        }
        
        private void Form2_Load(object sender, EventArgs e)
        {
            Button btn = new Button();
            btn.Size = new Size(200, 200);
            btn.Location = new Point(0, 0);
            btn.BackColor = Color.Gainsboro;
            btn.Text = test;
            btn.Click += Btn_Click;
            Controls.Add(btn);


            Button btn1 = new Button();
            btn1.Size = new Size(200, 200);
            btn1.Location = new Point(0, 0);
            btn1.BackColor = Color.Gainsboro;
            btn1.Text = test;
            btn1.Click += Btn1_Click;
            Controls.Add(btn1);
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            //Insert

        }

        private void Btn_Click(object sender, EventArgs e)
        {
            //select 
            WebApi("http://192.168.3.10:5000/api/Select");
        }

        private void WebApi(string weburl)
        {
            WebClient client = new WebClient();
            //NameValueCollection data = new NameValueCollection();
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            client.Encoding = Encoding.UTF8;    //한글처리

            string url = weburl;
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
                lv.Items.Add(new ListViewItem(new string[] { ht["m_No"].ToString(), ht["m_Name"].ToString(), ht["m_Price"].ToString(), "1" }));
            }
        }
    }
}
