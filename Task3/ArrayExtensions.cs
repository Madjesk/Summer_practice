public static class ArrayExtensions
{
    public enum SortOrder
    {
        Ascending,
        Descending
    }

    public enum SortingAlgorithm
    {
        InsertionSort,
        SelectionSort,
        HeapSort,
        QuickSort,
        MergeSort
    }
    
    private static int CompareToMethod<T>(T? x, T? y) where T : IComparable<T>
    {
        if (x == null && y != null) return -1;
        if (x != null && y == null) return 1;
        if (x == null && y == null) return 0;
        if (x != null && y != null) return x.CompareTo(y);
        return 0;
    }
    
    public static T[] Sort<T>(
        this T[] collection,
        SortOrder sortOrder,
        SortingAlgorithm sortingAlgorithm) where T : IComparable<T>
    {
        Comparison<T> comparerDelegate = CompareToMethod<T>;
        return ChooseSortingAlgorithm(collection, sortOrder, sortingAlgorithm, comparerDelegate );
    }
    
    public static T[] Sort<T>(
        this T[] collection,
        SortOrder sortOrder,
        SortingAlgorithm sortingAlgorithm,
        Comparison<T> comparer)
    {
        return ChooseSortingAlgorithm(collection, sortOrder, sortingAlgorithm, comparer);
    }

    public static T[] Sort<T>(
        this T[] collection,
        SortOrder sortOrder,
        SortingAlgorithm sortingAlgorithm,
        Comparer<T> comparer)
    {
        var comparerDelegate = new Comparison<T>(comparer.Compare);
        return ChooseSortingAlgorithm(collection, sortOrder, sortingAlgorithm, comparerDelegate);
    }
    
    public static T[] Sort<T>(
        this T[] collection,
        SortOrder sortOrder,
        SortingAlgorithm sortingAlgorithm,
        IComparer<T> comparer)
    {
        var comparerDelegate = new Comparison<T>(comparer.Compare);
        return ChooseSortingAlgorithm(collection, sortOrder, sortingAlgorithm, comparerDelegate);
    }

    private static T[] ChooseSortingAlgorithm<T>(T[] collection, SortOrder sortOrder,
        SortingAlgorithm sortingAlgorithm, Comparison<T> comparer)
    {
        switch (sortingAlgorithm)
        {
            case SortingAlgorithm.InsertionSort:
            return InsertionSort(collection, sortOrder, comparer);
            case SortingAlgorithm.SelectionSort:
                return SelectionSort(collection, sortOrder, comparer);
            case SortingAlgorithm.HeapSort:
                return HeapSort(collection, sortOrder, comparer);
            case SortingAlgorithm.QuickSort:
                return QuickSort(collection, sortOrder, comparer);
            case SortingAlgorithm.MergeSort:
                return MergeSort(collection, sortOrder, comparer);
            default:
                throw new ArgumentException("Invalid sorting algorithm specified.");
        }
    }

    private static int CompareItems<T>(T item1, T item2, SortOrder sortOrder, Comparison<T> comparer)
    {
        if (sortOrder == SortOrder.Ascending)
            return comparer(item1, item2);
        else
            return comparer(item2, item1);
    }
    
    private static T[] InsertionSort<T>(T[] collection, SortOrder sortOrder, Comparison<T> comparer)
    {
        int length = collection.Length;

        for (int i = 1; i < length; i++)
        {
            T key = collection[i];
            int j = i - 1;

            while (j >= 0 && CompareItems(collection[j], key, sortOrder, comparer) > 0)
            {
                collection[j + 1] = collection[j];
                j--;
            }

            collection[j + 1] = key;
        }

        return collection;
    }
    
    private static T[] SelectionSort<T>(T[] collection, SortOrder sortOrder, Comparison<T> comparer)
    {
        int length = collection.Length;

        for (int i = 0; i < length - 1; i++)
        {
            int minIndex = i;

            for (int j = i + 1; j < length; j++)
            {
                if (CompareItems(collection[j], collection[minIndex], sortOrder, comparer) < 0)
                    minIndex = j;
            }

            if (minIndex != i)
            {
                Swap(collection, i, minIndex);
            }
        }

        return collection;
    }
    
    private static T[] HeapSort<T>(T[] collection, SortOrder sortOrder, Comparison<T> comparer)
    {
        int length = collection.Length;

        for (int i = length / 2 - 1; i >= 0; i--)
            Heapify(collection, length, i, sortOrder, comparer);

        for (int i = length - 1; i >= 1; i--)
        {
            Swap(collection, 0, i);
            Heapify(collection, i, 0, sortOrder, comparer);
        }

        return collection;
    }

    private static void Heapify<T>(T[] collection, int length, int rootIndex, SortOrder sortOrder, Comparison<T> comparer)
    {
        int largestIndex = rootIndex; 
        int leftChildIndex = 2 * rootIndex + 1; 
        int rightChildIndex = 2 * rootIndex + 2; 

        if (leftChildIndex < length && CompareItems(collection[leftChildIndex], collection[largestIndex], sortOrder, comparer) > 0)
            largestIndex = leftChildIndex;

        if (rightChildIndex < length && CompareItems(collection[rightChildIndex], collection[largestIndex], sortOrder, comparer) > 0)
            largestIndex = rightChildIndex;

        if (largestIndex != rootIndex)
        {
            Swap(collection, rootIndex, largestIndex);
            Heapify(collection, length, largestIndex, sortOrder, comparer);
        }
    }
    
    private static T[] QuickSort<T>(T[] collection, SortOrder sortOrder, Comparison<T> comparer)
    {
        QuickSortRecursive(collection, 0, collection.Length - 1, sortOrder, comparer);
        return collection;
    }

    private static void QuickSortRecursive<T>(T[] collection, int left, int right, SortOrder sortOrder, Comparison<T> comparer)
    {
        if (left < right)
        {
            int pivotIndex = Partition(collection, left, right, sortOrder, comparer);
            QuickSortRecursive(collection, left, pivotIndex - 1, sortOrder, comparer);
            QuickSortRecursive(collection, pivotIndex + 1, right, sortOrder, comparer);
        }
    }

    private static int Partition<T>(T[] collection, int left, int right, SortOrder sortOrder, Comparison<T> comparer)
    {
        T pivot = collection[right];
        int i = left - 1;

        for (int j = left; j < right; j++)
        {
            if (CompareItems(collection[j], pivot, sortOrder, comparer) <= 0)
            {
                i++;
                Swap(collection, i, j);
            }
        }

        Swap(collection, i + 1, right);
        return i + 1;
    }

    private static void Swap<T>(T[] collection, int index1, int index2)
    {
        T temp = collection[index1];
        collection[index1] = collection[index2];
        collection[index2] = temp;
    }

    private static T[] MergeSort<T>(T[] collection, SortOrder sortOrder, Comparison<T> comparer)
    {
        if (collection.Length <= 1)
            return collection;

        int mid = collection.Length / 2;
        T[] leftArray = new T[mid];
        T[] rightArray = new T[collection.Length - mid];

        Array.Copy(collection, 0, leftArray, 0, mid);
        Array.Copy(collection, mid, rightArray, 0, collection.Length - mid);

        leftArray = MergeSort(leftArray, sortOrder, comparer);
        rightArray = MergeSort(rightArray, sortOrder, comparer);

        return MergeArrays(leftArray, rightArray, sortOrder, comparer);
    }

    private static T[] MergeArrays<T>(T[] leftArray, T[] rightArray, SortOrder sortOrder, Comparison<T> comparer)
    {
        int leftLength = leftArray.Length;
        int rightLength = rightArray.Length;
        int totalLength = leftLength + rightLength;
        T[] mergedArray = new T[totalLength];

        int i = 0, j = 0, k = 0;

        while (i < leftLength && j < rightLength)
        {
            if (CompareItems(leftArray[i], rightArray[j], sortOrder, comparer) <= 0)
            {
                mergedArray[k] = leftArray[i];
                i++;
            }
            else
            {
                mergedArray[k] = rightArray[j];
                j++;
            }
            k++;
        }

        while (i < leftLength)
        {
            mergedArray[k] = leftArray[i];
            i++;
            k++;
        }

        while (j < rightLength)
        {
            mergedArray[k] = rightArray[j];
            j++;
            k++;
        }

        return mergedArray;
    }

}