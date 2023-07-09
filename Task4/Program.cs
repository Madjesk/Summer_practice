using System.Diagnostics;

namespace Task4;

class Program
{
    static void Main(string[] args)
    {
        var functions = new Dictionary<string, Func<double, double>>
        {
            { "е^х", x => Math.Exp(x) },
            { "sin(x)", Math.Sin },
            { "cos(x)", Math.Cos }
        };

        var integrationMethods = new List<INumericalIntegration>
        {
            new LeftRectanglesMethod(),
             new RightRectanglesMethod(),
             new MidpointRectanglesMethod(),
             new TrapezoidalMethod(),
             new SimpsonMethod()
        };

        double lowerBound = 0.0;
        double upperBound = 1.0;
        double accuracy = 0.0001;

        foreach (var functionEntry in functions)
        {
            var functionName = functionEntry.Key;
            var function = functionEntry.Value;

            Console.WriteLine($"Function: {functionName}");

            foreach (var integrationMethod in integrationMethods)
            {
                var methodName = integrationMethod.MethodName;

                var stopwatch = Stopwatch.StartNew();
                double result = integrationMethod.CalculateIntegral(function, lowerBound, upperBound, accuracy);
                stopwatch.Stop();

                Console.WriteLine($"Method: {methodName}");
                Console.WriteLine($"Integral value: {result}");
                Console.WriteLine($"Iterations: {GetIterationsCount(lowerBound, upperBound, accuracy)}");
                Console.WriteLine($"Time: {stopwatch.ElapsedMilliseconds} ms");
                Console.WriteLine();
            }
        }
    }

    public static int GetIterationsCount(double lowerBound, double upperBound, double accuracy)
    {
        double stepSize = accuracy;
        int iterations = (int)((upperBound - lowerBound) / stepSize);
        return iterations;
    }
}
