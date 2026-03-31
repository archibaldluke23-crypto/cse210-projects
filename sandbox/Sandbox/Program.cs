using System;
using System.Linq;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(Occurences());

        int Occurences()
        {
            string haystack = "sadbutsd";
            string needle = "sad";
            char[] splitHaystack = haystack.ToCharArray();
            char[] splitNeedle = needle.ToCharArray();
            int needleWordLength = splitNeedle.Count();
            int haystackWordLength = splitHaystack.Count();
            int matchingInARow = 0;
            bool match = false;
            int returnValue = -1;
        
            for (int i = 0; i < haystackWordLength; i++)
            {
                if (match == false)
                {
                    if (splitHaystack[i] == splitNeedle[matchingInARow])
                    {
                        matchingInARow += 1;
                        if (matchingInARow == needleWordLength)
                        {
                            match = true;
                            returnValue = i - needleWordLength + 1;
                        }
                    }
                    else
                    {
                        matchingInARow = 0;
                    }
                }
            }
            return returnValue;
        }
    }
}
/*public class Solution {
    public int StrStr(string haystack, string needle) 
    {
        char[] splitHaystack = haystack.ToCharArray();
        char[] splitNeedle = needle.ToCharArray();
        int needleWordLength = splitNeedle.Count();
        int haystackWordLength = splitHaystack.Count();
        int matchingInARow = 0;
        bool match = false;
        int returnValue = -1;
       
        for (int i = 0; i < haystackWordLength; i++)
        {
            if (match == false)
            {
                if (splitHaystack[i] == splitNeedle[matchingInARow])
                {
                    matchingInARow += 1;
                    if (matchingInARow == needleWordLength)
                    {
                        match = true;
                        returnValue = i - needleWordLength + 1;
                    }
                }
                else
                {
                    matchingInARow = 0;
                }
            }
        }
        return returnValue;
    }
}*/