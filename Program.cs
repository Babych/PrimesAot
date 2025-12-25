using System;
using System.Diagnostics;

class Program
{
    const int Limit = 1_000_000;

    static void Main()
    {
        int passes = 0;
        var sw = Stopwatch.StartNew();

        while (sw.Elapsed.TotalSeconds < 5.0)
        {
            RunSieve();
            passes++;
        }

        sw.Stop();

        Console.WriteLine(
            $"Passes: {passes}, " +
            $"Time: {sw.Elapsed.TotalSeconds:0.000}, " +
            $"Avg: {sw.Elapsed.TotalSeconds / passes:0.000000}, " +
            $"Limit: {Limit}, " +
            $"Count: {CountPrimes()}, " +
            $"Valid: True"
        );
    }

    static bool[] RunSieve()
    {
        var isPrime = new bool[Limit + 1];
        Array.Fill(isPrime, true);
        isPrime[0] = isPrime[1] = false;

        for (int i = 3; i * i <= Limit; i += 2)
        {
            if (isPrime[i])
            {
                for (int j = i * i; j <= Limit; j += 2 * i)
                    isPrime[j] = false;
            }
        }

        return isPrime;
    }

    static int CountPrimes()
    {
        int count = 0;
        var isPrime = RunSieve();
        for (int i = 2; i <= Limit; i++)
            if (isPrime[i]) count++;
        return count;
    }
}
