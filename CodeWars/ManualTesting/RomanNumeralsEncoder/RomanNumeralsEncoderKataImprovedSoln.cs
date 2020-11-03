using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KataSolutions.RomanNumeralsEncoder
{
    public class RomanNumeralsEncoderKata
    {
        static Dictionary<string, int> numeralMap = new Dictionary<string, int>
            {
                { "M",  1000 },
                { "D", 500 },
                { "C", 100 },
                { "L", 50 },
                { "X", 10 },
                { "V", 5 },
                { "I", 1 },
            };

        public static string Solution(int n)
        {
            StringBuilder sb = new StringBuilder();

            // split n into 1000s, 100s, 10s, 1s
            string nString = n.ToString("0000");
            int thousands = int.Parse(nString[0].ToString()) * 1000;
            int hundreds = int.Parse(nString[1].ToString()) * 100;
            int tens = int.Parse(nString[2].ToString()) * 10;
            int ones = int.Parse(nString[3].ToString());

            for (int i = 0; i < nString.Length; i++)
            {
                int parsedVal = int.Parse(nString[i].ToString());
                int scaledByPow10 = (int)Math.Pow(10, (4 - (i + 1))) * parsedVal;

                if (parsedVal == 9 || parsedVal == 4)
                {
                    sb.Append(FindNumeralBySubtraction(scaledByPow10));
                }
                else
                {
                    sb.Append(FindNumeralByAddition(scaledByPow10));
                }
            }

            return $"{sb}";
        }

        public static string FindNumeralBySubtraction(int number)
        {
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<string, int> kvp in numeralMap)
            {
                int complement = numeralMap.Values.FirstOrDefault(x => kvp.Value - x == number);
                if (complement != 0)
                {
                    sb.Append(numeralMap.FirstOrDefault(x => x.Value == complement).Key);
                    sb.Append(kvp.Key);
                    break;
                }
            }

            return sb.ToString();
        }

        public static string FindNumeralByAddition(int number)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < numeralMap.Count; i++)
            {
                var divider = number / numeralMap.ElementAt(i).Value;
                var remainder = number % numeralMap.ElementAt(i).Value;
                if (divider != 0 && divider < 10)
                {
                    for (int j = 0; j < divider; j++)
                    {
                        sb.Append(numeralMap.ElementAt(i).Key);
                    }
                    if (remainder != 0)
                    {
                        KeyValuePair<string, int> nextElement = numeralMap.ElementAt(i + 1);
                        for (int j = 0; j < remainder / nextElement.Value; j++)
                        {
                            sb.Append(nextElement.Key);
                        }
                    }
                    break;
                }
            }

            return sb.ToString();
        }
    }
}
