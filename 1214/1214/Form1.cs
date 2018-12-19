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

namespace _1214
{
    public partial class Form1 : Form
    {
        private Commons comm;
        private string no;

        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Click += btn1;
            button2.Click += btn2;
            button3.Click += btn3;
            button4.Click += btn4;
            listView1.MouseClick += lv1;
            listView1.FullRowSelect = true;

            comm = new Commons(this);
        }

        private void lv1(object sender, EventArgs e)
        {
            ListView lv = (ListView)sender;
            lv.FullRowSelect = true; //리스트 items 전체 클릭
            ListView.SelectedListViewItemCollection itemGroup = lv.SelectedItems;
            //ListViewItem item = itemGroup[0];

            for (int i = 0; i < itemGroup.Count; i++)
            {
                ListViewItem item = itemGroup[i];
                //MessageBox.Show(item.SubItems[0].Text);
                no = item.SubItems[0].Text;
                //MessageBox.Show(no);
                textBox1.Text = item.SubItems[1].Text;
                textBox2.Text = item.SubItems[2].Text;
            }
        }
        //select
        private void btn1(object o, EventArgs e)
        {
            comm.R();
        }
        //delete
        private void btn2(object sender, EventArgs e)
        {
            comm.CUD("sp_delete", true, false, no);
            comm.R();
        }
        //Insert
        private void btn3(object o, EventArgs e)
        {
            comm.CUD("sp_Insert", false, true, "0");
            comm.R();
        }
        //update
        private void btn4(object o, EventArgs e)
        {

            comm.CUD("sp_update", true, true, no);
            comm.R();
        }
    }
}
