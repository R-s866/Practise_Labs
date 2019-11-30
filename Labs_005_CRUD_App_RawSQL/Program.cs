using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;

namespace Labs_005_CRUD_App_RawSQL
{
    class Program
    {
        static List<Customer> customers = new List<Customer>();
        static Customer addedCustomer;

        static void Main(string[] args)
        {
            Console.WriteLine();
            // connection string
            string connectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Northwind";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                
                addedCustomer = AddCustomer(connection);
                
                UpdateCustomer(connection, addedCustomer);

                DeleteCustomer(connection, addedCustomer);

                ListCustomers(connection);
            }
        }

        #region List Customers

        static void ListCustomers(SqlConnection sqlConnection)
        {
            using (var sqlCommand = new SqlCommand("SELECT * FROM CUSTOMERS", sqlConnection))
            {
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var customer = new Customer()
                    {
                        CustomerId = "ROSS1",
                        CompanyName = "Sparta",
                        ContactName = "Ross",
                        City = "London",
                        Country = "uk"
                    };
                    customers.Add(customer);
                }
            }

            /*foreach (var c in customers)
            {
                Console.WriteLine($"{ c.CustomerId}{c.ContactName}{c.CompanyName}" 
                    + $"{c.City}{c.Country}");
            }*/
            
            Console.WriteLine("");
            Console.WriteLine($"{ "CustomerId",-15} {"ContactName",-30} {"CompanyName",-40}"
                 + $"{"City",-15} {"Country",-15}");
            Console.WriteLine("");
            customers.ForEach(c =>
                Console.WriteLine($"{ c.CustomerId, -15} {c.ContactName, -30} {c.CompanyName, -40}"
                    + $"{c.City, -15} {c.Country, -15}"));
        }

        #endregion

        #region Add Customer

        static Customer AddCustomer(SqlConnection sqlConnection)
        {
            string n = GenerateRandomId(5);
            var newCustomer = new Customer()
            {
                CustomerId = n,
                CompanyName = "Sparta",
                ContactName = "james",
                City = "London",
                Country = "uk"
            };
            /*var sqlString = "INSERT INTO CUSTOMERS(CustomerId,ContactName,CompanyName,City,Country)" +
                            "VALUES ('ROSS1','Sparta','Ross','London','UK')";
            using (var sqlCommand = new SqlCommand(sqlString, sqlConnection))
            {
                int updated = sqlCommand.ExecuteNonQuery();
                Console.WriteLine($"{updated} new records added to database");
            }*/

            var sqlString2 = "INSERT INTO CUSTOMERS(CustomerId,ContactName,CompanyName,City,Country)" +
                            "VALUES (@CustomerId,@ContactName,@CompanyName,@City,@Country)";

            using (var sqlCommand2 = new SqlCommand(sqlString2, sqlConnection))
            {
                sqlCommand2.Parameters.AddWithValue("@CustomerId", newCustomer.CustomerId);
                sqlCommand2.Parameters.AddWithValue("@ContactName", newCustomer.ContactName);
                sqlCommand2.Parameters.AddWithValue("@CompanyName", newCustomer.CompanyName);
                sqlCommand2.Parameters.AddWithValue("@City", newCustomer.City);
                sqlCommand2.Parameters.AddWithValue("@Country", newCustomer.Country);


                int updated = sqlCommand2.ExecuteNonQuery();
                //Console.WriteLine($"{updated} new records added to database");
                if (updated == 1)
                {
                    return newCustomer;
                }
            }

            return null;
        }

        #endregion

        #region Update Customer

        static void UpdateCustomer(SqlConnection connection, Customer c)
        {
            c.ContactName = "james Deverol";

            var sqlString2 = $"UPDATE Customers SET ContactName='{c.ContactName}'" +
                            $"WHERE CustomerId='{c.CustomerId}'";

            using (var sqlCommand2 = new SqlCommand(sqlString2, connection))
            {
                int updated = sqlCommand2.ExecuteNonQuery();
            }
        }

        #endregion

        #region Delete Customer

        static void DeleteCustomer(SqlConnection connection, Customer c)
        {
            var sqlString2 = $"DELETE FROM Customers WHERE CustomerId ='{c.CustomerId}'";

            using (var sqlCommand2 = new SqlCommand(sqlString2, connection))
            {
                int updated = sqlCommand2.ExecuteNonQuery();
            }
        }

        #endregion

        static string GenerateRandomId(int lenght)
        {
            Random random = new Random();
            StringBuilder o = new StringBuilder();

            for (int i = 0; i < lenght; i++)
            {
                char c = Convert.ToChar(random.Next(65, 90));
                o.Append(c);
            }
            return o.ToString();
        }
    }

    class Customer
    {
        public string CustomerId { get; set; }
        public string ContactName { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
