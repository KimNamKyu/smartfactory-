using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Class2
    {
        static void Main()
        {
            /*
            //숫자 맞추기 게임
            Random rand = new Random();
            int num = rand.Next(1, 101);
            Console.WriteLine(num);

            while (true)
            {
                Console.WriteLine("숫자를 입력하세요");
                int input = int.Parse(Console.ReadLine());

                if (input > num) Console.WriteLine("더 작은 숫자입니다.");
                else if (input < num) Console.WriteLine("더 큰 숫자입니다.");
                else
                {
                    Console.WriteLine("정답입니다.");
                    break;
                }
            }
            */

            //가위바위보 게임
            Random rand = new Random();
            int num = rand.Next(1, 4);

            while (true)
            {
                Console.WriteLine("1,2,3 중 하나를 고르세요");
                int input = int.Parse(Console.ReadLine());

                if (num - input == 0) Console.WriteLine("무승부입니다");
                else if(num - input == -1 || num - input == 2)
                {
                    Console.WriteLine("졌습니다");
                    break;
                }else if(num - input == -2 || num - input == -1)
                {
                    Console.WriteLine("이겼습니다.");
                    break;
                }
            }
        }
    }
}
