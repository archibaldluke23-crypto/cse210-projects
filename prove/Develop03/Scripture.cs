public class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();
    private Random _rng = new Random();
    private List<Word> _hiddenWords = new List<Word>();
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        string[] words = text.Split(" ");
        int newLineMarker = 0;
        foreach (string differentWord in words)
        {
            newLineMarker += 1;
            string addWord = differentWord; // Needed to create a new variable because I can't add "\n" to the 
                                            // differntWord because its in a foreach loop 
            if (newLineMarker == 16)
            {
                addWord = differentWord + "\n"; // stops words from being cut in half in the terminal by creating new lines early
                newLineMarker = 0;
            }
            Word word = new Word(addWord);
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
        
        bool completelyHidden = true;
        foreach (Word word in _words)
        {
            bool hid = word.IsWordHidden();
            if (hid == false)
            {
                completelyHidden = false;
            }
        }
        return completelyHidden;
    }
    public void HideRandomWords(int count)
    {
    for (int i = 0; i < count; i++)
        {
            bool alreadyHidden = false;
            bool stop = false;
            do
            {
                stop = IsCompletelyHidden();
                int index = _rng.Next(0, _words.Count); 
                Word word = _words[index];
                alreadyHidden = word.IsWordHidden();
                if (alreadyHidden == false)
                {
                    word.Hide();
                    _hiddenWords.Add(word);
                }
            } while (alreadyHidden == true && stop == false);
        }
    }
    public void UndoHiddenWords(int count)
    {
        if (_hiddenWords.Count == 0)
        {
            Console.WriteLine("Can't undo any more words.\n");
        }
        else
        {
            for (int i = 0; i < count; i++)
            {
                int index = _hiddenWords.Count - 1;
                Word hiddenWord = _hiddenWords[index];
                _hiddenWords.RemoveAt(index);
                hiddenWord.UnHide();
            }
        }
    }
}
