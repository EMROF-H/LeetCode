/*
 * @lc app=leetcode.cn id=239 lang=csharp
 *
 * [239] 滑动窗口最大值
 */

// @lc code=start
public class Solution
{
    public int[] MaxSlidingWindow(int[] nums, int k)
    {
        int[] result = new int[nums.Length - k + 1];
        LinkedList<int> list = new();
        for (int i = 0; i < k; i++)
        {
            while (list.Count > 0 && nums[i] >= nums[list.Last.Value])
            {
                list.RemoveLast();
            }
            list.AddLast(i);
        }

        result[0] = nums[list.First.Value];
        for (int i = 0; i < result.Length - 1; i++)
        {
            while (list.Count > 0 && nums[i + k] >= nums[list.Last.Value])
            {
                list.RemoveLast();
            }
            list.AddLast(i + k);
            while (list.First.Value <= i)
            {
                list.RemoveFirst();
            }
            result[i + 1] = nums[list.First.Value];
        }
        return result;
    }
}
// @lc code=end

public class FaultedSolution
{
    public int[] MaxSlidingWindow(int[] nums, int k)
    {
        int[] result = new int[nums.Length - k + 1];
        PriorityQueue<int, int> priorityQueue = new(
            Comparer<int>.Create((left, right) => right - left));

        for (int i = 0; i < k; i++)
        {
            priorityQueue.Enqueue(nums[i], nums[i]);
        }
        result[0] = priorityQueue.Peek();
        for (int i = 0; i < result.Length - 1; i++)
        {
            priorityQueue.Enqueue(nums[i + k], nums[i + k]);
            int max = priorityQueue.Peek();
            if (max == nums[i])
            {
                priorityQueue.Dequeue();
                result[i + 1] = priorityQueue.Peek();
            }
            else
            {
                result[i + 1] = max;
            }
        }
        result[^1] = priorityQueue.Dequeue();
        return result;
    }
}