using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace swPackage
{
    public class FormLoad
    {
        private Form TargetForm;
        private string ViewType;

        public FormLoad(Form TargetForm)
        {
            //MessageBox.Show("실행됨?");
            this.TargetForm = TargetForm;
            
        }

        public EventHandler GetHandler(string ViewType)
        {
            this.ViewType = ViewType;
            return GetLoad;
        }

        private void GetLoad(object o, EventArgs e)
        {
            switch (ViewType)
            {
                case "MDI":
                    MessageBox.Show("MDI 불렀니?");
                    TargetForm.IsMdiContainer = true;
                    TargetForm.FormBorderStyle = FormBorderStyle.FixedSingle;
                    TargetForm.MaximizeBox = false;
                    TargetForm.MinimizeBox = false;
                    TargetForm.BackColor = Color.Blue;
                    break;
                case "SDI":
                    MessageBox.Show("SDI 불렀니?");
                    TargetForm.IsMdiContainer = false;
                    TargetForm.FormBorderStyle = FormBorderStyle.None;
                    TargetForm.MaximizeBox = false;
                    TargetForm.MinimizeBox = false;
                    TargetForm.BackColor = Color.Yellow;
                    break;
                default:
                    MessageBox.Show("누구냐?");
                    break;
            }
        }
    }
}
