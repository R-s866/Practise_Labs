using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RandomNameGeneratorLibrary;

namespace Labs_006_Rabbits_Init_100
{
    class Program
    {
        public static List<Rabbit> rabbits = new List<Rabbit>();
        
        static void Main(string[] args)
        {
            using (var db = new RabbitContext())
            {
                while (true)
                {
                    rabbits = ListRabbits(db);

                    UpdateRabbits(db);
                
                    AddRabbit(db);
                
                    rabbits = ListRabbits(db);

                    db.SaveChanges();
            
                    PrintRabbits(rabbits);
                }
            }
        }

        public static List<Rabbit> ListRabbits(RabbitContext db)
        {
            return db.Rabbits.ToList();
        }

        public static void UpdateRabbits(RabbitContext db)
        {
            foreach (Rabbit i in rabbits)
            {
                i.RabbitAge++;
            }
            db.SaveChanges();
        }

        public static void HolyHandGrenadeOfAntioch(RabbitContext db)
        {
            Random random = new Random();

            foreach (Rabbit i in rabbits)
            {
                int o = random.Next(1, 3);

                if (o == 1)
                {
                    db.Remove(i);
                }
            }
        }

        public static void AddRabbit(RabbitContext db)
        {
            foreach (Rabbit i in rabbits)
            {
                if (i.RabbitAge > 2)
                {
                    Rabbit r = NewRabbit();
                    db.Add(r);

                }
            }
            db.SaveChanges();
        }

        public static void PrintRabbits(List<Rabbit> rabbits)
        {
            rabbits.ForEach (r => 
                Console.WriteLine($"{r.RabbitId, -10}{r.RabbitName, -30}{r.RabbitAge}")) ;
        }

        #region New Rabbit

        public static Rabbit NewRabbit()
        {
            var na = new PersonNameGenerator();
            Rabbit r = new Rabbit()
            {
                RabbitName = na.GenerateRandomFirstName(),
                RabbitAge = 0
            };

            return r;
        }

        #endregion

    }

    #region Rabbit Calss

    class Rabbit
    {
        public int RabbitId { get; set; }
        public string RabbitName { get; set; }
        public int RabbitAge { get; set; }
    }

    class RabbitContext : DbContext
    {
        public DbSet<Rabbit> Rabbits { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RabbitsDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            builder.UseSqlServer(connectionString);
        }
    }

    #endregion
}
