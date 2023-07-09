namespace Task4;

public class SimpsonMethod : INumericalIntegration
{
    public string MethodName => "Simpson's Method";

    public double CalculateIntegral(Func<double, double> function, double lowerBound, double upperBound, double accuracy)
    {
        double stepSize = accuracy; 

        int numSegments = (int)((upperBound - lowerBound) / stepSize); 

        if (numSegments % 2 != 0)
        {
            numSegments++; 
        }

        double segmentWidth = (upperBound - lowerBound) / numSegments;

        double integral = 0.0;

        for (int i = 0; i < numSegments; i += 2)
        {
            double x0 = lowerBound + i * segmentWidth; 
            double x1 = lowerBound + (i + 1) * segmentWidth; 
            double x2 = lowerBound + (i + 2) * segmentWidth; 

            double y0 = function(x0); 
            double y1 = function(x1); 
            double y2 = function(x2); 

            double segmentArea = segmentWidth * (y0 + 4 * y1 + y2) / 3.0; 
            integral += segmentArea;
        }

        return integral;
    }
}