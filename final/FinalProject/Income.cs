public abstract class Income:Movement
{

    public Income(User user, double value, Category category, string description):base(user, value, category, description){
        
    }

    public override string[] GetToBalance(){
        string[] result = {
            $"{GetDateString()}",
            $"{GetDescription()}",
            $"$ {GetValueFormated()}",
            $""
        };
        return result;
    }

    public abstract string GetToShow();

    public abstract string GetDataForSave();
    
    public override double GetValueExpense(){
        return 0;
    }

    public override double GetValueIncome(){
        return GetValue();
    }
}