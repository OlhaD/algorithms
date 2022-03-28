namespace Sortings
{
    public abstract class BaseSort
    {
        public abstract int[] Sort(int[] array);

        protected virtual void Swap(ref int firstElement, ref int secondElement)
        {
            var temp = firstElement;
            firstElement = secondElement;
            secondElement = temp;
        }
    }
}
