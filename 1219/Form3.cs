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
    public partial class Form3 : Form
    {
        private Panel pn1;
        private Panel pn2;
        private string nNo;

        public Form3()
        {
            InitializeComponent();
            Load += Form3_Load;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Load1_panel();
            Load2_panel();


        }
        private void Load1_panel()
        {
            pn1 = new Panel();
            pn1.Size = new Size(572, 100);
            pn1.Location = new Point(0, 350);
            pn1.BackColor = Color.Gainsboro;
            Controls.Add(pn1);

            Button btn1 = new Button();
            btn1.Size = new Size(70, 50);
            btn1.Location = new Point(300, 20);
            btn1.Name = "btn1";
            btn1.Click += Btn_Click;
            btn1.BackColor = Color.White;
            btn1.Text = "목록";
            pn1.Controls.Add(btn1);

            Button btn2 = new Button();
            btn2.Size = new Size(70, 50);
            btn2.Location = new Point(390, 20);
            btn2.Click += Btn_Click;
            btn2.BackColor = Color.White;
            btn2.Name = "btn2";
            btn2.Text = "수정";
            pn1.Controls.Add(btn2);

            Button btn3 = new Button();
            btn3.Size = new Size(70, 50);
            btn3.Location = new Point(480, 20);
            btn3.Click += Btn_Click;
            btn3.BackColor = Color.White;
            btn3.Name = "btn3";
            btn3.Text = "삭제 ";
            pn1.Controls.Add(btn3);
            
        }

        private void Load2_panel()
        {
            pn2 = new Panel();
            pn2.Size = new Size(572, 100);
            pn2.Location = new Point(0, 350);
            pn2.BackColor = Color.Gainsboro;
            Controls.Add(pn2);

            Button btn4 = new Button();
            btn4.Size = new Size(70, 50);
            btn4.Location = new Point(390, 40);
            btn4.Click += Btn_Click;
            btn4.BackColor = Color.White;
            btn4.Name = "btn4";
            btn4.Text = "확인";
            pn2.Controls.Add(btn4);

            Button btn5 = new Button();
            btn5.Size = new Size(70, 50);
            btn5.Location = new Point(480, 40);
            btn5.Click += Btn_Click;
            btn5.BackColor = Color.White;
            btn5.Name = "btn5";
            btn5.Text = "삭제";
            pn2.Controls.Add(btn5);

            Label label = new Label();
            label.Text = "비밀번호";
            label.Location = new Point(20, 25);
            pn2.Controls.Add(label);

            TextBox tb = new TextBox();
            tb.Size = new Size(300, 100);
            tb.Location = new Point(20, 50);
            pn2.Controls.Add(tb);
            
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            WebAPI api = new WebAPI();
            Button btn = (Button)sender;
            Hashtable ht = new Hashtable();
            switch (btn.Name)
            {
                case "btn1":
                    this.Dispose();
                    break;
                case "btn2":
                    pn1.Visible = false;
                    pn2.Visible = true;
                    break;
                case "btn3":
                    pn1.Visible = false;
                    pn2.Visible = true;
                    break;
                case "btn4":
                    pn2.Visible = false;

                    pn1.Visible = true;
                    break;
                case "btn5":
                    pn2.Visible = false;
                    ht.Add("nNo",nNo);
                    api.Post("http://192.168.3.11:5000/delete", ht);
                    pn1.Visible = true;
                    break;
                default:
                    break;
            }
        }

    }
}
