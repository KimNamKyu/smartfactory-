using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //IPAddress[] addr = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList;

            //foreach (var list in addr)
            //{
            //Console.WriteLine(list);
            //}
            //Console.WriteLine(addr[addr.Length - 1].ToString());

            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            string ip = "";
            for(int i = 0; i<host.AddressList.Length; i++)
            {
                if(host.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                {
                    ip = host.AddressList[i].ToString();
                }
            }
            Console.WriteLine("ip : {0} ", ip);
        }
    }
}
