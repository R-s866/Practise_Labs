using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Lab_023_Serialization_JSON
{
    class Program
    {
        static void Main(string[] args)
        {
            var customer = new Customer(1, "jeff", "f121n233ad2snkf");
            var customer2 = new Customer(2, "Setive", "h78yy2hnwjebihsayd");

            List<Customer> customers = new List<Customer>() { customer, customer2 };

            // Serialise
            var JSONCustomerList = JsonConvert.SerializeObject(customers);
            Console.WriteLine(JSONCustomerList);
            // save to file
            File.WriteAllText("data.json",JSONCustomerList);

            // Read
            var JSONSring = File.ReadAllText("data.json");

            // Deserialize
            var customersFromJSON =
                JsonConvert.DeserializeObject<List<Customer>>(JSONSring);

            customersFromJSON.ForEach(c => Console.WriteLine($"{c.Name, -10} {c.Age}"));
        }
    }

    [Serializable]
    public class Customer
    {
        public int Age { get; set; }
        public string Name { get; set; }

        [NonSerialized]
        private string nino;

        public Customer(int age, string name, string nino)
        {
            this.Age = age;
            this.Name = name;
            this.nino = nino;
        }
    }
}
