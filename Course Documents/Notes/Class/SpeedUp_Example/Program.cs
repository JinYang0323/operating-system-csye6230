using System;
using System.Diagnostics;
using System.Threading;

namespace SpeedUp_Example
{
    class Program
    {
        static int[] values = new int[500000000];
        static long[] partialResults = new long[Environment.ProcessorCount];
        static int portionSize;

        static void Main(string[] args)
        {
            Console.WriteLine("Number of Processors = " + Environment.ProcessorCount);
            portionSize = (int)500000000 / Environment.ProcessorCount;
            GenerateValues();
            Stopwatch watch = new Stopwatch();

            // Calculate result in serial execution
            watch.Start();
            long result = 0;
            for (int i = 0; i < values.Length; i++)
            {
                result += values[i];
            }
            watch.Stop();
            Console.WriteLine("Sum = " + result);
            Console.WriteLine("Time taken = " + watch.Elapsed);

            watch.Reset();
            watch.Start();

            //Now calculate result in Parallel
            Thread[] threads = new Thread[Environment.ProcessorCount];
            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                threads[i] = new Thread(() => SumValues(i));
                threads[i].Start();
            }
            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                threads[i].Join();
            }

            long partialresults = 0;
            for (int i = 0; i < partialResults.Length; i++)
            {
                partialresults += partialResults[i];
            }
            watch.Stop();

            Console.WriteLine("Sum = " + result);
            Console.WriteLine("Time taken = " + watch.Elapsed);
        }

        static void SumValues(int processorNumber)
        {
            long sum = 0;
            int index = (int)processorNumber;
            for (int i = index * portionSize; i < index * portionSize + portionSize; i++)
            {
                sum += values[i];
            }
            partialResults[index] = sum;
        }
        static void GenerateValues()
        {
            Random rand = new Random(956);
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = rand.Next(10);
            }
        }
    }
}
