using System;
using System.Threading;

namespace LamdaExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "";
            Thread th = new Thread(()=>{
                // for(int i = 0; i < 10; i ++){
                    Console.WriteLine("I am inside " + Thread.CurrentThread.Name);
                //     Thread.Sleep(1000);
                // }
                name = "Ashish";
            });
            th.Name = "LamdaExpression Thread";
            th.Start();

            th.Join();
            Console.WriteLine(name);

            for(int i = 0; i < 50; i ++){
                Console.WriteLine("I am inside " + Thread.CurrentThread.Name);
                Thread.Sleep(1000);
            }
        }
    }
}
