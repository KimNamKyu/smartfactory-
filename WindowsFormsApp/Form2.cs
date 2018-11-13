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

//2018.11.13 수업 내용
namespace WindowsFormsApp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            Load += Form2_Load;
        }
        private void Form2_Load(object o, EventArgs args)
        {
            
            ListView listView1 = new ListView();
            
            ColumnHeader columnHeader1 = new ColumnHeader();
            ColumnHeader columnHeader2 = new ColumnHeader();
            ColumnHeader columnHeader3 = new ColumnHeader();
            //범위를 지정해서 화면 출력
            //listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1,  columnHeader2, columnHeader3});
            listView1.Columns.Add(columnHeader1);
            listView1.Columns.Add(columnHeader3);
            listView1.Columns.Add(columnHeader2);

            
            columnHeader1.Text = "col1";
            columnHeader1.Width = 200;
            columnHeader1.TextAlign = HorizontalAlignment.Center;
            columnHeader2.Text = "col2";
            columnHeader3.Text = "col3";

            listView1.GridLines = true;
            listView1.Location = new Point(12, 243);
            listView1.Name = "listView1";
            listView1.Size = new Size(776, 195);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            /*

            ListViewItem item1 = new ListViewItem("hello");
            item1.SubItems.Add("Hello");
            item1.SubItems.Add("구리");

            listView1.Items.AddRange(new ListViewItem[] { item1 });
            */
            Controls.Add(listView1);
            
            //가상데이터 생성
            ArrayList arry = new ArrayList();
            arry.Add(new Items(new string[] { "item1", "1", "2" }));
            arry.Add(new Items(new string[] { "item2", "4", "5" }));
            arry.Add(new Items(new string[] { "item3", "7", "8" }));

            // ListView 데이터 넣기 
            ListViewItem item;
            for (int i = 0; i < arry.Count; i++)
            {
                Items row = (Items)arry[i];
                item = new ListViewItem(row.getCol); ;
                item.SubItems.Add(row.getCol2());
                item.SubItems.Add(row.getCol3());
                listView1.Items.Add(item);
            }

            string txts = "";
            foreach (ColumnHeader ch in listView1.Columns)
            {
                txts += ch.Text + "";
            }
            MessageBox.Show(txts);

        }

    }
    // Class생성 가상데이터 불러오기.
    public class Items
    {
        string col1;
        string col2, col3;
        public Items(string[] a)
        {
            col1 = a[0];
            col2 = a[1];
            col3 = a[2];
        }
        public string getCol
        {
            get
            {
                return col1;
            }
        }
        /*
        public string getCol1()
        {
            return col1;
        }
        */
        public string getCol2()
        {
            return col2;
        }
        public string getCol3()
        {
            return col3;
        }
    }
}
