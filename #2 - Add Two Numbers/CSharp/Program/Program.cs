using System;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static ListNode AddTwoNumbers(ListNode l1, ListNode l2, int? landing)
        {
            var val = (l1?.val ?? 0) + (l2?.val ?? 0) + (landing ?? 0);
            var currentNode = new ListNode(val % 10);
            int? nextLanding = null;
            if (val >= 10)
            {
                nextLanding = val / 10;
            }

            if (l1?.next != null || l2?.next != null)
            {
                currentNode.next = AddTwoNumbers(l1?.next, l2?.next, nextLanding);
                return currentNode;
            }

            if (nextLanding.HasValue)
                currentNode.next = new ListNode(nextLanding.Value);
            return currentNode;
        }
    }
}
