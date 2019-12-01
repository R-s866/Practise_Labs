using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Lab_004_ConnectToRawSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            // @ means take LITTERALLY WHATS in the the following string
            // ie no 'escaping' of characters allowed
            // example @"C:\folder\file" is good
            //          "C:\\folder\\file" escaping backslash

            // Connection string for the 'Northwind' database
            string connectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Northwind";
            // Opens connection using a new instance of SqlConnection
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Reads data from 'Customers' table in 'Northwind' database
                using (var sqlCommand = new SqlCommand("SELECT * FROM CUSTOMERS", connection))
                {
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        // Returns Id and Name from table
                        string customerId = reader["CustomerID"].ToString();
                        string contactName = reader["ContactName"].ToString();

                        // Writes Id and Name to console
                        Console.WriteLine($"{customerId, -15}{contactName}");
                    }
                }
            }
        }
    }
}
