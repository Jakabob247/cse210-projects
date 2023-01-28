namespace Develop02;

/*
 * The purpose of this class is to parse text data and load it into a new Entry class.
 */

public class EntryReader
{
    private string _date;
    private string _prompt;
    private string _body;
    
    public EntryReader(string fileLoc, int entryNum)
    {

        string[] lines = System.IO.File.ReadAllLines(fileLoc);
        
        // Get the whole journal into one string
        string wholeThing = ""; 
        foreach (string line in lines)
        {
            wholeThing += line + "\n";
        }

        // Split the entries apart
        string[] entries = wholeThing.Split("----------------\n"); 
        string[] entryLines = entries[entryNum].Split(new string[] {"\r\n", "\r", "\n"}, StringSplitOptions.None);
        
        // Get the entry data
        string date = entryLines[0];
        string prompt = entryLines[1];

        List<string> bodyList = new List<string>();
        for (int i = 2; i < entryLines.Length; i++)
        {
            bodyList.Add(entryLines[i]);
        }

        string body = "";
        foreach (string line in bodyList)
        {
            body += line + "\n";
        }

        // Set the entry data to local variables
        _date = date;
        _prompt = prompt;
        _body = body;
    }

    public static string[] GetAllEntries(string fileLoc)
    {
        
        string[] lines = System.IO.File.ReadAllLines(fileLoc);
        
        // Get the whole journal into one string
        string wholeThing = ""; 
        foreach (string line in lines)
        {
            wholeThing += line + "\n";
        }

        // Split the entries apart
        string[] entries = wholeThing.Split("----------------\n");
        
        return entries;
    }

    public void PrintEntry()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"Body:\n{_body}");
    }
}