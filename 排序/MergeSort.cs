public class MergeSortClass
{
    public static void MergeSort(int[] array) => MergeSort(array, 0, array.Length - 1);

    public static void MergeSort(int[] array, int left, int right)
    {
        if (left < right)
        {
            int mid = left + (right - left) / 2;
            MergeSort(array, left, mid);
            MergeSort(array, mid + 1, right);
            Merge(array, left, mid, right);
        }
    }

    private static void Merge(int[] array, int left, int mid, int right)
    {
        if (left - right == 1) return;

        int[] temp = new int[right - left + 1];

        {
            int index, leftIndex = left, rightIndex = mid + 1;
            for (index = 0; leftIndex <= mid && rightIndex <= right; index++)
            {
                if (array[leftIndex] <= array[rightIndex])
                {
                    temp[index] = array[leftIndex];
                    leftIndex++;
                }
                else
                {
                    temp[index] = array[rightIndex];
                    rightIndex++;
                }
            }

            while (leftIndex <= mid)
            {
                temp[index] = array[leftIndex];
                index++;
                leftIndex++;
            }

            while (rightIndex <= right)
            {
                temp[index] = array[rightIndex];
                index++;
                rightIndex++;
            }
        }

        for (int i = 0; i < temp.Length; i++)
        {
            array[left + i] = temp[i];
        }
    }
}
