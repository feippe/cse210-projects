public class Word {

    private string _word;
    private bool _hidden;

    public Word(string word){
        _word = word;
        _hidden = false;
    }

    public void Hide(){
        _hidden = true;
    }
    public void Show(){
        _hidden = false;
    }

    public bool IsHidden(){
        return _hidden;
    }

    public string GetDisplayWord(){
        if(IsHidden()){
            return GetWordHidden();
        }else{
            return _word;
        }
    }

    private string GetWordHidden(){
        string hiddenWord = "";
        foreach (var character in _word){
            hiddenWord = $"{hiddenWord}_";
        }
        return hiddenWord;
    }
    
}