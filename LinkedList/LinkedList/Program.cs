using System;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var tasks = new Tasks();

            var first = new ListNode(1);
            first.next = new ListNode(2);
            first.next.next = new ListNode(4);

            var second = new ListNode(1);
            second.next = new ListNode(3);
            second.next.next = new ListNode(4);

            var list = tasks.MergeTwoLists(first, second);
            while (list != null)
            {
                Console.Write(list.val + "-");
                list = list.next;
            }
        }
    }
}
