using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    [TestClass]
    class Program
    {
        [TestMethod]
        static void Main(string[] args)
        {
            /**********************************************
             *  from : 찾을 데이터 ( 배열 변수 )
             *  where : 조건식
             *  order by : 정렬
             *  select : 가져올 항목
             **********************************************/

            int[] nums = new int[9]
            {
                1,2,3,4,5,6,7,8,9
            };

            IEnumerable<int> numQuery = from num in nums where (num % 3) == 0 select num;
            
            foreach (var item in numQuery)
            {
                Console.WriteLine(item);
            }

            string[] strs = new string[] {"asp", "mes", "cloud", ".net", "web" };
            var strQuery = from str in strs where str.Length == 3 select str;
            foreach (var item in strQuery)
            {
                Console.WriteLine(item);
            }

            List<Test> tests = new List<Test>
            {
                 new Test {Name = "asp", age = 5},
                 new Test {Name = "web", age = 15},
                 new Test {Name = "core", age = 25},
                 new Test {Name = "net", age = 35},
            };
            Console.WriteLine("===========================================");
            var listQuery = from test in tests where test.age > 10 orderby test.Name descending select test.Name;

            foreach (var name in listQuery)
            {
                Console.WriteLine(name);
            }

        }
        [TestClass]
        public class Test
        {
            public string Name { get; set; }
            public int age { get; set; }
        }
    }
}
