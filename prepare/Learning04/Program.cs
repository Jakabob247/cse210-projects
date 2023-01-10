using System;

class Program
{
    static void Main(string[] args)
    {
        AskNumberList();
    }

    private static void AskNumberList()
    {
        // Error checking, making sure the user inputs the correct format.
        try
        {
            // Initialize variables
            List<int> numbers = new List<int>();
            int input;
            bool repeat = true;
        
            Console.Write("Enter a list of numbers, enter 0 when finished.\n");
            // Prompt user to enter the numbers until they enter '0'
            while(repeat)
            {
                Console.Write("Number : ");
                input = int.Parse(Console.ReadLine());

                if (input == 0)
                    repeat = false;
                else
                    numbers.Add(input);
            }
            
            // Calculate desired information
            CalculateNumbers(numbers);
        }
        catch (FormatException e)
        {
            Console.WriteLine("\n---------------\nIncorrect Format, please enter a whole number.\nRestarting...\n---------------\n");
            AskNumberList();
        }
        
        
    }

    private static void CalculateNumbers(List<int> numberList)
    {
        // Initialize variables
        int sum = 0;
        double average = 0;
        int largest = 0;
        int smallestPositive = 9999999;

        // Loop through number list & calculate wanted info
        foreach (int number in numberList)
        {
            sum += number;
            average += number;

            if (largest == 0)
                largest = number;

            if (number > largest)
                largest = number;

            if (number > 0 && number < smallestPositive)
                smallestPositive = number;
        }
        
        // calculate the average
        average /= numberList.Count;

        // Sort the list
        List<int> sortedList = numberList;
        sortedList.Sort();

        // Give user the information they desired.
        Console.WriteLine($"\nThe sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest is: {largest}");
        Console.WriteLine($"The smallest positive is: {smallestPositive}");
        Console.WriteLine("The sorted list:");

        // Print the sorted numbers list.
        foreach (var number in sortedList)
        {
            Console.WriteLine(number);
        }
    }
}