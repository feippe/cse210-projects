public class User
{
    private string _name;

    public User(string name){
        _name = name;
    }

    public string GetName(){
        return _name;
    }

    public string GetDataForSave(){
        return GetName();
    }

}