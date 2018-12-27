using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace example
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
            select.Click += btn;
            insert.Click += btn;
            update.Click += btn;
            delete.Click += btn;
            listView1.Click += lvbtn;
            listView1.FullRowSelect = true;
        }
       
        private void lvbtn(object sender, EventArgs e)
        {
            ListView lv = (ListView)sender;
            ListView.SelectedListViewItemCollection itemGroup = lv.SelectedItems;
            ListViewItem item = itemGroup[0];
        }

        private void btn(object sender, EventArgs e)
        {
           
        }
    }
}
