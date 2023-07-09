namespace Task4;

public class LeftRectanglesMethod : INumericalIntegration
{
    public string MethodName => "Left Rectangle Method";

    public double CalculateIntegral(Func<double, double> function, double lowerBound, double upperBound, double accuracy)
    {
        double stepSize = accuracy; 

        double integral = 0.0;
        double x = lowerBound;

        while (x < upperBound)
        {
            integral += function(x) * stepSize;
            x += stepSize;
        }

        return integral;
    }
}