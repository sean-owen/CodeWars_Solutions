using System;
using System.Collections.Generic;
using System.Text;

namespace KataSolutions.SharedBitCounter
{
    public static class SharedBitCounterKata
    {
        public static bool SharedBits(int a, int b)
        {
            int and = a & b;
            if (and > 0)
            {
                int conditionMet = 0;
                while (and > 0)
                {
                    conditionMet += and % 2;
                    if (conditionMet > 1)
                    {
                        return true;
                    }

                    and /= 2;
                }
            }
            return false;

        }
    }
}