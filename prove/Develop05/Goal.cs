public abstract class Goal {

    private string _shortName;
    private string _description;
    private int _points;

    public Goal(string name, string description, int points) {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public string GetShortName(){
        return _shortName;
    }
    public string GetDescription(){
        return _description;
    }
    public int GetPoints(){
        return _points;
    }
    public virtual int SetNewRecord(){
        return GetPoints();
    }

    public virtual bool IsComplete(){
        return false;
    }

    public abstract string GetResumeForList();

    public abstract string GetDataForSave();

}