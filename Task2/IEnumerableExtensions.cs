public static class EnumerableExtensions  
{
    public static IEnumerable<IEnumerable<T>> GetCombinations<T>(this IEnumerable<T> collection, int k, IEqualityComparer<T> comparer=null)
    {
        if (collection == null)
            throw new ArgumentNullException();
        
        if (k <= 0)
            throw new ArgumentException("The k must be greater than zero.");
        
        collection.CheckEquality(comparer);
        
        var elements = collection.ToList();
        if (k > elements.Count)
            throw new ArgumentException("k must not exceed the number of elements in the input collection.");

        var combinations = new List<T>();
        var results = new List<IEnumerable<T>>();

        GenerateCombinations(elements, k, 0, combinations, results);

        return results;
    }

    private static void GenerateCombinations<T>(List<T> elements, int k, int startIndex, List<T> combinations, List<IEnumerable<T>> results)
    {
        if (combinations.Count == k)
        {
            results.Add(combinations.ToList());
            return;
        }

        for (int i = startIndex; i < elements.Count; i++)
        {
            combinations.Add(elements[i]);
            GenerateCombinations(elements, k, i, combinations, results);
            combinations.RemoveAt(combinations.Count - 1);
        }
    }
    
    public static IEnumerable<IEnumerable<T>> GetAllSubsets<T>(this IEnumerable<T> collection, IEqualityComparer<T> comparer=null)
    {
        collection.CheckEquality(comparer);
        
        var inputList = collection.ToList();
        var subsets = new List<List<T>> { new List<T>() };  
        
        foreach (var item in inputList)
        {
            var currentSubsets = new List<List<T>>();
            
            foreach (var subset in subsets)
            {
                var newSubset = new List<T>(subset) { item };
                currentSubsets.Add(newSubset);
            }
            subsets.AddRange(currentSubsets);
        }
        
        return subsets;
    }
    
    public static IEnumerable<IEnumerable<T>> GetAllPermutations<T>(this IEnumerable<T> collection, IEqualityComparer<T> comparer=null)
    {
        collection.CheckEquality(comparer);
        
        var inputList = collection.ToList();
        var length = inputList.Count;
    
        if (length == 0)
        {
            throw new ArgumentException("Wrong lenght");
        }
        if (length == 1)
        {
            yield return inputList; 
        }
        else
        {
            for (int i = 0; i < length; i++)
            {
                var element = inputList[i];
                var remainingElements = inputList.Take(i).Concat(inputList.Skip(i + 1)); //all elements without curr element
                var permutationsOfRemaining = GetAllPermutations(remainingElements);

                foreach (var permutation in permutationsOfRemaining)
                {
                    yield return new List<T> { element }.Concat(permutation);
                }
            }
        }
    }
    
    private static bool CheckEquality<T>(this IEnumerable<T> collection, IEqualityComparer<T> comparer = null)
    {
        if (collection == null)
            throw new ArgumentNullException(nameof(collection));

        comparer ??= EqualityComparer<T>.Default;
        var uniqueElements = new HashSet<T>(comparer);

        foreach (var element in collection)
        {
            if (!uniqueElements.Add(element))
            {
                throw new ArgumentException("Duplicate elements found.", nameof(collection));
            }
        }

        return true;
    }
    
}