namespace DataStructures.StackQueue
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region MyQueue Example
            //MyQueue<int> queue = new MyQueue<int>(1);
            //queue.Enqueue(1);
            //queue.Enqueue(2);

            //var firstItem = queue.Dequeue(); // 1
            //Console.WriteLine($"ilk element: {firstItem}");

            //var secondItem = queue.Dequeue(); // 2
            //Console.WriteLine($"ikinci element: {secondItem}");

            #endregion


            #region CircularQueue Example
            //var queue = new CircularQueue<string>(5);

            //Console.WriteLine("----- İlk 5 Enqueue -----");
            //queue.Enqueue("A");
            //queue.Enqueue("B");
            //queue.Enqueue("C");
            //queue.Enqueue("D");
            //queue.Enqueue("E");
            //PrintStatus(queue);

            //// 2. 3 dənə Dequeue edək
            //Console.WriteLine("\n----- 3 Dequeue -----");
            //queue.Dequeue();
            //queue.Dequeue();
            //queue.Dequeue();
            //PrintStatus(queue);

            //// 3. 3 yeni element əlavə edək (fırlanacaq)
            //Console.WriteLine("\n----- 3 Enqueue (F, G, H) -----");
            //queue.Enqueue("F");
            //queue.Enqueue("G");
            //queue.Enqueue("H");
            //PrintStatus(queue);

            //// 4. 1 dənə də əlavə edək (Extend çağırılacaq!)
            //Console.WriteLine("\n----- 1 Enqueue (I) - Extend çağırılır -----");
            //queue.Enqueue("I");
            //PrintStatus(queue);

            //Console.ReadKey();

            //var queue1 = new CircularQueue<string>();
            //queue1.Enqueue("A");
            //queue1.Enqueue("B");
            //Console.WriteLine(queue1.Peek());
            #endregion

            #region Stack
            //var stack = new MyStack<string>();

            //Console.WriteLine("Stack boşdurmu? " + stack.IsEmpty()); // True

            //Console.WriteLine("\n 3 element elave olunur...");
            //stack.Push("A");
            //stack.Push("B");
            //stack.Push("C");

            //Console.Write("Peek (sonuncu element): ");
            //stack.Peek(); // C

            //Console.WriteLine("Stack boşdurmu? " + stack.IsEmpty()); // False

            //Console.WriteLine("\n Elementler bir-bir çıxarılır:");
            //Console.WriteLine("Pop: " + stack.Pop()); // C
            //Console.WriteLine("Pop: " + stack.Pop()); // B

            //Console.Write("Peek: ");
            //stack.Peek(); // A

            //Console.WriteLine("Pop: " + stack.Pop()); // A

            //Console.WriteLine("\nStack boşdurmu? " + stack.IsEmpty()); // True

            //try
            //{
            //    Console.WriteLine("\n Boş stack üzerinde Pop test edilir:");
            //    stack.Pop(); // throw exception
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Error: " + ex.Message);
            //}
            #endregion

        }

        #region CircularQueue Example
        //static void PrintStatus(CircularQueue<string> queue)
        //{
        //    Console.WriteLine("Queue Status:");

        //    var queueType = typeof(CircularQueue<string>);
        //    var elementsField = queueType.GetField("elements", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        //    var headField = queueType.GetField("head", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        //    var tailField = queueType.GetField("tail", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        //    var countField = queueType.GetField("count", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        //    var capacityField = queueType.GetField("capacity", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

        //    var elements = (string[])elementsField.GetValue(queue);
        //    int head = (int)headField.GetValue(queue);
        //    int tail = (int)tailField.GetValue(queue);
        //    int count = (int)countField.GetValue(queue);
        //    int capacity = (int)capacityField.GetValue(queue);

        //    Console.WriteLine($"Head: {head}");
        //    Console.WriteLine($"Tail: {tail}");
        //    Console.WriteLine($"Count: {count}");
        //    Console.WriteLine($"Capacity: {capacity}");
        //    Console.Write("Elements: [");

        //    for (int i = 0; i < elements.Length; i++)
        //    {
        //        Console.Write(elements[i] ?? "null");
        //        if (i < elements.Length - 1)
        //            Console.Write(", ");
        //    }

        //    Console.WriteLine("]");
        //}

        #endregion
    }
}
