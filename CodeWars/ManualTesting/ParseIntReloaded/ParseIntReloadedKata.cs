using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KataSolutions.ParseIntReloaded
{
    public class ParseIntReloadedKata
    {
        static Dictionary<string, int> textNumberPairs = new Dictionary<string, int>()
        {
            { "one", 1 },
            { "two", 2 },
            { "three", 3 },
            { "four", 4 },
            { "five", 5 },
            { "six", 6 },
            { "seven", 7 },
            { "eight", 8 },
            { "nine", 9 },

            { "ten", 10 },
            { "eleven", 11 },
            { "twelve", 12 },
            { "thirteen", 13 },
            { "fourteen", 14 },
            { "fifteen", 15 },
            { "sixteen", 16 },
            { "seventeen", 17 },
            { "eighteen", 18 },
            { "nineteen", 19 },
            { "twenty", 20 },

            { "thirty", 30 },
            { "forty", 40 },
            { "fifty", 50 },
            { "sixty", 60 },
            { "seventy", 70 },
            { "eighty", 80 },
            { "ninety", 90 },
        };

        static Dictionary<string, int> textNumberMultipliers = new Dictionary<string, int>()
        {
            { "hundred", 100 },

            { "thousand", 1000 },

            { "million", 1000000 },
        };

        // TODO - consider how this could be simplified
        public static int ParseInt(string s)
        {
            string[] splitInput = s.Split(' ');
            int output = 0;
            int sumWithOutput = 0;
            var usedMultipliers = new List<int>();

            for (int i = 0; i < splitInput.Length; i++)
            {
                string valueLCase = splitInput[i].ToLower();
                if (valueLCase != "and")
                {
                    string[] splitValue = valueLCase.Split('-');
                    for (int j = 0; j < splitValue.Length; j++)
                    {
                        if (textNumberPairs.ContainsKey(splitValue[j]))
                        {
                            sumWithOutput += textNumberPairs[splitValue[j]];
                        }

                        if (textNumberMultipliers.ContainsKey(splitValue[j]))
                        {
                            int indexValue = textNumberMultipliers[splitValue[j]];
                            if (usedMultipliers.FirstOrDefault(x => x > indexValue) != 0)
                            {
                                sumWithOutput *= textNumberMultipliers[splitValue[j]];
                                output += sumWithOutput;
                                sumWithOutput = 0;
                            }
                            else
                            {
                                usedMultipliers.Add(indexValue);

                                output += sumWithOutput;
                                sumWithOutput = 0;

                                output = output * indexValue;
                            }
                        }
                    }
                }
            }

            output += sumWithOutput;
            return output;
        }
    }
}
