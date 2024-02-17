public class Frequency
{
    private int _id;
    private string _name;

    public Frequency(int id, string name){
        _id = id;
        _name = name;
    }

    public string GetName(){
        return _name;
    }

    public int GetId(){
        return _id;
    }

}