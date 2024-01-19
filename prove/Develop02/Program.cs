using System;
using System.IO;

//I added more information to the Entries as an excess of the requirement.

class Program
{
    static void Main(string[] args)
    {
        int optionSelected = 1;
        Journal journal = new Journal();

        while(optionSelected>=1 && optionSelected<=4){
            Console.WriteLine("Please select one of the fallowing choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");

            Console.Write("What would you like to do?: ");
            string optionSelectedString = Console.ReadLine();
            optionSelected = int.Parse(optionSelectedString);

            switch(optionSelected) {
                case 1:
                    journal.PromptNewEntry();
                    break;
                case 2:
                    journal.Display();
                    break;
                case 3:
                    Console.WriteLine("What is the filename?");
                    Console.Write("> ");
                    string fileName_load = Console.ReadLine();
                    journal.LoadJournal(fileName_load);
                    break;
                case 4:
                    Console.WriteLine("What is the filename?");
                    Console.Write("> ");
                    string fileName_save = Console.ReadLine();
                    journal.SaveJournal(fileName_save);
                    break;
            }
        }
    }


}