public abstract class Expense:Movement
{

    public Expense(User user, double value, Category category, string description):base(user, value, category, description){

    }

    public override string[] GetToBalance(){
        string[] result = {
            $"{GetDateString()}",
            $"{GetDescription()}",
            $"",
            $"($ {GetValueFormated()})"
        };
        return result;
    }

    public abstract string GetToShow();

    public abstract string GetDataForSave();

    public override double GetValueExpense(){
        return GetValue();
    }

    public override double GetValueIncome(){
        return 0;
    }

}