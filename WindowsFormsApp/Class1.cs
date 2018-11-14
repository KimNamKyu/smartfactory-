using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// 11월14일 수업내용
namespace WindowsFormsApp
{
    class Class1 
    {
        public void btn(btnobject bb)   
        {
            Button btn = new Button();
            btn.DialogResult = DialogResult.OK;
            btn.Name = bb.Name;
            btn.Text = bb.Text;
            btn.Size = new Size(bb.SX, bb.SY);  
            btn.Location = new Point(bb.PX, bb.PY); 
            btn.Cursor = Cursors.Hand;
            btn.Click += bb.eh;
            bb.Form.Controls.Add(btn);
        }

        public void lb(lbobject lb)
        {
            Label label = new Label();
            label.Name = lb.Name;
            label.Text = lb.Text;
            label.Size = new Size(lb.SX, lb.SY);
            label.Location = new Point(lb.PX, lb.PY);
            label.Cursor = Cursors.Hand;
            lb.Form.Controls.Add(label);
        }
    }
}
