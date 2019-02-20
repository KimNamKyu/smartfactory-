using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test;

namespace WindowsFormsApp
{
    public partial class Form2 : Form
    {
        private Form3 f3;

        public Form2()
        {
            InitializeComponent();
            Load += Form2_Load;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (FormLoad.GetLoad(this, "MDI"))
            {
                foreach (Control ctl in this.Controls)
                {
                    if (ctl.Name == "contents")
                    {
                        if (f3 != null) f3.Dispose();
                        f3 = new Form3();
                        f3.MdiParent = this;
                        //f3.BackColor = Color.Red;
                        ctl.Controls.Add(f3);
                        f3.Show();
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("오류");
            }
        }
    }
}
