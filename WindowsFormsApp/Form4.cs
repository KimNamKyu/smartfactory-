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

namespace WindowsFormsApp
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            Load += Form4_Load; //폼이 시작되기 전에 동작
        }
        private void Form4_Load(object sender, EventArgs args)  
        {
            //Button btn = c1.btn(); 
            //Controls.Add(btn);

            //Class1 c1 = new Class1(this);
            //c1.btn();
            
            Class1 c1 = new Class1();
            //c1.btn(this, "btn_1", "버튼1", 100, 50, 30, 30);
            //c1.btn(this, "btn_1", "버튼1", 100, 50, 30, (30 + 30 + 50));
            ArrayList arr = new ArrayList();
            arr.Add(new btnobject(this, "btn_1", "버튼1", 100, 50, 30, 30, btn1_Click));
            arr.Add(new btnobject(this, "btn_1", "버튼1", 100, 50, 30, (30 + 30 + 50), btn2_Click));
            arr.Add(new lbobject(this, "lb", "라벨1", 100, 50, (30+30+100), 30));

            for (int i = 0; i<arr.Count; i++)
            {
                //제어문 사용하여 type비교
                if (typeof(btnobject) == arr[i].GetType())  //arr[i] 객체가 btn의 객체이면 (type을 비교)
                {
                    c1.btn((btnobject)arr[i]);  
                }
                else if (typeof(lbobject) == arr[i].GetType()) //arr[i] 객체가 lb (type 비교)
                {
                    c1.lb((lbobject)arr[i]);
                }
            }
        }
        //버튼이벤트
        private void btn1_Click(object o, EventArgs args)
        {
            MessageBox.Show("btn1 Open");
        }
        private void btn2_Click(object o, EventArgs args)
        {
            MessageBox.Show("btn2 Open");
        }
    }
}
