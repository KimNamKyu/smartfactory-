using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] a = new int[9, 9];
            int aa = 3;
           //for(int i = 9; i>0; i = i - aa)
           // {
           //     Console.WriteLine("{0} {1} {2}",i,(i-1),(i-2));
           // }
           for(int i = 0; i<9; i= i+ aa)
            {
                Console.WriteLine("{0} {1} {2}", i, (i - 1), (i - 2));
            }
        }
    }
}
