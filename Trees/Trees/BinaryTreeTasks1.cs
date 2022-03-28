using System;
using System.Collections.Generic;
using System.Text;

namespace Trees
{
    public class BinaryTreeTasks1 : BinaryTree
    {
        public BinaryTreeTasks1(int root) : base(root)
        {
        }

        //public Node BuildTreeFromInorderAndPreOrder(List<int> preorder, List<int> inorder)
        //{
        //    int preorderIndex = 0;
        //    int inorderIndex = 0;
        //    var tree = new Node(preorder[preorderIndex]);
        //    preorderIndex++;

        //    var current = tree;
        //    var stack = new Stack<Node>();
        //    stack.Push(tree);

        //    var inOrderQueue = new Queue<int>();
        //    for (int j = 0; j < inorder.Count; j++)
        //    {
        //        inOrderQueue.Enqueue(inorder[j]);
        //    }

        //    for (; preorderIndex < preorder.Count && inorderIndex < inorder.Count; preorderIndex++)
        //    {
        //        if (current.Left == null)
        //        {
        //            current.Left = new Node(preorder[preorderIndex]);
        //            current = current.Left;
        //        }else if (current.Right == null)
        //        {
        //            current.Right = new Node(preorder[preorderIndex]);
        //            current = current.Right;
        //        }
        //        stack.Push(current);

        //        if(inorderIndex == inorder.Count - 1)
        //        {
        //            return tree;
        //        }

        //        // edge left
        //        var edgeLeft = inorder[inorderIndex];
        //        if (preorder[preorderIndex] == edgeLeft)
        //        {
        //            inorderIndex++;
        //            stack.Pop();

        //            current = stack.Pop();
        //            if(inorder[inorderIndex] != stack.Peek().Value)
        //            {
        //                current.Right = new Node(inorder[inorderIndex]);
        //                current = current.Right;
        //                stack.Push(current);
        //                inorderIndex++;
        //            }
        //            else
        //            {
        //                current = stack.Pop();
        //                inorderIndex++;
        //            }
        //        }
        //    }


        //    return tree;
        //}

        //public Node BuildTreeFromInorderAndPreOrder(List<int> preorder, List<int> inorder)
        //{
        //    int preorderIndex = 0;
        //    int inorderIndex = 0;
        //    var tree = new Node(preorder[preorderIndex]);
        //    preorderIndex++;

        //    var current = tree;
        //    var stack = new Stack<Node>();
        //    stack.Push(tree);

        //    var inOrderQueue = new Queue<int>();
        //    for (int j = 0; j < inorder.Count; j++)
        //    {
        //        inOrderQueue.Enqueue(inorder[j]);
        //    }

        //    var preOrderQueue = new Queue<int>();
        //    for (int j = 1; j < preorder.Count; j++)
        //    {
        //        preOrderQueue.Enqueue(preorder[j]);
        //    }

        //    current = BuildTreeFromInorderAndPreOrder(current, preOrderQueue, inOrderQueue);

        //    return tree;
        //}

        //public Node BuildTreeFromInorderAndPreOrder(Node root, Queue<int> preOrder, Queue<int> inOrder)
        //{
        //    if(root == null)
        //    {
        //        return null;
        //    }

        //    var curr = inOrder.Peek();


        //    while (preOrder.Count > 0 && inOrder.Count > 0)
        //    {
        //        if (root.Value != curr)
        //        {
        //            root.Left = new Node(preOrder.Dequeue());
        //            BuildTreeFromInorderAndPreOrder(root.Left, preOrder, inOrder);
        //        }
        //        else
        //        {
        //            if (preOrder.Peek() == curr)
        //            {
        //                root.Right = new Node(preOrder.Dequeue());
        //                inOrder.Dequeue();
        //                BuildTreeFromInorderAndPreOrder(root.Right, preOrder, inOrder);
        //            }
        //            else
        //            {

        //                //root.Right = new Node(preOrder.Dequeue());
        //                inOrder.Dequeue();

        //                BuildTreeFromInorderAndPreOrder(root.Right, preOrder, inOrder);
        //            }
        //        }
        //    }

        //    return root;
        //}

        //public Node BuildTreeFromInorderAndPostOrder(List<int> inorder, List<int> postorder)
        //{
        //    var postOrderStack = new Stack<int>(postorder);
        //    var inOrderStack = new Stack<int>(inorder);

        //    var current = new Node(postOrderStack.Pop());
        //    inorder.RemoveAll(x => x == current.Value);
        //    var tree = BuildTreeFromInorderAndPostOrder(current, false, inorder, postOrderStack);

        //    return tree;
        //}
        //public Node BuildTreeFromInorderAndPostOrder(Node root, bool isLeaf, List<int> inorder, Stack<int> postorder)
        //{
        //    if(inorder.Count == 0 || postorder.Count == 0)
        //    {
        //        return root;
        //    }

        //    if (isLeaf)
        //    {
        //        isLeaf = false;
        //        inorder.RemoveAll(x => x == root.Value);

        //        return root;
        //    }
        //    if (inorder[inorder.Count - 1] == postorder.Peek())
        //    {
        //        isLeaf = true;
        //        inorder.RemoveAll(x => x == root.Value);

        //        if (inorder.Count == 1 && postorder.Count == 1)
        //        {
        //            return root;
        //        }
        //    }

            

        //    root.Right = BuildTreeFromInorderAndPostOrder(new Node(postorder.Pop()), isLeaf, inorder, postorder);

        //    if (inorder.Count == 0 || postorder.Count == 0)
        //    {
        //        return root;
        //    }

        //    root.Left = BuildTreeFromInorderAndPostOrder(new Node(postorder.Pop()), isLeaf, inorder, postorder);

        //    return root;
        //}

        public TreeNode LinkNodes(TreeNode root)
        {
            if(root == null)
            {
                return null;
            }

            var height = GetHeight(root);
            for(int i = 1; i <= height; i++)
            {
                LinkNodesPerLevel(root, i);
            }

            _previous = null;

            return root;
        }        

        private int GetHeight(TreeNode root)
        {
            if(root == null)
            {
                return 0;
            }

            var leftHeight = GetHeight(root.left);
            var rightHeight = GetHeight(root.right);

            return leftHeight > rightHeight ? leftHeight + 1 : rightHeight + 1;
        }

        private TreeNode _previous = null;

        private void LinkNodesPerLevel(TreeNode root, int level)
        {
            if(root == null)
            {
                return;
            }
            if(level == 1)
            {
                if (_previous != null)
                {
                    _previous.Next = root;
                }
                else
                {
                    _previous = root;
                }
            }
            else if (level > 1)
            {
                _previous = null;
                LinkNodesPerLevel(root.left, level - 1);
                LinkNodesPerLevel(root.right, level - 1);
            }
        }

        public TreeNode MergeTrees(TreeNode t1, TreeNode t2)
        {
            if(t1 == null)
            {
                return t2;
            }
            if(t2 == null)
            {
                return t1;
            }

            t1.val += t2.val;

            t1.left = MergeTrees(t1.left, t2.left);
            t1.right = MergeTrees(t1.right, t2.right);

            return t1;
        }
    }
}
