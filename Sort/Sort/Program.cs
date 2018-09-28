using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("몇개의 숫자를 입력할 것인지 입력하세요.");

            int n = int.Parse(Console.ReadLine());

            int[] nums = new int[n];
            int[] results = new int[n];

            Console.WriteLine("정렬할 숫자를 입력해주세요.");

            for (int i=0;i<n;i++)
            {
                int num = int.Parse(Console.ReadLine());

                nums[i] = num;
            }

            Console.WriteLine("오름차순으로 정렬하고 하나씩 출력하세요.");

            for(int x=0;x<n;x++)
            {

            }

            
            

        }
    }
}
