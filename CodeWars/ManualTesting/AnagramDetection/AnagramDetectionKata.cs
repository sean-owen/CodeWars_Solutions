using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace KataSolutions.AnagramDetection
{
    public class AnagramDetectionKata
    {
        public static bool IsAnagram(string test, string original)
        {
            bool result = false;
            // your code goes here
            int testLength = test.Count();
            int originalLength = original.Count();

            if (testLength == originalLength)
            {
                result = true;
                List<char> testList = test.ToLower().ToCharArray().ToList();
                testList.Sort();

                List<char> originalList = original.ToLower().ToCharArray().ToList();
                originalList.Sort();

                for (int i = 0; i < testLength; i++)
                {
                    if (testList[i] != originalList[i])
                    {
                        result = false;
                        break;
                    }
                }

            }



            return result;
        }
    }
}
