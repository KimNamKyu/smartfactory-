﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    class lbobject
    {
        //Form form;
        TabPage tabPage;
        string name, text;
        int sX, sY, pX, pY;

        public lbobject(TabPage tabPage, string name, string text, int sX, int sY, int pX, int pY)
        {
            // this.form = form;
            this.tabPage= tabPage;
            this.name = name;
            this.text = text;
            this.sX = sX;
            this.sY = sY;
            this.pX = pX;
            this.pY = pY;
        }
        //속성으로 하기위해
    /*public Form Form
        {
            get
            {
                return form;
            }
        }*/
   
        public TabPage TabPage
        {
            get
            {
                return tabPage;
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
