using System;
using System.Runtime.Serialization.Formatters.Soap;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Lab_022_Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            var customer = new Customer(1, "jeff", "f121n233ad2snkf");
            var customer2 = new Customer(2, "Setive", "h78yy2hnwjebihsayd");

            List<Customer> customers = new List<Customer>() { customer, customer2 };

            // We are going to seialise customer to XML format
            // Create obet for serialisation
            // SOAP = simple object Access Protocol = XML Transmission mechanism
            var formatter = new SoapFormatter();

            // Stream customer to file
            using (var stream = new FileStream
                ("data.xml", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                // Serialise data to XML as a stream if data and sen to the file stream
                formatter.Serialize(stream, customers);
            }

            // Print out file
            Console.WriteLine(File.ReadAllText("data.xml"));

            // Reverse

            var customersFromXml = new List<Customer>();
            // Stream READ
            using (var reader = File.OpenRead("data.xml"))
            {
                // Deserialize XML => customer
                customersFromXml = formatter.Deserialize(reader) as List<Customer>;
            }

            customersFromXml.ForEach(c => Console.WriteLine($"{c.Name} {c.Age}"));
        }
    }

    [Serializable]
    class Customer
    {
        public int Age { get; set; }
        public string Name { get; set; }
        
        [NonSerialized]
        private string nino;

        public Customer (int age, string name, string nino)
        {
            this.Age = age;
            this.Name = name;
            this.nino = nino;
        }
    }
}
