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

namespace architect
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
        }

        private void Form1_Load(Object o, EventArgs args)
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add(new Item("button",0,0,"최적화"));
            arrayList.Add(new Item("button", 0, 100, "관리"));
            arrayList.Add(new Item("button", 0, 200, "삭제"));
            arrayList.Add(new Item("button", 0, 300, "PC상태"));

            for (int i = 0; i<arrayList.Count; i++)
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
                    Bitmap bmp = (Bitmap)PictureBox1.Image;
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
            foreach(Control ct in Controls)
            {
                if (ct.Name != "button") ct.BackColor = Color.Gray;
            }
            btn = (Button)o;
            btn.BackColor = (btn.BackColor == Color.Green ? btn.BackColor = Color.Silver : btn.BackColor = Color.SkyBlue);
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
    }
}
