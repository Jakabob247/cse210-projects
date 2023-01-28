namespace Develop02;

/*
 * The purpose of this class is to parse data from Entry class and write it to a new text file.
 */

public class EntryWriter
{
    public EntryWriter(Entry dataEntry, string filename)
    {
        string path = filename;

        if (File.Exists(path))
        {
            using (StreamWriter newFile = File.AppendText(path))
            {
                newFile.WriteLine();
                newFile.WriteLine("--------------------------------");
                newFile.WriteLine(dataEntry.Date);
                newFile.WriteLine(dataEntry.Prompt);
                newFile.WriteLine(dataEntry.Body);
            }
        }
        else
        {
            using (StreamWriter newFile = new StreamWriter(filename))
            {
                newFile.WriteLine("--------------------------------");
                newFile.WriteLine(dataEntry.Date);
                newFile.WriteLine(dataEntry.Prompt);
                newFile.WriteLine(dataEntry.Body);
            }
        }
        
    }
}