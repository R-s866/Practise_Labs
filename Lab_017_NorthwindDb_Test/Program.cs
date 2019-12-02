using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Lab_017_NorthwindDb_Test
{
    #region Summary

    /*
     * This was a Lab is to count how many people are within
     * the 'Customers' table using the 'Northwind' database
     * 
     * The challange was to 
     */

    #endregion

    class Program
    {
        public static List<Customer> customers = new List<Customer>();
        static void Main(string[] args)
        {
            var n = new NorthwindDb();
            Console.WriteLine(n.CountNorthwind("London"));
            Console.ReadLine();
        }
        
    }
    public class NorthwindDb
    {
        public int CountNorthwind(string city)
        {
            using (var db = new NorthwindEntities1())
            {
                if (city == null)
                {
                    return db.Customers.Count();
                }
                else
                {
                    int onlyLondon = db.Customers.Where(City => city.Equals("London")).Count();

                    return onlyLondon;
                }
            }
        }
    }
}
