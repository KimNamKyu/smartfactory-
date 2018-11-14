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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            Load += Form6_Load;
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            Location = new Point(0,80);
            Size = new Size(200, 200);
        }
        
    }
}
