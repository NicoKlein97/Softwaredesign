using System;
using System.Collections.Generic;

namespace Aufgabe7
{
    class QuizSingle : QuizElement
    {
        public QuizOption[] options;
        public string type = "single";

        public override void ShowOptions()
        {
            for (int i = 0; i < this.options.Length; i++)
            {
                int displayNumber = i + 1;
                Console.WriteLine(displayNumber + ". " + options[i].text);
            }
        }

        public override bool CheckAnswer(string _answer)
        {
            for (int i = 0; i < options.Length; i++)
            {
                if (_answer == options[i].text && options[i].correct == true)
                {
                    return true;
                }
                else if (_answer == options[i].text && options[i].correct == false)
                {
                    return false;
                }
            }
            return false;
        }

        public override bool SetupByUserInput()
        {
            List<QuizOption> quizOptions = new List<QuizOption>();

            Console.WriteLine("Please write down your question");
            string question = Console.ReadLine();

            Console.WriteLine("How many options you you wanna have ?");
            string numberString = Console.ReadLine();
            int numberInt = Int32.Parse(numberString);
            bool correctBool = false;

            for (int i = 1; i < numberInt + 1; i++)
            {
                Console.WriteLine("Please insert Option nr. " + i);
                string text = Console.ReadLine();

                Console.WriteLine("Is this option correct ? Write true or false");
                string correctString = Console.ReadLine();
                if (correctString == "true")
                {
                    correctBool = true;
                }
                else if (correctString == "false")
                {
                    correctBool = false;
                }

                QuizOption option = new QuizOption();
                option.text = text;
                option.correct = correctBool;
                quizOptions.Add(option);
            }

            this.question = question;
            QuizOption[] array = quizOptions.ToArray();
            this.options = array;
            return true;
            return true;
        }
    }
}