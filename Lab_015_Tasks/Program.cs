using System;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Lab_015_Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize and start stopwatch
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            // This is a task that can take a delegate or we can create an anonyamous method using lambda syntax
            var task01 = new Task(
                // This is an anonymous method with the lambda method
                () => { }
            );
            // This is how to start a task
            task01.Start();

            // Initializes and starts a task with an anonyamous method inside
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

            // Writes the time the App finishes, normally finishes before some of the tasks above
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            Console.ReadLine();
        }
    }
}
