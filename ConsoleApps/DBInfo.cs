using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApps
{
    //멤버 클래스 활용
    public class DBInfo
    {
        public string server, uid, password, database;

        public DBInfo()
        {
            server = "(localdb)\\ProjectsV13";
            uid = "root";
            password = "1234";
            database = "Tes2";
        }

        public Hashtable GetDB()
        {
            Hashtable db = new Hashtable();
            db.Add("server",server);
            db.Add("uid",uid);
            db.Add("password",password);
            db.Add("database",database);

            return db;
        }
    }
}
