using System;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Reverse(-123));
        }

        static int Reverse(int x)
        {
            var negative = false;
            if (x < 0)
            {
                x *= -1;
                negative = true;
            }

            var s = x.ToString().ToCharArray();
            Array.Reverse(s);

            try
            {
                return int.Parse((negative ? "-" : "") + new string(s));
            }
            catch
            {
                return 0;
            }
        }

        static int Reverse2(int x)
        {
            var result = 0;
            while (x != 0)
            {
                var lastN = x % 10;
                x /= 10;
                if (result > int.MaxValue / 10 || (result == int.MaxValue / 10) && lastN > 7) return 0;
                if (result < int.MinValue / 10 || (result == int.MinValue / 10 && lastN < -8)) return 0;
                result = result * 10 + lastN;
            }

            return result;
        }
    }
}
