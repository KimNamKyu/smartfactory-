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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
            //CreateMyPanel();
        }

        private Button btn;
        private void Form1_Load(object sender, EventArgs e)
        {
            //객체를 넣는방법
            ArrayList arrList = new ArrayList();  //여러개 삽입가능 행추가가능.
            arrList.Add(new Item("button",30,30,"btn_1"));   //object 형식은 무엇을 넣어도 상관없다.
            arrList.Add(new Item("label", 30, 110, "lb_1"));
            arrList.Add(new Item("button",30, 190, "btn_2"));

            for(int i = 0; i<arrList.Count; i++)
            {
               Control_create((Item)arrList[i]);
            }

            /* 위에 나열한것과 동일한 방법 스트링을 넣은 방법
            string[] ctrList = { "button", "label", "button" };

            for (int i = 0; i < ctrList.Length; i++) //버튼 3개 반복
            {
                if (ctrList[i] == "button")
                {
                    Controls.Add(btn_create(i));
                }
                else if(ctrList[i] == "label")
                {
                    Controls.Add(lb_create(i));
                }
            }
            */

        }
        private void Control_create(Item item)
        {
            Control ctr = new Control();
            
            //button or label 불러옴
            switch (item.getType())
            {
                case "button":
                    Button btn = new Button();
                    btn.DialogResult = DialogResult.OK;
                    btn.Cursor = Cursors.Hand;
                    btn.Click += btn_Click;
                    ctr = btn;
                    break;
                case "label":
                    ctr = new Label();
                    break;
                default:
                    break;
            }
            ctr.Name = item.getTxt();
            ctr.Text = item.getTxt();
            ctr.Size = new Size(100, 50); 
            ctr.Location = new Point(item.getX(), item.getY());
            Controls.Add(ctr);
        }
        private Button btn_create(int i)
        {
            //button 클래스의 생성자 생성
            btn = new Button();

            //설정
            btn.DialogResult = DialogResult.OK;
            btn.Name = string.Format("btn_ : {0}", (i + 1));
            btn.Text = string.Format("확인 : {0}", (i + 1));
            btn.Size = new Size(100, 50);  //사이즈는 Size 생성자를 생성
            btn.Location = new Point((100 * i) + 30, 30);  //x값 증가시켜 위치 변경
            btn.Cursor = Cursors.Hand;  //커서 손모양 변경
            //Controls.Add(btn);  //화면 등록  ->> 여러개 넣었으므로 배열!
            btn.Click += btn_Click; //메소드를 연결 / += : 추가의 의미
            return btn;
        }

        private Label lb;
        private Label lb_create(int i)
        {
            lb = new Label();
            lb.Name = string.Format("lb_ : {0}", (i + 1));
            lb.Text = string.Format("확인 : {0}", (i + 1));
            lb.Size = new Size(100, 50);  
            lb.Location = new Point((100 * i) + 30, 30);  
            return lb;
        }
        private Panel panel1;
        private TextBox textBox1;
        private Label label1;
        public void CreateMyPanel()
        {
            for( int i = 0; i<3; i++)
            {
                panel1 = new Panel();
                textBox1 = new TextBox();
                label1 = new Label();

                // Initialize the Panel control.
                panel1.Location = new Point(56, (156*i)+0);
                panel1.Size = new Size(250, 140);
                // Set the Borderstyle for the Panel to three-dimensional.
                panel1.BorderStyle = System.Windows.Forms.BorderStyle.None;
                panel1.BackColor = Color.Blue;

                // Initialize the Label and TextBox controls.
                label1.Location = new Point(16, 16);
                label1.Text = "최적화";
                label1.Size = new Size(104, 16);
                textBox1.Location = new Point(16, 32);
                textBox1.Text = "";
                textBox1.Size = new Size(152, 20);

                // Add the Panel control to the form.
                this.Controls.Add(panel1);
                // Add the Label and TextBox controls to the Panel.
                panel1.Controls.Add(label1);
                panel1.Controls.Add(textBox1);

                //panel1.Click += ;
            }
        }
        private void btn_Click(object o, EventArgs args)
        {
            //string names = "";
            foreach (Control ct in Controls)    //배열에 넣은 btn.Name 가져오기
            {
                //names += ct.Name + " ";
                if(ct.Name != "btn_2") ct.BackColor = Color.Silver;
            }
            //MessageBox.Show(names);

            btn = (Button)o;  //o는 객체이므로 button으로 형변환을 해주어야함
            //MessageBox.Show(btn.Text);
            //색깔넣기
            btn.BackColor = (btn.BackColor == Color.Green ? btn.BackColor = Color.Silver : btn.BackColor = Color.Green);

            /*
            if(btn.BackColor == Color.Green)
            {
                btn.BackColor = Color.Silver;
            }
            else
            {
                btn.BackColor = Color.Green;
            }
            */
        }
    }

    public class Item
    {
        private string type; //button, label
        private int X, Y;
        private string txt;

        public Item(string type,int X, int Y, string txt)
        {
            this.type = type;
            this.X = X;
            this.Y = Y;
            this.txt = txt;
        }

        //public 으로 데이터를 담고 있을 객체로 가져다 사용 가능
        public string getType()
        {
            return type;
        }
        public int getX()
        {
            return X;
        }
        public int getY()
        {
            return Y;
        }
        public string getTxt()
        {
            return txt;
        }
    }
}
