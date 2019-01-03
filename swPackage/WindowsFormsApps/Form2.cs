using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using swPackage;
namespace WindowsFormsApps
{
    public partial class Form2 : Form
    {
        private Form3 f3;

        public Form2()
        {
            InitializeComponent();
            //FormLoad fl = new FormLoad(this);
            //Load += fl.GetHandler("MDI");
            Load += Form2_Load;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (FormLoad.GetLoad(this, "MDI"))
            {
                foreach (Control ctl in this.Controls)
                {
                    if(ctl.Name == "Content")
                    {
                        if (f3 != null) f3.Dispose();
                        f3 = new Form3();
                        f3.MdiParent = this;
                        f3.BackColor = Color.Gray;
                        ctl.Controls.Add(f3);
                        f3.Show();
                        break;
                    }
                }
            }
            else
            {

            }
        }
    }
}
