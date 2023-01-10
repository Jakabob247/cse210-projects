using System;

class Program
{
    static void Main(string[] args)
    {
        // Initialize variables
        bool repeat = false; // Determines whether the player will play again.
        string answer = "";
        int guess = -5;
        int guessNum = 0;
        
        do
        {
            // Pick random number
            int randNum = PickRandomNumber();
            // Error checking, making sure the user enters a number instead of something else.
            try
            {
                // Repeat the guessing sequence until the user gets it correct.
                while(guess != randNum)
                {
                    Console.Write("Make a guess : ");
                    answer = Console.ReadLine();
                    guess = int.Parse(answer);
                    guessNum++;
                    
                    if(guess > randNum)
                        Console.WriteLine("\nToo high! Guess lower.");
                    if(guess < randNum)
                        Console.WriteLine("\nToo low! Guess higher.");
                }
                // Once broken out of, congratulate the player & ask to play again.
                Console.WriteLine($"\nCorrect! You got it in: {guessNum} guess(es)!");
                Console.Write("Would you like to play again? (y/n) : ");
                answer = Console.ReadLine();
                if (answer[0] == "y"[0])
                    repeat = true;
                else
                    repeat = false;
            }
            catch (FormatException e)
            {
                Console.WriteLine("Incorrect format, please enter a number.\nRestarting...\n\n");
                repeat = true;
            }
        } while (repeat);
    }

    private static int PickRandomNumber()
    {
        Random numberGen = new Random();
        return numberGen.Next(0, 100);
    }
}