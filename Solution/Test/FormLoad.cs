using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Test
{
    public static class FormLoad
    {
        private static bool hm;
        private static int mx, my;

        public static bool GetLoad(Form targetForm, string viewType)
        {
            switch (viewType)
            {
                case "MDI":
                    targetForm.IsMdiContainer = true;
                    targetForm.FormBorderStyle = FormBorderStyle.None;

                    Panel header = new Panel();
                    Panel contents = new Panel();
                    Label close = new Label();
                    
                    header.Size = new Size(targetForm.Width, 50);
                    header.Location = new Point(0, 0);
                    header.Dock = DockStyle.Top;
                    header.BackColor = Color.Aqua;
                    header.MouseDown += (a, b) => 
                    {
                        hm = true;
                        mx = Cursor.Position.X - targetForm.Left;
                        my = Cursor.Position.Y - targetForm.Top;
                    };
                    header.MouseMove += (a, b) => 
                    {
                        if (hm)
                        {
                            targetForm.Left = Cursor.Position.X - mx;
                            targetForm.Top = Cursor.Position.Y - my;
                        }
                    };
                    header.MouseUp += (a, b) => { hm = false; };
                    header.DoubleClick += (a, b) => 
                    {
                        if(targetForm.WindowState == FormWindowState.Maximized)
                        {
                            targetForm.WindowState = FormWindowState.Normal;
                        }
                        else
                        {
                            targetForm.WindowState = FormWindowState.Maximized;
                        }                        
                    };
                    targetForm.Controls.Add(header);
                    
                    contents.Location = new Point(0, 0);
                    contents.Dock = DockStyle.Fill;
                    contents.BackColor = Color.Beige;
                    contents.Name = "contents";
                    targetForm.Controls.Add(contents);
                    
                    close.Size = new Size(33, 30);
                    close.Location = new Point(targetForm.Width - 40, 8);
                    close.AutoSize = false;
                    close.Anchor = AnchorStyles.Right;
                    close.Text = "X";
                    close.Font = new Font("굴림", 22F, FontStyle.Bold);
                    close.Cursor = Cursors.Hand;
                    close.Click += (a, b) => { Application.Exit(); };
                    header.Controls.Add(close);

                    return true;
                case "SDI":
                    targetForm.IsMdiContainer = false;
                    targetForm.Dock = DockStyle.Fill;
                    targetForm.FormBorderStyle = FormBorderStyle.None;
                    return true;
                default:
                    MessageBox.Show("누구냐?");
                    return false;
            }            
        }
    }
}
