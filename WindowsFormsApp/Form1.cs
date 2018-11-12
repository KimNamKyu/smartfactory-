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
            Load += Form1_Load; // Form 실행 시 기본 적으로 실행될  내용 호출
        }

        private Button btn;
        private Label lb;

        private void Form1_Load(object sender, EventArgs e)
        {
            // *가상 데이터 생성
            ArrayList arrList = new ArrayList();  //여러개 삽입가능 행추가가능.
            arrList.Add(new Item("button",30,30,"btn_1"));   //object 형식은 무엇을 넣어도 상관없다.
            arrList.Add(new Item("label", 30, 110, "lb_1"));
            arrList.Add(new Item("button",30, 190, "btn_2"));

            for(int i = 0; i<arrList.Count; i++)    //가상 데이터를 이용한 화면 구성하기
            {
                Control ctr =  Control_create((Item)arrList[i]);    //구성될 각 화면 내용 받아오기
                Controls.Add(ctr);  //받아온 Control 정보를 이용하여 화면 구성하기
            }

            /* 1차원 배열로 화면 구성하기
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
        private Control Control_create(Item item)
        {
            Control ctr = new Control();    //리턴 객체 만들기
            
            //button or label 불러옴
            switch (item.getType())
            {
                case "button":  //button 부분 정의 하기
                    Button btn = new Button();
                    btn.DialogResult = DialogResult.OK;
                    btn.Cursor = Cursors.Hand;
                    btn.Click += btn_Click;
                    ctr = btn;  //button 객체를 리턴 객체에 변경하기
                    break;
                case "label":
                    Label lb = new Label();
                    ctr = lb;   //label 객체를 리턴 객체에 변경하기
                    break;
                default:
                    break;
            }
            //리턴 객체에 공동으로 적용할 속성 정의하기
            ctr.Name = item.getTxt();
            ctr.Text = item.getTxt();
            ctr.Size = new Size(100, 50); 
            ctr.Location = new Point(item.getX(), item.getY());

            return ctr; //정의 한 Control 보내기
        }
        private Button btn_create(int i)    //button 객체 정의하기
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

       
        private Label lb_create(int i)  //lable 객체 정의하기
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

    public class Item   //Control 객체 생성 시 필요한 속성 정보 담을 객체 생성
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
