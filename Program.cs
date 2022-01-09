using System.Linq.Expressions;
using System.Threading;
using System;

namespace ThreadSynchronization
{
    class Program
    {

        static void Main(string[] args)
        {
            //Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} Main Thread...");
            AutoResetEventSample.Run();
        }



    }
}