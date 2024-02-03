public class ListingActivity : Activity {

    private List<string> _prompts;
    private List<string> _answers;

    public ListingActivity(string name, string description) : base(name, description) {
        _prompts = new List<string>();
        _answers = new List<string>();
    }

    public void AddPrompt(string prompt){
        _prompts.Add(prompt);
    }

    public string GetRandomPrompt(){
        Random random = new Random();
        return _prompts[random.Next(_prompts.Count())];
    }

    public void AddAnswer(string answer){
        _answers.Add(answer);
    }

    public List<string> GetAnswers(){
        return _answers;
    }


}