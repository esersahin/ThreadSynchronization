namespace LockSample;

static class Program
{
    private static readonly object Locker = new ();

    private static void Main(string[] args)
    {
        var i = 0;

        while (i < 5)
        {
            new Thread(DoWork).Start();
            i++;
        } // end
    } // end Main

    static void DoWork()
    {
        try
        {
            lock (Locker)
            {
                Console.WriteLine("Thread {0} is starting", Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(1000);
                throw new Exception("Exception in thread");
                Console.WriteLine("Thread {0} is completed", Thread.CurrentThread.ManagedThreadId);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            //throw;
        }
    } // end DoWork
} // end class Program