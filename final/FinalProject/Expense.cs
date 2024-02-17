public abstract class Expense 
{
    private DateTime _date;
    private double _value;
    private Category _category;
    private string _description;
    private User _user;

    public Expense(User user, double value, Category category, string description){
        _date = new DateTime();
        _value = value;
        _category = category;
        _description = description;
        _user = user;
    }

    public DateTime GetDate(){
        return _date;
    }

    public double GetValue(){
        return _value;
    }

    public Category GetCategory(){
        return _category;
    }

    public string GetDescription(){
        return _description;
    }

    public User GetUser(){
        return _user;
    }

    public virtual string GetToShow(){
        return $"${GetValue()} - {GetCategory().GetName()} - {GetDate()} - {GetUser().GetName()}";
    }

}