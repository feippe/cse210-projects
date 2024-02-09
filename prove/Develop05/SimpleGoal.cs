public class SimpleGoal : Goal {

    private bool _isComplete;

    public SimpleGoal(string name, string description, int points):base(name, description, points) {
        _isComplete = false;
    }

    public override bool IsComplete() {
        return _isComplete;
    }
    
    public void Complete(){
        _isComplete = true;
    }

    public override int SetNewRecord(){
        Complete();
        return GetPoints();
    }

    public override string GetResumeForList() {
        string isComplete = " ";
        if(IsComplete()){
            isComplete = "X";
        }
        return $"[{isComplete}] {GetShortName()} ({GetDescription()})";
    }

    public override string GetDataForSave(){
       return $"SimpleGoal|{GetShortName()}|{GetDescription()}|{GetPoints()}|{_isComplete}";
    }

}