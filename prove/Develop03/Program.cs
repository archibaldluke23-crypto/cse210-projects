using System;


// To exceed requirments in this assignment I made an undo feature that allows the user to type "back"
// which will restore the last 3 words hidden in the scripture. I also made it so the words don't get cut off in the terminal 
// when creating a new line.
class Program
{
    static void Main(string[] args) 
    {
        /*Alma 7:11 And he shall go forth, suffering pains and afflictions and temptations of every kind; and this that the word might be fulfilled which saith he will take upon him the pains and the sicknesses of his people.*/
        /*John 3:16 For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.*/
        string input = "";
        bool hidden = false;
        Reference reference = new Reference("Alma", 7, 11, 12);
        Scripture scripture = new Scripture(reference, "And he shall go forth, suffering pains and afflictions and temptations of every kind; and this that the word might be fulfilled which saith he will take upon him the pains and the sicknesses of his people. 12 And he will take upon him death, that he may loose the bands of death which bind his people; and he will take upon him their infirmities, that his bowels may be filled with mercy, according to the flesh, that he may know according to the flesh how to succor his people according to their infirmities.");
        while (input != "quit" && hidden == false)
        {
            hidden = scripture.IsCompletelyHidden();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress enter to continue, type 'quit' to finish, or type 'back' to unhide the last hidden words: ");
            input = Console.ReadLine();
            if (input == "back")
            {
                scripture.UndoHiddenWords(3);
            }
            else if (input == "")
                scripture.HideRandomWords(3);
            else if (input != "quit")
                Console.WriteLine("Invade input. Press enter, type 'quit', or type 'back'\n");
        }
    }
}