using System;
using System.Threading;

namespace ThreadSynchronization
{
    public static class ManualResetEventSample
    {
        public static void Run()
        {
            for (var i = 0; i < 5; i++)
            {
                
            }
        }

        public static void Write()
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} writing...");
            Thread.Sleep(2000);
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} writing completed...");
        }

        public static void Read()
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} writing...");
            Thread.Sleep(2000);
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} writing completed...");
        }


    }


}