using System;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;

namespace Lab_016_Tasks
{
    class Program
    {
        // Stopwatch can give the time in milliseconds since the stopwatch was started
        static Stopwatch s = new Stopwatch();
        static void Main(string[] args)
        {
            #region Basics Of Task

            // Start the stop watch when the app starts
            s.Start();

            Console.WriteLine("\n\n ============================ Basics Of Tasks =========================\n");

            // Intro to tasks and how to run a task
            var task01 = Task.Run(() => { 
                // Outputs data about task completion
                Console.WriteLine("Task01 is running");
                // Outputs time the task finished
                Console.WriteLine($"Task01 is completed at time {s.ElapsedMilliseconds}");
            });

            // Adding a Method to an action delegate
            var actionDelegate = new Action(SpecialActionMethod);
            // Using that action delegate as a task
            var task02 = new Task(actionDelegate);
            task02.Start();

            // Initialize array of anonymous tasks 
            Task[] taskArray = new Task[]
            {
                new Task(()=> { /* do a job */}),
                new Task(()=> { /* do a job */}),
                new Task(()=> { /* do a job */}),
                new Task(()=> { /* do a job */})
            };
            // Start array of anonymous tasks
            foreach(var task in taskArray)
            {
                task.Start();
            }

            // Initialize and starting array of anonymous tasks
            var taskArray2 = new Task[3];
            taskArray2[0] = Task.Run(() => {
                Console.WriteLine($"Array Task 0 completed at {s.ElapsedMilliseconds}");
            });
            taskArray2[1] = Task.Run(() => {
                Console.WriteLine($"Array Task 1 completed at {s.ElapsedMilliseconds}");
            });
            taskArray2[2] = Task.Run(() => {
                Console.WriteLine($"Array Task 2 completed at {s.ElapsedMilliseconds}");
            });

            // Waits for first task to finish before executing
            Task.WaitAny(taskArray2);
            Console.WriteLine($"Wating for first array task to complete at {s.ElapsedMilliseconds}");
             // Waits for all tasks to be finished before executing
            Task.WaitAll(taskArray2);
            Console.WriteLine($"Waiting for all array task to complete at {s.ElapsedMilliseconds}");

            #endregion

            // Array for testing 
            int[] myCollection = new int[] { 10, 20, 30, 40, 50, 60 };

            Console.WriteLine("\n\n ============================ Parallel loop =========================\n");
            
            // Record time to compare against when each task finishes
            long paraLoopStartTime = s.ElapsedMilliseconds;
            long e = 0;

            // Using a Parallel loop, each pass of the loop is a task and run on different threads
            Parallel.ForEach(myCollection, (i) => {
                Thread.Sleep(i * 100);
                Console.WriteLine($"A pass of loop completed at {i} {s.ElapsedMilliseconds}");
                // If a Pass of the loop is quicker that the last. value is stored in 'e'
                if (s.ElapsedMilliseconds > e)
                {
                    e = s.ElapsedMilliseconds;
                }
            });

            // Subtract the parallel loop start time with 'e' to get the longest time a pass took to complete
            Console.WriteLine($"The longest pass of the loop took {e - paraLoopStartTime}");

            Console.WriteLine("\n\n ============================ sync loop =========================\n");

            Console.WriteLine($"Sync loop started at {s.ElapsedMilliseconds}");
            // Record time to compare against when the loop finishes
            long syncLoopStartTime = s.ElapsedMilliseconds;
            // synchronously loop through array and writeline when each pass finishes
            foreach (int i in myCollection) {
                Thread.Sleep(i * 100);
                Console.WriteLine($"A pass of the loop completed at {i} {s.ElapsedMilliseconds}");
            }

            // Write the loop finish time and the time taken to finish
            Console.WriteLine($"The loop finished at {s.ElapsedMilliseconds}");
            Console.WriteLine($"The sync loop took {s.ElapsedMilliseconds - syncLoopStartTime} seconds to complete");

            Console.WriteLine("\n\n ========================= Parallel LINQ ============================\n");

            // Generating a list from a database using LINQ
            var databaseOutPut =
                (from item in myCollection
                 select item * item)
                 .AsParallel()
                 .ToList();
            // .AsParallel() is useful when working with a big datebase, if there was alot of queries to complete
            // it will split the loop onto seperate thread

            Console.WriteLine("\n\n ========================= Tasks with Return ============================\n");

            // Task that returns a int 
            var taskWithReturnData = new Task<int>(() => {
                int total = 0;
                // Runs throught the loop and increaments total by 1
                for(int i = 0; i < 100; i++) { total++; }
                return total;
            });
            taskWithReturnData.Start();

            // Writes the time to complete a 100 pass loop
            Console.WriteLine($"Looped through Array and incremented total by 1, completed at {s.ElapsedMilliseconds}");
            // Writes the return value of the task
            Console.WriteLine($"the awnser is but this hangs the main thread{taskWithReturnData.Result}");

            // Writes when the main method on the main thread has finished
            Console.WriteLine($"Main Method has finished at time {s.ElapsedMilliseconds} in Milliseconds");
            Console.ReadLine();
        }

        static void SpecialActionMethod()
        {
            // This method is used as an action delegate which is inturn used in a task
            Console.WriteLine("This Action Method takes no parameters. returns nothing" +
                "perfroms an action, in this case prints out..");
            int total = 0;
            // Runs through loop incrementing total by 1, loops 1,000,000 times
            for (int i = 0; i < 1_000_000; i++)
            {
                total += i;
            }
            // Writes when the method has completed the loop
            Console.WriteLine($"Special Action Method completed at {s.ElapsedMilliseconds}");
        }
    }
}
