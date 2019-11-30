using System;

namespace Labs_010_Events
{
    class Program
    {
        // creating delegate type
        delegate void MyDelegate();
        delegate int MyDelegate2(int i);
        // create event (init to emty event)
        static event MyDelegate MyEvent;
        static event MyDelegate2 MyEvent2;

        static void Main(string[] args)
        {
            // add methods to event
            MyEvent += Method01;
            MyEvent += Method02;
            // fire event
            MyEvent();

            MyEvent2 += Method03;
            MyEvent2 += Method03;
            MyEvent2 += Method03;
            MyEvent2 += Method03;

            Console.WriteLine(MyEvent2(10)); // why can you use the return types of the method
        }

        static void Method01()
        {
            Console.WriteLine("method1");
        }

        static void Method02()
        {
            Console.WriteLine("method2");
        }

        static int Method03(int e)
        {
            return e * e;
        }
    }
}
