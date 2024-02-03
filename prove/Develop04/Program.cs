using System;

/*
Showing Creativity and Exceeding Requirements
When you exit the program, the number of activities you completed and the total time spent are displayed.
*/

class Program
{
    
    static void Main(string[] args)
    {
        int totalTime = 0;
        int totalActivities = 0;

        BreathingActivity bActivity = new BreathingActivity("Breathing Activity", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.");
        bActivity.SetBreatheInMessage("Breathe in...");
        bActivity.SetBreatheOutMessage("Now breathe out...");

        ReflectionActivity rActivity = new ReflectionActivity("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
        rActivity.AddPrompt("Think of a time when you stood up for someone else.");
        rActivity.AddPrompt("Think of a time when you did something really difficult.");
        rActivity.AddPrompt("Think of a time when you helped someone in need.");
        rActivity.AddPrompt("Think of a time when you did something truly selfless.");
        rActivity.AddQuestion("Why was this experience meaningful to you?");
        rActivity.AddQuestion("Have you ever done anything like this before?");
        rActivity.AddQuestion("How did you get started?");
        rActivity.AddQuestion("How did you feel when it was complete?");
        rActivity.AddQuestion("What made this time different than other times when you were not as successful?");
        rActivity.AddQuestion("What is your favorite thing about this experience?");
        rActivity.AddQuestion("What could you learn from this experience that applies to other situations?");
        rActivity.AddQuestion("What did you learn about yourself through this experience?");
        rActivity.AddQuestion("How can you keep this experience in mind in the future?");

        ListingActivity lActivity = new ListingActivity("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
        lActivity.AddPrompt("Who are people that you appreciate?");
        lActivity.AddPrompt("What are personal strengths of yours?");
        lActivity.AddPrompt("Who are people that you have helped this week?");
        lActivity.AddPrompt("When have you felt the Holy Ghost this month?");
        lActivity.AddPrompt("Who are some of your personal heroes?");

        ShowMenu();
        int option = int.Parse(Console.ReadLine());

        //Thread.Sleep(1000);

        while(option>0 && option<=4){
            Console.Clear();
            switch(option){
                case 1:
                    totalActivities++;
                    bActivity.SetBreatheInMessageIsNext(true);
                    Console.WriteLine($"Welcome to the {bActivity.GetName()}");
                    Console.WriteLine("");
                    Console.WriteLine(bActivity.GetDescription());
                    Console.WriteLine("");
                    Console.Write("How long, in seconds, would you like for your session? ");
                    bActivity.SetDurationInSeconds(int.Parse(Console.ReadLine()));
                    totalTime+=bActivity.GetDurationInSeconds();
                    Console.Clear();

                    Console.WriteLine("Get ready...");
                    Thread.Sleep(bActivity.GetSmallDelay());
                    ShowSpinner(bActivity.GetSmallDelayInSeconds());

                    DateTime startTimeBA = DateTime.Now;
                    DateTime futureTimeBA = startTimeBA.AddSeconds(bActivity.GetDurationInSeconds());
                    int waitingBreathe = 2;
                    while(DateTime.Now < futureTimeBA){
                        if(bActivity.IsBreatheInMessageNext()){
                            Console.WriteLine("");
                            ShowMessageWithSeconds(bActivity.GetBreatheInMessage(),waitingBreathe);
                            bActivity.SetBreatheInMessageIsNext(false);
                        }else{
                            ShowMessageWithSeconds(bActivity.GetBreatheOutMessage(),waitingBreathe);
                            bActivity.SetBreatheInMessageIsNext(true);
                        }
                        waitingBreathe++;
                    }

                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine(bActivity.GetEndingMessage());
                    ShowSpinner(bActivity.GetBigDelayInSeconds());
                    Console.WriteLine("");
                    Console.WriteLine($"You have completed another {bActivity.GetDurationInSeconds()} seconds of the {bActivity.GetName()}");
                    ShowSpinner(bActivity.GetBigDelayInSeconds());
                    break;
                case 2:
                    totalActivities++;
                    rActivity.SetBigDelay(6000);
                    Console.WriteLine($"Welcome to the {rActivity.GetName()}");
                    Console.WriteLine("");
                    Console.WriteLine(rActivity.GetDescription());
                    Console.WriteLine("");
                    Console.Write("How long, in seconds, would you like for your session? ");
                    rActivity.SetDurationInSeconds(int.Parse(Console.ReadLine()));
                    totalTime+=rActivity.GetDurationInSeconds();
                    Console.Clear();

                    Console.WriteLine("Get ready...");
                    Thread.Sleep(rActivity.GetSmallDelay());
                    ShowSpinner(rActivity.GetSmallDelayInSeconds());
                    Console.WriteLine("");

                    Console.WriteLine("Consider the following prompt:");
                    Console.WriteLine("");
                    Console.WriteLine($" --- {rActivity.GetRandomPrompt()} ---");
                    Console.WriteLine("");
                    Console.WriteLine("When you have something in mind, press enter to continue.");
                    Console.ReadLine();

                    Console.Write("Now ponder on each of the following questions as they related to this experience.");
                    ShowMessageWithSeconds("You may begin in: ", 4);
                    Console.Clear();

                    DateTime startTimeRA = DateTime.Now;
                    DateTime futureTimeRA = startTimeRA.AddSeconds(rActivity.GetDurationInSeconds());
                    while(DateTime.Now < futureTimeRA){
                        Console.Write($"> {rActivity.GetRandomQuestion()} ");
                        ShowSpinner(rActivity.GetBigDelayInSeconds());
                        Console.WriteLine("");
                    }

                    rActivity.SetBigDelay(3000);
                    Console.WriteLine("");
                    Console.WriteLine(rActivity.GetEndingMessage());
                    ShowSpinner(rActivity.GetBigDelayInSeconds());
                    Console.WriteLine("");
                    Console.WriteLine($"You have completed another {rActivity.GetDurationInSeconds()} seconds of the {rActivity.GetName()}");
                    ShowSpinner(rActivity.GetBigDelayInSeconds());

                    break;
                case 3:
                    totalActivities++;
                    Console.WriteLine($"Welcome to the {lActivity.GetName()}");
                    Console.WriteLine("");
                    Console.WriteLine(lActivity.GetDescription());
                    Console.WriteLine("");

                    Console.Write("How long, in seconds, would you like for your session? ");
                    lActivity.SetDurationInSeconds(int.Parse(Console.ReadLine()));
                    totalTime+=lActivity.GetDurationInSeconds();
                    Console.Clear();

                    Console.WriteLine("Get ready...");
                    Thread.Sleep(bActivity.GetSmallDelay());
                    ShowSpinner(lActivity.GetBigDelayInSeconds());
                    Console.WriteLine("");

                    Console.WriteLine("List as many responses you can to the following prompt:");
                    Console.WriteLine($" --- {lActivity.GetRandomPrompt()} ---");
                    ShowMessageWithSeconds("You may begin in: ", 4);
                    Console.WriteLine("");

                    DateTime startTimeLA = DateTime.Now;
                    DateTime futureTimeLA = startTimeLA.AddSeconds(lActivity.GetDurationInSeconds());
                    while(DateTime.Now < futureTimeLA){
                        Console.Write("> ");
                        lActivity.AddAnswer(Console.ReadLine());
                    }
                    Console.WriteLine($"You listed {lActivity.GetAnswers().Count()} items!");
                    Console.WriteLine("");

                    Console.WriteLine(lActivity.GetEndingMessage());
                    ShowSpinner(lActivity.GetBigDelayInSeconds());
                    Console.WriteLine("");
                    Console.WriteLine($"You have completed another {lActivity.GetDurationInSeconds()} seconds of the {lActivity.GetName()}");
                    ShowSpinner(lActivity.GetBigDelayInSeconds());

                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine($"You spent a total of {totalTime} seconds on {totalActivities} activities.");
                    Console.WriteLine("");
                    option = 5;
                    break;
            }
            if(option<4){
                Thread.Sleep(1000);
                ShowMenu();
                option = int.Parse(Console.ReadLine());
            }
        }

    }

    static void ShowMenu(){
        Console.Clear();
        Console.WriteLine("Menu Options:");
        Console.WriteLine("  1. Start breathing activity");
        Console.WriteLine("  2. Start reflection activity");
        Console.WriteLine("  3. Start listing activity");
        Console.WriteLine("  4. Show statistics and Quit.");
        Console.Write("Select a choice from the menu: ");
    }

    static void ShowSpinner(int seconds){
        string[] symbols = {"-", "\\", "|", "/"};
        int position = 0;
        Console.Write(symbols[position]);
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(seconds);
        while(DateTime.Now < futureTime){
            Thread.Sleep(250);
            position++;
            if(position>=4){position=0;}
            Console.Write("\b \b");
            Console.Write(symbols[position]);
        }
        Console.Write("\b \b");
    }

    static void ShowMessageWithSeconds(string text, int seconds){
        Console.WriteLine("");
        Console.Write(text);
        while(seconds>0){
            Console.Write(seconds);
            Thread.Sleep(1000);
            Console.Write("\b \b");
            seconds--;
        }
    }
}