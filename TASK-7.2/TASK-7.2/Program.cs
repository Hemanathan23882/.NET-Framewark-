// See https://aka.ms/new-console-template for more information
using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string str = Console.ReadLine();

        // 1. Reverse the string
        char[] ch = str.ToCharArray();
        Array.Reverse(ch);
        string reversed = new string(ch);
        Console.WriteLine("Reversed String: " + reversed);

        // 2. Extract substring from 2nd position till end
        if (str.Length >= 2)
            Console.WriteLine("Substring from 2nd character: " + str.Substring(1));
        else
            Console.WriteLine("String too short for substring.");

        // 3. Replace any given character with '$'
        Console.Write("Enter a character to replace: ");
        char toReplace = Console.ReadKey().KeyChar;
        Console.WriteLine();

        string replacedString = str.Replace(toReplace, '$');
        Console.WriteLine("String after replacement: " + replacedString);

        // 4. Copy and modify
        string copyString = str;           // copy
        string modifiedCopy = copyString + "_modified";

        Console.WriteLine("Original String: " + str);
        Console.WriteLine("Modified Copy String: " + modifiedCopy);
    }
}
