using Task3;
using static ArrayExtensions;

class Program
{
    public static int IntComparer2(int x, int y)
    {
        return (x - y);
    }
    
    static void Main()
    {
        int[] arr = { 5, 2, 10, 1, 6 };
        try
        {
            var sortedNumbers1 = arr.Sort(SortOrder.Ascending, SortingAlgorithm.InsertionSort);
            var sortedNumbers2 = arr.Sort(SortOrder.Ascending, SortingAlgorithm.HeapSort, new IntComparer());
            var sortedNumbers3 = arr.Sort(SortOrder.Ascending, SortingAlgorithm.QuickSort, Comparer<int>.Create(new Comparison<int>(IntComparer2)));
            var sortedNumbers4 = arr.Sort(SortOrder.Ascending, SortingAlgorithm.MergeSort,  new Comparison<int>(IntComparer2));
            var sortedNumbers5 = arr.Sort(SortOrder.Ascending, SortingAlgorithm.SelectionSort);
            foreach (int number in sortedNumbers1)  Console.Write(number + " "); 
            Console.WriteLine();
            foreach (int number in sortedNumbers2)  Console.Write(number + " "); 
            Console.WriteLine();
            foreach (int number in sortedNumbers3)  Console.Write(number + " "); 
            Console.WriteLine();
            foreach (int number in sortedNumbers4)  Console.Write(number + " "); 
            Console.WriteLine();
            foreach (int number in sortedNumbers5)  Console.Write(number + " "); 
            Console.WriteLine();
            
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine("Произошла ошибка: " + ex.Message);
        }
    }
}
