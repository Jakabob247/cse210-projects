public class Prep02
{
    static void Main(string[] args)
    {
        // Initialize variables, defaulting values to avoid errors.
        string letterGrade = "F";
        string delimiter = "";
        string finalGrade = "";
        int percent = 0;

        // Ask user for their grade percentage
        Console.WriteLine("What is your grade percentage?");

        // Read & parse their answer to convert it into an integer value
        string answer = Console.ReadLine();
        percent = int.Parse(answer);

        // Determine their base grade value, then determine what the delimiter is.
        switch(percent)
        {
            case >= 90:
                letterGrade = "A";
                delimiter = DetermineDelimiter(percent);
                if(delimiter == "+")
                    delimiter = "";
                break;
            case >= 80:
                letterGrade = "B";
                delimiter = DetermineDelimiter(percent);
                break;
            case >= 70:
                letterGrade = "C";
                delimiter = DetermineDelimiter(percent);
                break;
            case >= 60:
                letterGrade = "D";
                delimiter = DetermineDelimiter(percent);
                break;
        }

        // Store the final grade value & display it to the user.
        finalGrade = $"{letterGrade}{delimiter}";

        if(percent >= 70)
            Console.WriteLine($"Congratulations! You passed with a grade of {finalGrade}!");
        else
            Console.WriteLine($"Sorry, you only got {finalGrade}. You did not pass the class.");
    }

    // Detemines the delimiter based on what percent value is passed in as a parameter. Used multiple times, so I put it into a method to make things easier.
    private static string DetermineDelimiter(int percentValue)
    {
        string digitized = percentValue.ToString();
        int delimit = int.Parse(digitized.Substring(1,1));

        if(delimit >= 7)
            return "+";

        if(delimit <= 3)
            return "-";

        return "";
    }
}