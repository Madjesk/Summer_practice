namespace Task2;

public class CustomEqualityComparer<T> : IEqualityComparer<T>
{
    public bool Equals(T x, T y)
    {
        return EqualityComparer<T>.Default.Equals(x, y);
    }

    public int GetHashCode(T obj)
    {
        return EqualityComparer<T>.Default.GetHashCode(obj);
    }
}