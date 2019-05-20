using System;
using System.Collections.Generic;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var sampleString = "abcabcbb";
            var length = GetLongestSubstring1(sampleString);
            var length2 = GetLongestSubstring2(sampleString);
            System.Console.WriteLine(length);
            System.Console.WriteLine(length2);
        }

        /// <summary>
        /// Normal Solution: loop all the string.
        /// </summary>
        /// <param name="target">targent string</param>
        /// <returns>Longenest Substring</returns>
        static int GetLongestSubstring1(string target)
        {
            var currentString = "";
            var currentLongest = 0;

            for (var i = 0; i < target.Length; i++)
            {
                var index = currentString.IndexOf(target[i]);
                if (index > -1)
                {
                    currentString = currentString.Substring(index + 1);
                }

                currentString += target[i];
                if (currentString.Length > currentLongest)
                {
                    currentLongest++;
                }
            }

            return currentLongest;
        }

        static int GetLongestSubstring2(string target)
        {
            var hashSet = new Dictionary<char, int>();
            int l = target.Length, m = 0;
            for (int i = 0, j = 0; j < l; j++)
            {
                if (hashSet.TryGetValue(target[j], out var index))
                {
                    i = Math.Max(index + 1, i);
                }

                m = Math.Max(m, j - i + 1);
                hashSet[target[j]] = j;
            }

            return m;
        }
    }
}
