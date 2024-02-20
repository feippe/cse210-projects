public class VariableExpense:Expense
{

    public VariableExpense(User user, double value, Category category, string description):base(user, value, category, description){
        
    }

    public override string GetToShow(){
        return $"(${GetValue()}) [V] - {GetCategory().GetName()} - {GetDateString()} - {GetUser().GetName()}";
    }

    public override string GetDataForSave(){
        return $"V|{GetDateString()}|{GetValue()}|{GetCategory().GetName()}|{GetDescription()}|{GetUser().GetName()}";
    }
    
}