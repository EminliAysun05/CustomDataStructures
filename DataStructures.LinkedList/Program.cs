namespace DataStructures.LinkedList;

public class Program
{
    static void Main(string[] args)
    {
        CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
        customLinkedList.AddFirst(10);
        customLinkedList.AddLast(20);
        customLinkedList.AddLast(new[] {3, 15, 25 });
        customLinkedList.AddMiddle(45,3);
        //customLinkedList.RemoveFirst();
       // customLinkedList.RemoveLast();
      // customLinkedList.RemoveWithValue(20);
        Print();
        Console.ReadLine();

        void Print()
        {
            foreach (var item in customLinkedList)
            {
                Console.WriteLine(item);
            }
        }
    }
   

}


