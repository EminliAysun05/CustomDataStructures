using System.Collections;

namespace DataStructures.LinkedList;

public class CustomLinkedList<T> : IEnumerable<T>
{
    public Node<T> Head { get; private set; }
    public Node<T> Tail { get; private set; }

    public void AddFirst(T data)
    {
        var newNode = new Node<T>(data);
        if (Head == null)
        {
            Head = Tail = newNode;
        }
        else
        {
            newNode.Next = Head;
            Head = newNode;
        }
    }

    public void AddLast(T data)
    {
        var newNode = new Node<T>(data);
        if (Tail == null)
        {
            Head = Tail = newNode;
        }
        else
        {
            Tail.Next = newNode;
            Tail = newNode;
        }
    }

    public void AddLast(IEnumerable<T> data)
    {
        foreach (var item in data)
        {
            AddLast(item);
        }
    }

    public void AddMiddle(T data, int index)
    {
        if (index < 0 || (Head == null && index > 0))
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");

        if (index == 0)
        {
            AddFirst(data);
            return;
        }

        var newNode = new Node<T>(data);
        var current = Head;
        for (int i = 0; i < index - 1 && current != null; i++)
        {
            current = current.Next;
        }

        if (current == null)
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");

        newNode.Next = current.Next;
        current.Next = newNode;

        if (newNode.Next == null)
            Tail = newNode;
    }

    public void RemoveFirst()
    {
        if (Head == null)
            throw new InvalidOperationException("List is empty.");

        Head = Head.Next;
        if (Head == null)
            Tail = null; 

    }

    public void RemoveLast()
    {
        if (Head == null)
            return;

        if (Tail == null)
            throw new InvalidOperationException("List is empty.");

        if (Head == Tail)
        {
            Head = Tail = null;
            return;
        }

        var previous = Head;
        while (previous.Next != Tail)
        {
            previous = previous.Next;
        }

        previous.Next = null;
        Tail = previous;
    }

    public void RemoveWithValue(T value)
    {
        if (Head == null)
            return;

        if (EqualityComparer<T>.Default.Equals(Head.Data, value))
        {
            RemoveFirst();
            return;
        }

        Node<T> current = Head;
        while (current.Next != null && !EqualityComparer<T>.Default.Equals(current.Next.Data, value))
        {
            current = current.Next;
        }

        if (current.Next == null)
            return; // Value not found

        current.Next = current.Next.Next;

        if (current.Next == null) // If we removed the last node
            Tail = current;
    }
    public IEnumerator<T> GetEnumerator()
    {
        Node<T> current = Head;
        while (current is not null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public class Node<T>
{
    public T Data { get; set; }
    public Node<T> Next { get; set; } //bir sonraki node'u referas edir

    public Node(T data)
    {
        Data = data;
    }
    public override string ToString() => $"Data - {Data}";

}
}
