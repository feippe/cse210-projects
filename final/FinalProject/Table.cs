public class Table 
{
    private int _tableWidth = 0;
    private int[] _sizes = {};

    public Table(int[] sizes, string[] columns, List<Movement> movements, string[] aligns){
        _sizes = sizes;
        _tableWidth = 0;
        foreach (int size in sizes){
            _tableWidth += size;
        }
        PrintLine();
        PrintRow(aligns, columns);
        PrintLine();

        double totalIncomes = 0;
        double totalExpenses = 0;

        foreach (Movement movement in movements){
            totalIncomes += movement.GetValueIncome();
            totalExpenses += movement.GetValueExpense();
            PrintRow(aligns, movement.GetToBalance());
        }

        PrintLine();
        string[] columnsTotal = {"","Total",$"$ {String.Format("{0:0.00}",totalIncomes)}",$"($ {String.Format("{0:0.00}",totalExpenses)})"};
        PrintRow(aligns, columnsTotal);
        PrintLine();

        double balance = totalIncomes - totalExpenses;
        if(balance>=0){
            string[] columnsBalance = { "", "Balance", $"$ {String.Format("{0:0.00}",balance)}" ,"" };
            PrintRow(aligns, columnsBalance);
        }else{
            string[] columnsBalance = { "", "Balance", "", $"($ {String.Format("{0:0.00}",balance)})" };
            PrintRow(aligns, columnsBalance);
        }
        PrintLine();

    }

    private void PrintLine(){
        Console.WriteLine(new string('-', _tableWidth + _sizes.Length + 1));
    }

    private void PrintRow(string[] aligns, params string[] columns){
        string row = "|";
        int position = 0;
        foreach (string column in columns){
            switch(aligns[position]){
                case "center":
                    row += AlignCentre(column, _sizes[position]) + "|";
                    break;
                case "left":
                    row += AlignLeft(column, _sizes[position]) + "|";
                    break;
                case "right":
                    row += AlignRight(column, _sizes[position]) + "|";
                    break;
            }
            position++;
        }
        Console.WriteLine(row);
    }

    private string AlignCentre(string text, int width){
        text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;
        if (string.IsNullOrEmpty(text)){
            return new string(' ', width);
        }else{
            return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
        }
    }

    private string AlignLeft(string text, int width){
        text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;
        if (string.IsNullOrEmpty(text)){
            return new string(' ', width);
        }else{
            return text.PadRight(width);
        }
    }

    private string AlignRight(string text, int width){
        text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;
        if(string.IsNullOrEmpty(text)){
            return new string(' ', width);
        }else{
            return text.PadLeft(width);
        }
    }

}