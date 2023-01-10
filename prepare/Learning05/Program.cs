using System;

class Program
{
    static string userName;
    private static int favoriteNumber;
    
    static void Main(string[] args)
    {
        DisplayWelcome();
        PromptUserName();
        PromptUserNumber();
        DisplayResult(favoriteNumber, userName);
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    static void PromptUserName()
    {
        Console.Write("Enter your name: ");
        userName = Console.ReadLine();
    }

    static void PromptUserNumber()
    {
        try
        {
            Console.Write("Enter your favorite number: ");
            favoriteNumber = int.Parse(Console.ReadLine());
        }
        catch (FormatException e)
        {
            Console.WriteLine("Please enter a whole number.");
            PromptUserNumber();
        }
    }

    static int SquareNumber(int number)
    {
        return number * number;
    }

    static void DisplayResult(int squareNumber, string name)
    {
        Console.WriteLine($"{userName}, the square of your number is {SquareNumber(favoriteNumber)}.");
    }
}