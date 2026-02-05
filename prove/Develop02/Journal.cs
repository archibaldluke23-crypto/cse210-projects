public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }
    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
      
    }
    public void SaveToFile(string fileName, string streak)
    {
        int i = 1;
        bool firstLine = true;
        foreach (Entry entry in _entries)
        {
            // Check if its the last entry to be saved to the file then assign the streak to that entry
            if (i == _entries.Count())
            {
                entry._streak = streak;
            }

            string toFileEntry = entry.ToFileLine("|");

            if (firstLine == true)
            {
                // override the file and add the entry
                File.WriteAllText(fileName, $"{toFileEntry}\n"); // Got help from chatGPT to learn the syntax for writing to files
                firstLine = false;                               // specificly "File.WriteAllText(fileName, line)"
                                                                // and "File.AppendAllText(fileName, line)"
                i += 1;
            }
            else
            {
                // Add the entry to the file
                File.AppendAllText(fileName, $"{toFileEntry}\n");
                i += 1;
            }
            
        }
    }
    public void LoadFromFile(string fileName) // Got help from chatGPT to learn the syntax for reading from files
                                            // specificly "File.ReadLines(fileName)"
    {
        _entries.Clear();
        foreach (string line in File.ReadLines(fileName)) // go through each line of the file
        {
            Entry fromFileEntry = new Entry();
            Entry transfromedEntry = fromFileEntry.FromFileLine(line, "|"); // converts the line into an entry

            _entries.Add(transfromedEntry); // add it back to the list
        }
    }
}