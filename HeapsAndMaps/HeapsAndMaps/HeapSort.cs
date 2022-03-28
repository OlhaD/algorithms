using System;

namespace HeapsAndMaps
{
    public class HeapSort
    {
        public void Sort(int[] arr)
        {
            // Build the tree
            for (int i = arr.Length / 2 - 1; i >= 0; i--)
            {
                Heapify(arr, arr.Length, i);
            }

            for(int i = arr.Length - 1; i >= 0; i--)
            {
                Swap(arr, i, 0);
                Heapify(arr, i, 0);
            }
        }
        
        private void Heapify(int[] arr, int length, int i)
        {
            var largest = i;
            var left = i * 2 + 1;
            var right = i * 2 + 2;

            if(left < length && arr[left] > arr[largest])
            {
                largest = left;
            }

            if(right < length && arr[right] > arr[largest])
            {
                largest = right;
            }

            if(i != largest)
            {
                Swap(arr, i, largest);
                Heapify(arr, length, largest);
            }
        }

        private void Swap(int[] arr, int i, int j)
        {
            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
