public class Scripture {

    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string scripture){
        _reference = reference;
        string[] words = scripture.Split(' ');
        _words = new List<Word>();
        for(int j=0; j<words.Count(); j++){
            _words.Add(new Word(words[j]));
        }
    }

    public void HideRandomWords(int numberToHide){
        int hiddenWordsCount = 0;
        bool goon = true;
        Random random = new Random();
        while(goon == true){
            List<Word> showingWords = GetShowingWords();
            if(hiddenWordsCount>=numberToHide || showingWords.Count==0){
                goon = false;
            }else{
                showingWords[random.Next(showingWords.Count)].Hide();
                hiddenWordsCount++;
            }
        }
    }

    private List<Word> GetShowingWords(){
        List<Word> showingWords = new List<Word>();
        for(int k=0; k<_words.Count; k++){
            if(_words[k].IsHidden() == false){
                showingWords.Add(_words[k]);
            }
        }
        return showingWords;
    }

    public string GetDisplayScripture(){
        string scripture = "";
        for(int i=0; i<_words.Count; i++){
            scripture = $"{scripture}{_words[i].GetDisplayWord()} ";
        }
        return scripture;
    }

    public bool IsCompletelyHidden(){
        for(int i=0; i<_words.Count; i++){
            if(_words[i].IsHidden() == false){
                return false;
            }
        }
        return true;
    }

    public int GetHiddenWordsCount(){
        int hiddenWordsCount = 0;
        for(int l=0; l<_words.Count; l++){
            if(_words[l].IsHidden() == true){
                hiddenWordsCount++;
            }
        }
        return hiddenWordsCount;
    }

}