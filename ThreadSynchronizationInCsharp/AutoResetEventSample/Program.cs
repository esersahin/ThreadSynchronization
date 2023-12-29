AutoResetEvent autoResetEvent = new(true);

var i = 0;

while(i < 5)
{
    new Thread(Write).Start();
    i++;
} // end

Thread.Sleep(3000);
autoResetEvent.Set();

return;

void Write()
{
    Console.WriteLine("Thread {0} is waiting...", Environment.CurrentManagedThreadId);
    autoResetEvent.WaitOne();
    Console.WriteLine("Thread {0} is writing...", Environment.CurrentManagedThreadId);
    Thread.Sleep(5000);
    Console.WriteLine("Thread {0} is writing completed", Environment.CurrentManagedThreadId);
    autoResetEvent.Set();
}

// void Read()
// {
//     Console.WriteLine("Thread {0} is reading...", Thread.CurrentThread.ManagedThreadId);
//     Thread.Sleep(2000);
//     Console.WriteLine("Thread {0} is reading completed", Thread.CurrentThread.ManagedThreadId);
// }