public class QuickSortClass
{
    public static void QuickSort(int[] array) => QuickSort(array, 0, array.Length - 1);

    public static void QuickSort(int[] array, int left, int right)
    {
        if (left < right)
        {
            int standard = array[left];
            int[] temp = new int[right - left + 1];

            int leftIndex = 0, rightIndex = temp.Length - 1;
            for (int i = left + 1; i <= right; i++)
            {
                if (array[i] < standard)
                {
                    temp[leftIndex] = array[i];
                    leftIndex++;
                }
                else
                {
                    temp[rightIndex] = array[i];
                    rightIndex--;
                }
            }
            temp[leftIndex] = standard;

            QuickSort(temp, 0, leftIndex - 1);
            QuickSort(temp, rightIndex + 1, temp.Length - 1);

            for (int i = 0; i < temp.Length; i++)
            {
                array[left + i] = temp[i];
            }
        }
    }
}
