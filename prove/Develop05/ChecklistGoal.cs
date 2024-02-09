public class ChecklistGoal : Goal {

    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus):base(name, description, points){
        _target = target;
        _bonus = bonus;
        _amountCompleted = 0;
    }

    public void SetAmountCompleted(int amount){
        _amountCompleted = amount;
    }

    public override void RecordEvent() {

    }

    public override bool IsComplete() {
        return _amountCompleted==_target;
    }

    public override string GetDetailsString() {
        return "";
    }

    public override string GetResumeForList() {
        string isComplete = " ";
        if(IsComplete()){
            isComplete = "X";
        }
        return $"[{isComplete}] {GetShortName()} ({GetDescription()}) -- Currently completed: {_amountCompleted}/{_target}";
    }

    public override string GetDataForSave(){
       return $"ChecklistGoal|{GetShortName()}|{GetDescription()}|{GetPoints()}|{_amountCompleted}|{_target}|{_bonus}";
    }

}