using System;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsPalindrome3(131));
        }

        static bool IsPalindrome(int x)
        {
            if (x < 0) return false;
            var reverse = x.ToString().ToCharArray();
            Array.Reverse(reverse);
            return x.ToString() == new string(reverse);
        }

        static bool IsPalindrome2(int x)
        {
            if (x < 0) return false;
            var digits = (int)Math.Log10(x) + 1;
            if (digits == 1) return true;
            var i = 1;
            while (digits > i)
            {
                var l = x / (int)Math.Pow(10, digits - 1);
                var r = (x % (int)Math.Pow(10, i)) / (int)Math.Pow(10, i - 1);
                if (l != r) return false;
                x = x - (r * (int)Math.Pow(10, i - 1)) - (l * (int)Math.Pow(10, digits - 1));
                digits--;
                i++;
            }

            return true;
        }

        static bool IsPalindrome3(int x)
        {
            if (x < 0 || (x % 10 == 0 && x != 0))
            {
                return false;
            }
            var reverse = 0;
            while (reverse < x)
            {
                reverse = reverse * 10 + x % 10;
                x = x / 10;
            }

            return reverse == x || reverse/10 == x;
        }
    }
}
