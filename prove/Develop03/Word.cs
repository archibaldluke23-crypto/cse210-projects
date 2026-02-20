public class Word
{
    private string _text;
    private bool _isHidden;
    private string _originalText;
    private bool _endLineWord;
    public Word(string text)
    {
        _text = text;
        _originalText = text;
        _isHidden = false;
        if (text.Contains("\n"))
        {
            _endLineWord = true;
        }
    }
    public void Hide()
    {
        string dashedWord = "";
        int wordLength = _text.Length;
        for (int i = 1; i <= wordLength; i++)
        {
            dashedWord += "_";
        }
        if (_endLineWord)
            dashedWord += "\n";
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
    public void UnHide()
    {
        _text = _originalText;
        _isHidden = false;
    }
}