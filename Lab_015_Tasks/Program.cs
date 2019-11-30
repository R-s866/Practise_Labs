using System;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Lab_015_Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            // inside here can go a delegate or we can create and anonyamous 
            //  method using lambda syntax
            var task01 = new Task(
                () => { }       // this is an anonymous method
            );
            task01.Start();

            var task02 = Task.Run(
                () => { Console.WriteLine("in task 2"); }
            );

            var task03 = Task.Run(
                () => { Console.WriteLine("in task 3"); }
            );

            var task04 = Task.Run(
                () => { Console.WriteLine("in task 4"); }
            );

            var task05 = Task.Run(
                () => { Console.WriteLine("in task 5"); }
            );

            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            Console.ReadLine();
        }
    }
}
