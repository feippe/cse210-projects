using System;

//Exceed the requirements: I added a counter for hidden words and show them on the screen for the user.

class Program 
{
    static void Main(string[] args)
    {
        Random random = new Random();
        Reference reference = new Reference("1 Nephi", 3, 7);
        Scripture scripture = new Scripture(reference, "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them.");

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