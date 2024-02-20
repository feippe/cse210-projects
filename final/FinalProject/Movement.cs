public abstract class Movement 
{
    private DateTime _date;
    private double _value;
    private Category _category;
    private string _description;
    private User _user;

    public DateTime GetDate(){
        return _date;
    }

    public string GetDateString(){
        return _date.ToString("MM/dd/yyyy");
    }

    public void SetDate(DateTime date){
        _date = date;
    }

    public double GetValue(){
        return _value;
    }

    public string GetValueFormated(){
        //string value = string.Parse();
        //return _value.ToString("0.##");
        //return string.Format("{0:N2}", Math.Round(_value, 2));
        return String.Format("{0:0.00}", _value);
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

    public Movement(User user, double value, Category category, string description){
        _date = DateTime.Now;
        _value = value;
        _category = category;
        _description = description;
        _user = user;
    }

    public abstract string[] GetToBalance();

    public abstract double GetValueExpense();

    public abstract double GetValueIncome();
}