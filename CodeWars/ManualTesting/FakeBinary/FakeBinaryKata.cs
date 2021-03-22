using System;
using System.Collections.Generic;
using System.Text;

namespace KataSolutions.FakeBinary
{
    public class FakeBinaryKata
    {
        public static string FakeBin(string x)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var letter in x)
            {
                if (Char.GetNumericValue(letter) < 5)
                {
                    sb.Append("0");
                }
                else
                {
                    sb.Append("1");
                }
            }
            return sb.ToString();
        }
    }
}
