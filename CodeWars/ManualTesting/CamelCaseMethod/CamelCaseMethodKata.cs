using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KataSolutions.CamelCaseMethod
{
    public static class CamelCaseMethodKata
    {
        public static string CamelCase(this string str)
        {
            string camelCased = string.Empty;
            string[] wordsArray = str.Split(' ');

            foreach(string word in wordsArray)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    if(i == 0)
                    {
                        camelCased += word.ToUpper()[i];
                    }
                    else
                    {
                        camelCased += word.ToLower()[i];
                    }
                }
            }
            return camelCased;
        }
    }
}
