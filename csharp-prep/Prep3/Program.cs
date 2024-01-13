using System;

class Program
{
    static void Main(string[] args)
    {

        bool play = true;

        while (play){
            int guesses = 0;

            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 100);

            Console.WriteLine("What is your guess?");
            string guessNumberString = Console.ReadLine();
            int guessNumber = int.Parse(guessNumberString);
            guesses = 1;

            while (magicNumber != guessNumber){
                if(magicNumber > guessNumber){
                    Console.WriteLine("Higher");
                }else{
                    Console.WriteLine("Lower");
                }
                
                Console.WriteLine("What is your guess?");
                guessNumberString = Console.ReadLine();
                guessNumber = int.Parse(guessNumberString);
                guesses += 1;
            }

            Console.WriteLine("YES!");
            if(guesses>1){
                Console.WriteLine($"You guess in {guesses} attempts!");
            }else{
                Console.WriteLine($"You guess in 1 attempt!");
            }

            Console.WriteLine("Do you want to play again? (write 'yes' if you want to play again)");
            string playAgain = Console.ReadLine();

            if(playAgain.ToLower() != "yes"){
                play = false;
            }
        }

    }
}