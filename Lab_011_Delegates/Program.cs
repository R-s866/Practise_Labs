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
            // Delegates can be referenced as a class using the new keyword
            var delegateInstance = new Delegate01(MyMethod01);
            // Calls the method inside the delegate
            delegateInstance();

            // trivial cases can simplfiy (same result)
            // 1. omit 'new'
            Delegate01 delegateInstance2 = MyMethod01;
            delegateInstance2();

            // action delegate is void and takes no params
            Action delegateInstance03 = MyMethod01;
            delegateInstance03();

            // This will not work as it returns a type
            // Action delegateInstance04 = MyMethod02;

            // Delegate Instace that returns x param cubed : uses the Lambda impression
            Delegate02 delegateInstance05 = (x) => { return x * x * x; };
            Console.WriteLine($"When i pass 10 into delegateInstance05 it returns {delegateInstance05(10)}");

            // Delegate Instace that returns x param cubed : uses the Lambda impression shorter version
            Delegate02 delegateInstance06 = x => x * x *x;
            Console.WriteLine($"When i pass 10 into delegateInstance06 it returns {delegateInstance05(10)}");

            checked
            {
                // Call delegate instance 05 and 06, to cube 10, then the return value, 
                // Then MyMethod01 squares that return value. Writes result
                int i = MyMethod02(delegateInstance05(delegateInstance06(10)));
                Console.WriteLine(i);
            }
        }

        static void MyMethod01()
        {
            Console.WriteLine("Method01 has been called");
        }

        static int MyMethod02(int i)
        {
            return i * i;
        }
    }
}
