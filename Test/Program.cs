using System;
using System.Collections.Generic;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bitte geben Sie den Satz ein, welchen Sie umgedreht haben wolen");
            String satz = Console.ReadLine();

            Console.WriteLine("Reverse Letters -------> " + reverseLetters(satz));

            Console.WriteLine("Reverse Words -------> " + reverseWords(satz));

            Console.WriteLine("ReverseSentences -------> " + reverseSentence(satz));

        }

        public static string reverseLetters(String _satz)
        {
            List<char> characters = new List<char>();

            for (int i = _satz.Length - 1; i > -1; i--)
            {
                characters.Add(_satz[i]);
            }
            string reversedString = string.Join("", characters.ToArray());

            return reversedString;
        }

        public static string reverseWords(String _sentence)
        {

            string[] words = _sentence.Split(" ");
            List<string> listOfWords = new List<string>();

            foreach (var word in words)
            {
                listOfWords.Add(word);
            }

            listOfWords.Reverse();
            string reversedWords = string.Join(" ", listOfWords.ToArray());

            return reversedWords;
        }

        public static string reverseSentence(String _sentence)
        {

            string wordsReversed = reverseWords(_sentence);
            string sentenceReversed = reverseLetters(wordsReversed);

            return sentenceReversed;

        }
    }
}
