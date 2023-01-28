using System;

namespace Develop02;

/*
 * Somewhat obvious, but this class is the program's entry point.
 *
 * For this journaling program, I have opted to simply use a .txt file format,
 *  because this way, someone could open it in notepad and understand & read through their
 *  journal via any text editor.
 * 
 * The entries are separated by a very specific set of dashes '--------------------------------',
 *  which is something the program can easily see and recognize, plus the user is highly unlikely
 *  to enter that specific set of dashes.
 */

class Program
{
    static void Main(string[] args)
    {
        Journal myJournal = new Journal();
        myJournal.PromptUserMenu();
    }
}