using System;
using System.Collections.Concurrent;

namespace Lab_011_Delegates
{
    class Program
    {
        // Matching Delegate
        public delegate void Delegate01();

        // Non trival Delegates
        public delegate int Delegate02(int x);

        static void Main(string[] args)
        {
            // delegates can be referenced as a lass
            // using the new keyword

            var delegateInstance = new Delegate01(MyMethod01);
            // call this
            delegateInstance();// call the method

            // trivial cases can simplfiy (same result)
            // 1. omit 'new'
            Delegate01 delegateInstance2 = MyMethod01;
            delegateInstance2(); // call

            // action delegate is an 
            Action delegateInstance03 = MyMethod01;
            delegateInstance03();

            Delegate02 delegateInstance4 = (x) => { return x * x * x; };


            Delegate02 delegateInstance5 = x => x * x *x;

            checked
            {
                int i = MyMethod02(delegateInstance5(delegateInstance5(10)));
                Console.WriteLine(i);
            }


        }

        static void MyMethod01()
        {
        }
        static int MyMethod02(int i)
        {
            return i * i;
        }
    }
}
