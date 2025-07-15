namespace DataStructures.StackQueue;

public class MyStack<T> //LIFO - last in first out
{
    private const int DEFAULT_SIZE = 50;
    private T[] elements;
    private int top = -1; //top, index harda saxlayacam... popu burdan edirik
    private int count => top + 1; 
    public MyStack(int initialSize = DEFAULT_SIZE)
    {
        elements = new T[initialSize];
    }

    public void Push(T item)
    {
        if (top == elements.Length - 1) //doldurubsa
        {
            Extend(); //boyutlandiriram
        }

        top++;
        elements[top] = item;
    }

    private void Extend() //old->1 2   new->1 2 0 0 
    {
        var newArray = new T[elements.Length * 2];
        Array.Copy(elements, newArray, elements.Length);
        elements = newArray;
    }

    public T Pop()
    {
        ThrowIfEmpty();
        if (top>0 && top == elements.Length / 4) //4de birine qeder dusubse,(dordde biri qalibsa) shrink edecem
        {
            Shrink();
        }

        T item = elements[top]; //sonuncu giren birinci cixir
        elements[top--] = default; //0, o top'u silirem

        return item;
    }
    private void ThrowIfEmpty()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Stack is empty");
        }
    }

    public bool IsEmpty()
    {
        return top == -1;
    }

    private void Shrink() // 1 2 0 0    1 2
    {
        var newArray = new T[elements.Length / 2];
        Array.Copy(elements, 0, newArray, 0, top + 1);
        elements = newArray;
        
    }

    public void Peek()
    {
        ThrowIfEmpty();
        Console.WriteLine(elements[top]);
    }
}
