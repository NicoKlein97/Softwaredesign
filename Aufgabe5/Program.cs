using System;
using System.Collections.Generic;
using System.Collections;

namespace Aufgabe5
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dieser Code wurde nach dem Aktivitätsdiagramm von Hatice-Nur Tüysüz geschrieben.

            Console.WriteLine("Bitte einen Satz eingeben");
            var text = Console.ReadLine();

            string letters = reverseLetters(text);
            string words = reverseWords(text);
            string sentence = reverseSentence(text);

           Console.WriteLine("letters = " + letters);
           Console.WriteLine("words = " + words);
           Console.WriteLine("sentence = " + sentence);
        }        

        public static string reverseLetters(string _text){

            char[] letters = _text.ToCharArray();
            Array.Reverse(letters);
            _text = String.Join("", letters);

            return _text;
        }

        public static string reverseWords(string _text){

            string[] words = _text.Split(" ");
            Array.Reverse(words);
            _text = String.Join(" ", words);

            return _text;
        }

        public static string reverseSentence(string _text){

            string[] wordText = _text.Split(" ");
            string turnWord = "";
            string[] finalText = new string[wordText.Length];

            for(int i = 0; i< wordText.Length; i++){ // hier musste -1 entfernt werden
                turnWord += wordText[i];
                string wordIsTurned = "";
                Console.WriteLine("i " + turnWord);

                for (int k = turnWord.Length - 1; k >= 0; k--)
                {
                    wordIsTurned += turnWord[k]; // Inhalt der inneren for-Scheife war aus dem Diagramm nicht ersichtlich
                }

                turnWord = "";
                finalText[i] = wordIsTurned;
            }

            _text = String.Join(" ", finalText);
            return _text;
        }
    }
}
