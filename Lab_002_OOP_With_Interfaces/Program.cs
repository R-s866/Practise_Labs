using System;

namespace Lab_002_OOP_With_Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    // Mammal base class 
    class Mammal
    {
        public bool IsWarmBlooded;
        public double Weight { get; set; }
        public double Height { get; set; }
        public double Lenght { get; set; }

        // Initiate 'Mammal' class with 4 properties
        public Mammal(bool IsWarmBlooded, double Weight, double Height, double Lenght)
        {
            this.IsWarmBlooded = true;
            this.Weight = Weight;
            this.Height = Height;
            this.Lenght = Lenght;
        }
    }

    // 'Cat' class inherrits 'Mammal' implements 
    class Cat : Mammal, IUseSmell, IUseVision
    {
        public string MyType { get; set; }

        // Initiate 'Cat' class that inherrits 'Mammal' and implements IUseVision and IUseSmell
        public Cat(bool IsWarmBlooded, double Weight, double Height, double Lenght, string MyType) 
            : base(IsWarmBlooded,Weight,Height,Lenght)
        {
            this.MyType = MyType;
        }

        // Base method Roar can be overriden
        public virtual void Roar()
        {
        }

        // Base methods can be overriden implemented from IUseVision and IUseSmell
        public virtual void SeeMyPrey()
        {
            Console.WriteLine("{0} is roaring", MyType);

        }
        public virtual void SmellMyPrey()
        {
            Console.WriteLine("{0} is roaring", MyType);

        }
    }
    class Lion : Cat
    {
        // Initiate 'Lion' class inherrits properties from 'Cat' class
        public Lion(bool IsWarmBlooded, double Weight, double Height, double Lenght, string MyType)
            : base(IsWarmBlooded, Weight, Height, Lenght, MyType)
        {
        }

        // Overrides base 'Cat' methodds
        public override void Roar()
        {
            Console.WriteLine("{0} is roaring and is scary", MyType);
        }
        public override void SeeMyPrey()
        {
            Console.WriteLine("{0} sees prey and is scary", MyType);

        }
        public override void SmellMyPrey()
        {
            Console.WriteLine("{0} Smells prey and is scary", MyType);

        }
    }
    class Tiger : Cat
    {
        // Initiate 'Tiger' class inherrits properties from 'Cat' class
        public Tiger(bool IsWarmBlooded, double Weight, double Height, double Lenght, string MyType)
            : base(IsWarmBlooded, Weight, Height, Lenght, MyType)
        {
        }

        // Overrides base 'Cat' methodds
        public override void Roar()
        {
            Console.WriteLine("{0} is roaring and is quick", MyType);
        }
        public override void SeeMyPrey()
        {
            Console.WriteLine("{0} sees prey and is quick", MyType);

        }
        public override void SmellMyPrey()
        {
            Console.WriteLine("{0} Smells prey and is quick", MyType);

        }
    }

    // Interfaces to help with class sturcture 
    interface IUseVision
    {
        public void SeeMyPrey();
    }
    interface IUseSmell
    {
        public void SmellMyPrey();
    }
}
