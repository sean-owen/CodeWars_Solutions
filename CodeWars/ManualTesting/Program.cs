using ManualTesting.TwoSum;
using System;

namespace ManualTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] a = new int[] { 121, 144, 19, 161, 19, 144, 19, 11 };
            //int[] b = new int[] { 121, 14641, 20736, 36100, 25921, 361, 20736, 361 };
            int[] a = new int[] { 1, 1, 1 };
            int[] b = new int[] { 1, 1, 1 };

            bool result = Kata.comp(a, b);
            Console.WriteLine(result.ToString());
        }
    }    
}

