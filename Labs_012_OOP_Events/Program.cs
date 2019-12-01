using System;

namespace Labs_012_OOP_Events
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize a new child class and call the grow method
            var james = new Child("James");
            james.Grow();
        }
    }

    class Child
    {
        // Trival Event Annual Birthday
        // Declare the delegate BirthdayDelegate
        public delegate void BirthdayDelegate();
        // Declare BirthdayDelegates event
        public event BirthdayDelegate HaveABirthday;

        public string Name { get; set; }
        public int Age { get; set; }

        // Child Class that takes a string
        public Child(string n)
        {
            this.Name = Name;
            this.Age = Age;
            // Add the HaveAParty + EatingCake methods to the Event
            HaveABirthday += HaveAParty;
            HaveABirthday += EatCake;
        }

        public void Grow()
        {
            // Calls the having a party Event Which calls the 2 methods below 
            HaveABirthday();
        }

        public void HaveAParty()
        {
            // Increments age then writes Age
            this.Age++;
            Console.WriteLine($"Hey celebrating another year Age is now {this.Age}");
        }

        public void EatCake()
        {
            // Writes name
            Console.WriteLine($"{this.Name} is Eating Cake");
        }
    }
}
