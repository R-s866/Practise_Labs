using System;

namespace Lab_002_OOP_With_Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    class Mammal
    {
        public bool IsWarmBlooded;
        public double Weight { get; set; }
        public double Height { get; set; }
        public double Lenght { get; set; }

        public Mammal(bool IsWarmBlooded, double Weight, double Height, double Lenght)
        {
            this.IsWarmBlooded = true;
            this.Weight = Weight;
            this.Height = Height;
            this.Lenght = Lenght;
        }
    }
    class Cat : Mammal, IUseSmell, IUseVision
    {
        public string MyType { get; set; }
        public Cat(bool IsWarmBlooded, double Weight, double Height, double Lenght, string MyType) 
            : base(IsWarmBlooded,Weight,Height,Lenght)
        {
            this.MyType = MyType;
        }
        public virtual void Roar()
        {
        }
        public virtual void SeeMyPrey()
        {
            Console.WriteLine("{0} is roaring", MyType);

        }
        public virtual void SmellMyPrey()
        {
            Console.WriteLine("{0} is roaring", MyType);

        }
    }
    /*class Lion : Cat
    {
        public override void Roar()
        {
            Console.WriteLine("{0} is roaring", MyType);
        }
        public override void SeeMyPrey()
        {
            Console.WriteLine("{0} is roaring", MyType);

        }
        public override void SmellMyPrey()
        {
            Console.WriteLine("{0} is roaring", MyType);

        }
    }
    class Tiger : Cat
    {
        public override void Roar()
        {
            Console.WriteLine("{0} is roaring", MyType);
        }
        public override void SeeMyPrey()
        {
            Console.WriteLine("{0} is roaring", MyType);

        }
        public override void SmellMyPrey()
        {
            Console.WriteLine("{0} is roaring", MyType);

        }
    }*/
    interface IUseVision
    {
        public void SeeMyPrey();
    }
    interface IUseSmell
    {
        public void SmellMyPrey();
    }
}
