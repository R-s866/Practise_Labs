using System;

namespace Lab_003_OOP_All_Features
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

        }
        // Clothes (base class) inplements 'IUnisex'
        class Clothes : IUnisex
        {
            public string MyType { get; set; }
            public bool IsUnisex { get; set; }

            // Initiates Clothes with MyType and IsUnisex properties
            public Clothes(string MyType, bool IsUnisex)
            {
                this.MyType = MyType;
                this.IsUnisex = IsUnisex;
            }

            // Creates virtual Underwear method
            public virtual void Underwear()
            {

            }

            // Writes to console if 'Clothes' is Unisex
            public void ClothingIsUnisex()
            {
                Console.WriteLine("{0} :  this item is Unisex", MyType);
            }
        }
        
        // Top inherrits from clothes (base)
        class Top : Clothes
        {
            public bool HasSleeves { get; set; }

            // Initiates from base class, with extra property HasSleeves
            public Top(string MyType, bool IsUnisex, bool HasSleeves) 
                : base(MyType,IsUnisex)
            {
                this.HasSleeves = HasSleeves;
            }

            // Override base Underwear method
            public override void Underwear()
            {
                Console.WriteLine("this item can be used as underware");
            }
        }

        // Bottom inherrits from clothes (base)
        class Bottom : Clothes
        {
            public int Lenght { get; set; }
            public int Waist { get; set; }

            // Initiates from base class, with extra properties Lenght and Width
            public Bottom(string MyType, bool IsUnisex, int Lenght, int Waist)
                : base(MyType, IsUnisex)
            {
                this.Lenght = Lenght;
                this.Waist = Waist;
            }
        }
        class TShirt : Top
        {
            // Initiates from base class, with no extra properties
            public TShirt(string MyType, bool IsUnisex, bool HasSleeves)
                : base(MyType, IsUnisex, HasSleeves)
            {
            }
            // Override base underwear method
            public override void Underwear()
            {
                Console.WriteLine("this item can be used as underware");
            }
        }
        class Boxers : Bottom
        {
            // Initiates from base class, with no extra properties
            public Boxers(string MyType, bool IsUnisex, int Lenght, int Waist)
                : base(MyType, IsUnisex, Lenght, Waist)
            {
            }

            // Override base underwear method
            public override void Underwear()
            {
                Console.WriteLine("{0} :  this item can be used as underware");
            }
        }

        // IUnisex interface hold clothing is unisex method
        interface IUnisex
        {
            public void ClothingIsUnisex();
        }
    }
}
