using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Design;
using System.Threading.Tasks.Dataflow;
using System.Runtime.InteropServices.ComTypes;

namespace Lab_014_LINQ
{
    #region Summary

    /*
     * 1. Read Northwind using Entity core 2.1.1
     * 2. Basic LINQ
     * 3. More advanced LINQ
     * 
     */

    #endregion

    class Program
    {
        static List<Customer> customersList ;
        static List<Customer> customers;
        static List<Product> products;
        static List<Category> categories;

        static void Main(string[] args)
        {
            // 'Northwind : Dbcontext' uses the 'Northwind' database 
            using (var db = new Northwind())
            {
                // Returns customers from 'Northwind' database, customers from cities : london, berlin : only
                customersList = (from customer in db.Customers
                     where customer.City == "London" || customer.City == "Berlin"
                     orderby customer.ContactName
                     select customer).ToList();

                // Print list of customers
                PrintCustomers(customersList);

                // Returns customers from 'Northwind' database and shows selected infomation, ie. name + location
                var selected3 =
                    (from customer in db.Customers
                     select new
                     {
                         // Returns Contact name as Name and Customer city + Country as Location
                         Name = customer.ContactName,
                         Location = customer.City + "" + customer.Country
                     }).ToList();

                // Writes Location and Name
                selected3.ForEach(c => Console.WriteLine($"{c.Location}{c.Name}"));


                var selected4 = (from customer in db.Customers
                                 select new ModifiedCustomer(customer.ContactName, customer.City)).ToList();

                selected4.ForEach(c => Console.WriteLine($"{c.Location}{c.Name}"));

                //grouping
                Console.WriteLine("\n\nlist of products\n" +
                                "==================================\n");
                var select5 = from customer in db.Customers
                              group customer by customer.City into Cities
                              orderby Cities.Key
                              select new
                              {
                                  Cities.Key,
                                  count = Cities.Count()
                              };

                //select5.ForEachAsync(c => Console.WriteLine($"{c.Key.}{c.Count}"));

                //products =
                //    from p in db.Products
                //    join c in db.Categories
                //    on p.CategoryID equals c.CategoryID
                //    select new
                //    {
                //        id = p.ProductID,
                //        c.CategoryID
                //    }

                Console.WriteLine("\n\nNow Print the same list but using much smarter 'dot'\n notation to join tables\n" +
                    "=====================================\n");
                products = db.Products.ToList();
                categories = db.Categories.ToList();
                products.ForEach(p => Console.WriteLine($"{p.ProductID,-15}{p.ProductName,-30}{p.Category.CategoryName}"));

                Console.WriteLine("\nList Catergories With Count of Products\n" +
                    "And Sub-List of Product Names\n" +
                    "==============================================");

                categories.ForEach(l =>
                    {
                        Console.WriteLine($"{l.CategoryID,-5}{l.CategoryName} has {l.Products.Count} products");
                       // l.Products.ForEach(args => );
                    }
                );

                Console.WriteLine($"\n\nLINQ Lambda Notation \n");
                customers = db.Customers.ToList();
                Console.WriteLine($"Count is {customers.Count}");

                Console.WriteLine("\n\nList of Cities Distinct\n");

                var cityList = db.Customers.Select(c => c.City).Distinct().OrderBy(c=>c).ToList();
                cityList.ForEach(c => Console.WriteLine(c));

                var cityListFiltered = db.Customers
                                        .Select(c => c.City)
                                        .Where(city => city.Contains("o"))
                                        .Distinct()
                                        .OrderBy(c => c)
                                        .ToList();
                cityListFiltered.ForEach(city => Console.WriteLine(city));
            }

            static void PrintCustomers(List<Customer> customers)
            {
                customers.ForEach(c => Console.WriteLine($"{c.CustomerID}{c.ContactName}{c.Country}"));
                
            }
        }
    }

    #region DatabaseContextAndClasses

    /* 
     * 
     * 1. ModifiedCustomer: 
     *      Class template for updating an current entry in the database.
     * 2. Customer, Category, Product: 
     *      Classes template that mimic the table columns in the database.
     * 3. Northwind : DBContext
     * 
     */

    class ModifiedCustomer
    {
        public string Name { get; set; }
        public string Location { get; set; }

        public ModifiedCustomer(string Name, string Location)
        {
            this.Name = Name;
            this.Location = Location;
        }
    }

    public partial class Customer
    {
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
    }
    
    public partial class Category
    {
        public Category()
        {
            this.Products = new List<Product>();
        }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Product> Products { get; set; }

    }

    public partial class Product
    {
        public virtual Category Category { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int? CategoryID { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; } = 0;
        public short? UnitsInStock { get; set; } = 0;
        public short? UnitsOnOrder { get; set; } = 0;
        public short? ReorderLevel { get; set; } = 0;
        public bool Discontinued { get; set; } = false;
    }


    public class Northwind : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;" + "Initial Catalog=Northwind;" + "Integrated Security = true;" + "MultipleActiveResultSets=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .Property(c => c.CategoryName)
                .IsRequired()
                .HasMaxLength(15);

            // define a one-to-many relationship
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category);

            modelBuilder.Entity<Product>()
                .Property(c => c.ProductName)
                .IsRequired()
                .HasMaxLength(40);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products);
        }
    }
    #endregion
}
