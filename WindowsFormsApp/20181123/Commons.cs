using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20181123
{
    class Commons
    {
        public Panel getPanel(Hashtable hashtable)
        {
            Panel panel = new Panel();
            panel.Size = (Size) hashtable["size"];
            panel.Location = (Point) hashtable["point"];
            panel.BackColor = (Color)hashtable["color"];
            panel.Name = hashtable["name"].ToString(); //name으로 찾기.
            return panel;
        }
        
        public Button getButton(Hashtable hashtable)
        {
            Button btn = new Button();
            btn.Size = (Size)hashtable["size"];
            btn.Location = (Point)hashtable["point"];
            btn.BackColor = (Color)hashtable["color"];
            btn.Name = hashtable["name"].ToString();
            btn.Text = hashtable["text"].ToString();
            btn.Click += (EventHandler)hashtable["click"];
            return btn;
        }
    }
}
