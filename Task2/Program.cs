using Task2;
public class Program
{
    public static void Main()
    {
        try
        {
            var numbers = new[] { 1, 2, 3};
            var combinations = EnumerableExtensions.GetCombinations(numbers, 2, new CustomEqualityComparer<int>());
            foreach (var combination in combinations)
            {
                Console.WriteLine("[" + string.Join(", ", combination) + "]");
            }

            Console.WriteLine();

            var subsets = EnumerableExtensions.GetAllSubsets(numbers, new CustomEqualityComparer<int>());
            foreach (var subset in subsets)
            {
                Console.WriteLine("[" + string.Join(", ", subset) + "]");
            }

            Console.WriteLine();

            var permutations = EnumerableExtensions.GetAllPermutations(numbers, new CustomEqualityComparer<int>());
            foreach (var permutation in permutations)
            {
                Console.WriteLine("[" + string.Join(", ", permutation) + "]");
            }
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine("Произошла ошибка: " + ex.Message);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Произошла ошибка: " + ex.Message);
        }
        
    }
}
