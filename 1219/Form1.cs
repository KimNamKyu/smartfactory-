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
    public partial class Form1 : Form
    {
        WebAPI api = new WebAPI();
        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Click += btn;
            select.Click += btn;
            listView1.MouseClick += lv1;
            api.SelectListView("http://192.168.3.11:5000/select", listView1);
        }

        private void lv1(object sender, MouseEventArgs e)
        {
            ListView lv = (ListView)sender;
            ListView.SelectedListViewItemCollection slv = lv.SelectedItems;
            for (int i = 0; i < slv.Count; i++)
            {
                ListViewItem item = slv[i];
                
            }
            Form3 form3 = new Form3();
            form3.ShowDialog();
            
        }

        private void btn(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            ApiCommon(btn.Name);
        }
        private void ApiCommon(string type)
        {
            Hashtable ht = new Hashtable();
            switch (type)
            {
                case "select":
                    MessageBox.Show("버튼1");
                    Form2 form2 = new Form2();
                    form2.ShowDialog();
                    break;
                case "button1":
                    MessageBox.Show("버튼2");
                    api.SelectListView("http://192.168.3.11:5000/select", listView1);
                    break;
            }
        }
    }
}
