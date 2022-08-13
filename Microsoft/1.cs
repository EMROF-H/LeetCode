using System;
using System.Collections;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

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