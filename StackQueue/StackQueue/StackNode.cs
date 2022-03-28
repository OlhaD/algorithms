namespace StackQueue
{
    public class StackNode
    {
        public StackNode(int value)
        {
            Value = value;
        }

        public int Value { get; set; }

        public StackNode Next { get; set; }
    }
}
