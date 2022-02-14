using System;

namespace _01_基础知识_类型转换
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 10;
            double b = a;

            double c = 10.0;
            a = (int)c;//整型超过11位会溢出


            Father f = new Son();
            //Son s = (Son)f;
            Son s = f as Son;
            //as强转时，即使无法转换也不会报错
            s.SonMethod();

            //Father f = new Father();
            //Son s = (Son)f;
            //无法转换，f本质需是Son，才可以转换
            //按Alt+Enter可以展开报错提示
        }
    }

    class Father
    {

    }

    class Son : Father
    {
        public void SonMethod()
        {

        }
    }
}
