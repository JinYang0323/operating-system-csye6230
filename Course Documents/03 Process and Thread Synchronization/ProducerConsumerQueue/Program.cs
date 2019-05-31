using System;
using System.Threading;
using System.Collections.Generic;

namespace ProducerConsumerQueue
{
    class Program
    {
        static object obj = new Object();

        static Random rand = new Random();

        static Queue<int> queue = new Queue<int>();

        static void ProducerFunction()
        {
            while (true)
            {
                int val = rand.Next(50);
                queue.Enqueue(val);
                Console.WriteLine(Thread.CurrentThread.Name + " Enqued: " + val);
                Thread.Sleep(100);
            }
        }

        static void ConsumerFunction()
        {
            while (true)
            {
                if (queue.Count > 0)
                {
                    int val = queue.Dequeue();

                    Console.WriteLine(Thread.CurrentThread.Name + " Dequeued: " + val);
                    Thread.Sleep(50);

                }
            }
        }

        static void Main(string[] args)
        {
            // Thread bluetooth = new Thread(AddMoneyToBank);
            // Thread northEastern = new Thread(AddMoneyToBank);
            // bluetooth.Name = "Bluetooth";
            // northEastern.Name = "North Eastern";

            // bluetooth.Start();
            // Thread.Sleep(500);
            // northEastern.Start();

            Thread producer1 = new Thread(ProducerFunction);
            producer1.Name = "producer1";
            Thread producer2 = new Thread(ProducerFunction);
            producer2.Name = "producer2";
            Thread producer3 = new Thread(ProducerFunction);
            producer3.Name = "producer3";

            Thread consumer1 = new Thread(ConsumerFunction);
            consumer1.Name = "consumer1";
            Thread consumer2 = new Thread(ConsumerFunction);
            consumer2.Name = "consumer2";

            producer1.Start();
            Thread.Sleep(100);
            producer2.Start();
            Thread.Sleep(100);
            producer3.Start();
            Thread.Sleep(100);

            consumer1.Start();
            Thread.Sleep(100);
            consumer2.Start();
            Thread.Sleep(100);


            while (true)
            {
                Thread.Sleep(5000);
            }

        }
    }
}
