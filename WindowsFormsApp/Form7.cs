using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Form7 : Form
    {
        Timer timer;
        Panel pan1, pan2;
        public Form7()
        {
            InitializeComponent();
            Size = new Size(220, 200);
            // 테스트 2
            pan1 = new Panel();
            pan1.Height = 100;
            pan1.Width = 20;
            pan1.Location = new Point(100, 50);
            pan1.BackColor = Color.Silver;
            Controls.Add(pan1);

            pan2 = new Panel();
            pan2.Height = 100;
            pan2.Width = 20;
            pan2.Location = new Point(100, 50);
            pan2.BackColor = Color.Red;
            Controls.Add(pan2);

            timer = new Timer();
            timer.Interval = 20;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();

            if (pan1.Height > 100) pan1.Height = 1;
            else if (pan1.Height == 85) timer.Stop();
            else pan1.Height = pan1.Height + 1;

            timer.Start();
        }
    }
}

