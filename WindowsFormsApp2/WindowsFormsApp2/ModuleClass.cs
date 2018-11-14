using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    class ModuleClass
    {
        public void btn(btnobject bb)
        {
            Button btn = new Button();
            btn.Name = bb.Name;
            btn.Text = bb.Text;
            btn.Size = new Size(bb.SX, bb.SY);
            btn.Location = new Point(bb.PX, bb.PY);
            btn.Cursor = Cursors.Hand;
            bb.TabPage.Controls.Add(btn);
        }

        public void lb(lbobject lb)
        {
            Label label = new Label();
            label.Name = lb.Name;
            label.Text = lb.Text;
            label.Size = new Size(lb.SX, lb.SY);
            label.Location = new Point(lb.PX, lb.PY);
            label.Cursor = Cursors.Hand;
            lb.TabPage.Controls.Add(label);
        }
        
        public void lv(lvobject lv)
        {
            ListView listView1 = new ListView();
            listView1.View = View.Details;
            listView1.CheckBoxes = true;
            listView1.GridLines = true;
            listView1.Location = new Point(lv.PX, lv.PY);
            listView1.Size = new Size(lv.SX, lv.SY);
            ArrayList col_list = new ArrayList();
            ArrayList item_list = new ArrayList();

            //헤더 데이터 생성
            col_list.Add(new String[] { "", "25", "C" });
            col_list.Add(new String[] { "프로그램명", "180", "C" });
            col_list.Add(new String[] { "제작사", "100", "C" });
            col_list.Add(new String[] { "설치일", "100", "C" });

            //item 데이터 생성
            item_list.Add(new items(new string[] { "Chrom", "Google.inc", "2018.09.17", "asdsa" }));
            item_list.Add(new items(new string[] { "HeidiSQL", "Ansgar Becker", "2018.10.05" }));
            item_list.Add(new items(new string[] { "FileZilla Client 3.37.0", "Tim kosse", "2018.10.23" }));

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
                listView1.Columns.Add(columnHeader);
            }
            //item 설정
            for (int i = 0; i < item_list.Count; i++)
            {
                items row = (items)item_list[i];
                ListViewItem item = new ListViewItem(row.getCol); ;
                item.SubItems.Add(row.getCol2());
                item.SubItems.Add(row.getCol3());
                listView1.Items.Add(item);
            }
            lv.TabPage.Controls.Add(listView1);
         }
    }
}
