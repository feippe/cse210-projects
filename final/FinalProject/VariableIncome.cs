public class VariableIncome:Income
{

    public VariableIncome(User user, double value, Category category, string description):base(user, value, category, description){
        
    }

    public override string GetToShow(){
        return $"${GetValue()} [V] - {GetCategory().GetName()} - {GetDate()} - {GetUser().GetName()}";
    }

    public override string GetDataForSave(){
        return $"V|{GetDate()}|{GetValue()}|{GetCategory().GetName()}|{GetDescription()}|{GetUser().GetName()}";
    }
    
}