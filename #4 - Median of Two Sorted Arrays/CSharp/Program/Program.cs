using System;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1 2 2 3 4 4 5 6 8 10 11 12
            // the median should be (4 + 5)/2 = 4.5
            var testCase1Nums1 = new int[] { 1, 2, 3, 4, 5 };
            var testCase1Nums2 = new int[] { 2, 4, 6, 8, 10, 11, 12 };

            System.Console.WriteLine(FindMedianSortedArrays(testCase1Nums1, testCase1Nums2));

            // the median should be 5.0
            var testCase2Nums1 = new int[] { 1, 2, 3, 7, 8, 9 };
            var testCase2Nums2 = new int[] { 4, 5, 6 };
            System.Console.WriteLine(FindMedianSortedArrays(testCase2Nums1, testCase2Nums2));

            // the median should be (10 + 11)/2 = 10.5
            var testCase3Nums1 = new int[] { 1, 2, 3, 8, 9, 10 };
            var testCase3Nums2 = new int[] { 4, 5, 11, 12, 13, 14, 15, 16, 17, 18 };
            System.Console.WriteLine(FindMedianSortedArrays(testCase3Nums1, testCase3Nums2));

            // the median should be (3 + 4)/2 = 3.5
            var testCase4Nums1 = new int[] { };
            var testCase4Nums2 = new int[] { 1, 2, 3, 4, 5, 6 };
            System.Console.WriteLine(FindMedianSortedArrays(testCase4Nums1, testCase4Nums2));
        }

        static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            // This solution can be optimized.
            int currentMinNumber = 0,
                currentMaxNumber = 0,
                num1TakeMinIndex = -1,
                num2TakeMinIndex = -1,
                num1TakeMaxIndex = nums1.Length,
                num2TakeMaxIndex = nums2.Length;

            while (true)
            {
                // check if take all
                if (num1TakeMinIndex + 1 >= num1TakeMaxIndex && num2TakeMinIndex + 1 >= num2TakeMaxIndex)
                {
                    return (double)(currentMinNumber + currentMaxNumber) / 2;
                }

                if (num1TakeMinIndex + 1 >= num1TakeMaxIndex)
                {
                    num2TakeMinIndex++;
                    currentMinNumber = nums2[num2TakeMinIndex];
                    if (num2TakeMaxIndex - 1 == num2TakeMinIndex)
                    {
                        return (double)currentMinNumber;
                    }
                    num2TakeMaxIndex--;
                    currentMaxNumber = nums2[num2TakeMaxIndex];
                    continue;
                }

                if (num2TakeMinIndex + 1 >= num2TakeMaxIndex)
                {
                    num1TakeMinIndex++;
                    currentMinNumber = nums1[num1TakeMinIndex];
                    if (num1TakeMaxIndex - 1 == num1TakeMinIndex)
                    {
                        return (double)currentMinNumber;
                    }
                    num1TakeMaxIndex--;
                    currentMaxNumber = nums1[num1TakeMaxIndex];
                    continue;
                }

                if (nums1[num1TakeMinIndex + 1] <= nums2[num2TakeMinIndex + 1])
                {
                    num1TakeMinIndex++;
                    currentMinNumber = nums1[num1TakeMinIndex];
                }
                else
                {
                    num2TakeMinIndex++;
                    currentMinNumber = nums2[num2TakeMinIndex];
                }

                if (nums1[num1TakeMaxIndex - 1] >= nums2[num2TakeMaxIndex - 1])
                {
                    num1TakeMaxIndex--;
                    currentMaxNumber = nums1[num1TakeMaxIndex];
                }
                else
                {
                    num2TakeMaxIndex--;
                    currentMaxNumber = nums2[num2TakeMaxIndex];
                }
            }
        }
    }
}
