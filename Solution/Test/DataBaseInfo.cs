using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public static class DataBaseInfo
    {
        public static string TestDBInfo()
        {
            return string.Format("server={0};uid={1};password={2};database={3};", "(localdb)\\ProjectsV13", "root", "1234", "Test");
        }

        public static string RealDBInfo()
        {
            return string.Format("server={0};uid={1};password={2};database={3};", "(localdb)\\ProjectsV13", "root", "1234", "Real");
        }
    }
}
