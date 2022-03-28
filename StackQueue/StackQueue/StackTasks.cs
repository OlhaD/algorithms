using System.Collections.Generic;

namespace StackQueue
{
    public class StackTasks
    {
        public List<int> GetNextGreater(List<int> arr)
        {
            var stack = new Stack<int>();
            for (int i = arr.Count - 1; i >= 0; i--)
            {
                stack.Push(arr[i]);
            }

            var result = new List<int>();
            for (int i = 0; i < arr.Count; i++)
            {
                
                for(var j = i + 1; j < stack.Count; j++)
                {
                    if(arr[j] > arr[i])
                    {
                        result.Add(arr[j]);
                        break;
                    }                    
                }

                if (result.Count <= i)
                {
                    result.Add(-1);
                }
            }

            return result;
        }
    }
}
