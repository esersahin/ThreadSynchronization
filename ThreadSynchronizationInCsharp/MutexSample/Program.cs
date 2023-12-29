var mutex = new Mutex();

var i = 0;
while(i < 5)
{
    new Thread(Write).Start();
    i++;
} // end

// System.Threading.SynchronizationLockException:
// Object synchronization method was called from an unsynchronized block of code.

//Thread.Sleep(3000);
//mutex.ReleaseMutex();

return;

void Write()
{
    Console.WriteLine("Thread {0} is waiting...", Thread.CurrentThread.ManagedThreadId);
    mutex.WaitOne();
    Console.WriteLine("Thread {0} is writing...", Thread.CurrentThread.ManagedThreadId);
    Thread.Sleep(5000);
    Console.WriteLine("Thread {0} is writing completed", Thread.CurrentThread.ManagedThreadId);
    mutex.ReleaseMutex();
}