using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    class lvobject  //ListView 객체화
    {
        TabPage tabPage;
        int sX, sY, pX, pY;

        public lvobject(TabPage tabPage, int sX, int sY, int pX, int pY)
        {
            this.tabPage = tabPage;

            this.sX = sX;
            this.sY = sY;
            this.pX = pX;
            this.pY = pY;
        }
        public TabPage TabPage
        {
            get
            {
                return tabPage;
            }
        }

        public int SX
        {
            get
            {
                return sX;
            }
        }
        public int SY
        {
            get
            {
                return sY;
            }
        }
        public int PX
        {
            get
            {
                return pX;
            }
        }
        public int PY
        {
            get
            {
                return pY;
            }
        }
    }
}
