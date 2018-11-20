using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace interface1119
{
    class BtnSet
    {
        Form form;
        string name, text;
        int sX, sY, pX, pY;
        EventHandler eh;
        public BtnSet(Form form, string name, string text, int sX, int sY, int pX, int pY,EventHandler eh)
        {
            this.form = form;
            this.name = name;
            this.text = text;
            this.sX = sX;
            this.sY = sY;
            this.pX = pY;
            this.pY = pY;
            this.eh = eh;
        }
        public EventHandler Eh
        {
            get
            {
                return eh;
            }
        }
        public Form Form
        {
            get
            {
                return form;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
        }
        public string Text
        {
            get
            {
                return text;
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
                return PY;
            }
        }
    }
}
