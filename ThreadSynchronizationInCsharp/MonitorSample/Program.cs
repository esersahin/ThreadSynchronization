namespace MonitorSample;

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
        
        // System.Threading.SynchronizationLockException:
        // Object synchronization method was called from an unsynchronized block of code.
        // Thread.Sleep(3000);
        // Monitor.Exit(Locker);

    }     // end Main

    static void DoWork()
    {
        Monitor.Enter(Locker);

        try
        {
            Console.WriteLine("Thread {0} is starting", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(5000);
            throw new Exception("Exception in thread");
            Console.WriteLine("Thread {0} is completed", Thread.CurrentThread.ManagedThreadId);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            Monitor.Exit(Locker);
        }
    } // end DoWork
}
// end class Program