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

            string connectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Northwind";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var sqlCommand = new SqlCommand("SELECT * FROM CUSTOMERS", connection))
                {
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        string customerId = reader["CustomerID"].ToString();
                        string contactName = reader["ContactName"].ToString();

                        Console.WriteLine($"{customerId, -15}{contactName}");
                    }
                }
            }
        }
    }
}
