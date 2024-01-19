public class Journal{

    public List<Entry> _entries = new List<Entry>();

    public void Display(){
        Console.WriteLine("ENTRIES:");
        Console.WriteLine("");
        for(int i=0;i<_entries.Count;i++){
            _entries[i].Display();
            Console.WriteLine("");
        }
    }

    public void PromptNewEntry(){
        Entry entry = new Entry();
        entry.ReadAndCreateNewEntry();
        _entries.Add(entry);
    }

    public void LoadJournal(string fileName){
        string[] lines = System.IO.File.ReadAllLines(fileName);
        _entries = new List<Entry>();
        foreach (string line in lines){            
            Entry entry = new Entry();
            entry.SetDataByLine(line);
            _entries.Add(entry);
        }
    }

    public void SaveJournal(string fileName){
        using (StreamWriter outputFile = new StreamWriter(fileName)){
            for(int i=0;i<_entries.Count;i++){
                outputFile.WriteLine(_entries[i].GetDataInALine());
            }
        }
    }


}