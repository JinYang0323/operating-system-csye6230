using System;
using System.Threading;

namespace SimpleThread
{

    class Program
    {

        private static void SharedFunction()
        {
            Console.WriteLine("I am shared function");

        }

        private static int sharedInt = 5;
        static void Main(string[] args)
        {
            Thread current = Thread.CurrentThread;
            Console.WriteLine(current.Name);
            current.Name = "Main Thread";
            Console.WriteLine(current.Name);

            // Thread th1 = new Thread(AnotherThreadfunction);
            // th1.Start();

            // Thread th = new Thread(SimpleThreadFunction);
            // th.Name = "Simple Thread";
            // th.IsBackground = true;             //this is the background thread
            // th.Start();
            // SimpleThreadFunction();

            // sharedInt = 4;

            Thread thread_Eat = new Thread(EatFoodFunction);
            FoodItem food = new FoodItem();
            food.Name = "Hamburger";
            food.Price = 10;
            food.cusine = Cusine.American;
            thread_Eat.Start(food);

            // This is the main funcition
            // Even main function exit, the simple thread will continue
            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine("I am in " + Thread.CurrentThread.Name + " " + i);
                Thread.Sleep(1000);
            }
        }

        public static void EatFoodFunction(object obj)
        {
            try
            {
                FoodItem item = (FoodItem)obj;
                Console.WriteLine("Eating {0}, which is {1}, and price is {2}",
                item.Name, item.cusine, item.Price);
                for(int i = 0; i < 10; i++){
                    Console.WriteLine("I am eating food while main function can do its work");
                    Thread.Sleep(1000);
                }
            }
            catch
            {
                Console.WriteLine("Something is fishy about the food");
            }



        }
        public static void AnotherThreadfunction()
        {

        }
        public static void SimpleThreadFunction()
        {
            Console.WriteLine("Entering Simple Thread");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("I am in " + Thread.CurrentThread.Name + " " + i);
                Thread.Sleep(1000);
            }
            SharedFunction();
            sharedInt = 10;
            Console.WriteLine("Exiting Simple Thread");

        }
    }
}
