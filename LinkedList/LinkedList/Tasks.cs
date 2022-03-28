using System;
using System.Collections.Generic;

namespace LinkedList
{
    public class Tasks
    {
        public ListNode AddTwoNumbers(ListNode a, ListNode b)
        {
            var aNumber = GetNumberFromList(a);
            var bNumber = GetNumberFromList(b);
            var cNumber = aNumber + bNumber;
            var result = GetListFromNumber(cNumber);

            return result;
        }

        private int GetNumberFromList(ListNode a)
        {
            int result = 0;
            var root = a;
            var count = a.Count;
            var i = count - 1;
            while(root != null && i >= 0)
            {
                result += (int)(Math.Pow(10, i) * root.val);
                i--;
                root = root.next;
            }

            return result;
        }

        private ListNode GetListFromNumber(int cNumber)
        {
            var result = new ListNode();

            var str = Convert.ToString(cNumber);
            result.val = (int)(char.GetNumericValue(str[str.Length - 1]));

            for(int i = str.Length - 2; i >= 0; i--)
            {
                var current = result;
                // add to the end
                while(current.next != null)
                {
                    current = result.next;
                }
                var value = (int)(char.GetNumericValue(str[i]));
                current.next = new ListNode(value);
            }

            return result;
        }

        public ListNode DeleteDuplicates(ListNode root)
        {            
            var previous = root;
            var current = root.next;

            while (current != null)
            {
                if(previous.val == current.val)
                {
                    previous.next = current.next;
                    current = previous;
                }

                previous = current;
                current = current.next;
            }

            return root;
        }

        public ListNode RotateRight(ListNode root, int k)
        {
            if(root.next == null)
            {
                return root;
            }

            int i = 0;
            while(i < k)
            {
                var last = RemoveLast(root);
                root = InsertAsRoot(root, last);
                i++;
            }

            return root;
        }

        private ListNode RemoveLast(ListNode head)
        {
            var current = head;
            while (current.next.next != null)
            {
                current = current.next;
            }
            var last = current.next;
            current.next = null;

            return last;
        }

        private ListNode InsertAsRoot(ListNode root, ListNode last)
        {
            last.next = root;

            return last;
        }

        public ListNode RotateRightV2(ListNode root, int k)
        {
            if (root.next == null)
            {
                return root;
            }

            // Build cyclic list
            ListNode current = root;
            int size = 1;
            while (null != current.next)
            {
                size++;
                current = current.next;
            }
            current.next = root;

            // ???
            var count = size - k % size;
            while(count-- > 0)
            {
                current = current.next;
            }
            var start = current.next;
            current.next = null;

            return start;
        }

        public ListNode InsertionSortList(ListNode root)
        {
            int i = 0;
            var current = root;
            while(current != null)
            {
                var key = current;

                int j = 0;
                var temp = root;
                while(temp != null && j < i)
                {
                    if(temp.val > key.val)
                    {
                        var a = temp;
                        temp = key;
                        temp.next = a.next;

                        var b = key;
                        key = temp;
                        key.next = b.next;
                    }

                    j++;
                    temp = temp.next;
                }

                i++;
                current = current.next;
            }

            return root;
        }

        public ListNode DetectCycle(ListNode root)
        {
            var dict = new Dictionary<ListNode, int>();
            var current = root;
            while(current != null)
            {
                if (!dict.ContainsKey(current))
                {
                    dict.Add(current, 1);
                }
                else
                {
                    return current;
                }
                current = current.next;
            }

            return null;
        }

        public ListNode ReorderList(ListNode root)
        {
            if(root == null)
            {
                return null;
            }
            if(root.next == null || root.next.next == null)
            {
                return root;
            }

            var count = 0;
            var stack = new Stack<int>();
            var current = root;
            while(current  != null)
            {
                count++;
                stack.Push(current.val);
                current = current.next;
            }

            current = root;
            var previous = current;
            var i = 1;
            var toAddCount = count;
            while (current != null)
            {
                if(i % 2 == 0)
                {
                    // insert node from the end
                    var node = new ListNode(stack.Pop());

                    previous.next = node;
                    node.next = current;
                    current = node;
                }
                else
                {
                    // leave node from the begining
                    toAddCount--;
                }

                i++;
                if(i == count + 1)
                {
                    current.next = null;
                    return root;
                }

                previous = current;
                current = current.next;
            }

            return root;
        }

        public ListNode Partition(ListNode root, int value)
        {
            if (root == null)
            {
                return null;
            }
            if (root.next == null)
            {
                return root;
            }

            ListNode lastNode;
            var count = 0;
            var current = root;
            while (current.next != null)
            {
                count++;
                current = current.next;
            }
            lastNode = current;

            var i = 1;
            current = root;
            var previous = root;
            while (current != null)
            {
                if(i == count + 2)
                {
                    return root;
                }

                if (current.val >= value)
                {
                    // move to the end
                    lastNode.next = new ListNode(current.val);
                    lastNode = lastNode.next;

                    if (current == previous)
                    {
                        root = root.next;
                        current = current.next;
                        previous = current;
                    }
                    else
                    {
                        current = current.next;
                        previous.next = current;
                    }
                }
                else
                {
                    previous = current;
                    current = current.next;
                }
                i++;
            }

            return root;
        }

        public ListNode OddEvenList(ListNode head)
        {
            ListNode last = null;

            var current = head;
            var previous = current;

            var index = 1;
            while (current != null)
            {
                if (current == head)
                {
                    index++;
                }
                else
                {
                    if (index % 2 == 0)
                    {
                        // add node to the end
                        var node = new ListNode(current.val);
                        if (last == null)
                        {
                            last = node;
                        }
                        else if (last.next == null)
                        {
                            last.next = node;
                        }
                        else
                        {
                            var temp = last;
                            while (temp.next != null)
                            {
                                temp = temp.next;
                            }
                            temp.next = node;
                        }

                        // remove node
                        previous.next = current.next;
                    }
                    index++;
                }

                previous = current;
                current = current.next;
            }

            // merge lists
            var newLast = head;
            while (newLast.next != null)
            {
                newLast = newLast.next;
            }
            newLast.next = last;

            return head;
        }

        #region Merge Two Sorted Lists - https://leetcode.com/problems/merge-two-sorted-lists/

        // Time - O(N), Memory - O(1)
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            var leftNode = l1;
            var rightNode = l2;

            ListNode result = null;
            if (leftNode != null && (rightNode == null || leftNode.val <= rightNode.val))
            {
                result = new ListNode(leftNode.val);
                leftNode = leftNode.next;
            }
            else if (rightNode != null && (leftNode == null || rightNode.val <= leftNode.val))
            {
                result = new ListNode(rightNode.val);
                rightNode = rightNode.next;
            }

            ListNode head = result;

            while (leftNode != null || rightNode != null)
            {
                if (leftNode != null && (rightNode == null || leftNode.val <= rightNode.val))
                {
                    head.next = new ListNode(leftNode.val);
                    leftNode = leftNode.next;
                }
                else if (rightNode != null && (leftNode == null || rightNode.val <= leftNode.val))
                {
                    head.next = new ListNode(rightNode.val);
                    rightNode = rightNode.next;
                }
                head = head.next;
            }

            return result;
        }

        #endregion
    }
}
