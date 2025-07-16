using System.Collections;

namespace DataStructures.LinkedList;

public class CustomDoubleLinkedList<T> : IEnumerable<T>
{
    private Node _head;
    private Node _tail;
    private int _count;

    private Node First => _head;
    public Node Last => _tail;
    public int Count => _count;


    public void AddFirst(T t)
    {
        Node newNode = new Node(t);

        if (_head == null)
        {
            _head = _tail = newNode;
        }
        else
        {
            newNode.Next = _head;
            _head.Previous = newNode;
            _head = newNode;
        }
        _count++;
    }

    public void AddLast(T t)
    {
        Node newNode = new Node(t);

        if (_head == null)
        {
            _head = _tail = newNode;
        }
        else
        {
            _tail.Next = newNode;
            newNode.Previous = _tail;
            _tail = newNode;
        }
        _count++;
    }

    public void RemoveFirst()
    {
        if (_head == null)
            throw new InvalidOperationException("List is empty");

        if (_head.Next == _tail)
        {
            _head = _tail = null;
        }
        else
        {
            _head = _head.Next;
            _head.Previous = null;
        }
        _count--;
    }

    public void RemoveLast()
    {
        if (_tail == null)
            throw new InvalidOperationException("List is empty");

        if (_head == _tail)
        {
            _head = _tail = null;
        }
        else
        {
            _tail = _tail.Previous;
            _tail.Next = null;
        }
        _count--;
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node current = _head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }
    public void Remove(T value)
    {
        if (_head == null)
            return;

        Node current = _head;
        while (current != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Value, value))
            {
                if (current.Previous != null)
                {
                    current.Previous.Next = current.Next;
                }
                else
                {
                    _head = current.Next;
                }

                if (current.Next != null)
                {
                    current.Next.Previous = current.Previous;
                }
                else
                {
                    _tail = current.Previous;
                }

                _count--;
                return;
            }
            current = current.Next;
        }
    }

    public void Clear()
    {
        _head = _tail = null;
        _count = 0;
    }

    public Node Find(T value)
    {
        var current = _head;
        while (current != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Value, value))
                return current;
            current = current.Next;
        }
        return null;
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public class Node
    {
        public T Value { get; set; }
        public Node Previous { get; set; }
        public Node Next { get; set; }

        public Node(T t)
        {
            Value = t;
            Previous = null;
            Next = null;
        }


    }
}