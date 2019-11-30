using System;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;

namespace Labs_016_Tasks
{
    class Program
    {
        static Stopwatch s = new Stopwatch();
        static void Main(string[] args)
        {
            s.Start();

            var task01 = Task.Run(() => { 
                Console.WriteLine("Task01 is running");
                Console.WriteLine($"Task01 is completed at time {s.ElapsedMilliseconds}");
            });

            var actionDelegate = new Action(SpecialActionMethod);
            var task02 = new Task(actionDelegate);
            task02.Start();

            Console.WriteLine("\n\n =====================================================\n");

            // array of tasks 
            Task[] taskArray = new Task[]
            {
                new Task(()=> { /* do a job */}),
                new Task(()=> { /* do a job */}),
                new Task(()=> { /* do a job */}),
                new Task(()=> { /* do a job */})
            };
            foreach(var task in taskArray)
            {
                task.Start();
            }

            // named task array
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

            // wait for one or all of the array tasks to complete
            Task.WaitAny(taskArray2);
            Console.WriteLine($"Wating for first array task to complete at {s.ElapsedMilliseconds}");
            Task.WaitAll(taskArray2);
            Console.WriteLine($"Waiting for all array task to complete at {s.ElapsedMilliseconds}");

            Console.WriteLine("\n\n ========================== Parallel Loop ===========================\n");


            // Parallel for loop
            int[] myCollection = new int[] { 10, 20, 30, 40, 50, 60 };
            
            long elapsedAsyncStart = s.ElapsedMilliseconds;
            long e = 0;
            Parallel.ForEach(myCollection, (i) => {
                Thread.Sleep(i * 100);
                Console.WriteLine($"looped completed at {i} {s.ElapsedMilliseconds}");
                if (s.ElapsedMilliseconds < e)
                {
                    e = s.ElapsedMilliseconds;
                }
            });
            Console.WriteLine(e) ;

            Console.WriteLine("\n\n ============================ sync loop =========================\n");
            Console.WriteLine($"looped started at {s.ElapsedMilliseconds}");

            long elapsed = s.ElapsedMilliseconds;
            foreach (int i in myCollection) {
                //Thread.Sleep(i * 100);
                Console.WriteLine($"looped completed at {i} {s.ElapsedMilliseconds}");
            }

            Console.WriteLine($"looped finied at {s.ElapsedMilliseconds}");
            Console.WriteLine($"{s.ElapsedMilliseconds - elapsed}");

            Console.WriteLine("\n\n ========================= Parallen LINQ ============================\n");

            var databaseOutPut =
                (from item in myCollection
                 select item * item)
                 .AsParallel()
                 .ToList();
            // could do this with a real datebase if there was alot of queries to complete

            Console.WriteLine("\n\n =========================  ============================\n");

            var taskWithoutReturnData = new Task(() => { });
            var taskWithReturnData = new Task<int>(() => {
                int total = 0;
                for(int i = 0; i < 100; i++) { total += 1; }
                return total;
            });

            taskWithReturnData.Start();
            Console.WriteLine($"i have counter to 100 using a background task so i dont have to wait" +
                $"to hang the mian thread while i wait, completed at {s.ElapsedMilliseconds}");
            Console.WriteLine($"the awnser is but this hangs the main thread{taskWithReturnData.Result}");

            Console.WriteLine($"Main Method has finished at time {s.ElapsedMilliseconds} in Milliseconds");
            Console.ReadLine();
        }

        static void SpecialActionMethod()
        {
            Console.WriteLine("This Action Method takes no parameters. returns nothing" +
                "perfroms an action, in this case prints out..");
            int total = 0;
            for (int i = 0; i < 1_000_000; i++)
            {
                total += i;
            }
            Thread.Sleep(1000);
            Console.WriteLine($"Special Action Method completed at {s.ElapsedMilliseconds}");
        }
    }
}
