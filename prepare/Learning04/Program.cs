using System;

class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("Hello Learning04 World!");
        Console.WriteLine("-------------");

        Assignment a = new Assignment("Samuel Bennet", "Multiplication");
        Console.WriteLine(a.GetSummary());
        Console.WriteLine("-------------");

        MathAssignment m = new MathAssignment("Roberto Rodriguez", "Fractions", "Section 7.3", "Problems 8-19");
        Console.WriteLine(m.GetSummary());
        Console.WriteLine(m.GetHomeworkList());
        Console.WriteLine("-------------");

        WritingAssignment w = new WritingAssignment("Mary Waters", "European History ", "The Causes of World War II by Mary Waters");
        Console.WriteLine(w.GetSummary());
        Console.WriteLine(w.GetWritingInformation());
        Console.WriteLine("-------------");

    }
}