﻿using System;
using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        class MSsql
        {
            private SqlConnection conn;
            public bool status;

            public MSsql()
            {
                status = Connection();
            }

            private bool Connection()
            {
                string host = "(localdb)\\ProjectsV13";
                string user = "root";
                string password = "1234";
                string db = "gdc";

                string connStr = string.Format("server={0};uid={1};password={2};database={3}", host, user, password, db);
                SqlConnection conn = new SqlConnection(connStr);

                try
                {
                    conn.Open();
                    this.conn = conn;
                    //MessageBox.Show("MS-SQL 연결 성공!");
                    return true;
                }
                catch
                {
                    conn.Close();
                    this.conn = null;
                    //MessageBox.Show("MS-SQL 연결 실패!");
                    return false;
                }
            }

            public bool ConnectionClose()
            {
                try
                {
                    conn.Close();
                    //MessageBox.Show("MS-SQL 연결끊기 성공!");
                    return true;
                }
                catch
                {
                    //MessageBox.Show("MS-SQL 연결끊기 실패!");
                    return false;
                }
            }

            public bool NonQuery(string sql)
            {
                try
                {
                    if (status)
                    {
                        SqlCommand comm = new SqlCommand(sql, conn);
                        comm.ExecuteNonQuery();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;
                }
            }

            public SqlDataReader Reader(string sql)
            {
                try
                {
                    if (status)
                    {
                        SqlCommand comm = new SqlCommand(sql, conn);
                        return comm.ExecuteReader();
                    }
                    else
                    {
                        return null;
                    }
                }
                catch
                {
                    return null;
                }
            }

            public void ReaderClose(SqlDataReader reader)
            {
                reader.Close();
            }

            [TestMethod]
            public void MS()
            {
                System.Console.WriteLine("1111");
                Assert.AreEqual(1, "22");
            }
        }
    }
}
