public class Activity {

    private string _name;
    private string _startingMessage;
    private string _endingMessage;
    private string _description;
    private int _duration;
    private int _smallDelay;
    private int _bigDelay;

    public Activity(string name, string description) {
        _name = name;
        _description = description;
        _startingMessage = "";
        _endingMessage = "Well done!!";
        _smallDelay = 1000;
        _bigDelay = 3000;
    }

    public void SetStartingMessage(string message){
        _startingMessage = message;
    }

    public void SetDurationInSeconds(int durationInSeconds){
        _duration = durationInSeconds*1000;
    }
    public void SetDuration(int duration){
        _duration = duration;
    }

    public int GetDurationInSeconds(){
        return _duration/1000;
    }
    public int GetDuration(){
        return _duration;
    }
    

    public string GetName(){
        return _name;
    }

    public string GetDescription(){
        return _description;
    }

    public string GetEndingMessage(){
        return _endingMessage;
    }

    public int GetSmallDelay(){
        return _smallDelay;
    }

    public void SetBigDelay(int duration){
        _bigDelay = duration;
    }

    public int GetBigDelay(){
        return _bigDelay;
    }

    public int GetSmallDelayInSeconds(){
        return _smallDelay/1000;
    }

    public int GetBigDelayInSeconds(){
        return _bigDelay/1000;
    }




}