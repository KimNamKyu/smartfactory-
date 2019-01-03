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
            Database db = new Database(Test.RealDBInfo());
            Hashtable resultMap = db.GetReader("select rNo, rName, rDesc from [Rule];");

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
                    result += string.Format("rNo : {0}, rName : {1}, rDesc : {2}", row["rNo"], row["rName"], row["rDesc"]);
                }
                MessageBox.Show(result);
            }
        }
    }
}
