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
        }
        private Button btn;
        private void Form1_Load(object sender, EventArgs e)
        {
            for(int i =0; i<3; i++)
            {
                //button 클래스의 생성자 생성
                Button btn = new Button();

                //설정
                btn.DialogResult = DialogResult.OK;
                btn.Text = string.Format("확인 : {0}" , (i+1));
                btn.Size = new Size(100, 50);  //사이즈는 Size 생성자를 생성
                btn.Location = new Point((100*i)+30, 30);  //x값 증가시켜 위치 변경
                btn.Cursor = Cursors.Hand;

                Controls.Add(btn);  //화면 등록
                btn.Click += btn_Click; //메소드를 연결 / += : 추가의 의미

            }
        }

        private void btn_Click(object o, EventArgs args)
        {
            btn = (Button)o;  //o는 객체이므로 형변환을 해주어야함
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
