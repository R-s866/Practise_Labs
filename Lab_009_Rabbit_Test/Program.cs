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
        }
    }

    public class RabbitCollection
    {
        // Container for rabbits
        public static List<Rabbit> rabbits;
       
        public static (int AgeAll, int rabbitCount) MultiplyRabbits (int totalYears)
        {
            // Int that increments when a rabbit is added to use as the rabbit id
            int countId = 0;
            
            // Initialize the list of rabbit
            rabbits = new List<Rabbit>();

            // Initialize the first rabbit as loop relys on having something in it
            Rabbit r = new Rabbit
            {
                RabbitId = countId,
                RabbitName = "rabbit" + countId,
                Age = 0
            };
            countId++;
            rabbits.Add(r);

            // For every int param years loop
            for(int i = 0; i < totalYears; i++)
            {
                // For every rabbit in the array 
                foreach(Rabbit c in rabbits.ToArray())
                {
                    // Increment the current rabbits age
                    c.Age++;
                    // Create a new rabbit with given agruments
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

            // Gets the total amount of in the array
            int count = rabbits.Count();
            int ageTotal = 0;
            // Loops through array and adds age to total to get sum of rabbits age
            // Writes the age of each rabbit in the array
            rabbits.ForEach(r => {
                ageTotal += r.Age;
                Console.WriteLine(r.Age);
            });
            // Writes the total sum age off all rabbits
            Console.WriteLine(ageTotal);

            // returns total age and count for tests
            return (ageTotal, count);
        }

        public static (int AgeAll, int rabbitCount) MultiplyRabbitsAboveAgeThree(int totalYears)
        {
            // Int that increments when a rabbit is added to use as the rabbit id
            int countId = 0;

            // Initialize the list of rabbit
            rabbits = new List<Rabbit>();

            // Initialize the first rabbit as loop relys on having something in it
            Rabbit r = new Rabbit
            {
                RabbitId = countId,
                RabbitName = "rabbit" + countId,
                Age = 0
            };
            countId++;
            rabbits.Add(r);

            // For every int param years loop
            for (int i = 0; i < totalYears; i++)
            {
                // For every rabbit in the array 
                foreach (Rabbit c in rabbits.ToArray())
                {
                    // Increment the current rabbits age
                    c.Age++;
                    // If rabbits age is 3 or above make a new rabbit
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
                }

            }

            int count = rabbits.Count();
            int ageTotal = 0;
            rabbits.ForEach(r => ageTotal += r.Age);

            // Returns sum of all rabbits age and count of rabbit array
            return (ageTotal, count);
        }
    }

    // Rabbit Class that take an : Id, Name, Age
    public class Rabbit
    {
        public int RabbitId { get; set; }
        public string RabbitName { get; set; }
        public int Age { get; set; }
    }
}
