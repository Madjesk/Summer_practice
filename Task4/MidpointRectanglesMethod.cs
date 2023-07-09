namespace Task4;

public class MidpointRectanglesMethod : INumericalIntegration
{
    public string MethodName => "Midpoint Rectangle Method";

    public double CalculateIntegral(Func<double, double> function, double lowerBound, double upperBound, double accuracy)
    {
        double stepSize = accuracy; 

        double integral = 0.0;
        double x = lowerBound + stepSize / 2.0; // Середина каждого прямоугольника

        while (x <= upperBound)
        {
            integral += function(x) * stepSize;
            x += stepSize;
        }

        return integral;
    }
}