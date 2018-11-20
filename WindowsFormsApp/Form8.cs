using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Form8 : Form
    {
        public Form8()
        {

            InitializeComponent();
            Load += Form8_Load;
        }

        Panel panel;

        private void Form8_Load(object sender, EventArgs e)
        {
            this.ShowIcon = false;
            this.Text = "";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ForeColor = Color.Red;
            this.Font = new Font(this.Font, FontStyle.Bold);

            this.IsMdiContainer = true;
            this.Size = new Size(1000, 800);

            // 영역 설정
            panel = new Panel();
            panel.Width = 900;
            panel.Location = new Point(100, 0);
            panel.Dock = DockStyle.Right;
            Controls.Add(panel);

            Class1 c1 = new Class1();
            c1.btn(new btnobject(this, "btn1", "Black", 83, 50, 0, 0, btn_Click));
            c1.btn(new btnobject(this, "btn2", "Red", 83, 50, 0, 60, btn_Click));
            c1.btn(new btnobject(this, "btn3", "Blue", 83, 50, 0, 120, btn_Click));
        }

        Form form = null;

        private void btn_Click(Object o, EventArgs e)
        {

            if (form != null)
            {
                form.Close();
                form = null;
            }

            Button btn = (Button)o;

            form = new Form();
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.FormBorderStyle = FormBorderStyle.None;
            switch (btn.Text)
            {
                case "Black":
                    form.BackColor = Color.Black;
                    break;
                case "Red":
                    form.BackColor = Color.Red;
                    break;
                case "Blue":
                    form.BackColor = Color.Blue;
                    break;
                default:
                    form.BackColor = Color.Yellow;
                    break;
            }
            panel.Controls.Add(form);
            form.Show();
        }

        private void btn2_Click(Object o, EventArgs e)
        {
            foreach (Control ctr in Controls)
            {
                if (ctr.Name == "btn3")
                {
                    MessageBox.Show(ctr.Text);
                    ctr.Dispose();
                }
            }
        }
    }
}
