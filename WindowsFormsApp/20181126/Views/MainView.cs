using DB;
using MySql.Data.MySqlClient;
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
        private MYsql db;
        private Commons comm;
        private Panel head, contents;
        private Button btn1, btn2, btn3;
        private Form parentForm, tagetForm;
        private Hashtable hashtable;

        public MainView(Form parentForm)
        {
            this.parentForm = parentForm;
            db = new MYsql();
            comm = new Commons();
            getView();
        }

        private void getView()  //화면구성
        {
            string sql = "select * from ViewControl;";
            MySqlDataReader sdr = db.Reader(sql);
            
            string[] arr = new string[sdr.FieldCount];
            while (sdr.Read())
            {
                string svName = sdr["svName"].ToString();
                int RGB = Convert.ToInt32(sdr["color"]);
                int btnevent = Convert.ToInt32(sdr["event"]);

                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    arr[i] = sdr.GetValue(i).ToString();
                    //MessageBox.Show(arr[i].ToString());
                }

                if (svName == "head")
                {
                    hashtable = new Hashtable();
                    hashtable.Add("size", new Size(Convert.ToInt32(sdr["sizeX"]), Convert.ToInt32(sdr["sizeY"])));
                    hashtable.Add("point", new Point(Convert.ToInt32(sdr["pointX"]), Convert.ToInt32(sdr["pointY"])));
                    hashtable.Add("name", sdr["svName"].ToString());
                    hashtable.Add("color", GetColor(RGB));
                    head = comm.getPanel(hashtable, parentForm);
                }

                else if (svName == "contents")
                {
                    hashtable = new Hashtable();
                    hashtable.Add("size", new Size(Convert.ToInt32(sdr["sizeX"]), Convert.ToInt32(sdr["sizeY"])));
                    hashtable.Add("point", new Point(Convert.ToInt32(sdr["pointX"]), Convert.ToInt32(sdr["pointY"])));
                    hashtable.Add("name", sdr["svName"].ToString());
                    hashtable.Add("color", GetColor(RGB));
                    contents = comm.getPanel(hashtable, parentForm);
                }

                if (svName == "btn1")
                {
                    hashtable = new Hashtable();
                    hashtable.Add("size", new Size(Convert.ToInt32(sdr["sizeX"]), Convert.ToInt32(sdr["sizeY"])));
                    hashtable.Add("point", new Point(Convert.ToInt32(sdr["pointX"]), Convert.ToInt32(sdr["pointY"])));
                    hashtable.Add("name", sdr["svName"].ToString());
                    hashtable.Add("text", sdr["svText"].ToString());
                    hashtable.Add("color", GetColor(RGB));
                    hashtable.Add("click", (EventHandler)Eventget(btnevent));
                    btn1 = comm.getButton(hashtable, head);
                }

                if (svName == "btn2")
                {
                    hashtable = new Hashtable();
                    hashtable.Add("size", new Size(Convert.ToInt32(sdr["sizeX"]), Convert.ToInt32(sdr["sizeY"])));
                    hashtable.Add("point", new Point(Convert.ToInt32(sdr["pointX"]), Convert.ToInt32(sdr["pointY"])));
                    hashtable.Add("name", sdr["svName"].ToString());
                    hashtable.Add("text", sdr["svText"].ToString());
                    hashtable.Add("color", GetColor(RGB));
                    hashtable.Add("click", (EventHandler)Eventget(btnevent));
                    btn2 = comm.getButton(hashtable, head);
                }

                if (svName == "btn3")
                {
                    hashtable = new Hashtable();
                    hashtable.Add("size", new Size(Convert.ToInt32(sdr["sizeX"]), Convert.ToInt32(sdr["sizeY"])));
                    hashtable.Add("point", new Point(Convert.ToInt32(sdr["pointX"]), Convert.ToInt32(sdr["pointY"])));
                    hashtable.Add("name", sdr["svName"].ToString());
                    hashtable.Add("text", sdr["svText"].ToString());
                    hashtable.Add("color", GetColor(RGB));
                    hashtable.Add("click", (EventHandler)Eventget(btnevent));
                 
                    btn3 = comm.getButton(hashtable, head);
                }
            }
            db.ReaderClose(sdr);
        }

        private Color GetColor(int num)
        {
            switch (num)
            {
                case 1:
                    return Color.Silver;
                case 2:
                    return Color.Yellow;
                default:
                    return Color.White;
            }
        }
        private EventHandler Eventget(int num)
        {
            switch (num)
            {
                case 1:
                    return btn1_click;
                case 2:
                    return btn2_click;
                default :
                    return btn3_click;
            }
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
