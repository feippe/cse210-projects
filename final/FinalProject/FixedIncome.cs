public class FixedIncome:Income
{
    private Frequency _frequency;

    public FixedIncome(User user, double value, Category category, string description, Frequency frequency):base(user, value, category, description){
        _frequency = frequency;
    }

    public Frequency GetFrequency(){
        return _frequency;
    }

    public override string GetToShow(){
        return $"${GetValue()} [F] - {GetCategory().GetName()} - {GetDate()} - {GetUser().GetName()}";
    }
    
    public override string GetDataForSave(){
        return $"F|{GetDate()}|{GetValue()}|{GetCategory().GetName()}|{GetDescription()}|{GetUser().GetName()}|{GetFrequency().GetId()}|{GetFrequency().GetName()}";
    }
}