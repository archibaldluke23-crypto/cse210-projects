public class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();
    private Random _rng = new Random();
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        string[] words = text.Split(" ");
        foreach (string differentWord in words)
        {
            Word word = new Word(differentWord);
            _words.Add(word);
        }
    }
    public string GetDisplayText()
    {
        string text = "";
        foreach (Word word in _words)
        {
            
            text += $"{word.GetDisplayText()} ";
        }
        return $"{_reference.ToString()} {text}";
    }
    public bool IsCompletelyHidden()
    {
        bool hid = false; //
        bool completelyHidden = true;
        foreach (Word word in _words)
        {
            hid = word.IsWordHidden();
            if (hid == false)
            {
                completelyHidden = false;
            }
        }
        return completelyHidden;
    }
    public void HideRandomWords(int count)
    {
    for (int i = 1; i <= count; i++) // when finding the last word it 
        {
            bool alreadyHidden = false;
            bool stop = false;
            do
            {
            stop = IsCompletelyHidden();
            int number = _rng.Next(0, _words.Count); // 
            alreadyHidden = _words[number].IsWordHidden();
            if (alreadyHidden == false)
                _words[number].Hide();
            } while (alreadyHidden == true && stop == false);
        }
    }
    public void FindHiddenWords()
    {
        
    }
}
