public class EternalGoal : Goal {

    public EternalGoal(string name, string description, int points):base(name, description, points){

    }

    public override string GetResumeForList() {
        return $"[ ] {GetShortName()} ({GetDescription()})";
    }

    public override string GetDataForSave(){
       return $"EternalGoal|{GetShortName()}|{GetDescription()}|{GetPoints()}";
    }

}