﻿using DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20181123
{
    public partial class MappingForm : Form
    {
        private MSsql db;
        
        public MappingForm(Object oDB)
        {
            InitializeComponent();
            this.db = (MSsql)oDB;
            Load += MappingForm_Load;     
        }

        private void MappingForm_Load(object sender, EventArgs e)
        {
            BackColor = Color.Black;
        }
    }
}
