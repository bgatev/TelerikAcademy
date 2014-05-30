using System;

public class Statistics
{
    public void PrintStatistics(double[] inputData, int dataSize)
    {
        double maxElement = int.MinValue, minElement = int.MaxValue, avgElement = 0;

        for (int i = 0; i < dataSize; i++)
        {
            if (inputData[i] > maxElement)
            {
                maxElement = inputData[i];
            }
        }

        PrintMaxElement(maxElement);

        for (int i = 0; i < dataSize; i++)
        {
            if (inputData[i] < minElement)
            {
                minElement = inputData[i];
            }
        }

        PrintMinElement(minElement);

        for (int i = 0; i < dataSize; i++)
        {
            avgElement += inputData[i];
        }

        PrintAvgElement(avgElement / dataSize);
    }

    private void PrintAvgElement(double element)
    {
        Console.WriteLine(element);
    }

    private void PrintMinElement(double element)
    {
        Console.WriteLine(element);
    }

    private void PrintMaxElement(double element)
    {
        Console.WriteLine(element);
    }
}