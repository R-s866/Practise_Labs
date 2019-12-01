using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Sqlite;
using System.Collections.Generic;
using System.Linq;

using System;

namespace Lab_007_NorthwindSQLite
{
    #region Summary

	/* 
	 * 1. Access data from 'PensDb'
	 * 2. Retrives data from 'Pens' table
	 * 3. Add or Remove a 'Pen' from the 'Pens' table
	 * 
	 */

    #endregion

    class Program
	{
		static List<Pen> pens = new List<Pen>();
		
		static void Main(string[] args)
		{
			// 'PenContext : DbContext', recives data from 'PensDb'
			using (var db = new PensContext())
			{
				pens = GetPens(db);

				AddPen(db);

				RemovePen(db, 3);
			}
		}

		// Adds a new 'Pen' to the 'Pens' table and saves changes
		static void AddPen(PensContext db)
		{
			Pen p = new Pen()
			{
				PenType = "Biro",
				InkColor = "Blue"
			};
			db.Add(p);
			db.SaveChanges();
		}

		// Removes 'Pen' at given int within the pens list and save changes to 'Pens' table
		static void RemovePen(PensContext db, int i)
		{
			if (pens[i] != null)
			{
				db.Remove(pens[i]);
			}
			db.SaveChanges();
		}

		// Returns the values of the 'Pens' Table in 'PensDb'
		static List<Pen> GetPens(PensContext db)
		{
			return db.Pens.ToList();
		}
	}

    #region Database

    /*
	 * Returns data from the 'Pens' table from 'PensDb'
	 * 'Pens' table :
	 * 
	 *		PenId   --   PenType   --   InkColor
	 */

    class PensContext : DbContext
	{
		public DbSet<Pen> Pens { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder builder)
		{
			string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PensDb;
										Integrated Security=True;Connect Timeout=30;Encrypt=False;
										TrustServerCertificate=False;ApplicationIntent=ReadWrite;
										MultiSubnetFailover=False";
			builder.UseSqlite(connectionString);
		}
	}

	class Pen
	{
		public int PenId { get; set; }
		public string PenType { get; set; }
		public string InkColor { get; set; }
	}

    #endregion
}
