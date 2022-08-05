public class Solution
{
    public int[] ReversePrint(ListNode head)
    {
        short count = 0;
        for (ListNode node = head; node != null; node = node.next)
        {
            count++;
        }

        int[] result = new int[count];
        while (count-- != 0)
        {
            result[count] = head.val;
            head = head.next;
        }
        return result;
    }
}