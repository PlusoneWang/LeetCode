using System;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            var watch = new Stopwatch();
            watch.Start();
            var nums = TwoSum(new[] { 11, 15, 2, 7 }, 9);
            watch.Stop();
            System.Console.WriteLine(JsonConvert.SerializeObject(nums));
            System.Console.WriteLine(watch.Elapsed);
            System.Console.WriteLine("-----------");
            watch.Restart();
            var nums2 = TwoSum(new[] { 3, 3 }, 6);
            watch.Stop();
            System.Console.WriteLine(JsonConvert.SerializeObject(nums2));
            System.Console.WriteLine(watch.Elapsed);
            System.Console.WriteLine("-----------");
        }

        public static int[] TwoSum(int[] nums, int target)
        {
            var dictionary = new Dictionary<int, int>();
            for (var i = 0; i < nums.Length; i++)
            {
                if (dictionary.TryGetValue(target - nums[i], out var val))
                {
                    if (val != i)
                        return new int[] { val, i };
                }
                if (!dictionary.TryAdd(nums[i], i))
                {
                    dictionary[nums[i]] = i;
                }
            }

            return new int[0];
        }
    }
}
