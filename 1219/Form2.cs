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

namespace _1219
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            Load += Form2_Load;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            button1.Click += btn;
            button2.Click += btn;
        }

        private void btn(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            ApiCommon(btn.Name);
        }

        private void ApiCommon(string type)
        {
            WebAPI api = new WebAPI();
            Hashtable ht = new Hashtable();
            switch (type)
            {
                case "button1":
                    ht.Add("nTitle", textBox1.Text);
                    ht.Add("nContent", textBox2.Text);
                    ht.Add("uName", textBox3.Text);
                    ht.Add("uPasswd", textBox4.Text);
                    api.Post("http://192.168.3.11:5000/insert", ht);
                    break;
                case "button2":
                    this.Dispose();
                    break;
            }
        }

    }
}
