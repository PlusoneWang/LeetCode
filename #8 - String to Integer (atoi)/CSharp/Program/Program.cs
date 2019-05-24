using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = int.MaxValue;
            Console.WriteLine(MyAtoi2(" -2147483647 asdfabce"));
        }

        static int MyAtoi(string str)
        {
            str = str.Trim();
            Regex pattern = new Regex(@"^([\\+|\\-]*)([0-9]{1,})");
            Match match = pattern.Match(str);
            if (match.Groups[2].Value.Length == 0)
                return 0;
            var prefix = match.Groups[1].Value;
            if (prefix.Length > 1)
            {
                return 0;
            }

            var numbers = prefix + match.Groups[2].Value;

            try
            {
                return Convert.ToInt32(numbers);
            }
            catch (OverflowException exception)
            {
                if (prefix == "-") return int.MinValue;
                return int.MaxValue;
            }
            catch (FormatException exception)
            {
                return 0;
            }
        }

        static int MyAtoi2(string str)
        {
            // always: break when find out non-number char
            // step 0: ignore whitespace and find plus or minus
            // step 1: find out numbers, or break
            int step = 0;
            int start = 0, end = -1;
            bool positive = true;

            for (var i = 0; i < str.Length; i++)
            {
                var c = str[i];
                if (step == 0)
                {
                    if (c == 32)
                    {
                        // ignore whitespace in step 1
                        continue;
                    }

                    if (c == 43 || c == 45)
                    {
                        positive = c == 43;
                        start = i + 1;
                        step = 1;
                        continue;
                    }

                    if (c >= 48 && c <= 57)
                    {
                        step = 1;
                        start = end = i;
                        continue;
                    }

                    return 0;
                }

                if (step == 1)
                {
                    if (c >= 48 && c <= 57)
                    {
                        end = i;
                        continue;
                    }

                    break;
                }
            }

            if (end < start)
            {
                return 0;
            }

            var s = str.Substring(start, end - start + 1);
            var cs = s.ToCharArray();
            var result = 0;
            for (var i = 0; i < cs.Length; i++)
            {
                var num = cs[i] - 48;
                if (positive && (result > int.MaxValue / 10 || (result == int.MaxValue / 10 && (num > 7)))) return int.MaxValue;
                if (!positive && ((result * -1) < int.MinValue / 10 || (result * -1 == int.MinValue / 10 && num > 8))) return int.MinValue;
                result = result * 10 + num;
            }

            return positive ? result : result * -1;
        }
    }
}
