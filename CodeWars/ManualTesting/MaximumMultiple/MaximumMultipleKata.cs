using System;
using System.Collections.Generic;
using System.Text;

namespace KataSolutions.MaximumMultiple
{
    public static class MaximumMultipleKata
    {
        public static int MaxMultiply(int divisor, int bound)
        {
            //Do some magic
            int multiplier = 0;
            int maxDivisor = divisor;
            while (maxDivisor < bound)
            {
                maxDivisor = multiplier * divisor;
                multiplier++;
            }

            return maxDivisor == bound ? maxDivisor : maxDivisor - divisor;
        }
    }
}
