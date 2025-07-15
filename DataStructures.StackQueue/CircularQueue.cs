namespace DataStructures.StackQueue;

public class CircularQueue<T>
{
    private T[] elements;
    private int head = 0;
    private int tail = 0;
    private int count = 0;
    private int capacity;

    private const int DEFAULT_SIZE = 5;

    public CircularQueue(int initizalSize = DEFAULT_SIZE)
    {
        capacity = initizalSize;
        elements = new T[capacity];
    }

    public void Enqueue(T item)
    {
        if (count == capacity)
        {
            Extend();
        }

        elements[tail] = item;
        tail = (tail + 1) % capacity; // circular increment
        count++;
    }

    private void Extend()
    {
        var newCapacity = capacity * 2;
        var newArray = new T[newCapacity];

        for (int i = 0; i < count; i++)
        {
            newArray[i] = elements[(head + i) % capacity];
        }

        elements = newArray;
        capacity = newCapacity;
        head = 0;
        tail = count;
    }

    public T Dequeue()
    {

        ThrowIfEmpty();
        T item = elements[head];

        elements[head] = default;
        head = (head + 1) % capacity; // circular increment
        count--;

        return item;
    }

    public bool IsEmpty()
    {
        return count == 0;
    }

    private void ThrowIfEmpty()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Queue is empty");
        }
    }
}
