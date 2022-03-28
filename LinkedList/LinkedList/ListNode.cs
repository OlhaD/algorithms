namespace LinkedList
{
    public class ListNode
    {
        public ListNode()
        {
        }

        public ListNode(int value)
        {
            val = value;
        }

        public int val { get; set; }

        public ListNode next { get; set; }
        public int Count
        {
            get
            {
                var root = this;
                var count = 0;

                while (root != null)
                {
                    count++;
                    root = root.next;
                }

                return count;
            }
        }
    }
}