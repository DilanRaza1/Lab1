using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Application
{
    public static void Main(string[] args)
    {
        // Be användaren att ange en sträng
        Console.WriteLine("Enter a string:");
        // Läs in strängen från användaren
        string userInput = Console.ReadLine();
        // Anropa metoden MarkDuplicates för att markera dubbletter
        MarkDuplicates(userInput);
    }

    static public void MarkDuplicates(string input)
    {
        // Skapa en HashSet för att lagra unika siffror
        HashSet<char> digitSet = new HashSet<char>();

        // Loopar genom varje tecken i inmatningssträngen
        for (int i = 0; i < input.Length; i++)
        {
            // Kontrollera om det aktuella tecknet är en siffra
            if (Char.IsDigit(input[i]))
            {
                // Lägg till siffran i HashSet (detta kommer endast att hålla unika siffror)
                digitSet.Add(input[i]);
            }

            // Inre loop för att hitta dubbletter av det aktuella tecknet
            for (int k = i + 1; k < input.Length; k++)
            {
                // Kontrollera om det finns en dubblett av tecknet på position i
                if (input[i] == input[k])
                {
                    // Skapa ett segment av strängen som innehåller dubbletttecknen
                    string highlightSegment = input[i] + input.Substring(i + 1, k - i - 1) + input[k];

                    // Kontrollera om segmentet innehåller några bokstäver
                    if (Regex.IsMatch(highlightSegment, "[a-zA-Z]"))
                    {
                        // Om segmentet innehåller bokstäver, avbryt loopen
                        break;
                    }

                    // Skriv ut delen av strängen före dubbletten
                    Console.Write(input.Substring(0, i));
                    // Ändra textfärgen till gul för markering
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    // Skriv ut det första dubbletttecknet
                    Console.Write(input[i]);
                    // Skriv ut delen av strängen mellan dubbletterna
                    Console.Write(input.Substring(i + 1, k - i - 1));
                    // Skriv ut det andra dubbletttecknet
                    Console.Write(input[k]);
                    // Återställ textfärgen till standard
                    Console.ResetColor();
                    // Skriv ut delen av strängen efter dubbletterna
                    Console.WriteLine(input.Substring(k + 1));


                    break;
                }
            }
        }
    }
}