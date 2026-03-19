using System;
using System.Linq;
class Program
{
    static void Main(string[] args)
    {
        string s = "CXC";
        string[] symbols = s.Select(c => c.ToString()).ToArray();
        int total = 0;
        for (int i = 0; i < symbols.Count(); i++)
        {
            string symbol = symbols[i];
            if (symbol == "I")
            {
                if (i < symbols.Count() - 1)
                {
                    if (symbols[i+1] == "V" || symbols[i+1] == "X")
                        total -= 1;
                    else 
                        total +=1;
                }
                
                else
                    total += 1;
            }
            else if (symbol == "V")
                total += 5;
            else if (symbol == "X")
            {
                if (i < symbols.Count() - 1)
                {
                    if (symbols[i+1] == "L" || symbols[i+1] == "C")
                        total -= 10;
                    else 
                        total +=10;
                }
                else
                    total += 10;
            }
            else if (symbol == "L")
                total += 50;
            else if (symbol == "C")
            {
                if (i < symbols.Count() - 1)
                {
                    if (symbols[i+1] == "D" || symbols[i+1] == "M")
                        total -= 100;
                    else 
                        total +=100;
                }
                else
                    total += 100;
            }
            else if (symbol == "D")
                total += 500;
            else if (symbol == "M")
                total += 1000;
            
        }
        Console.WriteLine(total);
    }
}
      