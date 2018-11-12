using System;
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
            CreateMyPanel();
        }

        private Button btn;
        private void Form1_Load(object sender, EventArgs e)
        {
            for(int i =0; i<3; i++) //버튼 3개 반복
            {
                //button 클래스의 생성자 생성
                btn = new Button();

                //설정
                btn.DialogResult = DialogResult.OK;
                btn.Name = string.Format("btn_ : {0}", (i + 1));
                btn.Text = string.Format("확인 : {0}" , (i+1));
                btn.Size = new Size(100, 50);  //사이즈는 Size 생성자를 생성
                btn.Location = new Point((100*i)+30, 30);  //x값 증가시켜 위치 변경
                btn.Cursor = Cursors.Hand;  //커서 손모양 변경

                Controls.Add(btn);  //화면 등록  ->> 여러개 넣었으므로 배열!
                btn.Click += btn_Click; //메소드를 연결 / += : 추가의 의미

            }
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
}
