using System;
using System.Collections.Generic;

namespace Aufgabe5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bitte geben Sie den Satz ein, welchen Sie umgedreht haben wolen");
            String satz = Console.ReadLine();

            Console.WriteLine(satz + " -------> " + umdrehen(satz));

        }

        public static string umdrehen(String _satz)
        {
            List<char> characters = new List<char>();

            for (int i = _satz.Length - 1; i > -1; i--)
            {
                characters.Add(_satz[i]);
            }
            string reversedString = string.Join("", characters.ToArray());
            return reversedString;
        }
    }
}
