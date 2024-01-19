public class Entry{

    public string _date;
    public string _prompt;
    public string _response;
    public string _place;
    private Random _random = new Random();

    List<string> _prompts = new List<string>();

    public Entry(){
        _prompts.Add("Who was the most interesting person I interacted with today?");
        _prompts.Add("What was the best part of my day?");
        _prompts.Add("How did I see the hand of the Lord in my life today?");
        _prompts.Add("What was the strongest emotion I felt today?");
        _prompts.Add("If I had one thing I could do over today, what would it be?");
    }

    public void Display(){
        Console.WriteLine($"Date: {_date} - Place: {_place} - Prompt: {_prompt}");
        Console.WriteLine(_response);
    }

    public string GetDataInALine(){
        return $"{_date}||{_place}||{_prompt}||{_response}";
    }

    public void SetDataByLine(string line){
        string[] parts = line.Split("||");
        _date = parts[0];
        _place = parts[1];
        _prompt = parts[2];
        _response = parts[3];
    }

    public void ReadAndCreateNewEntry(){

        DateTime currentTime = DateTime.Now;
        _date = currentTime.ToShortDateString();

        int position = _random.Next(_prompts.Count);
        _prompt = _prompts[position];

        Console.WriteLine("Write your place: ");
        Console.Write("> ");
        _place = Console.ReadLine();

        Console.WriteLine(_prompt);
        Console.Write("> ");
        _response = Console.ReadLine();

    }
}