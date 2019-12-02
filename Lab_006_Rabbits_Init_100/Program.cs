using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RandomNameGeneratorLibrary;

namespace Labs_006_Rabbits_Init_100
{
	#region Summary

	/*
	 * Read 'RabbitDb' using EntityFrameworkCore
	 * 1.	Loop through list adds a new rabbit each pass,
	 *		where the rabbit is 3 or over.
	 * 2.	Loops through list and increments age by 1, updates db.
	 * 3.	Loops through list and remove 1 in 3 rabbits, updates db.
	 */

	#endregion

	class Program
	{
		public static List<Rabbit> rabbits = new List<Rabbit>();
		
		static void Main(string[] args)
		{
			// 'RabbitContext : DbContext' Uses the 'RabbitDb' database
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

		// Returns list of 'rabbits' from 'Rabbits' table in 'RabbitDb'
		public static List<Rabbit> ListRabbits(RabbitContext db)
		{
			return db.Rabbits.ToList();
		}

		// Loops through 'rabbits' list and Increments age by 1, updates database
		public static void UpdateRabbits(RabbitContext db)
		{
			foreach (Rabbit i in rabbits)
			{
				i.RabbitAge++;
			}
			db.SaveChanges();
		}

		// Loops through 'rabbits' list and randomly removes 1 at a ratio of 33.333%, updates database
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
			db.SaveChanges();
		}

		// Adds a new 'Rabbit' to 'Rabbits' table in 'RabbitDb', updates database
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

		// Loops through 'rabbits' list a writes their : Id , Name , Age
		public static void PrintRabbits(List<Rabbit> rabbits)
		{
			rabbits.ForEach (r => 
				Console.WriteLine($"{r.RabbitId, -10}{r.RabbitName, -30}{r.RabbitAge}")) ;
		}

		#region New Rabbit

		// Initilizes and returns a new 'Rabbit' with a random name 
		// using RandomNameGeneratorLibrary, and with the age of 0
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

	#region Database

	/*
	 * 'Rabbit' Class take : 
	 *		Id , Name , Age
	 * 
	 * 'Rabbits' table stucture : 
	 *		RabbitId  --  RabbitName  --  RabbitAge
	 *		
	 *	'RabbitDb' contains : 
	 *		Rabbits
	 */

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
			string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RabbitsDB;
										Integrated Security=True;Connect Timeout=30;Encrypt=False;
										TrustServerCertificate=False;ApplicationIntent=ReadWrite;
										MultiSubnetFailover=False";
			builder.UseSqlServer(connectionString);
		}
	}

	#endregion
}
