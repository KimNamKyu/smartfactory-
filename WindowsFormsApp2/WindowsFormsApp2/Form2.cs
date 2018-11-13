using System;
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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            Load += Form1_Load;
            
        }
        private void Form1_Load(object o, EventArgs args)
        {
            for(int i =0; i<4; i++)
            {
                btn_create(i);
            }
        }
        private Button btn;
        private void btn_create(int i)
        {
            btn = new Button();

            btn.DialogResult = DialogResult.OK;
            btn.Name = string.Format("btn_{0}",i);
            btn.Location = new Point(0, (100*i)+0);
            btn.Size = new Size(150, 100);
            btn.Cursor = Cursors.Hand;

            btn.Click += btn_Click;
            Controls.Add(btn);
        }
        private void btn_Click(object o, EventArgs args)
        {
            btn = (Button)o;
            //MessageBox.Show(btn.Name);
            foreach(Control ct in Controls)
            {
                if (btn.Name == "btn_2") MyTabs();
            }

            //btn.Name = (btn.Name == "btn2" ? tabPage2 : );
        }

        private void CrateMyPanel()
        {
            Panel p1 = new Panel();
            p1.Location = new Point(150, 0);
            p1.Size = new Size(700, 500);
            p1.BorderStyle = BorderStyle.None;
            p1.BackColor = Color.Yellow;

            ListView listView1 = new ListView();
            listView1.View = View.Details;
            listView1.CheckBoxes = true;
            listView1.GridLines = true;
            listView1.Location = new Point(160, 80);
            listView1.Size = new Size(600, 250);

            listView1.Columns.Add("",25);
            listView1.Columns.Add("프로그램명", 180);
            listView1.Columns.Add("제작사", 200);
            listView1.Columns.Add("설치일", 100);
            listView1.BackColor = Color.Gainsboro;
            listView1.ForeColor = Color.Black;

            ListViewItem item1 = new ListViewItem(" ", 60);
            item1.SubItems.Add("Chrom");
            item1.SubItems.Add("Google.inc");
            item1.SubItems.Add("2018.09.17");

            ListViewItem item2 = new ListViewItem(" ", 40);
            item2.SubItems.Add("HeidiSQL");
            item2.SubItems.Add("Ansgar Becker");
            item2.SubItems.Add("2018.10.05");

            ListViewItem item3 = new ListViewItem(" ", 40);
            item3.SubItems.Add("FileZilla Client 3.37.0");
            item3.SubItems.Add("Tim kosse");
            item3.SubItems.Add("2018.10.23");


            listView1.Items.AddRange(new ListViewItem[] { item1, item2, item3 });
            Controls.Add(listView1);
            Controls.Add(p1);
        }

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private ListView listView1;
        private ListView listView2;
        private CheckBox checkBox1;
        private void MyTabs()
        {
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            tabPage3 = new TabPage();

            //TabPage[] tabPages = { tabPage1, tabPage2, tabPage3 };
            //tabControl1.SizeMode = TabSizeMode.FillToRight;

            tabControl1.Padding = new Point(22, 20);
            tabControl1.Controls.AddRange(new Control[] { tabPage1, tabPage2, tabPage3 });
            tabControl1.Location = new Point(150, 0);
            tabControl1.Size = new Size(600, 500);
            
            tabPage1.Text = "프로그램 삭제";
            tabPage2.Text = "개인정보 삭제";
            tabPage3.Text = "파일 강제삭제";

            ListPrint();
            UserDelete();
            
            tabPage1.Controls.Add(listView1);
            tabPage2.Controls.Add(checkBox1);
            LIstPrint2();
            tabPage3.Controls.Add(listView2);
            Controls.AddRange(new Control[] { tabControl1 });
        }       
        
        private void ListPrint()
        {
            listView1 = new ListView();
            listView1.View = View.Details;
            listView1.CheckBoxes = true;
            listView1.GridLines = true;
            listView1.Location = new Point(40, 40);
            listView1.Size = new Size(505, 250);

            listView1.Columns.Add("", 25,HorizontalAlignment.Center);
            listView1.Columns.Add("프로그램명", 180, HorizontalAlignment.Center);
            listView1.Columns.Add("제작사", 200, HorizontalAlignment.Center);
            listView1.Columns.Add("설치일", 100,HorizontalAlignment.Center);
            listView1.BackColor = Color.Gainsboro;
            listView1.ForeColor = Color.Black;

            ListViewItem item1 = new ListViewItem(" ", 60);
            item1.SubItems.Add("Chrom");
            item1.SubItems.Add("Google.inc");
            item1.SubItems.Add("2018.09.17");

            ListViewItem item2 = new ListViewItem(" ", 40);
            item2.SubItems.Add("HeidiSQL");
            item2.SubItems.Add("Ansgar Becker");
            item2.SubItems.Add("2018.10.05");

            ListViewItem item3 = new ListViewItem(" ", 40);
            item3.SubItems.Add("FileZilla Client 3.37.0");
            item3.SubItems.Add("Tim kosse");
            item3.SubItems.Add("2018.10.23");


            listView1.Items.AddRange(new ListViewItem[] { item1, item2, item3 });
            
        }

        private void UserDelete()
        {
            for(int i = 0; i<5; i++)
            {
                checkBox1 = new CheckBox();
                checkBox1.AutoSize = true;
                checkBox1.Location = new Point(160, (20*i)+60);
                checkBox1.Name = "checkBox1";
                checkBox1.Size = new Size(86, 16);
                checkBox1.TabIndex = 0;
                checkBox1.Text = string.Format("목록 삭제",(i+1));
                checkBox1.UseVisualStyleBackColor = true;
                tabPage2.Controls.Add(checkBox1);
            }
        }
        private void LIstPrint2()
        {
            listView2 = new ListView();
            listView2.View = View.Details;
            listView2.CheckBoxes = true;
            listView2.GridLines = true;
            listView2.Location = new Point(40, 40);
            listView2.Size = new Size(505, 250);

            listView2.Columns.Add(" ", 25);
            listView2.Columns.Add("파일명", 480);
            listView2.BackColor = Color.Gainsboro;
            listView2.ForeColor = Color.Black;

            ListViewItem item1 = new ListViewItem(" ",100);
            item1.SubItems.Add("WindowsApp.exe");
            ListViewItem item2 = new ListViewItem(" ", 100);
            item2.SubItems.Add("WindowsApp2.exe");

            listView2.Items.AddRange(new ListViewItem[] { item1,item2 });
            
        }
    }
}
