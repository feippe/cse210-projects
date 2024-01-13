using System;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello Prep3 World!");

        Console.WriteLine("What is the magic number?");
        string magicNumberString = Console.ReadLine();
        int magicNumber = int.Parse(magicNumberString);

        Console.WriteLine("What is your guess?");
        string guessNumberString = Console.ReadLine();
        int guessNumber = int.Parse(guessNumberString);

        while (magicNumber != guessNumber){
            if(magicNumber > guessNumber){
                Console.WriteLine("Higher");
            }else{
                Console.WriteLine("Lower");
            }
            
            Console.WriteLine("What is your guess?");
            guessNumberString = Console.ReadLine();
            guessNumber = int.Parse(guessNumberString);
        }

        Console.WriteLine("Yes!");

    }
}