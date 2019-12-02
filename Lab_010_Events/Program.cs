using System;

namespace Labs_010_Events
{
    class Program
    {
        // Create trival delegate type 
        delegate void MyDelegate();
        // Create non trival delegate type
        delegate int MyDelegate2(int i);
        // Create events that match delegate (initilized to empty event)
        static event MyDelegate MyEvent;
        static event MyDelegate2 MyEvent2;

        static void Main(string[] args)
        {
            // Add methods to event
            MyEvent += Method01;
            MyEvent += Method02;
            // Run Event that runs both methods in the delegate
            MyEvent();

            // Add methods to event, methods that take an int param and return the squared value
            MyEvent2 += Method03;
            MyEvent2 += Method03;
            MyEvent2 += Method03;
            MyEvent2 += Method03;
            // Write the return values
            Console.WriteLine(MyEvent2(10));
        }

        static void Method01()
        {
            Console.WriteLine("Method01 has been called");
        }

        static void Method02()
        {
            Console.WriteLine("Method02 has been called");
        }

        static int Method03(int e)
        {
            // Return the squared value of the int param 
            return e * e;
        }
    }
}
