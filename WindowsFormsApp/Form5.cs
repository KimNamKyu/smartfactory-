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

//MDI 예제
namespace WindowsFormsApp
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            Load += Form5_Load;
        }
        Panel panel;
        private void Form5_Load(object o, EventArgs args)
        {
            IsMdiContainer = true;
            Size = new Size(1000, 800);

            panel = new Panel();
            panel.Location = new Point(0, 80);
            panel.Size = new Size(1000, 400);
            panel.BackColor = Color.Aqua;

            Class1 c1 = new Class1();
            c1.btn(new btnobject(this, "btn", "버튼1", 100, 50, 30, 30, btn_Click));
        }
        private void btn_Click(object o, EventArgs args)
        {
            Form6 f6 = new Form6();
            f6.MdiParent = this;    //mdiparent는 자기자신이다.
            f6.Show();
        }
    }
}
