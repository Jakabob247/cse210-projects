using System;

class Prep01
{
    static void Main(string[] args)
    {
        string firstName;
        string lastName;

        Console.WriteLine("Please enter your first and last name (one space, no commas)");
        string[] fullName = Console.ReadLine().Split(" ");

        firstName = fullName[0];
        lastName = fullName[1];

        Console.WriteLine($"\nYour name is {lastName}, {firstName} {lastName}");
    }
}
