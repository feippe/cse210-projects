public class FixedExpense:Expense
{
    private Frequency _frequency;

    public FixedExpense(User user, double value, Category category, string description, Frequency frequency):base(user, value, category, description){
        _frequency = frequency;
    }

    public Frequency GetFrequency(){
        return _frequency;
    }

    public override string GetToShow(){
        return $"(${GetValue()}) [F] - {GetCategory().GetName()} - {GetDateString()} - {GetUser().GetName()}";
    }
    
    public override string GetDataForSave(){
        return $"F|{GetDateString()}|{GetValue()}|{GetCategory().GetName()}|{GetDescription()}|{GetUser().GetName()}|{GetFrequency().GetId()}|{GetFrequency().GetName()}";
    }
    
}