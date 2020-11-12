using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace KataSolutions.SumStringsAsNumbers
{
    public class SumStringsAsIntsKata
    {
        public static string sumStrings(string a, string b)
        {
            BigInteger.TryParse(a, out BigInteger i);
            BigInteger.TryParse(b, out BigInteger j);

            var output = i + j;
            return $"{output}";
        }
    }
}
