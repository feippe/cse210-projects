public class SystemManager
{
    private List<User> _users;
    private List<Expense> _expenses;
    private List<Income> _incomes;
    private List<Category> _categories;
    private List<Frequency> _frequencies;
    private string _dataBaseFilesPath;
    

    public SystemManager(){
        _users = new List<User>();
        _expenses = new List<Expense>();
        _incomes = new List<Income>();
        _categories = new List<Category>();
        _frequencies = new List<Frequency>();
        _frequencies.Add(new Frequency(1,"Weekly"));
        _frequencies.Add(new Frequency(2,"Monthly"));
        _frequencies.Add(new Frequency(3,"Annual"));
    }

    private List<User> GetUsers(){
        return _users;
    }

    private List<Expense> GetExpenses(){
        return _expenses;
    }

    private List<Income> GetIncomes(){
        return _incomes;
    }

    private List<Category> GetCategories(){
        return _categories;
    }

    private List<Frequency> GetFrequencies(){
        return _frequencies;
    }

    private double GetBalance(){
        return 0;
    }

    private List<Expense> GetExpensesByCategory(Category category){
        return new List<Expense>();
    }

    private List<Income> GetIncomesByCategory(Category category){
        return new List<Income>();
    }

    private void AddUser(User user){
        _users.Add(user);
        updateUserDatabase();
    }

    private void RemoveUser(User user){
        _users.Remove(user);
        updateUserDatabase();
    }

    private void AddCategory(Category category){
        _categories.Add(category);
        updateCategoryDatabase();
    }

    private void RemoveCategory(Category category){
        _categories.Remove(category);
        updateCategoryDatabase();
    }

    private void AddExpense(Expense expense){

    }

    private void RemoveExpense(Expense expense){

    }

    private void AddIncome(Income income){
        _incomes.Add(income);
        updateIncomeDatabase();
    }

    private void RemoveIncome(Income income){
        _incomes.Remove(income);
        updateIncomeDatabase();
    }

    public void LoadDataBase(string dataBaseName, List<string> filesDataBase){
        _dataBaseFilesPath = dataBaseName;
        foreach (string fileName in filesDataBase){
            string[] fileLines = System.IO.File.ReadAllLines($"{dataBaseName}/{fileName}.txt");
            int position = 0;
            switch (fileLines[0].ToUpper()){
                case "DATABASE USERS":
                    position = 0;
                    foreach (string line in fileLines){
                        if(position>0){
                            _users.Add(new User(line));
                        }
                        position++;
                    }
                    break;
                case "DATABASE CATEGORIES":
                    position = 0;
                    foreach (string line in fileLines){
                        if(position>0){
                            _categories.Add(new Category(line));
                        }
                        position++;
                    }
                    break;
                case "DATABASE INCOMES":
                    position = 0;
                    foreach (string line in fileLines){
                        if(position>0){
                            string[] parts = line.Split("|");
                            if(parts[0]=="V"){
                                User user = new User(parts[5]);
                                double value = double.Parse(parts[2], System.Globalization.CultureInfo.InvariantCulture);
                                Category category = new Category(parts[3]);
                                string description = parts[4];
                                Income income = new VariableIncome(user, value, category, description);
                                _incomes.Add(income);
                            }else if(parts[0]=="F"){
                                User user = new User(parts[5]);
                                double value = double.Parse(parts[2], System.Globalization.CultureInfo.InvariantCulture);
                                Category category = new Category(parts[3]);
                                string description = parts[4];
                                Frequency frequency = new Frequency(int.Parse(parts[6]),parts[7]);
                                Income income = new FixedIncome(user, value, category, description, frequency);
                                _incomes.Add(income);
                            }
                        }
                        position++;
                    }
                    break;
                case "DATABASE EXPENSES":
                    //TODO: do something
                    break;
            }
        }
    }

    public void Start(){
        int option = 0;
        while (option != 10){
            ShowMainMenu();
            option = OptionRead();
            switch(option){
                case 1:
                    //TODO: Create a new expense
                    break;
                case 2:
                    ShowNewIncome();
                    break;
                case 3:
                    //TODO: List expenses
                    break;
                case 4:
                    ShowListIncomes();
                    break;
                case 5:
                    //TODO: Show balance
                    break;
                case 6:
                    ShowUsers();
                    break;
                case 7:
                    ShowNewUser();
                    break;
                case 8:
                    ShowCategories();
                    break;
                case 9:
                    ShowNewCategory();
                    break;
                case 10:
                    ShowMessage("Closing the program.", 1500);
                    break;
                default:
                    ShowMessage("Please select a valid option.", 1500);
                    break;
            }
        }
    }

    private void ShowListIncomes(){
        Console.Clear();
        Console.WriteLine("=== INCOMES LIST ===");
        Console.WriteLine("");
        int position = 0;
        foreach (Income income in GetIncomes()){
            position++;
            Console.WriteLine($"{position}. {income.GetToShow()}");
        }
        Console.Write("Press enter to return to main menu, or enter the number to delete an income: ");
        int option = OptionRead();

        if(option>0 && option<=GetIncomes().Count){
            RemoveIncome(GetIncomes()[option-1]);
            ShowMessage("Income deleted!", 1500);
            ShowListIncomes();
        }
    }

    private bool ShowNewIncome(){
        //SELECTING USER
        Console.Clear();
        Console.WriteLine("=== NEW INCOME ===");
        Console.WriteLine("");
        Console.WriteLine("Please select the user asociated to the new income.");
        int position = 0;
        foreach(User theuser in GetUsers()){
            position++;
            Console.WriteLine($"{position}. {theuser.GetName()}");
        }
        Console.Write("Select the option, or press enter to cancel: ");
        int option = OptionRead();
        User user;
        if(option>0 && option<=GetUsers().Count){
            user = GetUsers()[option-1];
        }else{
            ShowMessage($"Income creation canceled.",1500);
            return false;
        }

        //SELECTING CATEGORY
        Console.Clear();
        Console.WriteLine("=== NEW INCOME ===");
        Console.WriteLine("");
        Console.WriteLine($"User: {user.GetName()}");
        Console.WriteLine("");
        Console.WriteLine("Please select the category asociated to the new income.");
        position = 0;
        foreach(Category thecategory in GetCategories()){
            position++;
            Console.WriteLine($"{position}. {thecategory.GetName()}");
        }
        Console.Write("Select the option, or press enter to cancel: ");
        option = OptionRead();
        Category category;
        if(option>0 && option<=GetCategories().Count){
            category = GetCategories()[option-1];
        }else{
            ShowMessage($"Income creation canceled.",1500);
            return false;
        }

        //WRITING VALUE
        Console.Clear();
        Console.WriteLine("=== NEW INCOME ===");
        Console.WriteLine("");
        Console.WriteLine($"User: {user.GetName()}");
        Console.WriteLine($"Category: {category.GetName()}");
        Console.WriteLine("");
        Console.Write("Please enter the value of the new income, or press enter to cancel: ");
        double value = 0;
        if(!double.TryParse(Console.ReadLine(), System.Globalization.NumberStyles.AllowDecimalPoint , new System.Globalization.CultureInfo("en-US"), out value)){
            ShowMessage($"Income creation canceled.",1500);
            return false;
        }

        //WRITING DESCRIPTION
        Console.Clear();
        Console.WriteLine("=== NEW INCOME ===");
        Console.WriteLine("");
        Console.WriteLine($"User: {user.GetName()}");
        Console.WriteLine($"Category: {category.GetName()}");
        Console.WriteLine($"Value: ${value}");
        Console.WriteLine("");
        Console.WriteLine("Please enter a description for the new income, or press enter to cancel: ");
        string description = Console.ReadLine();
        if(description==""){
            ShowMessage($"Income creation canceled.",1500);
            return false;
        }

        //IS FIXED INCOME
        Console.Clear();
        Console.WriteLine("=== NEW INCOME ===");
        Console.WriteLine("");
        Console.WriteLine($"User: {user.GetName()}");
        Console.WriteLine($"Category: {category.GetName()}");
        Console.WriteLine($"Value: ${value}");
        Console.WriteLine($"Description: {description}");
        Console.WriteLine("");
        Console.Write("This income is Variable or Fixed? (V/F), or press enter or another key to cancel: ");
        string fixedOrVariable = Console.ReadLine().ToUpper();
        Console.WriteLine("");
        switch (fixedOrVariable){
            case "V":
                //CREATING VARIABLE INCOME
                VariableIncome variableIncome = new VariableIncome(user, value, category, description);
                AddIncome(variableIncome);
                ShowMessage($"Income successfully created",1500);
                return true;
                break;
            case "F":
                Console.Clear();
                Console.WriteLine("=== NEW INCOME ===");
                Console.WriteLine("");
                Console.WriteLine($"User: {user.GetName()}");
                Console.WriteLine($"Category: {category.GetName()}");
                Console.WriteLine($"Value: ${value}");
                Console.WriteLine($"Description: {description}");
                Console.WriteLine($"Type: Fixed");
                Console.WriteLine("");
                Console.WriteLine("Select frequency of the income.");
                position = 0;
                foreach(Frequency thefrequency in GetFrequencies()){
                    position++;
                    Console.WriteLine($"{thefrequency.GetId()}. {thefrequency.GetName()}");
                }
                Console.Write("Select the option, or press enter to cancel: ");
                option = OptionRead();
                Frequency frequency;
                if(option>0 && option<=GetFrequencies().Count){
                    frequency = GetFrequencies()[option-1];
                }else{
                    ShowMessage($"Income creation canceled.",1500);
                    return false;
                }

                //CREATING FIXED INCOME
                FixedIncome fixedIncome = new FixedIncome(user, value, category, description, frequency);
                AddIncome(fixedIncome);
                ShowMessage($"Income successfully created",1500);
                return true;
                break;
            default:
                ShowMessage($"Income creation canceled.",1500);
                return false;
                break;
        }

    }

    private void ShowNewUser(){
        Console.Clear();
        Console.WriteLine("=== NEW USER ===");
        Console.WriteLine("");
        Console.Write("Write the name of the new user, or press enter to cancel: ");
        string name = Console.ReadLine();
        Console.WriteLine("");
        if(name!=""){
            User user = new User(name);
            AddUser(user);
            ShowMessage($"The new user '{user.GetName()}' was created!",1500);
        }else{
            ShowMessage($"User creation canceled.",1500);
        }
    }

    private void ShowNewCategory(){
        Console.Clear();
        Console.WriteLine("=== NEW CATEGORY ===");
        Console.WriteLine("");
        Console.Write("Write the name of the new category, or press enter to cancel: ");
        string name = Console.ReadLine();
        Console.WriteLine("");
        if(name!=""){
            Category category = new Category(name);
            AddCategory(category);
            ShowMessage($"The new category '{category.GetName()}' was created!",1500);
        }else{
            ShowMessage($"Category creation canceled.",1500);
        }
    }

    private void ShowUsers(){
        Console.Clear();
        Console.WriteLine("=== USERS LIST ===");
        Console.WriteLine("");
        int position = 0;
        foreach (User user in GetUsers()){
            position++;
            Console.WriteLine($"{position}. {user.GetName()}");
        }
        Console.Write("Press enter to back the main menu, or enter the number of a user to delete it: ");
        int option = OptionRead();
        if(option>0 && option<=GetUsers().Count){
            User user = GetUsers()[option-1];
            RemoveUser(user);
            ShowMessage($"{user.GetName()} was deleted!", 1500);
        }
    }

    private void ShowCategories(){
        Console.Clear();
        Console.WriteLine("=== CATEGORIES LIST ===");
        Console.WriteLine("");
        int position = 0;
        foreach (Category category in GetCategories()){
            position++;
            Console.WriteLine($"{position}. {category.GetName()}");
        }
        Console.Write("Press enter to back the main menu, or enter the number of a category to delete it: ");
        int option = OptionRead();
        if(option>0 && option<=GetCategories().Count){
            Category category = GetCategories()[option-1];
            RemoveCategory(category);
            ShowMessage($"Category '{category.GetName()}' was deleted!", 1500);
        }
    }

    private int OptionRead(){
        int option = 0;
        return int.TryParse(Console.ReadLine(), out option) ? option : 0;
    }

    private void ShowMessage(string message, int time){
        Console.WriteLine(message);
        Thread.Sleep(time);
    }

    private void ShowMainMenu(){
        Console.Clear();
        Console.WriteLine("=== Wellcome to Expenses System ===");
        Console.WriteLine("");
        Console.WriteLine("Menu Options:");
        Console.WriteLine("   1. Create a new expense");
        Console.WriteLine("   2. Create a new income");
        Console.WriteLine("   3. List expenses");
        Console.WriteLine("   4. List incomes");
        Console.WriteLine("   5. Show balance");
        Console.WriteLine("   6. List users");
        Console.WriteLine("   7. Create a new user");
        Console.WriteLine("   8. List categories");
        Console.WriteLine("   9. Create a new category");
        Console.WriteLine("   10. Quit");
        Console.Write("Select a choice from the menu: ");
    }





    //FOR SAVE IN DATA BASE
    private void updateCategoryDatabase(){
        string path = $"{_dataBaseFilesPath}/categories.txt";
        try {
            System.IO.File.WriteAllText(path,string.Empty);
            using (StreamWriter outputFile = new StreamWriter(path)){
                outputFile.WriteLine("DATABASE CATEGORIES");
                foreach(Category category in GetCategories()){
                    outputFile.WriteLine(category.GetDataForSave());
                }
            }
        }catch(Exception e) {
            Console.WriteLine(e.Message);
        }
    }

    private void updateUserDatabase(){
        string path = $"{_dataBaseFilesPath}/users.txt";
        try {
            System.IO.File.WriteAllText(path,string.Empty);
            using (StreamWriter outputFile = new StreamWriter(path)){
                outputFile.WriteLine("DATABASE USERS");
                foreach(User user in GetUsers()){
                    outputFile.WriteLine(user.GetDataForSave());
                }
            }
        }catch(Exception e) {
            Console.WriteLine(e.Message);
        }
    }

    private void updateIncomeDatabase(){
        string path = $"{_dataBaseFilesPath}/incomes.txt";
        try {
            System.IO.File.WriteAllText(path,string.Empty);
            using (StreamWriter outputFile = new StreamWriter(path)){
                outputFile.WriteLine("DATABASE INCOMES");
                foreach(Income income in GetIncomes()){
                    outputFile.WriteLine(income.GetDataForSave());
                }
            }
        }catch(Exception e) {
            Console.WriteLine(e.Message);
        }
    }

}