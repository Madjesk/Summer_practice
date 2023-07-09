namespace Task4;

public class RightRectanglesMethod: INumericalIntegration
{
    public string MethodName => "Right Rectangle Method";

    public double CalculateIntegral(Func<double, double> function, double lowerBound, double upperBound,
        double accuracy)
    {
        double stepSize = accuracy;

        double integral = 0.0;
        double x = lowerBound + stepSize; 

        while (x <= upperBound)
        {
            integral += function(x) * stepSize;
            x += stepSize;
        }

        return integral;
    }
}