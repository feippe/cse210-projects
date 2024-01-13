using System;

class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("Please, write your percentage:");
        string percentageString = Console.ReadLine();
        int percentage = int.Parse(percentageString);

        string letter;
        int remainder = percentage % 10;
        string sign = "";

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

        if (remainder >= 7 && percentage < 90 && percentage >= 60){
            sign = "+";
        }else if(remainder < 3 && percentage >= 60){
            sign = "-";
        }

        if( percentage >= 70){ 
            Console.WriteLine($"Your grade is {letter}{sign}! Congratulations! You approved the semester.");
        }else{
            Console.WriteLine($"Your grade is {letter}{sign}. Sorry, You need to perform the semester again.");
        }

    }
}