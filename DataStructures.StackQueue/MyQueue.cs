namespace DataStructures.StackQueue;

public class MyQueue<T> //fifo - first in first out
{
    private const int DEFAULT_SIZE = 50;
    private T[] elements;
    private int head; //head, index harda saxlayacam... dequeueni burdan edirik
    private int tail = -1; //tail, index hansi siraya add edecem... enqueueni burdan edirik
    private int count = 0;//nece var tailde

    //0, 0, 0, 0, 0
    public MyQueue(int initialSize = DEFAULT_SIZE)
    {
        elements = new T[initialSize];
    }

    public void Enqueue(T item)
    {
        if(count == elements.Length) //dolubsa
        {
            Extend(); //genislendirirem
        }

        tail++;
        elements[tail] = item;
        count++;
    }

    public T Dequeue()
    {
        ThrowIfEmpty();

        T item = elements[head]; //ilk giren birinci cixir
        elements[head] = default!; //0, o head'i silirem
        head++;
        count--;

        if(count > 0 && count == elements.Length / 4) //4de birine qeder dusubse,(dordde biri qalibsa) shrink edecem
        {
            Shrink();
        } 

        return item;
    }

    private void ThrowIfEmpty()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Queue is empty");
        }
    }
    public bool IsEmpty()
    {
        return count == 0;
    }

    private void Extend() //old->1 2 3   new->1 2 3 0 0 0
    {
        var newArray = new T[elements.Length * 2];
        Array.Copy(elements, head, newArray, 0, count);
        elements = newArray;
        head = 0;
        tail = count - 1;
    }

    private void Shrink() //1 2 3 0 0 0 azalirsa qabaqdan sile sile gliersen
    {
        int capacity = elements.Length / 2;
        var newArray = new T[capacity];

        Array.Copy(elements, head, newArray, 0, count);
        elements = newArray;

        head = 0;
        tail = count - 1; //taili sonuncu elemente set edirem
    }
}

