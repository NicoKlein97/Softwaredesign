using System;
using System.Collections.Generic;

namespace Aufgabe7
{
    class Program
    {
        public static int points = 0;
        public static int attempts = 0;
        public static List<QuizElement> quizElements = new List<QuizElement>();
        static void Main(string[] args)
        {
            LoadQuizElement();
            bool continueGame = true;

            while (continueGame == true)
            {
                Console.WriteLine("You have " + Program.points + " points and needed " + Program.attempts + " attempts");
                string userAction = GetUserAction();

                switch (userAction)
                {
                    case "play":
                        bool solved = Program.PlayQuizElement();
                        Console.WriteLine(solved);
                        HandlePointsAndAttempts(solved);
                        break;
                    case "create":
                        CreateQuizElement();
                        break;
                    case "quit":
                        continueGame = false;
                        break;
                }
            }
        }

        public static void LoadQuizElement()
        {
            QuizSingle quiz = new QuizSingle();
            quiz.question = "Wie heißt der Hauptcharacter aus God Of War ?";
            quiz.callToAction = "Wähle eine der Antworten aus";
            quiz.options = new QuizOption[4];
            quiz.options[0] = new QuizOption { text = "Dante", correct = false };
            quiz.options[1] = new QuizOption { text = "Zeus", correct = false };
            quiz.options[2] = new QuizOption { text = "Kratos", correct = true };
            quiz.options[3] = new QuizOption { text = "Ares", correct = false };

            QuizMultiple quiz2 = new QuizMultiple();
            quiz2.question = "Welche Charaktere sind Teil des Zelda Universums ?";
            quiz2.callToAction = "Wähle ALLE richtigen Antworten aus";
            quiz2.options = new QuizOption[6];
            quiz2.options[0] = new QuizOption { text = "Link", correct = true };
            quiz2.options[1] = new QuizOption { text = "Epona", correct = true };
            quiz2.options[2] = new QuizOption { text = "Kratos", correct = false };
            quiz2.options[3] = new QuizOption { text = "König Hyrule", correct = true };
            quiz2.options[4] = new QuizOption { text = "Joker", correct = false };
            quiz2.options[5] = new QuizOption { text = "Aloy", correct = false };

            QuizFree quiz3 = new QuizFree();
            quiz3.question = "Was hat den Award 'Spiel des Jahres' bei den The Videogames Awards 2018 gewonnen ?";
            quiz3.correctAnswer = "god of war";

            QuizGuess quiz4 = new QuizGuess();
            quiz4.question = "Wie viele Millionen Einwohner hat Deutschland ?";
            quiz4.callToAction = "Gib Zahl ein";
            quiz4.correctAnswer = 82;
            quiz4.tolerance = 2;

            QuizBinary quiz5 = new QuizBinary();
            quiz5.question = " 5 + 5 = 13";
            quiz5.callToAction = "Ist die Antwort richtig ?";
            quiz5.correctAnswer = false;

            quizElements.Add(quiz);
            quizElements.Add(quiz2);
            quizElements.Add(quiz3);
            quizElements.Add(quiz4);
            quizElements.Add(quiz5);
        }

        public static bool PlayQuizElement()
        {
            Random rnd = new Random();
            int r = rnd.Next(quizElements.Count);
            QuizElement quiz = quizElements[r];

            quiz.show();
            quiz.ShowOptions();
            string answer = Console.ReadLine();
            return quiz.CheckAnswer(answer);
        }

        public static string GetUserAction()
        {
            Console.WriteLine("Was möchtest du tun ? Willst du Create, Play oder Quit ?");
            string action = Console.ReadLine();

            if (action == "Create")
            {
                Console.WriteLine("Welchen Quiztyp möchtest du spielen ?");
                action = Console.ReadLine();
            }
            return action;
        }

        public static void HandlePointsAndAttempts(bool _wasAnswerCorrect)
        {
            if (_wasAnswerCorrect == true)
            {
                Program.points ++;
            }
            else
            {
                Program.points --;
                Program.attempts ++;
            }
        }

        public static void CreateQuizElement(){
            Console.WriteLine("Welchen Typ willst du erstellen ? single, multiple, guess, free oder binary ?");
            string type = Console.ReadLine();

            switch (type)
                {
                    case "single":
                        QuizSingle quizUserSingle = new QuizSingle();
                        quizUserSingle.SetupByUserInput();
                        quizElements.Add(quizUserSingle);
                        break;
                    case "multiple":
                        QuizMultiple quizUserMultiple = new QuizMultiple();
                        quizUserMultiple.SetupByUserInput();
                        quizElements.Add(quizUserMultiple);
                        break;
                    case "guess":
                        QuizGuess quizUserGuess = new QuizGuess();
                        quizUserGuess.SetupByUserInput();
                        quizElements.Add(quizUserGuess);
                        break;
                    case "binary":
                        QuizBinary quizUserBinary = new QuizBinary();
                        quizUserBinary.SetupByUserInput();
                        quizElements.Add(quizUserBinary);
                        break;
                    case "free":
                        QuizFree quizUserFree = new QuizFree();
                        quizUserFree.SetupByUserInput();
                        quizElements.Add(quizUserFree);
                        break;        
                }
        }
    }
}
