using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Db;

namespace _20181121
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            Load += Main_Load;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            this.Size = new Size(500, 400);

            Panel headPanel = new Panel();
            headPanel.Size = new Size(500, 100);
            headPanel.Location = new Point(0, 0);
            headPanel.BackColor = Color.Silver;
            Controls.Add(headPanel);

            Panel contentsPanel = new Panel();
            contentsPanel.Size = new Size(500, 300);
            contentsPanel.Location = new Point(0, 100);
            contentsPanel.BackColor = Color.White;
            Controls.Add(contentsPanel);

            Button btn1 = new Button();
            btn1.Size = new Size(100, 60);
            btn1.Location = new Point(75, 20);
            btn1.BackColor = Color.White;
            btn1.Cursor = Cursors.Hand;
            btn1.Text = "MySQL";
            btn1.Name = "btn1";
            btn1.MouseHover += Btn_MouseHover;
            btn1.MouseLeave += Btn_MouseLeave;
            btn1.Click += Btn_Click;
            headPanel.Controls.Add(btn1);

            Button btn2 = new Button();
            btn2.Size = new Size(100, 60);
            btn2.Location = new Point((250 + 75), 20);
            btn2.BackColor = Color.White;
            btn2.Cursor = Cursors.Hand;
            btn2.Text = "MSSQL";
            btn2.Name = "btn2";
            btn2.MouseHover += Btn_MouseHover;
            btn2.MouseLeave += Btn_MouseLeave;
            btn2.Click += Btn_Click;
            headPanel.Controls.Add(btn2);
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            //MessageBox.Show(string.Format("Click {0}", btn.Name));
            switch (btn.Name)
            {
                case "btn1":
                    MYsql my = new MYsql();
                    my.Exec();
                    break;
                case "btn2":
                    MSsql ms = new MSsql();
                    ms.Exec();
                    break;
                default:
                    break;
            }
        }

        private void Btn_MouseHover(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.Yellow;
        }

        private void Btn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.White;
        }

    }
}
