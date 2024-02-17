public class FixedExpense:Expense
{
    private Frequency _frequency;

    public FixedExpense(User user, double value, Category category, string description, Frequency frequency):base(user, value, category, description){
        _frequency = frequency;
    }

    public Frequency GetFrequency(){
        return _frequency;
    }
    
}