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

//수업내용 ListView 메소드화 하기
namespace WindowsFormsApp
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            Load += Form3_Load;
        }
        private void Form3_Load(object o, EventArgs args)
        {
            //가상데이터 생성 > 나중에 DB에서 가져오면 됨.
            ArrayList col_list = new ArrayList();
            ArrayList item_list = new ArrayList();

            //헤더 데이터 생성
            col_list.Add(new String[] { "Colum1","100" ,"L"});
            col_list.Add(new String[] { "Colum2" ,"120","C"});
            col_list.Add(new String[] { "Colum3" ,"140","R"});
            //item 데이터 생성
            item_list.Add(new Items(new string[] { "item1", "1", "2" }));
            item_list.Add(new Items(new string[] { "item2", "4", "5" }));
            item_list.Add(new Items(new string[] { "item3", "7", "8" }));
            item_list.Add(new Items(new string[] { "item4", "9", "10" }));

            ListView lv =  lv_create(col_list, item_list);
            Controls.Add(lv);
        }
    
        private ListView lv_create(ArrayList col_list,ArrayList item_list)
        {
            ListView lv = new ListView();
            
            //리스트 뷰 속성 설정
            lv.GridLines = true;
            lv.Location = new Point(12, 243);
            lv.Name = "listView1";
            lv.Size = new Size(776, 195);
            lv.TabIndex = 0;
            lv.UseCompatibleStateImageBehavior = false;
            lv.View = View.Details;


            //헤더 설정
            bool h_check = ch_create(col_list, lv);

            // item 설정
            bool i_check = i_create(item_list, lv);

            return lv;
        }
        //헤더 설정
        private bool ch_create(ArrayList col_list,ListView lv)
        {
            //헤더 설정
            for (int i = 0; i < col_list.Count; i++)
            {
                string[] arr = (string[])col_list[i];
                ColumnHeader columnHeader = new ColumnHeader();
                columnHeader.Text = arr[0]; //배열 0번지에 넣는다.
                columnHeader.Width = Convert.ToInt32(arr[1]);   //형변환 안할꺼면 객체를 만들면 됨.

                switch (arr[2])
                {
                    case "L":
                        columnHeader.TextAlign = HorizontalAlignment.Left;
                        break;
                    case "C":
                        columnHeader.TextAlign = HorizontalAlignment.Center;
                        break;
                    case "R":
                        columnHeader.TextAlign = HorizontalAlignment.Right;
                        break;
                }
                lv.Columns.Add(columnHeader);
            }
            return true;
        }
        // item 설정
        private bool i_create(ArrayList item_list,ListView lv)
        {
            for (int i = 0; i < item_list.Count; i++)
            {
                Items row = (Items)item_list[i];
                ListViewItem item = new ListViewItem(row.getCol); ;
                item.SubItems.Add(row.getCol2());
                item.SubItems.Add(row.getCol3());
                lv.Items.Add(item);
            }
            return true;
        }
    }
}
