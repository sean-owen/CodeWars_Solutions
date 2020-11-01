using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KataSolutions
{
    public class Kata
    {
        // Got there in the end! Had to peak tests that were being run though.
        public static bool comp(int[] a, int[] b)
        {
            bool output = true;

            if (a == null || b == null)
            {
                return false;
            }

            if (!a.Any() && b.Any())
            {
                return false;
            }
            if (a.Any() && !b.Any())
            {
                return false;
            }
            if (!a.Any() && !b.Any())
            {
                return true;
            }

            var aList = new List<int>(a);

            for (int i = 0; i < b.Length; i++)
            {
                int squareRootValue = (int)Math.Sqrt((double)b[i]);
                if (!aList.Contains(squareRootValue))
                {
                    output = false;
                }
                else
                {
                    aList.Remove(squareRootValue);
                }
            }

            return output;
        }

    }
}
