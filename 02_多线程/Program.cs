using System;
using System.Threading;

namespace _02_多线程
{
    class Program
    {
        static void Main(string[] args)
        {
            //线程
            Thread t = Thread.CurrentThread;
            t.Name = "MainThread";
            Console.WriteLine(t.Name);

            //ThreadStart start = new ThreadStart(ChildThreadMethod);//委托
            //Thread childThread = new Thread(start);

            Thread childThread1 = new Thread(new ThreadStart(ChildThreadMethod1));
            childThread1.Start();

            Thread childThread2 = new Thread(new ThreadStart(ChildThreadMethod2));
            childThread2.Start();

            //Console.WriteLine("MainMethod");

            //while (isRun)
            //{
            //    Console.WriteLine("MainMethod: Coding...");
            //    Thread.Sleep(500);//休息500毫秒
            //}

            Thread.Sleep(3000);//休息3000毫秒

            //终止线程
            //childThread1.Abort();
            //childThread2.Abort();

            isRun = false;
        }

        private static bool isRun = true;

        private static void ChildThreadMethod1()
        {
            Console.WriteLine("ChildThread1 is Running");
            while (isRun)
            {
                Console.WriteLine("ChildThread1: Singing...");
                Thread.Sleep(500);//休息500毫秒
            }
        }

        private static void ChildThreadMethod2()
        {
            Console.WriteLine("ChildThread2 is Running");
            while (isRun)
            {
                Console.WriteLine("ChildThread2: Playing...");
                Thread.Sleep(500);//休息500毫秒
            }
        }
    }
}
