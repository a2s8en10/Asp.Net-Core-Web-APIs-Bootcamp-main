using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace longest_consecutive_sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] num = new int[5] { 4, 7, 8, 9, 5 };
            List<int> longest = new List<int>();

            for (int i = 0; i < num.Length - 1; i++)
            {
                if (num[i] < num[i + 1] && num[i + 1] == num[i] + 1)
                {
                    longest.Add(num[i]);
                    //longest.Add(num[i + 1]);
                }
            }
            foreach (int i in longest)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();
        }
    }
}
