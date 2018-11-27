using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Class1
    {
        void Main()
        {
            /*
            int Coin = 10;
            Console.WriteLine("주머니에는 동전이 {0}개 들어있습니다.",Coin);

            Console.WriteLine("어머니는 몇개의 동전을 주머니에 넣었나요?");
            string momCoin = Console.ReadLine();
            int numCoin1 = int.Parse(momCoin);  //어머니가 넣은 동전 수

            Console.WriteLine("아람이는 몇개의 동전을 꺼냈나요?");
            string aramCoin = Console.ReadLine();
            int numCoin2 = int.Parse(aramCoin);

            Console.WriteLine("우람이는 몇개의 동전을 꺼냈나요?");
            string uramCoin = Console.ReadLine();
            int numCoin3 = int.Parse(uramCoin);

            Coin = Coin + numCoin1 - numCoin2 - numCoin3;
            Console.WriteLine("주머니에 남아 있는 동전의 개수는 {0}개입니다.",Coin);
            

            Console.WriteLine("첫번째 숫자를 입력하세요");
            string num1 = Console.ReadLine();
            double number1 = double.Parse(num1);
            Console.WriteLine("두번째 숫자를 입력하세요");
            string num2 = Console.ReadLine();
            double number2 = double.Parse(num2);
            Console.WriteLine("연산자를 입력하세요 ");
            string inputoperator = Console.ReadLine();
            if(inputoperator == "+")
            {
                Console.WriteLine("{0} + {1} = {2}",num1,num2, num1 + num2);
            }
            else if(inputoperator == "-")
            {
                Console.WriteLine("{0} - {1} = {2}", num1, num2, number1 - number2);
            }
           

            int userInput = Convert.ToInt32(Console.ReadLine());

            if (userInput > 20 && userInput % 3 == 0) Console.WriteLine("20보다 큰 3의 배수입니다.");
            
            Console.WriteLine("학생 숫자를 입력하세요");
            int studentCount = int.Parse(Console.ReadLine());

            int[] ages = new int[studentCount];
            string[] names = new string[studentCount];
            double[] height = new double[studentCount];
            double[] weight = new double[studentCount];

            Console.WriteLine("몇 번째 학생의 정보를 추가 할까요?");
            int studentNumber = int.Parse(Console.ReadLine());

            if(studentNumber >= 0 && studentNumber <= studentCount -1)
            {
                Console.WriteLine("나이를 입력하세요");
                ages[studentNumber] = int.Parse(Console.ReadLine());

                Console.WriteLine("이름을 입력하세요");
                names[studentNumber] = Console.ReadLine();

                Console.WriteLine("키를 입력하세요");
                height[studentNumber] = double.Parse(Console.ReadLine());

                Console.WriteLine("몸무게를 입력하세요");
                weight[studentNumber] = double.Parse(Console.ReadLine());

                Console.Write(studentNumber);
                Console.WriteLine("번째 학생");
                Console.Write("이름 : ");
                Console.WriteLine(names[studentNumber]);
                Console.Write("나이 : ");
                Console.WriteLine(ages[studentNumber]);
                Console.Write("키 : ");
                Console.WriteLine(height[studentNumber]);
                Console.Write("몸무게 : ");
                Console.WriteLine(weight[studentNumber]);
            }
            

            //국어 영어 수학 과학 사회 점수를 입력받아 총점 평균을 구하는 프로그램
            //점수에 배열을 사용
            // 과목별 변수를 생성하지 않고 바로 점수 배열에 insert할 경우 컴퓨터가 효율적이다.
            int Count = 5;
            double[] score = new double[Count];

            Console.WriteLine("국어점수를 입력하세요");
            score[0] = double.Parse(Console.ReadLine());

            Console.WriteLine("영어점수를 입력하세요");
            score[1] = double.Parse(Console.ReadLine());

            Console.WriteLine("수학점수를 입력하세요");
            score[2] = double.Parse(Console.ReadLine());

            Console.WriteLine("과학점수를 입력하세요");
            score[3] = double.Parse(Console.ReadLine());

            Console.WriteLine("사회점수를 입력하세요");
            score[4] = double.Parse(Console.ReadLine());

            double sum = score[0] + score[1] + score[2] + score[3] + score[4];
            double ave = sum / Count;

            Console.Write("총점 : ");
            Console.WriteLine(sum);
            Console.Write("평균 : ");
            Console.WriteLine(ave);
            

            //반복문 While 특정조건이 발생할때 까지 반복

            int passcodeIndex = 0; //시작
            int[] userInput = new int[6];
            while (passcodeIndex <= 5)
            {
                Console.Write(passcodeIndex + 1);
                Console.WriteLine("번째 숫자를 넣어주세요");
                userInput[passcodeIndex] = int.Parse(Console.ReadLine());
                passcodeIndex += 1;
            }
            Console.Write("비밀번호 : ");
            for(int i = 0; i<userInput.Length; i++)
            {
                Console.Write(userInput[i]);
            }
            

            //심화 8-2
            /************************************************************************
             * 먼저 총학생 수를 입력받고 
             * 각학생마다 국어 영어 수학 점수 각각 입력 받는다.
             * 입력받은 점수를 계산해서 각 학생의 총점과 평균을 구하는 프로그램 작성
             * *********************************************************************

            Console.WriteLine("학생수를 입력하세요");
            int totalStudentNumber = int.Parse(Console.ReadLine()); // 총학생수 입력
            int studentIndex = 0;
            double[] koreanScores = new double[totalStudentNumber];
            double[] englishScores = new double[totalStudentNumber];
            double[] mathScores = new double[totalStudentNumber];

            while(studentIndex < totalStudentNumber)
            {
                Console.Write(studentIndex + 1);
                Console.WriteLine("번째 학생입니다.");

                Console.WriteLine("국어점수를 입력하세요 : ");
                koreanScores[studentIndex] = double.Parse(Console.ReadLine());

                Console.WriteLine("영어점수를 입력하세요 : ");
                englishScores[studentIndex] = double.Parse(Console.ReadLine());

                Console.WriteLine("수학점수를 입력하세요 : ");
                mathScores[studentIndex] = double.Parse(Console.ReadLine());

                Console.Write("총점 : ");
                double totalsum = koreanScores[studentIndex] + englishScores[studentIndex] + mathScores[studentIndex];
                Console.WriteLine(totalsum);

                Console.Write("평균 : ");
                double totalave = totalsum / 3;
                Console.WriteLine(totalave);
                Console.WriteLine();
                studentIndex += 1;
            }
            */

            //비밀번호 맞추기 for문 사용 
            /*
            int[] passcodeNumbers = { 6, 2, 1, 9, 4, 7 };

            int passcodeLength = 6;
            int[] userInput = new int[passcodeLength];

            for(int passcodeTryCount = 0; passcodeTryCount < 5; passcodeTryCount++) //시도
            {
                for(int passcodeIndext = 0; passcodeIndext < passcodeLength; passcodeIndext++)
                {
                    Console.Write(passcodeIndext + 1);
                    Console.WriteLine("번째 숫자를 넣어주세요.");
                    userInput[passcodeIndext] = int.Parse(Console.ReadLine());
                }
                bool isPasswordCorrect = true;
                for(int passcodeIndex = 0; passcodeIndex < passcodeLength; passcodeIndex++)
                {
                    if (userInput[passcodeIndex] != passcodeNumbers[passcodeIndex])
                    {
                        isPasswordCorrect = false;
                        Console.WriteLine("비밀번호가 틀렸습니다.");
                        break;
                    }
                }
                if(isPasswordCorrect)
                {
                    Console.WriteLine("문이 열렸습니다.");
                    break;
                }
            }
            */
            

        }
    }
}
