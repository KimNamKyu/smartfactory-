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
        private void Form1_Load(object sender, EventArgs e)
        {
            //button 클래스의 생성자 생성
            Button btn = new Button();

            //설정
            btn.DialogResult = DialogResult.OK;
            btn.Text = "확인";
            btn.Size = new Size(100, 50);  //사이즈는 Size 생성자를 생성
            btn.Location = new Point(30, 30);   //위치는 Point 생성자를 생성

            Controls.Add(btn);  //화면 등록
            btn.Click += btn_Click; //메소드를 연결 / += : 추가의 의미
        }

        private void btn_Click(object o, EventArgs args)
        {
            MessageBox.Show("클릭 메소드");
        }
    }
}
