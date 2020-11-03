using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KataSolutions.RomanNumeralsEncoder
{
    public class RomanNumeralsEncoderKataFirstSoln
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


        public static string FirstSolution(int n)
        {
            string nString = n.ToString("0000");
            StringBuilder romanNumeral = new StringBuilder();

            // index 0 of nstring
            if (nString[0] != '0')
            {
                int desiredValue = int.Parse(nString[0].ToString()) * 1000;
                bool shouldBreak = false;
                foreach (int value in numeralMap.Values)
                {
                    int complement = numeralMap.Values.FirstOrDefault(x => (value - x) == (desiredValue));
                    if (complement != 0)
                    {
                        romanNumeral.Append(numeralMap.FirstOrDefault(x => x.Value == complement).Key);
                        romanNumeral.Append(numeralMap.FirstOrDefault(x => x.Value == value).Key);
                        shouldBreak = true;
                    }

                    if (shouldBreak)
                    {
                        break;
                    }
                }

                if (!shouldBreak)
                {
                    for (int i = 0; i < (desiredValue / 1000); i++)
                    {
                        romanNumeral.Append("M");
                    }
                    shouldBreak = true;
                }
            }


            // index 1 of nstring
            if (nString[1] != '0')
            {
                int desiredValue = int.Parse(nString[1].ToString()) * 100;
                bool shouldBreak = false;
                foreach (int value in numeralMap.Values)
                {

                    int complement = numeralMap.Values.FirstOrDefault(x => (value - x) == (desiredValue));
                    if (complement != 0)
                    {
                        if (complement == 500 && value == 1000)
                            continue;

                        romanNumeral.Append(numeralMap.FirstOrDefault(x => x.Value == complement).Key);
                        romanNumeral.Append(numeralMap.FirstOrDefault(x => x.Value == value).Key);
                        shouldBreak = true;
                    }

                    if (shouldBreak)
                    {
                        break;
                    }
                }

                if (!shouldBreak)
                {
                    var fiveHundredth = desiredValue / 500;
                    var fiveHundredthRemainder = desiredValue % 500;
                    if (fiveHundredth != 0)
                    {
                        for (int i = 0; i < fiveHundredth; i++)
                        {
                            romanNumeral.Append("D");
                        }
                        shouldBreak = true;
                    }

                    if (fiveHundredthRemainder != 0)
                    {
                        for (int i = 0; i < fiveHundredthRemainder / 100; i++)
                        {
                            romanNumeral.Append("C");
                        }
                        shouldBreak = true;
                    }
                }
            }


            // index 2 of nstring
            if (nString[2] != '0')
            {
                int desiredValue = int.Parse(nString[2].ToString()) * 10;
                bool shouldBreak = false;

                foreach (int value in numeralMap.Values)
                {
                    int complement = numeralMap.Values.FirstOrDefault(x => (value - x) == (desiredValue));
                    if (complement != 0)
                    {
                        if (value == 100 && complement == 50)
                            continue;

                        romanNumeral.Append(numeralMap.FirstOrDefault(x => x.Value == complement).Key);
                        romanNumeral.Append(numeralMap.FirstOrDefault(x => x.Value == value).Key);
                        shouldBreak = true;
                    }

                    if (shouldBreak)
                    {
                        break;
                    }
                }
                if (!shouldBreak)
                {
                    var fiftieth = desiredValue / 50;
                    var fiftiethRemainder = desiredValue % 50;
                    if (fiftieth != 0)
                    {
                        for (int i = 0; i < fiftieth; i++)
                        {
                            romanNumeral.Append("L");
                        }
                        shouldBreak = true;
                    }

                    if (fiftiethRemainder != 0)
                    {
                        for (int i = 0; i < fiftiethRemainder / 10; i++)
                        {
                            romanNumeral.Append("X");
                            shouldBreak = true;
                        }
                    }
                }
            }


            // index 3 of nstring
            if (nString[3] != '0')
            {
                int desiredValue = int.Parse(nString[3].ToString());
                bool numeralsFound = false;
                foreach (int value in numeralMap.Values)
                {

                    int complement = numeralMap.Values.FirstOrDefault(x => (value - x) == desiredValue);
                    if (complement != 0)
                    {
                        if (value == 10 && complement == 5)
                            continue;

                        romanNumeral.Append(numeralMap.FirstOrDefault(x => x.Value == complement).Key);
                        romanNumeral.Append(numeralMap.FirstOrDefault(x => x.Value == value).Key);
                        numeralsFound = true;
                    }

                    if (numeralsFound)
                    {
                        break;
                    }
                }

                if (!numeralsFound)
                {
                    var fifth = desiredValue / 5;
                    var fifthRemainder = desiredValue % 5;
                    if (fifth != 0)
                    {
                        for (int i = 0; i < fifth; i++)
                        {
                            romanNumeral.Append("V");
                        }
                        numeralsFound = true;
                    }

                    if (fifthRemainder != 0)
                    {
                        for (int i = 0; i < fifthRemainder; i++)
                        {
                            romanNumeral.Append("I");
                        }
                        numeralsFound = true;
                    }
                }
            }

            return romanNumeral.ToString();
        }

    }
}
