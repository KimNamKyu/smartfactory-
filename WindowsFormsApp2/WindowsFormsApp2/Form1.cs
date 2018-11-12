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
        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
            CrateMyPanel();
        }
        private void Form1_Load(Object o, EventArgs args)
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add(new Item("button", 0, 0, "최적화"));
            arrayList.Add(new Item("button", 0, 100, "관리"));
            arrayList.Add(new Item("button", 0, 200, "삭제"));
            arrayList.Add(new Item("button", 0, 300, "PC상태"));

            for (int i = 0; i < arrayList.Count; i++)
            {
                Control_create((Item)arrayList[i]);
            }
        }
        private void Control_create(Item item)
        {
            Control ctr = new Control();

            switch (item.getType())
            {
                case "button":
                    Button btn = new Button();
                    btn.DialogResult = DialogResult.OK;
                    btn.Cursor = Cursors.Hand;
                    btn.Click += btn_Click;
                    ctr = btn;
                    break;
                default:
                    break;
            }
            ctr.Name = item.getTxt();
            ctr.Text = item.getTxt();
            ctr.Size = new Size(150, 100);
            ctr.Location = new Point(item.getX(), item.getY());

            Controls.Add(ctr);
        }


        Button btn = new Button();
        private void btn_Click(object o, EventArgs args)
        {
            foreach (Control ct in Controls)
            {
                if (ct.Name != "button") ct.BackColor = Color.Gainsboro;
            }
            btn = (Button)o;
            btn.BackColor = (btn.BackColor == Color.SkyBlue ? btn.BackColor = Color.Gainsboro : btn.BackColor = Color.SkyBlue);
            
        }
        public class Item
        {
            private string type;
            private int X, Y;
            private string txt;

            public Item(string type, int X, int Y, string txt)
            {
                this.txt = txt;
                this.type = type;
                this.X = X;
                this.Y = Y;
            }

            public string getType()
            {
                return type;
            }
            public string getTxt()
            {
                return txt;
            }
            public int getX()
            {
                return X;
            }
            public int getY()
            {
                return Y;
            }

        }

        private Bitmap MyImage;
        public void ShowMyImage(string fileToDisplay, int xSize, int ySize)
        {
            PictureBox pictureBox1 = new PictureBox();
            if (MyImage != null)
            {
                MyImage.Dispose();
            }
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            MyImage = new Bitmap(fileToDisplay);
            pictureBox1.ClientSize = new Size(xSize, ySize);

            pictureBox1.Image = (Image)MyImage;
        }

        private void CrateMyPanel()
        {
            Panel p1 = new Panel();
            p1.Location = new Point(150, 0);
            p1.Size = new Size(700, 500);
            p1.BorderStyle = BorderStyle.None;
            p1.BackColor = Color.Yellow;

            ListView listView1 = new ListView();
            listView1.View = View.Details;
            listView1.CheckBoxes = true;
            listView1.GridLines = true;
            listView1.Location = new Point(160, 80);
            listView1.Size = new Size(600, 250);
            
            listView1.Columns.Add("");
            listView1.Columns.Add("프로그램명", 120);
            listView1.Columns.Add("제작사", 180);
            listView1.Columns.Add("설치일", 100);

            ListViewItem item1 = new ListViewItem(" ", 0);
            item1.SubItems.Add("Chrom");
            item1.SubItems.Add("Google.inc");
            item1.SubItems.Add("2018.09.17");

            ListViewItem item2 = new ListViewItem(" ", 0);
            item2.SubItems.Add("HeidiSQL");
            item2.SubItems.Add("Ansgar Becker");
            item2.SubItems.Add("2018.10.05");

            ListViewItem item3 = new ListViewItem(" ", 0);
            item3.SubItems.Add("FileZilla Client 3.37.0");
            item3.SubItems.Add("Tim kosse");
            item3.SubItems.Add("2018.10.23");

           
            listView1.Items.AddRange(new ListViewItem[] { item1, item2, item3 });
            Controls.Add(listView1);
            Controls.Add(p1);
        }
    }
}