public class Entry{

    public string _date;
    public string _prompt;
    public string _response;
    private Random _random = new Random();

    List<string> _prompts = new List<string>();

    public Entry(){
        _prompts.Add("bla bla bla");
        _prompts.Add("ble ble ble");
        _prompts.Add("bli bli bli");
        _prompts.Add("blo blo blo");
        _prompts.Add("blu blu blu");
    }

    public void Display(){
        Console.WriteLine($"Date: {_date} - Prompt: {_prompt}");
        Console.WriteLine(_response);
    }

    public string GetDataInALine(){
        return $"{_date}||{_prompt}||{_response}";
    }
    public void SetDataByLine(string line){
        string[] parts = line.Split("||");
        _date = parts[0];
        _prompt = parts[1];
        _response = parts[2];
    }

    public void ReadAndCreateNewEntry(){

        DateTime currentTime = DateTime.Now;
        _date = currentTime.ToShortDateString();

        int position = _random.Next(_prompts.Count);
        _prompt = _prompts[position];

        Console.WriteLine(_prompt);
        Console.Write("> ");
        _response = Console.ReadLine();

    }
}