using System;
using System.Threading;

namespace ConsoleAppMonitorLock
{
    class FileAccess
    {
        public void WriteData(string str)
        {
            lock (this)
            {
                Monitor.Enter(this);
                Console.WriteLine("Writing " + str + " finished");
                Monitor.Exit(this);
            }
        }
    }
    class Program
    {
            static FileAccess fa = new FileAccess();

            public static void Thread1()
            {
                Console.WriteLine("Thread 1 Writing");
                fa.WriteData("String 1 -- my new data");
            }
            public static void Thread2()
            {
                Console.WriteLine("Thread 2 Writing");
                fa.WriteData("String 2 -- my new data");
            }
            static void Main(string[] args)
            {
                ThreadStart ts1 = new ThreadStart(Thread1);
                ThreadStart ts2 = new ThreadStart(Thread2);

                Thread t1 = new Thread(ts1);
                Thread t2 = new Thread(ts2);

                t1.Start();
                t2.Start();
            }
       
    }
   
}
