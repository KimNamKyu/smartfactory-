﻿using DB;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20181123
{
    public class MainView
    {
        private MSsql db;
        private Commons comm;
        private Panel head, contents;
        private Button btn1, btn2, btn3;
        private Form parentForm, tagetForm;
        private Hashtable hashtable;

        public MainView(Form parentForm)
        {
            this.parentForm = parentForm;
            db = new MSsql();
            comm = new Commons();
            getView();
        }

        private void getView()  //화면구성
        {

            string sql = "select * from ViewControl;";
            SqlDataReader sdr = db.Reader(sql);
            while (sdr.Read())
            {

                string vNo = sdr["vNo"].ToString();
                string svName = sdr["svName"].ToString();
                int sizeX = Convert.ToInt32(sdr["sizeX"].ToString());
                int sizeY = Convert.ToInt32(sdr["sizeY"].ToString());
                int pointX = Convert.ToInt32(sdr["pointX"].ToString());
                int pointY = Convert.ToInt32(sdr["pointY"].ToString());

               if(svName == "head")
                {
                    hashtable = new Hashtable();
                    hashtable.Add("type", "");
                    hashtable.Add("size", new Size(sizeX, sizeY));
                    hashtable.Add("point", new Point(pointX, pointY));
                    hashtable.Add("color", Color.Yellow);
                    hashtable.Add("name", svName);
                    head = comm.getPanel(hashtable, parentForm);
                }
               else if(svName == "contents")
                {
                    hashtable = new Hashtable();
                    hashtable.Add("size", new Size(sizeX, sizeY));
                    hashtable.Add("point", new Point(pointX, pointY));
                    hashtable.Add("color", Color.Green);
                    hashtable.Add("name", svName);
                    contents = comm.getPanel(hashtable, parentForm);
                }
                //MessageBox.Show(pointX.ToString() + " " + pointY.ToString() + " " + sizeX.ToString() + " " + sizeY.ToString());

            }

            /*
            hashtable = new Hashtable();
            hashtable.Add("type", "");
            hashtable.Add("size", new Size(1000, 100));
            hashtable.Add("point", new Point(0, 0));
            hashtable.Add("color", Color.Silver);
            hashtable.Add("name", "head");
            head = comm.getPanel(hashtable, parentForm);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(1000, 700));
            hashtable.Add("point", new Point(0, 100));
            hashtable.Add("color", Color.Yellow);
            hashtable.Add("name", "contents");
            contents = comm.getPanel(hashtable, parentForm);
            
            hashtable = new Hashtable();
            hashtable.Add("size", new Size(200, 80));
            hashtable.Add("point", new Point(100, 10));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "btn1");
            hashtable.Add("text", "Member");
            hashtable.Add("click", (EventHandler)btn1_click);
            btn1 = comm.getButton(hashtable, head);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(200, 80));
            hashtable.Add("point", new Point(400, 10));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "btn2");
            hashtable.Add("text", "Rule");
            hashtable.Add("click", (EventHandler)btn2_click);
            btn2 = comm.getButton(hashtable, head);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(200, 80));
            hashtable.Add("point", new Point(700, 10));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "btn3");
            hashtable.Add("text", "Mapping");
            hashtable.Add("click", (EventHandler)btn3_click);
            btn3 = comm.getButton(hashtable, head);
            */
        }

        private void btn1_click(object o, EventArgs a)
        {
            // form 초기화
            if (tagetForm != null) tagetForm.Dispose();
            // form 호출
            tagetForm = comm.getMdiForm(parentForm, new UserForm(db), contents);
            tagetForm.Show();
        }

        private void btn2_click(object o, EventArgs a)
        {
            // form 초기화
            if (tagetForm != null) tagetForm.Dispose();
            // form 호출
            tagetForm = comm.getMdiForm(parentForm, new RuleForm(db), contents);
            tagetForm.Show();
        }

        private void btn3_click(object o, EventArgs a)
        {
            // form 초기화
            if (tagetForm != null) tagetForm.Dispose();
            // form 호출
            tagetForm = comm.getMdiForm(parentForm, new MappingForm(db), contents);
            tagetForm.Show();
        }
    }
}
