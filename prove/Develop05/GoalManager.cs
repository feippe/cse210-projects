public class GoalManager {
    
    private List<Goal> _goals;
    private int _score;

    public GoalManager() {
        _goals = new List<Goal>();
        _score = 0;
    }

    private void AddGoal(Goal goal){
        _goals.Add(goal);
    }

    public void Start(){
        int option = 0;
        string fileName;

        while(option < 6){

            ShowMainMenu();
            option = int.Parse(Console.ReadLine());

            switch(option) {
                case 1:
                    //CREATE NEW GOAL
                    ShowCreateNewGoalMenu();
                    int optionCreateNewGoal = int.Parse(Console.ReadLine());
                    string name;
                    string description;
                    int points;
                    switch(optionCreateNewGoal) {
                        case 1:
                            //CREATE NEW GOAL : SIMPLE GOAL
                            Console.WriteLine("");
                            Console.Write("What is the name of your goal? ");
                            name = Console.ReadLine();
                            Console.Write("What is a short description of it? ");
                            description = Console.ReadLine();
                            Console.Write("What is the amount of points associated with this goal? ");
                            points = int.Parse(Console.ReadLine());
                            SimpleGoal simpleGoal = new SimpleGoal(name, description, points);
                            AddGoal(simpleGoal);
                            Console.WriteLine("");
                            ShowMessage("The simple goal was created successfully!", 1500);
                            break;
                        case 2:
                            //CREATE NEW GOAL : ETERNAL GOAL
                            Console.WriteLine("");
                            Console.Write("What is the name of your goal? ");
                            name = Console.ReadLine();
                            Console.Write("What is a short description of it? ");
                            description = Console.ReadLine();
                            Console.Write("What is the amount of points associated with this goal? ");
                            points = int.Parse(Console.ReadLine());
                            EternalGoal eternalGoal = new EternalGoal(name, description, points);
                            AddGoal(eternalGoal);
                            Console.WriteLine("");
                            ShowMessage("The eternal goal was created successfully!", 1500);
                            break;
                        case 3:
                            //CREATE NEW GOAL : CHECKLIST GOAL
                            Console.WriteLine("");
                            Console.Write("What is the name of your goal? ");
                            name = Console.ReadLine();
                            Console.Write("What is a short description of it? ");
                            description = Console.ReadLine();
                            Console.Write("What is the amount of points associated with this goal? ");
                            points = int.Parse(Console.ReadLine());
                            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                            int target = int.Parse(Console.ReadLine());
                            Console.Write("What is the bonus for accomplishing it that many times? ");
                            int bonus = int.Parse(Console.ReadLine());
                            ChecklistGoal checklistGoal = new ChecklistGoal(name, description, points, target, bonus);
                            AddGoal(checklistGoal);
                            Console.WriteLine("");
                            ShowMessage("The checklist goal was created successfully!", 1500);
                            break;
                    }
                    break;
                case 2:
                    //LIST GOALS
                    Console.Clear();
                    Console.WriteLine("The goals are:");
                    ListGoalNames();
                    Console.WriteLine("");
                    ShowScore();
                    PressEnterToContinue();
                    break;
                case 3:
                    //SAVE GOALS
                    Console.Write("What is the filename for the goal file? ");
                    fileName = Console.ReadLine();
                    SaveGoals(fileName);
                    Console.WriteLine("");
                    ShowMessage("The goal was saved successfully!", 1500);
                    break;
                case 4:
                    //LOAD GOALS
                    Console.Write("What is the filename for the goal file? ");
                    fileName = Console.ReadLine();
                    LoadGoals(fileName);
                    Console.WriteLine("");
                    ShowMessage("The goal was leaded successfully!", 1500);
                    break;
                case 5:
                    //do something
                    break;
                case 6:
                    //do something
                    break;
            }

        }
    }

    private void ShowMessage(string message, int time){
        Console.WriteLine(message);
        Thread.Sleep(time);
    }

    private void PressEnterToContinue(){
        Console.WriteLine("");
        Console.Write("Press the enter key to continue.");
        Console.ReadLine();
    }

    private void ShowMainMenu() {
        Console.Clear();
        Console.WriteLine("Menu Options:");
        Console.WriteLine("   1. Create New Goal");
        Console.WriteLine("   2. List Goals");
        Console.WriteLine("   3. Save Goals");
        Console.WriteLine("   4. Load Goals");
        Console.WriteLine("   5. Record Event");
        Console.WriteLine("   6. Quit");
        Console.Write("Select a choice from the menu: ");
    }

    private void ShowCreateNewGoalMenu() {
        Console.Clear();
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("   1. Simple Goal");
        Console.WriteLine("   2. Eternal Goal");
        Console.WriteLine("   3. Checklist Goal");
        Console.Write("Which type of goal would you like to create?: ");
    }

    private void ShowScore(){
        Console.WriteLine($"You have {_score} points.");
    }

    private void DisplayPlayerInfo(){

    }

    private void ListGoalNames(){
        int position = 1;
        foreach(Goal goal in _goals) {
            Console.WriteLine($"{position}. {goal.GetResumeForList()}");
            position++;
        }
    }

    private void ListGoalDetails(){
        
    }

    private void CreateGoal(){
        
    }

    private void RecordEvent(){
        
    }

    private void SaveGoals(string fileName){
        using (StreamWriter outputFile = new StreamWriter(fileName)){
            outputFile.WriteLine(_score);
            foreach(Goal goal in _goals){
                outputFile.WriteLine(goal.GetDataForSave());
            }
        }
    }

    private void LoadGoals(string fileName){
        string[] lines = System.IO.File.ReadAllLines(fileName);
        int position = 0;
        foreach (string line in lines) {
            if(position==0){
                _score = int.Parse(line);
            }else{
                string[] parts = line.Split("|");
                switch(parts[0]){
                    case "SimpleGoal":
                        SimpleGoal simpleGoal = new SimpleGoal(parts[1],parts[2],int.Parse(parts[3]));
                        if(parts[4]=="True"){
                            simpleGoal.Complete();
                        }
                        AddGoal(simpleGoal);
                        break;
                    case "EternalGoal":
                        EternalGoal eternalGoal = new EternalGoal(parts[1],parts[2],int.Parse(parts[3]));
                        if(parts[4]=="True"){
                            eternalGoal.Complete();
                        }
                        AddGoal(eternalGoal);
                        break;
                    case "ChecklistGoal":
                        ChecklistGoal checklistGoal = new ChecklistGoal(parts[1],parts[2],int.Parse(parts[3]),int.Parse(parts[5]),int.Parse(parts[6]));
                        checklistGoal.SetAmountCompleted(int.Parse(parts[4]));
                        AddGoal(checklistGoal);
                        break;
                }
            }
            position++;
        }
    }

}