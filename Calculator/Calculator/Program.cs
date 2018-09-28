using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            float num1, num2, num3;
            char mid;

            

            Console.WriteLine("연산을 할 두 수를 입력해주세요.");

            num1 = float.Parse(Console.ReadLine());
            num2 = float.Parse(Console.ReadLine());

            Console.WriteLine("어떤 연산자를 사용할지 입력하시오.");

            mid = char.Parse(Console.ReadLine());

            

            if (mid == '+')
            {
                num3 = num1 + num2;
            }
            else if (mid == '-')
            {
                num3 = num1 - num2;
            }
            else if (mid == '*')
            {
                num3 = num1 * num2;
            }
            else num3 = num1 / num2;

            Console.WriteLine("{0} {1} {2} = {3}", num1, mid, num2, num3);
        }
    }
}
