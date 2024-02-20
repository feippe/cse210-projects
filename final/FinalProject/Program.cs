using System;
using System.IO;
using System.Globalization;

class Program
{

    static void Main(string[] args)
    {
        System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
        customCulture.NumberFormat.NumberDecimalSeparator = ".";
        System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;

        SystemManager system = new SystemManager();

        List<string> filesDataBase = new List<string>();
        filesDataBase.Add("users");
        filesDataBase.Add("categories");
        filesDataBase.Add("expenses");
        filesDataBase.Add("incomes");


        Console.Clear();
        string dataBasePath = "dataBase";
        CreateFolder(dataBasePath);

        Console.WriteLine("=== Wellcome to Expenses System ===");
        Console.WriteLine("");
        Console.Write("Please write the name of your data base: ");
        string dataBaseName = Console.ReadLine();
        //string dataBaseName = "feippe";
        string dataBaseFilesPath = $"{dataBasePath}/{dataBaseName}";

        if(FolderExists(dataBaseFilesPath)){
            //the database exists
            system.LoadDataBase(dataBaseFilesPath,filesDataBase);
        }else{
            //the database is new
            CreateFolder(dataBaseFilesPath);
            try {
                foreach (string fileName in filesDataBase){
                    using (StreamWriter outputFile = new StreamWriter($"{dataBaseFilesPath}/{fileName}.txt")){
                        outputFile.WriteLine($"DATABASE {fileName.ToUpper()}");
                    }
                }
                Console.WriteLine("The new data base was created!");
            }catch(Exception e) {
                Console.WriteLine(e.Message);
            }
        }

        system.Start();

    }

    static void CreateFolder(string folder){
        if(!FolderExists(folder)){
            System.IO.Directory.CreateDirectory(folder);
        }
    }

    static bool FolderExists(string folder){
        return System.IO.Directory.Exists(folder);
    }

    static bool FileExists(string file){
        return System.IO.File.Exists(file);
    }


}