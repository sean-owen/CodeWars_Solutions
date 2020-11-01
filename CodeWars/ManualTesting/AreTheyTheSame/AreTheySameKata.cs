using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KataSolutions.TwoSum
{
    public class AreTheySameKata
    {
        // Got there in the end! Had to peak tests that were being run though.

        // Test 1a in Sample tests was the problem. From the description I did not comprehend that the values
        // in array 'a' squared had to have a unique match in array 'b'

        // This meant if a[0] * a[0] == b[0] was true
        // then a[0] * a[0] could not match to any other member of array b!

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
