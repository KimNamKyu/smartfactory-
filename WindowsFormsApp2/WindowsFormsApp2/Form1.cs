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


namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            tabPage3 = new TabPage();

            tabControl1.Padding = new Point(22, 20);
            tabControl1.Controls.AddRange(new Control[] { tabPage1, tabPage2, tabPage3 });
            tabControl1.Size = new Size(700, 500);

            tabPage1.Text = "프로그램 삭제";
            tabPage2.Text = "개인정보 삭제";
            tabPage3.Text = "파일 강제삭제";

            ModuleClass mc = new ModuleClass();
            ArrayList arr = new ArrayList();

            arr.Add(new lbobject(tabPage1, "lb", "라벨1", 100, 50, (30 + 30 + 100), 300));
            arr.Add(new btnobject(tabPage1, "bb", "버튼1", 300, 50, 30, 300));
            arr.Add(new lvobject(tabPage1, 500, 300, 30, 30));
            
            //제어문 사용하여 type비교
            for (int i = 0; i < arr.Count; i++)
            {
                if (typeof(btnobject) == arr[i].GetType())  //arr[i] 객체가 btn의 객체이면 (type을 비교)
                {
                    mc.btn((btnobject)arr[i]);
                }
                else if (typeof(lbobject) == arr[i].GetType()) //arr[i] 객체가 lb (type 비교)
                {
                    mc.lb((lbobject)arr[i]);
                }
                else if(typeof(lvobject) == arr[i].GetType())
                {
                    mc.lv((lvobject)arr[i]);
                }
            }


            Controls.AddRange(new Control[] { tabControl1 });
        }
    }
}