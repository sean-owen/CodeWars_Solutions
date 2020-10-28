using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManualTesting
{
    public class Kata
    {
        public static int[] TwoSum(int[] numbers, int target)
        {
            if (!numbers.Any())
                throw new ArgumentException();

            int[] complementsIndex = new int[2];

            for (int i = 0; i < numbers.Length; i++)
            {
                int complement = target - numbers[i];
                for (int j = i + 1;
                    j < (numbers.Length);
                    j++)
                {
                    if (numbers[j] == complement)
                    {
                        complementsIndex[0] = i;
                        complementsIndex[1] = j;
                        return complementsIndex;
                    }
                }
            }

            if (complementsIndex[0] == complementsIndex[1])
                throw new Exception();


            return complementsIndex;
        }
    }
}
