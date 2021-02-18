using System;
using System.Collections.Generic;
using System.Threading;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t1 = new Thread(() => Console.WriteLine("Thread 1"));
            t1.Start();
            Thread t2 = new Thread(() => Console.WriteLine("Thread 2"));
            t2.Start();
        }
    }
}
