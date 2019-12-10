using System;

namespace Lab_026_Fibibacci
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public static class Fibobacci
    {
        public static int ReturnFibonacciNthItemInSequenece(int n)
        {
            return n + (n--);
        }
    }

}
