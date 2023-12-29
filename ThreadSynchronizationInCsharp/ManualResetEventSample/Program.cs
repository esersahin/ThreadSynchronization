ManualResetEvent manualResetEvent = new (false);

new Thread(Write).Start();

var i = 0;
while (i < 5)
{
    new Thread(Read).Start();
    i++;
} // end

return;

void Write()
{
    Console.WriteLine("Thread {0} is writing...", Thread.CurrentThread.ManagedThreadId);
    manualResetEvent.Reset();
    Thread.Sleep(5000);
    Console.WriteLine("Thread {0} is writing completed", Thread.CurrentThread.ManagedThreadId);
    manualResetEvent.Set();
}

void Read()
{
    Console.WriteLine("Thread {0} is reading...", Thread.CurrentThread.ManagedThreadId);
    manualResetEvent.WaitOne();
    Thread.Sleep(2000);
    Console.WriteLine("Thread {0} is reading completed", Thread.CurrentThread.ManagedThreadId);
}

