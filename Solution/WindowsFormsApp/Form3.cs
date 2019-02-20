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
using Test;

namespace WindowsFormsApp
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            Load += Form3_Load;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            if (FormLoad.GetLoad(this, "SDI"))
            {
                try
                {
                    WebClient web = new WebClient();
                    ArrayList list = new ArrayList();
                    string url = "http://localhost:56300/api/Views";
                    Stream result = web.OpenRead(url);

                    StreamReader sr = new StreamReader(result);
                    string str = sr.ReadToEnd();

                    ArrayList strJs = JsonConvert.DeserializeObject<ArrayList>(str);
                    //MessageBox.Show(strJs.Count.ToString());
                    for (int i = 0; i < strJs.Count; i++)
                    {
                        JArray jo = (JArray)strJs[i];
                        string[] arr = new string[jo.Count];
                        for(int j=0; j<jo.Count; j++)
                        {
                            arr[j] = jo[j].ToString();
                        }
                        listView1.Items.Add(new ListViewItem(arr));
                        foreach (string[] row in list)
                        {
                            MessageBox.Show(row[0]);
                            listView1.Items.Add(new ListViewItem(new string[] { row[0], row[1], row[2] }));
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("오류");
                }
            }
        }
    }
}
