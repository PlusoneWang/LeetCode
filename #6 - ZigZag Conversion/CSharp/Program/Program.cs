using System;
using System.Text;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            /**
            1   5   9
            2 4 6 8
            3   7
             */
            System.Console.WriteLine(Convert_CleanUp("123456789", 3));
        }

        static string Convert(string s, int numRows)
        {
            /**
            1       9
            2     8 10     16
            3   7   11   15
            4 6     12 14
            5       13
            
            timesPerCycle = numRows + numRows - 2 = 5 + 5 - 2 = 8
            row 1 => (index + 1) % 8 = 1
            row 2 => (index + 1) % 8 = 2 || (index + 1) % 8 = 0 index = 7 = (5-2)*2 + 1
            row 3 => (index + 1) % 8 = 3 || (index + 1) % 8 = 7 index = 6 = (4-2)*2 + 2
            row 4 => (index + 1) % 8 = 4 || (index + 1) % 8 = 6 index = 5 = (4-3)*2 + 3
            row 5 => (index + 1) % 8 = 5
            */

            if (numRows < 2)
                return s;

            var result = string.Empty;
            if (numRows == 2)
            {
                for (var i = 0; i < s.Length; i += 2)
                {
                    result += s[i];
                }
                if (s.Length > 1)
                {
                    for (var i = 1; i < s.Length; i += 2)
                    {
                        result += s[i];
                    }
                }

                return result;
            }

            var timesPerCycle = numRows + numRows - 2; // 一個循環的總個數
            var totalCycle = s.Length / timesPerCycle; // 總循環數
            var remainder = s.Length % timesPerCycle; // 剩餘無法組成一個循環的個數
            for (var i = 1; i <= numRows; i++)
            {
                var zs = string.Empty;
                for (int j = 0; j < totalCycle; j++)
                {
                    zs += s[j * timesPerCycle + i - 1];
                    if (i > 1 && i < numRows)
                    {
                        zs += s[j * timesPerCycle + ((numRows - i) * 2 + i - 1)];
                    }
                }

                if (i <= remainder)
                {
                    zs += s[totalCycle * timesPerCycle + i - 1];
                    if (numRows - i > 0 && (totalCycle * timesPerCycle) + ((numRows - i) * 2 + i - 1) < s.Length)
                        zs += s[totalCycle * timesPerCycle + ((numRows - i) * 2 + i - 1)];
                }

                result += zs;
            }

            return result;
        }

        static string Convert_CleanUp(string s, int numRows)
        {
            if (s.Length < 2 || numRows < 2)
                return s;

            var result = new StringBuilder();
            var perCycle = numRows + (numRows - 2);
            var cycle = s.Length / perCycle;
            var remainder = s.Length % perCycle;
            for (var i = 0; i < numRows; i++)
            {
                for (var j = 0; j < cycle; j++)
                {
                    result.Append(s[j * perCycle + i]);
                    if (i > 0 && i < numRows - 1)
                    {
                        result.Append(s[j * perCycle + ((numRows - 1) * 2 - i)]);
                    }
                }

                if (i < remainder)
                {
                    result.Append(s[cycle * perCycle + i]);
                    if (i > 0 && i < numRows - 1 && (cycle * perCycle + ((numRows - 1) * 2 - i)) < s.Length)
                    {
                        result.Append(s[cycle * perCycle + ((numRows - 1) * 2 - i)]);
                    }
                }
            }

            return result.ToString();
        }
    }
}
