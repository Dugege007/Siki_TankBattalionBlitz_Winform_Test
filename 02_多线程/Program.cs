using System;
using System.Threading;

namespace _02_多线程
{
    class Program
    {
        static void Main(string[] args)
        {
            //线程
            //Thread t = Thread.CurrentThread;
            //t.Name = "MainThread";
            //Console.WriteLine(t.Name);

            //ThreadStart start = new ThreadStart(ChildThreadMethod);

            //Thread childThread = new Thread(start);

            Thread childThread1 = new Thread(new ThreadStart(ChildThreadMethod));

            childThread1.Start();

            Thread childThread2 = new Thread(new ThreadStart(ChildThreadMethod));

            childThread2.Start();

            //Console.WriteLine("Main Method");

            Thread.Sleep(2000);

            //childThread1.Abort();
            //childThread2.Abort();
            isRun = false;
        }

        private static bool isRun = true;

        private static void ChildThreadMethod()
        {
            while (isRun)
            {
                Console.WriteLine("ChildThread - 听歌中....");
                Thread.Sleep(500);
            }
        }
    }
}
