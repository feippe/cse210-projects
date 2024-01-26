using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning03 World!");
        Fraction demo1 = new Fraction();
        Fraction demo2 = new Fraction(5);
        Fraction demo3 = new Fraction(3,4);
        Fraction demo4 = new Fraction(1,3);

        /*Console.Write(demo1.GetTop());
        Console.WriteLine(demo1.GetBottom());

        Console.Write(demo2.GetTop());
        Console.WriteLine(demo2.GetBottom());

        Console.Write(demo3.GetTop());
        Console.WriteLine(demo3.GetBottom());

        demo1.SetTop(2);
        demo1.SetBottom(2);

        demo2.SetTop(6);
        demo2.SetBottom(2);

        demo3.SetTop(3);
        demo3.SetBottom(5);

        Console.Write(demo1.GetTop());
        Console.WriteLine(demo1.GetBottom());

        Console.Write(demo2.GetTop());
        Console.WriteLine(demo2.GetBottom());

        Console.Write(demo3.GetTop());
        Console.WriteLine(demo3.GetBottom());

        Console.WriteLine(demo1.GetFractionString());
        Console.WriteLine(demo1.GetDecimalValue());

        Console.WriteLine(demo2.GetFractionString());
        Console.WriteLine(demo2.GetDecimalValue());

        Console.WriteLine(demo3.GetFractionString());
        Console.WriteLine(demo3.GetDecimalValue());*/

        Console.WriteLine(demo1.GetFractionString());
        Console.WriteLine(demo1.GetDecimalValue());

        Console.WriteLine(demo2.GetFractionString());
        Console.WriteLine(demo2.GetDecimalValue());

        Console.WriteLine(demo3.GetFractionString());
        Console.WriteLine(demo3.GetDecimalValue());

        Console.WriteLine(demo4.GetFractionString());
        Console.WriteLine(demo4.GetDecimalValue());


    }
}