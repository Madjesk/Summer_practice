namespace Task4;

public interface INumericalIntegration
{
    double CalculateIntegral(Func<double, double> function, double lowerBound, double upperBound, double accuracy); 
    string MethodName { get; }
}