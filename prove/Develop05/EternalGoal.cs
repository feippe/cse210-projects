public class EternalGoal : Goal {

    private bool _isComplete;

    public EternalGoal(string name, string description, int points):base(name, description, points) {
        _isComplete = false;
    }

    public override void RecordEvent() {

    }

    public override bool IsComplete() {
        return _isComplete;
    }
    public void Complete(){
        _isComplete = true;
    }

    public override string GetResumeForList() {
        string isComplete = " ";
        if(IsComplete()){
            isComplete = "X";
        }
        return $"[{isComplete}] {GetShortName()} ({GetDescription()})";
    }

    public override string GetDataForSave(){
       return $"EternalGoal|{GetShortName()}|{GetDescription()}|{GetPoints()}|{_isComplete}";
    }

}