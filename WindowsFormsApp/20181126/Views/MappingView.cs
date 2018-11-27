using DB;
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
    class MappingView
    {
        private MSsql db;
        private Commons comm;
        private Panel member, rule, mapping, bottom;
        private Label label1, label2, label3, label4;
        private ComboBox comboBox1, comboBox2;
        private Button btn1, btn2;
        private Form parentForm;
        private Hashtable hashtable;
        private BindingSource bs;
        private ListView listView;
        private int mNo, rNo;

        public MappingView(Form parentForm, Object oDB)
        {
            this.parentForm = parentForm;
            this.db = (MSsql)oDB;
            comm = new Commons();
            getView();
        }

        private void getView()
        {
            hashtable = new Hashtable();
            hashtable.Add("type", "");
            hashtable.Add("size", new Size(500, 45));
            hashtable.Add("point", new Point(0, 0));
            hashtable.Add("color", Color.Red);
            hashtable.Add("name", "member");
            member = comm.getPanel(hashtable, parentForm);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(500, 45));
            hashtable.Add("point", new Point(500, 0));
            hashtable.Add("color", Color.Yellow);
            hashtable.Add("name", "rule");
            rule = comm.getPanel(hashtable, parentForm);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(1000, 655));
            hashtable.Add("point", new Point(0, 45));
            hashtable.Add("color", Color.Blue);
            hashtable.Add("name", "mapping");
            mapping = comm.getPanel(hashtable, parentForm);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(500, 20));
            hashtable.Add("point", new Point(0, 5));
            hashtable.Add("color", Color.Red);
            hashtable.Add("name", "label1");
            hashtable.Add("text", "Member");
            label1 = comm.getLabel(hashtable, member);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(500, 20));
            hashtable.Add("point", new Point(0, 5));
            hashtable.Add("color", Color.Yellow);
            hashtable.Add("name", "label2");
            hashtable.Add("text", "Rule");
            label2 = comm.getLabel(hashtable, rule);

            hashtable = new Hashtable();
            hashtable.Add("width", 500);
            hashtable.Add("point", new Point(0, 25));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "comboBox1");
            hashtable.Add("click", (EventHandler) Member_click);
            comboBox1 = comm.getComboBox(hashtable, member);

            hashtable = new Hashtable();
            hashtable.Add("width", 485);
            hashtable.Add("point", new Point(0, 25));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "comboBox2");
            hashtable.Add("click", (EventHandler) Rule_click);
            comboBox2 = comm.getComboBox(hashtable, rule);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(1000, 100));
            hashtable.Add("point", new Point(0, 520));
            hashtable.Add("color", Color.Green);
            hashtable.Add("name", "mapping");
            bottom = comm.getPanel(hashtable, mapping);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(200, 90));
            hashtable.Add("point", new Point(10, 3));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "btn1");
            hashtable.Add("text", "추가");
            hashtable.Add("click", (EventHandler)btn1_click);
            btn1 = comm.getButton(hashtable, bottom);

            hashtable = new Hashtable();
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "listView");
            hashtable.Add("click", (MouseEventHandler)listView_click);
            listView = comm.getListView(hashtable, mapping);

            hashtable = new Hashtable();
            hashtable.Add("size", new Size(200, 90));
            hashtable.Add("point", new Point(250, 3));
            hashtable.Add("color", Color.White);
            hashtable.Add("name", "btn2");
            hashtable.Add("text", "삭제 ");
            hashtable.Add("click", (EventHandler)btn2_click);
            btn2 = comm.getButton(hashtable, bottom);

            GetSelect();
        }


        private void GetSelect()
        {
            SelectMember();
            SelectRule();
            SelectMapping();
        }

        private void SelectMember()
        {
            string sql = "select mNo, mName from Member where delYn = 'N';";
            SqlDataReader sdr = db.Reader(sql);
            bs = new BindingSource();
            hashtable = new Hashtable();
            hashtable.Add("0", "선택하세요.");
            while (sdr.Read())
            {
                hashtable.Add(sdr.GetInt32(0), sdr.GetString(1));
            }
            db.ReaderClose(sdr);
            bs.DataSource = hashtable;
            comboBox1.DataSource = bs;
            comboBox1.SelectedIndexChanged += Member_click;
        }

        private void SelectRule()
        {
            string sql = "select rNo, rName from [Rule] where delYn = 'N';";
            SqlDataReader sdr = db.Reader(sql);
            bs = new BindingSource();
            hashtable = new Hashtable();
            hashtable.Add("0", "선택하세요.");
            while (sdr.Read())
            {
                hashtable.Add(sdr.GetInt32(0), sdr.GetString(1));
            }
            db.ReaderClose(sdr);
            bs.DataSource = hashtable;
            comboBox2.DataSource = bs;
            comboBox2.SelectedIndexChanged += Rule_click;
        }

        private void Member_click(object o, EventArgs a)
        {
            switch (comboBox1.SelectedValue.ToString()) {
                case "0":
                    return;
                default:
                    //MessageBox.Show(comboBox1.Text);
                    mNo = Convert.ToInt32(comboBox1.SelectedValue);
                    break;
            }
        }

        private void Rule_click(object o, EventArgs a)
        {
            switch (comboBox2.SelectedValue.ToString())
            {
                case "0":
                    return;
                default:
                    //MessageBox.Show(comboBox2.Text);
                    rNo = Convert.ToInt32(comboBox2.SelectedValue);
                    break;
            }
        }

        private void SelectMapping()
        {
            string sql = "SELECT [Mapping].mNo, [Member].mName, [Mapping].rNo, [Rule].rName FROM [Mapping] left outer join [Member] on ([Mapping].mNo = [Member].mNo and [Member].delYn = 'N') left outer join [Rule] on ([Mapping].rNo = [Rule].rNo and [Rule].delYn = 'N')  order by mNo;";
            SqlDataReader sdr = db.Reader(sql);

            listView.Clear();

            listView.Columns.Add("사용자번호", 100, HorizontalAlignment.Center);
            listView.Columns.Add("사용자명", 100, HorizontalAlignment.Center);
            listView.Columns.Add("권한번호", 100, HorizontalAlignment.Center);
            listView.Columns.Add("권한명", 100, HorizontalAlignment.Center);

            while (sdr.Read())
            {
                string[] arr = new string[sdr.FieldCount];
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    arr[i] = sdr.GetValue(i).ToString();
                }
                listView.Items.Add(new ListViewItem(arr));
            }
            db.ReaderClose(sdr);
        }

        //추가
        private void btn1_click(object sender, EventArgs e)
        {
            string sql = string.Format("select rNo, mNo from Mapping where rNo = {0} and mNo = {1};", rNo, mNo);
            SqlDataReader sdr = db.Reader(sql);

            bool check = true;

            while (sdr.Read())
            {
                check = false;
            }
            db.ReaderClose(sdr);

            if (check)
            {
                sql = string.Format("insert into [Mapping] values ({0},{1});", rNo, mNo);
                if (db.NonQuery(sql))
                {
                    MessageBox.Show("맵핑 추가 되었습니다.");
                }
                else
                {
                    MessageBox.Show("맵핑 추가 중 오류가 발생하였습니다.");
                }
            }
            else
            {
                MessageBox.Show("중복매핑 존재");
            }
            GetSelect();
            //MessageBox.Show(db.NonQuery(sql).ToString());
        }

        //삭제
        private void btn2_click(object sender, EventArgs e)
        {
            string sql = string.Format("delete from [Mapping] where rNo = {0} and mNo = {1};", rNo, mNo);
            if (db.NonQuery(sql))
            {
                MessageBox.Show("맵핑 삭제가 되었습니다.");
            }
            else
            {
                MessageBox.Show("맵핑 삭제 중 오류가 발생하였습니다.");
            }
            GetSelect();
        }


        private void listView_click(object o, EventArgs a)
        {
            ListView lv = (ListView)o;
            ListView.SelectedListViewItemCollection itemGroup = lv.SelectedItems;
            ListViewItem item = itemGroup[0];
        }
    }
}
