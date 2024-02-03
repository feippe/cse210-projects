public class BreathingActivity : Activity {

    private string _breatheInMessage;
    private string _breatheOutMessage;
    private bool _breatheInMessageIsNext;

    public BreathingActivity(string name, string description) : base(name, description) {
        _breatheInMessageIsNext = true;
    }

    public void SetBreatheInMessage(string message){
        _breatheInMessage = message;
    }

    public void SetBreatheOutMessage(string message){
        _breatheOutMessage = message;
    }

    public string GetBreatheInMessage(){
        return _breatheInMessage;
    }

    public string GetBreatheOutMessage(){
        return _breatheOutMessage;
    }

    public bool IsBreatheInMessageNext(){
        return _breatheInMessageIsNext;
    }

    public void SetBreatheInMessageIsNext(bool isNext){
        _breatheInMessageIsNext = isNext;
    }

}