namespace Task5;

class Program
{
    static void Main()
    {
        LinkedList<int> list = new LinkedList<int>();
        list.PushFront(10);
        list.PushBack(20);
        list.PushBack(30);
        list.PushAtIndex(99, 1);

        Console.WriteLine(list[0]); 
        Console.WriteLine(list[1]); 
        Console.WriteLine(list[2]); 
        Console.WriteLine(list[3]);

    }
}