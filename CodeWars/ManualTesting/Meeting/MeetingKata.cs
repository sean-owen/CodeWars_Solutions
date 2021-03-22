using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KataSolutions.Meeting
{
    public class MeetingKata
    {
        public static string Meeting(string s)
        {
            List<string> namesList = s.ToUpper().Split(';').ToList();
            namesList.Sort();

            var sortedNamesList = new List<string>();

            foreach (var fullName in namesList)
            {
                string[] myArray = fullName.Split(':');
                sortedNamesList.Add($"{myArray[1]}, {myArray[0]}");
            }
            sortedNamesList.Sort();

            StringBuilder sb = new StringBuilder();
            foreach (var fullName in sortedNamesList)
            {
                sb.Append($"({fullName})");
            }

            return sb.ToString();
        }
    }
}
