using System;
using System.Collections.Generic;
using System.Text;

namespace KataSolutions.OnesAndZeros
{
    public class OnesAndZerosKata
    {
        public static int binaryArrayToNumber(int[] BinaryArray)
        {
            //Code here
            int index = BinaryArray.Length - 1;
            double output = 0;
            foreach(int entry in BinaryArray)
            {
                if (entry == 1)
                {
                    output += Math.Pow(2, index);
                }
                index--;
            }

            return (int)output;
        }
    }
}
