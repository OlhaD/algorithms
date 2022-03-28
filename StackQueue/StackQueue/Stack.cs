namespace StackQueue
{
    public class Stack
    {
        StackNode Head { get; set; }

        private int _min = -1;

        public void push(int x)
        {
            if(Head == null)
            {
                Head = new StackNode(x);
                _min = x;
            }
            else
            {
                var current = Head;
                while(current.Next != null)
                {
                    if(current.Value < _min)
                    {
                        _min = current.Value;
                    }
                    current = current.Next;
                }
                current.Next = new StackNode(x);
                if (x < _min)
                {
                    _min = x;
                }
            }
        }

        public void pop()
        {
            if(Head == null)
            {
                return;
            }
            if(Head.Next == null)
            {
                Head = null;
                _min = -1;
                return;
            }

            var current = Head;
            while (current.Next.Next != null)
            {
                current = current.Next;
            }
            var recalculateMin = _min == current.Next.Value;
            current.Next = null;
            if (recalculateMin)
            {
                _min = getMinValue();
            }
        }

        public int top()
        {
            if (Head == null)
            {
                return -1;
            }

            var current = Head;
            while (current.Next != null)
            {
                current = current.Next;
            }

            return current.Value;
        }

        public int getMin()
        {
            if(Head == null)
            {
                return -1;
            }

            if(Head == null)
            {
                return -1;
            }

            if(_min == -1)
            {
                return getMinValue();
            }

            return _min;
        }

        private int getMinValue()
        {
            var min = int.MaxValue;
            var current = Head;
            while (current != null)
            {
                if (current.Value < min)
                {
                    min = current.Value;
                }
                current = current.Next;
            }

            return min;
        }
    }
}
