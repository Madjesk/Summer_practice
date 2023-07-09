namespace Task3;

public class IntComparer: IComparer<int>
{
    public int Compare(int x, int y)
    {
        return (x - y);
    }
}
