using System;
using System.IO;

//I added the option to cancel when you are creating a goal, and when you are recording an event.
//Additionally, I made letter checks (or options out of range) when requesting an option from the menus.

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        goalManager.Start();
    }
}