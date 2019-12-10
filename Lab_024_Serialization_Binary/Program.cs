using System;
using Lab_023_Serialization_JSON;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Lab_024_Serialization_Binary
{
    class Program
    {
        static void Main(string[] args)
        {
            var customer = new Customer(1, "jeff", "f121n233ad2snkf");
            var customer2 = new Customer(2, "Setive", "h78yy2hnwjebihsayd");

            List<Customer> customers = new List<Customer>() { customer, customer2 };

            // Formatter : allow us to serialise to Binary
            var formatter = new BinaryFormatter();

            // Stream to File
            using (var stream = new FileStream
                ("data.bin", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(stream, customers);
            }

            // Read Back
            var customersFromBinary = new List<Customer>();
            using (var reader = File.OpenRead("data.bin"))
            {
                customersFromBinary = formatter.Deserialize(reader) as List<Customer>;
            }

            customersFromBinary.ForEach(c => Console.WriteLine($"{c.Name,-10} {c.Age}"));
        }
    }
}
