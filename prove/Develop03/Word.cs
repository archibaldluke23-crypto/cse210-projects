public class Word
{
    private string _text;
    private bool _isHidden;
    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }
    public void Hide()
    {
        string dashedWord = "";
        int wordLength = _text.Length;
        for (int i = 1; i <= wordLength; i++)
        {
            dashedWord += "_";
        }
        _text = dashedWord;
        _isHidden = true;
    }
    public bool IsWordHidden()
    {
       return _isHidden;
    }
    public string GetDisplayText()
    {
        return _text;
    }
}