using System;
using System.Threading;

namespace ThreadSynchronization
{
    public class AutoResetEventSample
    {
        private static object _locker = new Object();

        private static AutoResetEvent objAuto = new AutoResetEvent(false);


        public static void Run()
        {
            #region One

            // new Thread(DoWork_One).Start();

            // Console.ReadLine();
            
            // objAuto.Set();
            
            #endregion

            #region two

            for (int i = 0; i < 5; i++)
            {
                new Thread(DoWork_Two).Start();
            }

            #endregion

        }

        private static void DoWork_One()
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} starting...");
            objAuto.WaitOne();
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} completed...");

        }

        private static void DoWork_Two()
        {
            try
            {
                Monitor.Enter(_locker);
                
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} starting...");
                Thread.Sleep(500);
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} completed...");

            }
            finally
            {
                Monitor.Exit(_locker);
            }
        }
    }
}