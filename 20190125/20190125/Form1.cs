using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace _20190125
{
    [TestClass]
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
        }

        PerformanceCounter cpu = new PerformanceCounter();
        PerformanceCounter User = new PerformanceCounter();
        PerformanceCounter Pagefs = new PerformanceCounter();

        private void Form1_Load(object sender, EventArgs e)
        {
            cpu.CategoryName = "Processor";
            cpu.CounterName = "% Processor Time";   // !정의 되어 있는 CounterName
            cpu.InstanceName = "1";
            label_cpu.Text = cpu.NextValue().ToString();

            User = new PerformanceCounter();
            User.CategoryName = "Memory";
            User.CounterName = "Available KBytes";   // !정의 되어 있는 CounterName

            Pagefs = new PerformanceCounter();
            Pagefs.CategoryName = "Processor";
            Pagefs.CounterName = " Page Faults/sec";   // !정의 되어 있는 CounterName
            

            timer1.Tick += Timer_tick;  //시작과 간격속성을 부여해야함 .
            timer1.Interval = 1000; // 1초
            timer1.Start();
        }

        private void Timer_tick(object o, EventArgs e)
        {
            int cpu_p = (int)cpu.NextValue();
            label_cpu.Text = $"CPU 사용률 : {cpu_p.ToString()} ";
            label1.Text = $"Category Name : {cpu.CategoryName}";
            label2.Text = $"Counter Name : {cpu.CounterName}";
            label3.Text = $"Instance Name : {cpu.InstanceName}";
            textBox1.Text = cpu.CounterHelp;

            label5.Text = $"메모리 사용률 : {(int)User.NextValue()}KB";
            label4.Text = $"Counter Name : {User.CounterName}";
            textBox2.Text = User.CounterHelp;

            //label6.Text = $"쓰레드 : {(int)Pagefs.NextValue()}";
        }

        [TestMethod]
        public void test()
        {

        }
    }
}
