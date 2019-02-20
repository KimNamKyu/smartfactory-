using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public static class Commons
    {
        public static Form getMdiForm(Form parentForm, Form tagetForm, Control parentDomain)
        {
            tagetForm.MdiParent = parentForm;
            tagetForm.WindowState = FormWindowState.Maximized;
            tagetForm.FormBorderStyle = FormBorderStyle.None;
            tagetForm.Dock = DockStyle.Fill;
            parentDomain.Controls.Add(tagetForm);
            return tagetForm;
        }
    }
}
