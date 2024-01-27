using System;

/*
Exceed the requirements: 
1. I added a counter for hidden words and show them on the screen for the user.
2. I put all the scripts in a txt file and the program picks them up from there, and takes one of them at random.
*/

class Program 
{
    static void Main(string[] args)
    {
        Random random = new Random();
        
        string[] lines = System.IO.File.ReadAllLines("scripture-base.txt");
        string line = lines[random.Next(lines.Count())];
        string[] parts = line.Split("|");

        Reference reference = new Reference(parts[0], int.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3]));
        Scripture scripture = new Scripture(reference, parts[4]);

        Console.Clear();
        Console.WriteLine(reference.GetDisplayReference());
        Console.WriteLine(scripture.GetDisplayScripture());
        Console.WriteLine("");
        Console.WriteLine($"Hidde words: {scripture.GetHiddenWordsCount()}");
        Console.WriteLine("");
        
        Console.WriteLine("Press enter to continue or type 'quit' to finish:");
        string command = Console.ReadLine();

        while(scripture.IsCompletelyHidden()==false && command!="quit"){
            Console.Clear();
            scripture.HideRandomWords(random.Next(2,4));
            Console.WriteLine(reference.GetDisplayReference());
            Console.WriteLine(scripture.GetDisplayScripture());
            Console.WriteLine("");
            Console.WriteLine($"Hidde words: {scripture.GetHiddenWordsCount()}");
            Console.WriteLine("");
            Console.WriteLine("Press enter to continue or type 'quit' to finish:");
            command = Console.ReadLine();
        }
        
    }

}
