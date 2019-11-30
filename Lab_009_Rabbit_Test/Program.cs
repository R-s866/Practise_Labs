using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Linq;
using Labs_006_Rabbits_Init_100;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Lab_009_Rabbit_Test
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(RabbitCollection.MultiplyRabbitsAboveAgeThree(4));
            ;
        }
    }

    public class RabbitCollection
    {
        public static List<Rabbit> rabbits;
        // input to years
        // 

        public static (int AgeAll, int rabbitCount) MultiplyRabbits (int totalYears)
        {
            int countId = 0;
            rabbits = new List<Rabbit>();

            Rabbit r = new Rabbit
            {
                RabbitId = countId,
                RabbitName = "rabbit" + countId,
                Age = 0
            };
            countId++;
            rabbits.Add(r);

            for(int i = 0; i < totalYears; i++)
            {
                foreach(Rabbit c in rabbits.ToArray())
                {
                    c.Age++;
                    Rabbit rab = new Rabbit
                    {
                        RabbitId = countId,
                        RabbitName = "rabbit" + countId,
                        Age = 0
                    };
                    countId++;
                    rabbits.Add(rab);
                } 
                
            }

            int count = rabbits.Count();
            int ageTotal = 0;
            rabbits.ForEach(r => ageTotal += r.Age);
            rabbits.ForEach(r => Console.WriteLine(r.Age));
            Console.WriteLine(ageTotal);

            return (ageTotal, count);
        }

        public static (int AgeAll, int rabbitCount) MultiplyRabbitsAboveAgeThree(int totalYears)
        {
            int countId = 0;
            rabbits = new List<Rabbit>();

            Rabbit r = new Rabbit
            {
                RabbitId = countId,
                RabbitName = "rabbit" + countId,
                Age = 0
            };
            countId++;
            rabbits.Add(r);

            for (int i = 0; i < totalYears; i++)
            {
                foreach (Rabbit c in rabbits.ToArray())
                {
                    if (c.Age >= 3)
                    {
                        Rabbit rab = new Rabbit
                        {
                            RabbitId = countId,
                            RabbitName = "rabbit" + countId,
                            Age = 0
                        };
                        countId++;
                        rabbits.Add(rab);
                    }
                    c.Age++;

                }

            }

            int count = rabbits.Count();
            int ageTotal = 0;
            rabbits.ForEach(r => ageTotal += r.Age);

            return (ageTotal, count);
        }
    }

    public class Rabbit
    {
        public int RabbitId { get; set; }
        public string RabbitName { get; set; }
        public int Age { get; set; }
    }
}
