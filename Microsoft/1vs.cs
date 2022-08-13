#region SolutionHead
using LeetCodeTest;
using LeetCodeTest.DataStructure;
using LeetCodeTest.Lazimium;
using LeetCodeTest.Leetcode.Classes;
#pragma warning disable CA1050
#pragma warning disable CA1822
// @lc code=start
#endregion

using System;
using System.Collections;

/*
public static class ListNodeExtension
{
    class EmptyNodeException : Exception
    {
        public override string Message => "An empty node is indexed.";
    }

    public static ListNode? NullableIndex(this ListNode node, int index = 1)
    {
        ListNode? result = node;
        for (int i = 0; i < index; i++)
        {
            if (result == null) throw new EmptyNodeException();
            result = result.Next;
        }
        return result;
    }

    public static ListNode Index(this ListNode node, int index = 1)
    {
        ListNode result = node;
        for (int i = 0; i < index; i++)
        {
            if (result.Next == null) throw new EmptyNodeException();
            result = result.Next;
        }
        return result;
    }

    public static ListNode End(this ListNode node)
    {
        while (node.Next != null) { node = node.Next; }
        return node;
    }

    public static ListNode Insert(this ListNode node, ListNode item)
    {
        item.End().Next = node.Next;
        node.Next = item;
        return node;
    }

    public static ListNode Delete(this ListNode node, int number = 1)
    {
        node.Next = node.NullableIndex(number + 1);
        return node;
    }

    public static List<double> ToValueList(this ListNode head)
    {
        List<double> list = new();
        if (head == null) return list;
        for (ListNode node = head; node.Next != null; node = node.Next)
        {
            list.Add(node.Value);
        }
        return list;
    }

    public static List<ListNode> ToNodeList(this ListNode head)
    {
        List<ListNode> list = new();
        if (head == null) return list;
        for (ListNode node = head; node.Next != null; node = node.Next)
        {
            list.Add(node);
        }
        return list;
    }

    public static ListNode GetMiddleNode(this ListNode head)
    {
        ListNode slow = head;
        ListNode? fast = head;
        while (fast != null && fast.Next != null)
        {
#pragma warning disable CS8600
#pragma warning disable CS8602
            slow = slow.Next;
#pragma warning restore CS8600
#pragma warning restore CS8602
            fast = fast.Next.Next;
        }
#pragma warning disable CS8603
        return slow;
#pragma warning restore CS8603
    }
}
*/

public class ListNode : IEnumerable<double>, IEnumerable<ListNode>
{
    public class ListNodeEnumerator : IEnumerator<ListNode>
    {
        readonly private ListNode Head;
        protected ListNode CurrentNode;
        private bool HasReset;

        internal ListNodeEnumerator(ListNode listNode)
        {
            Head = listNode;
            CurrentNode = listNode;
            Reset();
        }

        ListNode IEnumerator<ListNode>.Current { get => CurrentNode; }

        public object Current { get => this.Current; }

        public bool MoveNext()
        {
            if (HasReset)
            {
                HasReset = false;
                CurrentNode = Head;
                return true;
            }

            if (CurrentNode.Next == null) return false;
            else
            {
                CurrentNode = CurrentNode.Next;
                return true;
            }
        }

        public void Reset() => HasReset = true;

        public void Dispose() => GC.SuppressFinalize(this);
    }

    public class ListNodeVarEnumerator : ListNodeEnumerator, IEnumerator<double>
    {
        public ListNodeVarEnumerator(ListNode listNode) : base(listNode) { }

        double IEnumerator<double>.Current => CurrentNode.Value;
    }

    public double Value;
    public ListNode? Next;

    public ListNode(double value = 0, ListNode? next = null)
    {
        Value = value;
        Next = next;
    }

    public ListNode(double[] array)
    {
        if (array.Length == 0)
        {
            Value = 0;
            Next = null;
        }
        else
        {
            ListNode node = this;
            Value = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                node.Next = new(array[i]);
                node = node.Next;
            }
        }
    }

    IEnumerator<double> IEnumerable<double>.GetEnumerator() => new ListNodeVarEnumerator(this);

    IEnumerator<ListNode> IEnumerable<ListNode>.GetEnumerator() => new ListNodeEnumerator(this);

    IEnumerator IEnumerable.GetEnumerator() => new ListNodeEnumerator(this);

    public override string ToString()
    {
        return $"{{{String.Join(',', (IEnumerable<double>)this)}}}";
    }

    public static ListNode ToReverseDoubleListNode(int[] input)
    {
        ListNode result = new(input.Last());
        ListNode node = result;
        for (int i = input.Length - 2; i >= 0; i--)
        {
            node.Next = new(input[i]);
            node = node.Next;
        }
        return result;
    }

    public ListNode ReverseSortInsertFirst()
    {
        if (Next == null || Next.Value < Value) return this;
        ListNode result = Next;
        ListNode first = this;
        ListNode node = first;
        while (node.Next != null)
        {
            if (node.Next.Value < first.Value)
            {
                first.Next = node.Next;
                node.Next = first;
                return result;
            }
            node = node.Next;
        }
        node.Next = this;
        Next = null;
        return result;
    }
}

class Solution
{
    public int solution(int[] A)
    {
        Array.Sort(A);
        ListNode polution = ListNode.ToReverseDoubleListNode(A);
        double sum = A.Sum();
        double target = sum / 2.0;
        int result;
        for (result = 0; sum > target; result++)
        {
            polution.Value /= 2;
            sum -= polution.Value;
            polution = polution.ReverseSortInsertFirst();
        }
        return result;
    }
}

#region SolutionEnd
// @lc code=end
#pragma warning restore CA1050
#pragma warning restore CA1822
#endregion

public class Solution1
{
    public int FindNumberOfLIS(int[] nums)
    {
        int[] dpMaxLength = new int[nums.Length];
        int[] dpNumber = new int[nums.Length];
        (int lengthMax, int lengthMaxIndex) = (1, 0);
        for (int i = 0; i < nums.Length; i++)
        {
            (int length, int number) = (1, 0);
            for (int j = 0; j < i; j++)
            {
                if (nums[j] < nums[i])
                {
                    if (length < dpMaxLength[j] + 1)
                    {
                        length = dpMaxLength[j] + 1;
                        number = 1;
                    }
                    else if (length == dpMaxLength[j] + 1)
                    {
                        number += dpNumber[j];
                    }
                }
            }
            (dpMaxLength[i], dpNumber[i]) = (length, number);
            if (lengthMax < dpMaxLength[i])
            {
                (lengthMax, lengthMaxIndex) = (dpMaxLength[i], i);
            }
        }
        return dpNumber[lengthMaxIndex];
    }
}