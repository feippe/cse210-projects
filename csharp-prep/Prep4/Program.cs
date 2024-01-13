using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello Prep4 World!");

        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        Console.Write("Enter number: ");
        string numberString = Console.ReadLine();
        int theNumber = int.Parse(numberString);

        while (theNumber != 0){
            numbers.Add(theNumber);
            Console.Write("Enter number: ");
            numberString = Console.ReadLine();
            theNumber = int.Parse(numberString);
        }

        int sum = 0;
        double average = 0;
        int largest = 0;
        int smallestPositive = 0;

        foreach(int number in numbers){
            sum += number;
            if(number > largest){
                largest = number;
            }
            if(smallestPositive == 0){
                smallestPositive = number;
            }else if(number > 0 && smallestPositive > number){
                smallestPositive = number;
            }
        }
        average = (double)sum / numbers.Count;

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largest}");
        Console.WriteLine($"The smallest positive number is: {smallestPositive}");

        Console.WriteLine($"The sorted list is:");
        numbers.Sort();
        foreach(int number in numbers){
            Console.WriteLine(number);
        }

    }
}