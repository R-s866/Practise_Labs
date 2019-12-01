using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;

namespace Labs_005_CRUD_App_RawSQL
{
	#region Summary

	/*
	 * Using 'Northwind' database
	 * 1.   Returns data from 'Customers' table
	 * 2.   Add a new 'Customer' to 'Customers' table with random Id
	 * 3.   Remove 'Customer' from 'Customers' table at given index
	 * 4.   Update 'Customer' in 'Customers' table at given index
	 */

	#endregion

	class Program
	{
        #region Main

        static List<Customer> customers = new List<Customer>();
		static Customer addedCustomer;

		static void Main(string[] args)
		{
			Console.WriteLine();
			// Connection string for 'Northwind' database
			string connectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Northwind";
			// Sql Connection using the connection string above
			using (var connection = new SqlConnection(connectionString))
			{
				connection.Open();
				
				addedCustomer = AddCustomer(connection);
				
				UpdateCustomer(connection, addedCustomer);

				DeleteCustomer(connection, addedCustomer);

				ListCustomers(connection);
			}
		}

        #endregion

        #region List Customers

        // Reads from 'Northwind' database using SqlConnection param
        static void ListCustomers(SqlConnection sqlConnection)
		{
			// Reads all from 'Customers' Table and add to 'customers' list
			using (var sqlCommand = new SqlCommand("SELECT * FROM CUSTOMERS", sqlConnection))
			{
				SqlDataReader reader = sqlCommand.ExecuteReader();
				while (reader.Read())
				{
					var customer = new Customer()
					{
						CustomerId = reader["CustomerID"].ToString(),
						ContactName = reader["ContactName"].ToString(),
						CompanyName = reader["CompanyName"].ToString(),
						City = reader["City"].ToString(),
						Country = reader["Country"].ToString()
					};
					customers.Add(customer);
				}
			}
			
			// Heading for 'Customers' Sql table logic
			Console.WriteLine($"\n{ "CustomerId",-15} {"ContactName",-30} {"CompanyName",-40}"
				 + $"{"City",-15} {"Country",-15}\n");

			// Loops through 'customers' list and writes : Id , Name , Company , City , Country
			customers.ForEach(c =>
				Console.WriteLine($"{ c.CustomerId, -15} {c.ContactName, -30} {c.CompanyName, -40}"
					+ $"{c.City, -15} {c.Country, -15}")
			);
		}

		#endregion

		#region Add Customer

		static Customer AddCustomer(SqlConnection sqlConnection)
		{
			// Generates a new Id for the new 'Customer'
			string n = Customer.GenerateRandomId(5);
			// Initilizes a new 'Customer' with random Id
			var newCustomer = new Customer()
			{
				CustomerId = n,
				CompanyName = "Sparta",
				ContactName = "james",
				City = "London",
				Country = "uk"
			};

			// Insert sting to Add 'Customer' Instance
			var insertCustomerString = "INSERT INTO CUSTOMERS(CustomerId,ContactName,CompanyName,City,Country)" +
							"VALUES (@CustomerId,@ContactName,@CompanyName,@City,@Country)";

			// Insert logic that uses the insert string above to Add to the 'Customers' table
			using (var sqlCommand2 = new SqlCommand(insertCustomerString, sqlConnection))
			{
				sqlCommand2.Parameters.AddWithValue("@CustomerId", newCustomer.CustomerId);
				sqlCommand2.Parameters.AddWithValue("@ContactName", newCustomer.ContactName);
				sqlCommand2.Parameters.AddWithValue("@CompanyName", newCustomer.CompanyName);
				sqlCommand2.Parameters.AddWithValue("@City", newCustomer.City);
				sqlCommand2.Parameters.AddWithValue("@Country", newCustomer.Country);

				// Return 1 if successful and -1 if failed
				int updated = sqlCommand2.ExecuteNonQuery();
				Console.WriteLine($"{updated} new records added to database");

				// If successfully added return the new instance
				if (updated == 1)
				{
					return newCustomer;
				}
			}

			// If not successful return null
			return null;
		}

		#endregion

		#region Update Customer

		// Updates the 'Customers' table at given index
		static void UpdateCustomer(SqlConnection connection, Customer c)
		{
			// Change in infomation that need to be change
			c.ContactName = "james Deverol";

			// Update string to update 'Customer' at index of 'Customers' table
			var sqlString2 = $"UPDATE Customers SET ContactName='{c.ContactName}'" +
							$"WHERE CustomerId='{c.CustomerId}'";

			// Update logic that uses the update string above, to update 'Customers' table
			using (var sqlCommand2 = new SqlCommand(sqlString2, connection))
			{
				int updated = sqlCommand2.ExecuteNonQuery();
			}
		}

		#endregion

		#region Delete Customer

		// Deletes a 'Customer' from the 'Customers' table
		static void DeleteCustomer(SqlConnection connection, Customer c)
		{
			// Delete string to delete 'Customer' at index from 'Customers' table
			var sqlString2 = $"DELETE FROM Customers WHERE CustomerId ='{c.CustomerId}'";

			// Delete logic that uses the string above, to update 'Customers' table
			using (var sqlCommand2 = new SqlCommand(sqlString2, connection))
			{
				int updated = sqlCommand2.ExecuteNonQuery();
			}
		}

		#endregion

	}

    #region Customer Class

    // Class structure for Customer
    class Customer
	{
		public string CustomerId { get; set; }
		public string ContactName { get; set; }
		public string CompanyName { get; set; }
		public string City { get; set; }
		public string Country { get; set; }

		// Random 'Id' generator
		public static string GenerateRandomId(int lenght)
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

    #endregion

}
