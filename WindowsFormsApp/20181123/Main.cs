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
using DB;

namespace _20181123
{
    public partial class Main : Form
    {
        private MSsql db;
        private Commons comm;       //공통 = 컨트롤

        public Main()
        {
            InitializeComponent();
            Load += Form_Load;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            //생성자로 생성
            db = new MSsql();
            comm = new Commons();

            this.IsMdiContainer = true;
            this.Size = new Size(1000, 800);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Text = "회원정보";



            Hashtable hashtable = new Hashtable();
            hashtable.Add("size", new Size(1000, 100));
            hashtable.Add("point", new Point(0, 0));
            hashtable.Add("color", Color.Silver);
            hashtable.Add("name", "head");
            Panel panel1 = comm.getPanel(hashtable);
            Controls.Add(panel1);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(1000, 700));
            hashtable.Add("point", new Point(0, 100));
            hashtable.Add("color", Color.Yellow);
            hashtable.Add("name", "contents");
            Controls.Add(comm.getPanel(hashtable));

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(200, 90));
            hashtable.Add("point", new Point(100, 0));
            hashtable.Add("color", Color.Gainsboro);
            hashtable.Add("name", "button1");
            hashtable.Add("text", "사용자form");
            hashtable.Add("click", (EventHandler)Btn_Click);
            Button button1 = comm.getButton(hashtable);
            panel1.Controls.Add(button1);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(200, 90));
            hashtable.Add("point", new Point(300, 0));
            hashtable.Add("color", Color.Gainsboro);
            hashtable.Add("name", "button2");
            hashtable.Add("text", "ruelform ");
            hashtable.Add("click", (EventHandler)Btn1_Click);
            Button button2 = comm.getButton(hashtable);
            panel1.Controls.Add(button2);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(200, 90));
            hashtable.Add("point", new Point(500, 0));
            hashtable.Add("color", Color.Gainsboro);
            hashtable.Add("name", "button3");
            hashtable.Add("text", "Mapping ");
            hashtable.Add("click", (EventHandler)Btn3_Click);
            Button button3 = comm.getButton(hashtable);
            panel1.Controls.Add(button3);


            //버튼 이벤트 활성화

            //uf.Show();
            //패널에다가 넣기 위해 Name이 필요
            /*
            foreach (Control ctr in Controls)
            {
                if(ctr.Name == "contents")
                {
                    ctr.Controls.Add(uf);
                    uf.Show();
                }
            }
            */
        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            MappingForm mf = new MappingForm(db);
            mf.MdiParent = this;
            mf.WindowState = FormWindowState.Maximized;
            mf.FormBorderStyle = FormBorderStyle.None;

            foreach (Control ctr in Controls)
            {
                if (ctr.Name == "contents")
                {
                    ctr.Controls.Add(mf);
                    mf.Show();
                }
            }
        }

        //RuleForm
        private void Btn_Click(object sender, EventArgs e)
        {
            UserForm uf = new UserForm(db);
            uf.MdiParent = this;
            uf.WindowState = FormWindowState.Maximized;
            uf.FormBorderStyle = FormBorderStyle.None;

            foreach (Control ctr in Controls)
            {
                if (ctr.Name == "contents")
                {
                    ctr.Controls.Add(uf);
                    uf.Show();
                }
            }
        }
        //UserForm
        private void Btn1_Click(object sender, EventArgs e)
         {
            RuleForm rf = new RuleForm(db);
            rf.MdiParent = this;
            rf.WindowState = FormWindowState.Maximized;
            rf.FormBorderStyle = FormBorderStyle.None;

            foreach (Control ctr in Controls)
            {
                if (ctr.Name == "contents")
                {
                    ctr.Controls.Add(rf);
                    rf.Show();
                }
            }
        }
    }
}
