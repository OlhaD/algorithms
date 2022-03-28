namespace Trees
{
    public class TreeNode
    {
        public TreeNode(int value)
        {
            val = value;
        }

        public TreeNode left { get; set; }

        public TreeNode right { get; set; }

        public TreeNode Next { get; set; }

        public int val { get; set; }
    }
}
