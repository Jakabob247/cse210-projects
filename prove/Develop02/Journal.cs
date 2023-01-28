namespace Develop02;

/*
 * The purpose of this class is to run & handle information regarding the user's journal.
 */

public class Journal
{

    public Journal()
    {
        CreatePromptList();
    }
    
    private List<string> _prompts;
    private void CreatePromptList()
    {
        _prompts = new List<string>();
        
        _prompts.Add("Who was the most interesting person I interacted with today?");
        _prompts.Add("What was the best part of my day?");
        _prompts.Add("How did I see the hand of the Lord in my life today?");
        _prompts.Add("What was the strongest emotion I felt today?");
        _prompts.Add("If I had one thing I could do over today, what would it be?");
        _prompts.Add("What did I do that I was most proud of today?");
        _prompts.Add("What can I do better tomorrow?");
    }

    public void PromptUserMenu()
    {
        string menu = "Please select from the following list:\n" +
                      "1. Read from journal entry\n" +
                      "2. Write new journal entry\n" +
                      "3. Exit App\n" +
                      "\n" +
                      "Selection : ";
        
        Console.Write(menu);

        string answer = Console.ReadLine();

        if (answer == "1")
        {
            // Simple error handling, to catch if the user accidentally, or intentionally, tries to enter a file that
            //   doesn't exist.
            try
            {
                PromptEntryDates();
                PromptUserMenu();
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("\nCould not find file.\n");
                PromptUserMenu();
            }
            
        }
        
        if (answer == "2")
        {
            PromptNewEntry();
            PromptUserMenu();
        }
    }

    private void PromptEntryDates()
    {
        Console.WriteLine("Journal file : ");
        string path = Console.ReadLine();
        
        int index = 0;
        foreach (string entry in EntryReader.GetAllEntries(path))
        {
            if(index != 0)
            {
                string[] entryLines = entry.Split(new string[] {"\r\n", "\r", "\n"}, StringSplitOptions.None);
                string date = entryLines[0];
                Console.WriteLine($"{index}. {date}");
            }
            index++;
        }
        
        Console.Write("Selection : ");
        string answer = Console.ReadLine();

        if (answer != "0")
        {
            int parsedAnswer = int.Parse(answer);
            EntryReader readEntry = new EntryReader(path, parsedAnswer);
            Console.WriteLine();
            readEntry.PrintEntry();
        }
    }

    private void PromptNewEntry()
    {
        Entry newEntry = new Entry();
        DateTime theCurrentTime = DateTime.Now;
        string dateText = theCurrentTime.ToShortDateString();
        string randPrompt = _prompts[new Random().Next(_prompts.Count)];
        string body = "";
        Console.WriteLine(randPrompt);
        Console.WriteLine("Enter your journal text here : ");
        body = Console.ReadLine();

        newEntry.Date = dateText;
        newEntry.Prompt = randPrompt;
        newEntry.Body = body;
        
        Console.WriteLine("Which file is this going to? : ");
        string file = Console.ReadLine();

        EntryWriter writer = new EntryWriter(newEntry, file);
    }
}