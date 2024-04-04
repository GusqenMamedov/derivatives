using System;

class Program
{
    static void Main(string[] args)
    {
        double[] x = { 0.521, 0.523, 0.525, 0.527, 0.529 };
        double[] y = { 3.31894, 3.33426, 3.34965, 3.36511, 3.37858 };

        double[] firstDerivatives = CalculateFirstDerivatives(x, y);
        double[] secondDerivatives = CalculateSecondDerivatives(x, y);

        Console.WriteLine("1st derivatives:");
        for (int i = 0; i < firstDerivatives.Length; i++)
        {
            Console.WriteLine($"x = {x[i]}, dy/dx = {firstDerivatives[i]}");
        }

        Console.WriteLine("2nd derivatives:");
        for (int i = 0; i < secondDerivatives.Length; i++)
        {
            Console.WriteLine($"x = {x[i]}, d²y/dx² = {secondDerivatives[i]}");
        }
    }

    static double[] CalculateFirstDerivatives(double[] x, double[] y)
    {
        double[] firstDerivatives = new double[x.Length];

        for (int i = 0; i < x.Length; i++)
        {
            if (i > 0 && i < x.Length - 1)
            {
                firstDerivatives[i] = (y[i + 1] - y[i - 1]) / (x[i + 1] - x[i - 1]);
            }
            else if (i == 0)
            {
                firstDerivatives[i] = (-3 * y[i] + 4 * y[i + 1] - y[i + 2]) / (x[i + 2] - x[i]);
            }
            else
            {
                firstDerivatives[i] = (y[i - 2] - 4 * y[i - 1] + 3 * y[i]) / (x[i] - x[i - 2]);
            }
        }

        return firstDerivatives;
    }

    static double[] CalculateSecondDerivatives(double[] x, double[] y)
    {
        double[] secondDerivatives = new double[x.Length];

        for (int i = 0; i < x.Length; i++)
        {
            if (i > 0 && i < x.Length - 1)
            {
                secondDerivatives[i] = (y[i + 1] - 2 * y[i] + y[i - 1]) / Math.Pow(x[i + 1] - x[i], 2);
            }
            else if (i == 0)
            {
                secondDerivatives[i] = (-2 * y[i] + 5 * y[i + 1] - 4 * y[i + 2] + y[i + 3]) / Math.Pow(x[i + 1] - x[i], 2);
            }
            else
            {
                secondDerivatives[i] = (y[i - 3] - 4 * y[i - 2] + 5 * y[i - 1] - 2 * y[i]) / Math.Pow(x[i] - x[i - 1], 2);
            }
        }

        return secondDerivatives;
    }
}
