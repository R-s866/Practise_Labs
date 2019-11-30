using System;

namespace Labs_012_OOP_Events
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var james = new Child("James");
            james.Grow();
        }
    }

    class Child
    {
        // Trival Event Annual Birthday
        public delegate void BirthdayDelegate();
        public event BirthdayDelegate HaveABirthday;

        public string Name { get; set; }
        public int Age { get; set; }

        public Child(string n)
        {
            this.Name = Name;
            this.Age = Age;
            HaveABirthday += HaveABirthday;
        }

        public void Grow()
        {
            HaveABirthday();
        }

        public void HaveAParty()
        {
            this.Age++;
            Console.WriteLine($"Hey celebrating another year Age is now {this.Age}");
        }
    }
}
