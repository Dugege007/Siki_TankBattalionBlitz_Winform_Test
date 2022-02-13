using System;
using System.Collections.Generic;

namespace _01_基础知识_类型换换
{
    class Program
    {
        static void Main(string[] args)
        {
            //int a = 10;
            //double b = a;//10->10.0

            //double c = 34.23;
            //a = (int)c;

            //Console.WriteLine(a);
            //溢出

            //Father f = new Son();

            //Son s = f as Son;// null
            //s.SonMethod();

            Father f = new Father();

            //Son s = f as Son;
            //Console.WriteLine(s==null);

            Son s = (Son)f;

            List<int> l;
            //Alt + Enter
        }


    }

    class Father
    {

    }

    class Son:Father
    {
        public void SonMethod()
        {

        }
    }
    
}
