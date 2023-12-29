// https://www.youtube.com/watch?v=5Zv8fF-KPrE&list=PLGwE-blTx6XdwNTYE0KaSkoDITcAcwUCo

Semaphore semaphore = new (1, 1);

var i = 0;

while(i < 5)
{
    new Thread(Write).Start();
    i++;
} // end

return;

void Write()
{
    Console.WriteLine("Thread {0} is waiting...", Thread.CurrentThread.ManagedThreadId);
    
    try
    {
        semaphore.WaitOne();
        Console.WriteLine("Thread {0} is writing...", Thread.CurrentThread.ManagedThreadId);
        Thread.Sleep(5000);
        Console.WriteLine("Thread {0} is writing completed", Thread.CurrentThread.ManagedThreadId);
    }
    finally
    {
        semaphore.Release();    
    }
    
}