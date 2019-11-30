using System;

namespace Lab_003_OOP_All_Features
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

        }
        class Clothes : IUnisex
        {
            public string MyType { get; set; }
            public bool IsUnisex { get; set; }

            public Clothes(string MyType, bool IsUnisex)
            {
                this.MyType = MyType;
                this.IsUnisex = IsUnisex;
            }
            public virtual void Underwear()
            {

            }
            public void ClothingIsUnisex()
            {
                Console.WriteLine("{0} :  this item is Unisex", MyType);
            }
        }
        class Top : Clothes
        {
            public bool HasSleeves { get; set; }
            public Top(string MyType, bool IsUnisex, bool HasSleeves) 
                : base(MyType,IsUnisex)
            {
                this.HasSleeves = HasSleeves;
            }
            public override void Underwear()
            {
                Console.WriteLine("this item can be used as underware");
            }
        }
        class Bottom : Clothes
        {
            public int Lenght { get; set; }
            public int Waist { get; set; }
            public Bottom(string MyType, bool IsUnisex, int Lenght, int Waist)
                : base(MyType, IsUnisex)
            {
                this.Lenght = Lenght;
                this.Waist = Waist;
            }
        }
        class TShirt : Top
        {
            public TShirt(string MyType, bool IsUnisex, bool HasSleeves)
                : base(MyType, IsUnisex, HasSleeves)
            {
                this.HasSleeves = HasSleeves;
            }
            public override void Underwear()
            {
                Console.WriteLine("this item can be used as underware");
            }
        }
        class Boxers : Bottom
        {
            public Boxers(string MyType, bool IsUnisex, int Lenght, int Waist)
                : base(MyType, IsUnisex, Lenght, Waist)
            {
            }
            public override void Underwear()
            {
                Console.WriteLine("{0} :  this item can be used as underware");
            }
        }
        interface IUnisex
        {
            public void ClothingIsUnisex();
        }
    }
}
