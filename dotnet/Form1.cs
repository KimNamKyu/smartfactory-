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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace dotnet
{
    public partial class Form1 : Form
    {
        private Hashtable hashtable;
        private Commons comm;
        private ListView list;


        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ClientSize = new Size(700, 700);
            comm = new Commons();
            GetView();
        }

        private void GetView()
        {
            hashtable = new Hashtable();
            hashtable.Add("type", "");
            hashtable.Add("size", new Size(700, 500));
            hashtable.Add("point", new Point(0, 0));
            hashtable.Add("color", Color.Yellow);
            hashtable.Add("name", "head");
            Panel panel = comm.getPanel(hashtable);
            Controls.Add(panel);

            hashtable = new Hashtable();
            hashtable.Add("type", "");
            hashtable.Add("size", new Size(700, 500));
            hashtable.Add("point", new Point(0, 500));
            hashtable.Add("color", Color.Yellow);
            hashtable.Add("name", "head");
            Panel panel2 = comm.getPanel(hashtable);
            Controls.Add(panel2);


            hashtable = new Hashtable();
            hashtable.Add("size", new Size(200, 100));
            hashtable.Add("point", new Point(0, 0));
            hashtable.Add("color", Color.Gainsboro);
            hashtable.Add("name", "btn1");
            hashtable.Add("text", "조회");
            hashtable.Add("click", (EventHandler)btn_click);
            Button btn = comm.getButton(hashtable);
            panel2.Controls.Add(btn);
            
            hashtable = new Hashtable();
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "리스트");
            list = comm.getListView(hashtable);
            panel.Controls.Add(list);

            list.Columns.Add("id", 100);
            list.Columns.Add("name", 100);
            list.Columns.Add("passwd", 100);


        }

        private void btn_click(object sender, EventArgs e)
        {
            WebClient client = new WebClient();

            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            client.Encoding = Encoding.UTF8;    //한글처리

            string url = "http://192.168.0.2:5000/api/Select";

            Stream result = client.OpenRead(url);
            StreamReader sr = new StreamReader(result);
            string str = sr.ReadToEnd();
            
            ArrayList strJ = JsonConvert.DeserializeObject<ArrayList>(str);
            ArrayList arrayList = new ArrayList();
            foreach (JObject row in strJ)
            {
                //Hashtable ht = new Hashtable();
                foreach (JProperty col in row.Properties())
                {
                    //MessageBox.Show(strJ.Count.ToString());
                    //ht.Add(col.Name, col.Value);
                    ListViewItem item = new ListViewItem();
                    for(int i = 0; i<col.Count; i++)
                    {
                        item.SubItems.Add(col[i].ToString());
                    }
                }
            }
                //MessageBox.Show(strJ.ToString());

            //for(int i = 0; i<STR.Count; i++)
            // {
            //     JObject jo = (JObject)STR[i];
            //     //Hashtable ht = new Hashtable();
            //     foreach(JProperty col in jo.Properties())
            //     {
            //        //ht.Add(col.Name, col.Value);
            //        MessageBox.Show(col.Name.ToString(), col.Value.ToString());
            //        item = new JObject();
            //        item.Add("id", col.Name);
            //        item.Add("name", col.Value);
            //     }
            //  }
        }
    }
 }
    
