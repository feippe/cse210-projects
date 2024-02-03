public class ReflectionActivity : Activity {

    private List<string> _prompts;
    private List<string> _questions;

    public ReflectionActivity(string name, string description) : base(name, description) {
        _prompts = new List<string>();
        _questions = new List<string>();
    }

    public void AddPrompt(string prompt){
        _prompts.Add(prompt);
    }

    public void AddQuestion(string question){
        _questions.Add(question);
    }

    public string GetRandomPrompt(){
        Random random = new Random();
        return _prompts[random.Next(_prompts.Count())];
    }

    public string GetRandomQuestion(){
        Random random = new Random();
        return _questions[random.Next(_questions.Count())];
    }

}