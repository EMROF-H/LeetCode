public class CQueue
{
    LinkedList<int> values;

    public CQueue()
    {
        values = new();
    }

    public void AppendTail(int value)
    {
        values.AddLast(value);
    }

    public int DeleteHead()
    {
        if(values.Count == 0)
        {
            return -1;
        }
        else
        {
            int result = values.First();
            values.RemoveFirst();
            return result;
        }
    }
}