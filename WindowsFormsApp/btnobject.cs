using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    class btnobject
    {
        Form form;
        string name, text;
        int sX, sY, pX, pY;
        
        public btnobject(Form form, string name, string text, int sX, int sY, int pX, int pY, EventHandler eh)
        {
            this.form = form;
            this.name = name;
            this.text = text;
            this.sX = sX;
            this.sY = sY;
            this.pX = pX;
            this.pY = pY;
            this.eh = eh; //이벤트 헨들러 받기
        }
        //속성으로 하기위해
        public EventHandler eh; //객체!  공유해서 사용
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
                return pY;
            }
        }
    }
}
