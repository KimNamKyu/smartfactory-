using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Windows.Forms;
using Test;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WebClient web = new WebClient();
            ArrayList list = new ArrayList();
            string url = "http://localhost:56300/api/Views";
            Stream result = web.OpenRead(url);

            StreamReader sr = new StreamReader(result);
            string str = sr.ReadToEnd();

            ArrayList strJs = JsonConvert.DeserializeObject<ArrayList>(str);
            for(int i = 0; i< strJs.Count; i++)
            {
                JObject jo = (JObject)strJs[i];
                Hashtable ht = new Hashtable();

                foreach (var jp in jo.Properties())
                {
                    ht.Add(jp.Name, jp.Value);
                }
                list.Add(ht);
            }
            
        }
    }
}
