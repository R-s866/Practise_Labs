using System;

namespace Lab_030_Debuggin
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 20; i++)
            {
                var j = $"Your number doubles is {i * 2}";
                Console.WriteLine(j);
            }
#if DEBUG
            Console.WriteLine("this is greyed due to debug");
#endif

            // hacker man is here
        }
    }
}
