using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = "dddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd";
            System.Console.WriteLine(LongestPalindrome(s));
        }

        static string LongestPalindrome(string s)
        {
            if (s == null || s.Length == 0)
            {
                return "";
            }

            var result = s[0].ToString();
            var hashSetOfIndex = new Dictionary<char, List<int>>();
            int start = 0, end = 0;
            for (var i = 0; i < s.Length; i++)
            {
                // current char
                var c = s[i];

                // The index list witch store all position of c in string s.
                List<int> indexSet;

                if (hashSetOfIndex.TryGetValue(c, out indexSet))
                {
                    indexSet.Add(i);
                }
                else
                {
                    indexSet = new List<int>();
                    indexSet.Add(i);
                    hashSetOfIndex.Add(c, indexSet);
                }

                if (indexSet.Count == 1)
                    continue;

                int localStart = 0, localEnd = 0;
                // check if substring is palindromic between index indexSet[j] to i.
                for (int j = 0; j < indexSet.Count - 1; j++)
                {
                    var currentStepIndex = indexSet[j];
                    var index = currentStepIndex;
                    if (i - index == 1)
                    {
                        localStart = index;
                        localEnd = i;
                        break;
                    }

                    var isBreak = false;

                    var endIndex = currentStepIndex + ((i - currentStepIndex) / 2);
                    for (; index < endIndex + 1; index++)
                    {
                        var expectIndex = i - (index - currentStepIndex);
                        if (s[index] == s[expectIndex])
                        {
                            continue;
                        }

                        isBreak = true;
                        break;
                    }

                    if (isBreak)
                    {
                        continue;
                    }

                    localStart = currentStepIndex;
                    localEnd = i;

                    break;
                }


                if (localEnd - localStart > end - start)
                {
                    start = localStart;
                    end = localEnd;
                }
            }

            return s.Substring(start, end - start + 1);
        }

        static string LongestPalindrome2(string s)
        {
            if (s == null || s.Length < 1) return "";
            int start = 0, end = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int len1 = expandAroundCenter(s, i, i);
                int len2 = expandAroundCenter(s, i, i + 1);
                int len = Math.Max(len1, len2);
                if (len > end - start)
                {
                    start = i - (len - 1) / 2;
                    end = i + len / 2;
                }
            }

            return s.Substring(start, end - start + 1);
        }

        private static int expandAroundCenter(string s, int left, int right)
        {
            int L = left, R = right;
            while (L >= 0 && R < s.Length && s[L] == s[R])
            {
                L--;
                R++;
            }

            return R - L - 1;
        }
    }
}
