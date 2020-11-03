using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CarMakerProblem
{
    public static class CarMakerProblem
    {
        const int CAPACITY = 2;
        static Random random = new Random();

        static Queue<int> clients = new Queue<int>(CAPACITY);

        static Semaphore exclude = new Semaphore(1, 1);
        static Semaphore empty = new Semaphore(0, CAPACITY);
        static Semaphore full = new Semaphore(CAPACITY, CAPACITY);

        public static void CarMaker()
        {
            while (true)
            {
                Thread.Sleep(random.Next(1000, 2000));

                empty.WaitOne();
                exclude.WaitOne();

                if (clients.Count() > 0)
                {
                    Console.WriteLine("  CarMaker working...");
                    Thread.Sleep(random.Next(1000, 2000));
                    Console.WriteLine("  CarMaker done.");

                    Console.WriteLine("  Client " + clients.ElementAt(0) + " served.");
                    clients.Dequeue();
                }
                else
                {
                    Console.WriteLine("CarMaker waiting..");
                }

                try
                {
                    full.Release();
                }
                catch
                {
                }

                exclude.Release();
            }
        }

        public static void Client(Object o)
        {
            var n = (int)o;

            while (true)
            {
                Thread.Sleep(random.Next(1000, 2000));

                full.WaitOne();
                exclude.WaitOne();

                if (clients.Count() < CAPACITY)
                {
                    Console.WriteLine("  Client " + n + " waiting...");
                    clients.Enqueue(n);
                }
                else
                {
                    Console.WriteLine("  Client " + n + " no space.");
                }

                try
                {
                    empty.Release();
                }
                catch
                {
                }

                exclude.Release();
            }
        }
    }
}

