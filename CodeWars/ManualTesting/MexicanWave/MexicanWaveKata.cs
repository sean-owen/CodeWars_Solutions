using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KataSolutions.MexicanWave
{
    public class MexicanWaveKata
    {
        public List<string> Wave(string str)
        {
            str = str.ToLower();            
            List<string> strWaveList = new List<string>();

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != ' ')
                {
                    char[] strArray = str.ToCharArray();
                    strArray[i] = Char.ToUpper(strArray[i]);
                    strWaveList.Add(new string(strArray));
                }
            }

            return strWaveList;
        }
    }
}
