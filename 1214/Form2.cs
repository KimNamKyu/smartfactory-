using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1214
{
    public partial class Form2 : Form
    {
        private string no;
        private database db;
        
        public Form2()
        {
            InitializeComponent();
            Load += Form2_Load;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            db = new database();
            db.MYsql();
            button1.Click += Read;
            button2.Click += Delete;
            button3.Click += Insert;
            button4.Click += update;
            listView1.MouseClick += lv1;
        }

        private void Read(object sender, EventArgs e)
        {
            db.Read(listView1);
        }

        private void Delete(object sender, EventArgs e)
        {
            db.CUD("sp_delete", true, false);
        }

        private void Insert(object sender, EventArgs e)
        {
            db.CUD("sp_Insert", false, true);
        }

        private void update(object sender, EventArgs e)
        {
            db.CUD("sp_update", true, true);
        }

        private void lv1(object sender, MouseEventArgs e)
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
    }
}
