namespace Sortings
{
    public class QuickSort : BaseSort
    {
        public override int[] Sort(int[] array)
        {
            var sortedArray = Sort(0, array.Length - 1, array);

            return sortedArray;
        }

        private int[] Sort(int left, int right, int[] array)
        {
            if(left >= right)
            {
                return array;
            }
            
            var partitionIndex = GetPartitionIndex(left, right, array);

            Sort(left, partitionIndex - 1, array);
            Sort(partitionIndex + 1, right, array);

            return array;
        }

        private int GetPartitionIndex(int left, int right, int[] array)
        {
            var pivot = array[right];
            var index = left - 1;

            for (int i = left; i < right; i++)
            {
                if (array[i] <= pivot)
                {
                    index++;
                    Swap(ref array[index], ref array[i]);
                }
            }

            Swap(ref array[index + 1], ref array[right]);

            return index + 1;
        }
    }
}
