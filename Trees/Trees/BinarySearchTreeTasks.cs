using System;
using System.Collections.Generic;

namespace Trees
{
    public class BinarySearchTreeTasks : BinarySearchTree
    {
        public BinarySearchTreeTasks(int root) : base(root)
        {
        }
        
        public int GetNodesCount(TreeNode root)
        {
            if(root == null)
            {
                return 0;
            }
        
            return GetNodesCount(root.left) + GetNodesCount(root.right) + 1;
        }

        public int GetMax(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            var leftMax = GetMax(root.left);
            var rightMax = GetMax(root.right);
            
            if(leftMax > root.val)
            {
                return leftMax;
            }
            if(rightMax > root.val)
            {
                return rightMax;
            }

            return root.val;
        }

        public void PrintLeft(TreeNode root, Action<int> print)
        {
            if (root == null)
            {
                return;
            }

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            print(root.val);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                    print(node.left.val);
                }

                if (node.left != null)
                {
                    queue.Enqueue(node.right);
                }
            }
        }

        public TreeNode GetNextBiggerSuccessor(TreeNode root, int value)
        {
            var result = GetNextBiggerSuccessor(root, value, new TreeNode(int.MaxValue));
            if(result.val == value || result.val == int.MaxValue)
            {
                return null;
            }

            return result;
        }

        private TreeNode GetNextBiggerSuccessor(TreeNode root, int value, TreeNode currMax)
        {
            if(root == null || root.val > currMax.val)
            {
                return currMax;
            }

            if(root.val > value && root.val < currMax.val)
            {
                currMax = root;
            }

            currMax = GetNextBiggerSuccessor(root.left, value, currMax);
            currMax = GetNextBiggerSuccessor(root.right, value, currMax);

            return currMax;
        }

        public TreeNode GetNextBiggerSuccessorIterative(TreeNode root, int value)
        {
            var currMax = int.MaxValue;
            var current = root;
            var result = root;

            if (root.val == value && root.right != null)
            {
                current = root.right;
            }

            while (current.val != value)
            {
                if(current == null)
                {
                    break;
                }
                if(currMax > value && currMax > current.val)
                {
                    result = current;
                    currMax = current.val;
                }

                if(current.left == null || current.left.val == value)
                {
                    return current;
                }
                if(current.right == null || current.right.val == value)
                {
                    return current.right.right;
                }

                if(current.left.val > value)
                {
                    current = current.left;
                    continue;
                }
                if (current.right.val <= value)
                {
                    current = current.right;
                }
            }

            return result.val == value ? null : result;
        }

        public TreeNode BuildBST(List<int> arr)
        {
            var root = BuildBST(arr, 0, arr.Count - 1);

            return root;
        }

        private TreeNode BuildBST(List<int> arr, int left, int right)
        {
            if (left > right)
            {
                return null;
            }

            var mid = (right + left) / 2;
            var root = new TreeNode(arr[mid]);
            if (Root == null)
            {
                Root = root;
            }

            root.left = BuildBST(arr, left, mid - 1);
            root.right = BuildBST(arr, mid + 1, right);

            return root;
        }

        public int MinDiffInBST(TreeNode root)
        {
            return MinDiffInBST(root, int.MaxValue);
        }

        private int MinDiffInBST(TreeNode root, int min)
        {
            if (root == null)
            {
                return min;
            }

            if (root.left != null && root.val - root.left.val < min)
            {
                min = root.val - root.left.val;
            }

            if (root.left == null && root.right != null && root.right.val - root.val < min)
            {
                min = root.right.val - root.val;
            }

            min = MinDiffInBST(root.left, min);
            min = MinDiffInBST(root.right, min);

            return min;
        }
    }
}
