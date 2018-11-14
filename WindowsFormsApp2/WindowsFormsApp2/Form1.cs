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


namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            tabPage3 = new TabPage();

            tabControl1.Padding = new Point(22, 20);
            tabControl1.Controls.AddRange(new Control[] { tabPage1, tabPage2, tabPage3 });
            tabControl1.Size = new Size(700, 500);

            tabPage1.Text = "프로그램 삭제";
            tabPage2.Text = "개인정보 삭제";
            tabPage3.Text = "파일 강제삭제";

            ModuleClass mc = new ModuleClass();
            ArrayList arr = new ArrayList();
            ArrayList col_list = new ArrayList();
            ArrayList item_list = new ArrayList();
            arr.Add(new lbobject(tabPage1, "lb", "라벨1", 100, 50, (30 + 30 + 100), 300));
            arr.Add(new btnobject(tabPage1, "bb", "버튼1", 300, 50, 30, 300));


            //헤더 데이터 생성
            col_list.Add(new String[] { "", "25", "C" });
            col_list.Add(new String[] { "프로그램명", "180", "C" });
            col_list.Add(new String[] { "제작사", "200", "C" });
            col_list.Add(new String[] { "설치일", "200", "C" });

            //item 데이터 생성
            item_list.Add(new items(new string[] { "Chrom", "Google.inc", "2018.09.17","asdsa" }));
            item_list.Add(new items(new string[] { "HeidiSQL", "Ansgar Becker", "2018.10.05" }));
            item_list.Add(new items(new string[] { "FileZilla Client 3.37.0", "Tim kosse", "2018.10.23" }));
            


            //제어문 사용하여 type비교
            for (int i = 0; i < arr.Count; i++)
            {
                 if (typeof(btnobject) == arr[i].GetType())  //arr[i] 객체가 btn의 객체이면 (type을 비교)
                {
                    mc.btn((btnobject)arr[i]);
                }
                else if (typeof(lbobject) == arr[i].GetType()) //arr[i] 객체가 lb (type 비교)
                {
                    mc.lb((lbobject)arr[i]);
                }
            }
            ListView lv = lv_create(col_list, item_list);
            tabPage1.Controls.Add(lv);
            Controls.AddRange(new Control[] { tabControl1 });
        }


        private ListView lv_create(ArrayList col_list, ArrayList item_list)
        {
            ListView lv = new ListView();

            //리스트 뷰 속성 설정
            lv.GridLines = true;
            lv.CheckBoxes = true;
            lv.Location = new Point(40, 40);
            lv.Name = "listView1";
            lv.Size = new Size(700, 250);
            lv.TabIndex = 0;
            lv.View = View.Details;


            //헤더 설정
            bool h_check = ch_create(col_list, lv);

            // item 설정
            bool i_check = i_create(item_list, lv);

            return lv;
        }

        //헤더 설정
        private bool ch_create(ArrayList col_list, ListView lv)
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
        private bool i_create(ArrayList item_list, ListView lv)
        {
            for (int i = 0; i < item_list.Count; i++)
            {
                items row = (items)item_list[i];
                ListViewItem item = new ListViewItem(row.getCol); ;
                item.SubItems.Add(row.getCol2());
                item.SubItems.Add(row.getCol3());
                item.SubItems.Add(row.getCol4());
                lv.Items.Add(item);
            }
            return true;
        }
    }

}