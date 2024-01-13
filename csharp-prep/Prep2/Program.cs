using System;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello Prep2 World!");

        Console.WriteLine("Please, write your percentage:");
        string percentageString = Console.ReadLine();
        int percentage = int.Parse(percentageString);

        string letter;

        if (percentage >= 90){
            letter = "A";
        }else if (percentage >= 80){
            letter = "B";
        }else if (percentage >= 70){
            letter = "C";
        }else if (percentage >= 60){
            letter = "D";
        }else{
            letter = "F";
        }

        if( percentage >= 70){
            Console.WriteLine($"Your grade is {letter}! Congratulations! You approved the semester.");
        }else{
            Console.WriteLine($"Your grade is {letter}. Sorry, You need to perform the semester again.");
        }

    }
}