using System;

class Program
{
    static void Main(string[] args) // Add a "back" option so they can review the scripture before the last words were hidden.
    {
        /*Alma 7:11 And he shall go forth, suffering pains and afflictions and temptations of every kind; and this that the word might be fulfilled which saith he will take upon him the pains and the sicknesses of his people.*/
        /*John 3:16 For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.*/
        string end = "\n";
        bool hidden = false;
        Reference reference = new Reference("Alma", 7, 11);
        Scripture scripture = new Scripture(reference, "And he shall go forth, suffering pains and afflictions and temptations of every kind; and this that the word might be fulfilled which saith he will take upon him the pains and the sicknesses of his people.");
        while (end != "quit" && hidden == false)
        {
            hidden = scripture.IsCompletelyHidden();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress enter to continue or type 'quit' to finish: ");
            end = Console.ReadLine();

            scripture.HideRandomWords(3);
        }
    }
}