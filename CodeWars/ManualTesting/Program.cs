using KataSolutions.TwoSum;
using System;
using System.Linq;
using System.Text;

namespace KataSolutions
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] n = new int[]{ 1, 2, 2 };

            var qwerty = n.Select(x => x * x).ToArray().Sum();

            Console.WriteLine();

        }
    }    
}

