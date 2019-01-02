using swPackage;
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

namespace WindowsFormsApps
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DBInfo dbi = new DBInfo();
            Database db = new Database(dbi.GetDB());
            Hashtable resultMap = db.GetReader("select * from [Notice]");

            if (Convert.ToInt32(resultMap["MsgCode"]) == -1)
            {
                MessageBox.Show(resultMap["Msg"].ToString());
            }
            else
            {
                ArrayList resultList = (ArrayList)resultMap["Data"];
                string result = "";
                foreach (Hashtable row in resultList)
                {
                    result += string.Format("nNo : {0}, uName : {1}", row["nNo"], row["uName"]);
                }
                MessageBox.Show(result);
            }
        }
    }
}
