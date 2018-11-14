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

namespace architect
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControl1;
        private ListView listView1;
        private ListView listView2;
        private CheckBox checkBox1;
        private Panel panel3;
       // private Button btn;
        public Form1()
        {
            InitializeComponent();

            Load += Form1_Load;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Panel3_Load();
        }
        private void Panel3_Load()
        {
            panel3 = new Panel();
            panel3.Location = new Point(115, 0);
            panel3.Size = new Size(600, 400);
            panel3.BackColor = Color.Aqua;

            tabControl1 = MyTabs();
            panel3.Controls.AddRange(new Control[] { tabControl1 });
            Controls.Add(panel3);
        }
        private TabControl MyTabs()
        {
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            tabPage3 = new TabPage();

            tabControl1.Padding = new Point(22, 20);
            tabControl1.Controls.AddRange(new Control[] { tabPage1, tabPage2, tabPage3 });
            tabControl1.Size = new Size(600, 500);

            tabPage1.Text = "프로그램 삭제";
            tabPage2.Text = "개인정보 삭제";
            tabPage3.Text = "파일 강제삭제";

            listView1 = ListPrint();
            checkBox1 = UserDelete();
            listView2 = LIstPrint2();
            tabPage1.Controls.Add(listView1);
            tabPage2.Controls.Add(checkBox1);
            tabPage3.Controls.Add(listView2);

            return tabControl1;
        }

        private ListView ListPrint()
        {
            listView1 = new ListView();
            listView1.View = View.Details;
            listView1.CheckBoxes = true;
            listView1.GridLines = true;
            listView1.Location = new Point(40, 40);
            listView1.Size = new Size(505, 250);

            listView1.Columns.Add("", 25, HorizontalAlignment.Center);
            listView1.Columns.Add("프로그램명", 180, HorizontalAlignment.Center);
            listView1.Columns.Add("제작사", 200, HorizontalAlignment.Center);
            listView1.Columns.Add("설치일", 100, HorizontalAlignment.Center);
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

            return listView1;
        }
        private CheckBox UserDelete()
        {
         checkBox1 = new CheckBox();
         checkBox1.AutoSize = true;
         checkBox1.Location = new Point(160,  60);
         checkBox1.Name = "checkBox1";
         checkBox1.Size = new Size(86, 16);

         checkBox1.TabIndex = 0;
         checkBox1.Text = string.Format("목록 삭제");
         checkBox1.UseVisualStyleBackColor = true;
        
         return checkBox1;
        }
        private ListView LIstPrint2()
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

            ListViewItem item1 = new ListViewItem(" ", 100);
            item1.SubItems.Add("WindowsApp.exe");
            ListViewItem item2 = new ListViewItem(" ", 100);
            item2.SubItems.Add("WindowsApp2.exe");

            listView2.Items.AddRange(new ListViewItem[] { item1, item2 });
            
            return listView2;
        }
    }
}

