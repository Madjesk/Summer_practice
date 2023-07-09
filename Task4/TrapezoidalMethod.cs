namespace Task4;

public class TrapezoidalMethod : INumericalIntegration
{
    public string MethodName => "Trapezoidal Method";

    public double CalculateIntegral(Func<double, double> function, double lowerBound, double upperBound, double accuracy)
    {
        double stepSize = accuracy; 

        int numSegments = (int)((upperBound - lowerBound) / stepSize); 

        double integral = 0.0;

        for (int i = 0; i < numSegments; i++)
        {
            double x0 = lowerBound + i * stepSize; 
            double x1 = lowerBound + (i + 1) * stepSize; 

            double y0 = function(x0); 
            double y1 = function(x1); 

            double segmentArea = (y0 + y1) * stepSize / 2.0; 
            integral += segmentArea;
        }

        return integral;
    }
}
