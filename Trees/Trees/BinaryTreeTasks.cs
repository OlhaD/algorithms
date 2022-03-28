using System;
using System.Collections.Generic;

namespace Trees
{
    public class BinaryTreeTasks : BinaryTree
    {
        public BinaryTreeTasks(int root) : base(root)
        {
        }

        #region Is same tree - https://leetcode.com/problems/same-tree/

        // Time - O(N), Space - O(log(N)) - best case, O(N) - for completely unballanced tree, to keep a recursion stack.
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
            {
                return true;
            }

            if (p == null || q == null)
            {
                return false;
            }

            if (p.val != q.val)
            {
                return false;
            }

            return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
        }

        // Time - O(N), Space - O(log(N)) - best case, O(N) - for unballanced tree, to keep a dequee.
        public bool IsSameTreeV2(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
            {
                return true;
            }
            if (p == null || q == null)
            {
                return false;
            }

            var stack = new Stack<TreeNode>();
            stack.Push(p);
            stack.Push(q);

            while (stack.Count > 0)
            {
                var pNode = stack.Pop();
                var qNode = stack.Pop();
                if (pNode == null && qNode == null)
                {
                    continue;
                }
                if (pNode == null || qNode == null || pNode.val != qNode.val)
                {
                    return false;
                }

                stack.Push(pNode.left);
                stack.Push(qNode.left);
                stack.Push(pNode.right);
                stack.Push(qNode.right);
            }

            return true;
        }

        // iterate both, save nodes to lists and compare them
        public int IsSameTreeV3(TreeNode first, TreeNode second)
        {
            var firstValues = new List<int>();
            var secondValues = new List<int>();
            AddToList(first, firstValues);
            AddToList(second, secondValues);

            if (firstValues.Count != secondValues.Count)
            {
                return 0;
            }

            for (int i = 0; i < firstValues.Count; i++)
            {
                if (firstValues[i] != secondValues[i])
                {
                    return 0;
                }
            }

            return 1;
        }        

        #endregion

        #region Is symmetrick - https://leetcode.com/problems/symmetric-tree/

        // Time - O(N), Space - O(log(N)) - best case, O(N) - for completely unballanced tree, to keep a recursion stack.
        public bool IsSymmetric(TreeNode root)
        {
            return IsSymmetric(root, root);
        }

        private bool IsSymmetric(TreeNode left, TreeNode right)
        {
            if (left == null && right == null)
            {
                return true;
            }
            if (left == null || right == null || left.val != right.val)
            {
                return false;
            }

            return IsSymmetric(left.left, right.right) && IsSymmetric(left.right, right.left);
        }

        public bool IsSymmetricV2(TreeNode root)
        {
            return IsSymmetricV2(root, root);
        }

        // Time - O(N), Space - O(log(N)) - best case, O(N) - for unballanced tree, to keep a dequee.
        private bool IsSymmetricV2(TreeNode left, TreeNode right)
        {
            var stack = new Stack<TreeNode>();
            stack.Push(left);
            stack.Push(right);

            while (stack.Count > 0)
            {
                var leftNode = stack.Pop();
                var rightNode = stack.Pop();

                if (leftNode == null && rightNode == null)
                {
                    continue;
                }
                if (leftNode == null || rightNode == null || leftNode.val != rightNode.val)
                {
                    return false;
                }

                stack.Push(leftNode.left);
                stack.Push(rightNode.right);
                stack.Push(leftNode.right);
                stack.Push(rightNode.left);
            }

            return true;
        }

        // If write nodes in in-order traversal to an array, it will be a palindrom
        public int IsSymmetricV3(TreeNode root)
        {
            var list = new List<int>();
            AddToList(root, list);

            // is array palindrom
            for (int i = 0, j = list.Count - 1; i < list.Count && j >= 0 && i < j; i++, j--)
            {
                if (list[i] != list[j])
                {
                    return 0;
                }
            }

            return 1;
        }

        #endregion

        private TreeNode AddToList(TreeNode root, List<int> list)
        {
            if (root != null)
            {
                root.left = AddToList(root.left, list);
                list.Add(root.val);
                root.right = AddToList(root.right, list);
            }

            return root;
        }

        ///------------------

        public TreeNode Invert(TreeNode root)
        {
            var dict = new Dictionary<int, Stack<int>>();
            var height = GetHeight(root);
            for (int i = 1; i <= height; i++)
            {
                FillDict(root, i, i, dict);
            }

            for (int i = 1; i <= height; i++)
            {
                InvertTree(root, dict, i, i);
            }

            return root;
        }

        //private int GetHeight(Node root)
        //{
        //    if(root == null)
        //    {
        //        return 0;
        //    }

        //    var leftHeight = GetHeight(root.Left);
        //    var rightHeight = GetHeight(root.Right);

        //    return leftHeight > rightHeight ? leftHeight + 1 : rightHeight + 1;
        //}

        private void FillDict(TreeNode root, int level, int levelConst, Dictionary<int, Stack<int>> dict)
        {
            if(root == null)
            {
                return;
            }
            if(level == 1)
            {
                if (dict.ContainsKey(levelConst))
                {
                    dict[levelConst].Push(root.val);
                }
                else
                {
                    var stack = new Stack<int>();
                    stack.Push(root.val);
                    dict.Add(levelConst, stack);
                }
            }
            else if(level > 1)
            {
                FillDict(root.left, level - 1, levelConst, dict);
                FillDict(root.right, level - 1, levelConst, dict);
            }            
        }

        private void InvertTree(TreeNode root, Dictionary<int, Stack<int>> dict, int level, int levelConst)
        {
            if(root == null)
            {
                return;
            }
            if(level == 1)
            {
                var nodes = dict[levelConst];
                if(nodes.Count != 0)
                {
                    var newValue = nodes.Pop();
                    root.val = newValue;
                }
            }
            else if(level > 1)
            {
                InvertTree(root.left, dict, level - 1, levelConst);
                InvertTree(root.right, dict, level - 1, levelConst);
            }
        }

        public TreeNode InvertV2(TreeNode root)
        {
            if (root == null)
                return null;

            //LRP, post order traversal
            InvertV2(root.left);
            InvertV2(root.right);
            // swap left & right subtree
            TreeNode tmp = root.left;
            root.left = root.right;
            root.right = tmp;

            return root;
        }

        public List<int> PreorderTraversalIterative(TreeNode root)
        {
            if(root == null)
            {
                return new List<int>();
            }
            var result = new List<int>();
            var stack = new Stack<TreeNode>();
            var current = root;
            stack.Push(current);
            while (stack.Count > 0)
            {
                var node = stack.Pop();
                result.Add(node.val);

                if (node.right != null)
                {
                    stack.Push(node.right);
                }
                if(node.left != null)
                {
                    stack.Push(node.left);
                }               
            }

            return result;
        }

        

        

        public List<List<int>> ZigzagLevelOrder(TreeNode root)
        {
            var result = new List<List<int>>();
            var height = GetHeight(root);
            for(int i = 0; i <= height; i++)
            {
                var list = new List<int>();
                AddToListPerLevel(root, list, i + 1);
                if(i % 2 != 0)
                {
                    list.Reverse();
                }
                if (list.Count != 0)
                {
                    result.Add(list);
                }
            }

            return result;
        }

        private void AddToListPerLevel(TreeNode root, List<int> list, int level)
        {
            if(root == null)
            {
                return;
            }
            if(level == 1)
            {
                list.Add(root.val);
            }

            AddToListPerLevel(root.left, list, level - 1);
            AddToListPerLevel(root.right, list, level - 1);
        }

        public int GetHeight(TreeNode root)
        {
            //
            if (root == null)
            {
                //
                return 0;
            }

            var leftHeight = GetHeight(root.left);
            //
            var rightHeight = GetHeight(root.right);
            //
            return leftHeight > rightHeight ? leftHeight + 1 : rightHeight + 1;
        }

        public bool IsBinarySearchTree(TreeNode root)
        {
            return IsBinarySearchTree(root, null, null);
        }

        private bool IsBinarySearchTree(TreeNode root, TreeNode left, TreeNode right)
        {
            if (root == null)
            {
                return true;
            }

            if (left != null && root.val <= left.val)
            {
                return false;
            }
            if (right != null && root.val >= right.val)
            {
                return false;
            }

            return IsBinarySearchTree(root.left, left, root) &&
                IsBinarySearchTree(root.right, root, right);
        }

        public bool IsBalanced(TreeNode root)
        {
            bool isBalanced = true;
            IsBalanced(root, ref isBalanced);

            return isBalanced;
        }

        private int IsBalanced(TreeNode root, ref bool isBalanced)
        {
            if(root == null)
            {
                return 0;
            }
            if (!isBalanced)
            {
                return -1;
            }

            var leftHeight = IsBalanced(root.left, ref isBalanced);
            var rightHeight = IsBalanced(root.right, ref isBalanced);

            if(leftHeight > rightHeight)
            {
                if(leftHeight - rightHeight > 1)
                {
                    isBalanced = false;
                    return -1;
                }

                return leftHeight + 1;
            }
            else
            {
                if (rightHeight - leftHeight > 1)
                {
                    isBalanced = false;
                    return -1;
                }

                return rightHeight + 1;
            }
        }

        public int GetMinDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            if (root.left == null && root.right == null)
            {
                return 1;
            }

            int leftHeight = int.MaxValue;
            if (root.left != null) leftHeight = GetMinDepth(root.left) + 1;

            var rightHeight = int.MaxValue;
            if (root.right != null) rightHeight = GetMinDepth(root.right) + 1;

            return leftHeight > rightHeight ? rightHeight : leftHeight;
        }

        public List<List<int>> GetPathSum(TreeNode root, int sum)
        {
            var result = new List<List<int>>();
            GetPathSum(root, 0, sum, new Stack<TreeNode>(), result);

            return result;
        }

        // not ready
        private void GetPathSum(TreeNode root, int currentSum, int sum, Stack<TreeNode> nodes, List<List<int>> result)
        {
            currentSum += root.val;
            nodes.Push(root);

            if (root.left == null && root.right == null)
            {
                if (currentSum == sum)
                {
                    // nodes to result
                    var list = new List<int>();
                    foreach(var node in nodes)
                    {
                        list.Add(node.val);
                    }
                    result.Add(list);
                }

                nodes.Pop();
                currentSum -= root.val;

                return;
            }

            if (root.left != null) GetPathSum(root.left, currentSum, sum, nodes, result);
            if (root.right != null) GetPathSum(root.right, currentSum, sum, nodes, result);

            nodes.Pop();
            currentSum -= root.val;
        }

        public bool HasPathSum(TreeNode root, int sum)
        {
            var a = false;
            var result = HasPathSum(root, 0, sum, ref a);

            return result;
        }

        private bool HasPathSum(TreeNode root, int currentSum, int sum, ref bool hasPathSum)
        {
            currentSum += root.val;

            if (root.left == null && root.right == null)
            {
                if (currentSum == sum)
                {
                    hasPathSum = true;

                    return true;
                }

                currentSum -= root.val;

                return false;
            }

            if (root.left != null) HasPathSum(root.left, currentSum, sum, ref hasPathSum);
            if (root.right != null) HasPathSum(root.right, currentSum, sum, ref hasPathSum);

            currentSum -= root.val;

            return hasPathSum;
        }

        public int SumNumbers(TreeNode root)
        {
            var list = new List<long>();
            GetSumNumbers(root, 0, list);

            long result = 0;
            foreach (var number in list)
            {
                result += number;
            }

            return (int) result % 1003;
        }

        private void GetSumNumbers(TreeNode root, long num, List<long> list)
        {
            var numCount = root.val.ToString().Length;
            num = (num * (long) Math.Pow(10, numCount) + root.val) % 1003;

            // the leaf
            if(root.left == null && root.right == null)
            {
                list.Add(num);
            }

            if (root.left != null) GetSumNumbers(root.left, num, list);
            if (root.right != null) GetSumNumbers(root.right, num, list);

            // remove current symbol from number
            //var numCount = root.Value.ToString().Length;
            num = (num - root.val) / 10 * numCount; //str.Substring(0, str.Length - numCount);
        }


        public TreeNode ConvertToLinkedListInPlace(TreeNode root)
        {
            var queue = TraverseToList(root);
            queue.Dequeue();

            root = new TreeNode(root.val);
            var current = root;

            while(queue.Count > 0)
            {
                current.right = new TreeNode(queue.Dequeue());
                current = current.right;
            }

            return root;
        }

        private Queue<int> TraverseToList(TreeNode root)
        {
            var result = new Queue<int>();

            var stack = new Stack<TreeNode>();
            stack.Push(root);

            while(stack.Count != 0)
            {
                var node = stack.Pop();
                result.Enqueue(node.val);

                if (node.right != null) stack.Push(node.right);
                if (node.left != null) stack.Push(node.left);                
            }

            return result;
        }
    }
}