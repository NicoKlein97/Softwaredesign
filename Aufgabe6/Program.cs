using System;
using System.Collections.Generic;

namespace Aufgabe6
{
    class Program
    {
        public static List<Quizelement> listWithAllQuestionsAndAnswers = new List<Quizelement>();
        public static Player player = new Player();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to my little Quiz. Bevore we start, what is your name ?");
            player.playerName = Console.ReadLine();
            player.score = 0;
            game();
        }

        public static void game()
        {
            Quizelement quiz = CreationOfQuestionAndAnswers();
            Console.WriteLine("What do you want to do ?");
            Console.WriteLine(player.playerName + "'s Score is: " + player.score);
            Console.WriteLine("1. Answer Questions   2. Create Questions   3. Exit");
            string mode = Console.ReadLine();

            switch (mode)
            {
                case "1":
                    quiz.show();
                    Console.WriteLine("Welche Nummer ist richtig ?");
                    int userInput = Int32.Parse(Console.ReadLine());
                    quiz.IsAnswerCorrect(userInput, player);
                    game();
                    break;
                case "2":
                    CreateOwnQuestions();
                    game();
                    break;
                default:
                    Console.WriteLine("Alright. You finished with a score of " + player.score +  " points, I hope I'll see you again soon");
                    break;
            }

        }

        public static Quizelement CreationOfQuestionAndAnswers()
        {

            Quizelement quiz = new Quizelement();
            quiz.question = "Wer war der erste Bundeskanzler der BRD ?";
            quiz.answers = new Answer[4];
            quiz.answers[0] = new Answer { text = "Barack Obama", truth = false };
            quiz.answers[1] = new Answer { text = "Helmut Kohl", truth = false };
            quiz.answers[2] = new Answer { text = "Konrad Adenauer", truth = true };
            quiz.answers[3] = new Answer { text = "Angela Merkel", truth = false };

            Quizelement quiz2 = new Quizelement();
            quiz2.question = "Macht dieses Quiz Spaß ?";
            quiz2.answers = new Answer[2];
            quiz2.answers[0] = new Answer { text = "Ja", truth = true };
            quiz2.answers[1] = new Answer { text = "Nein", truth = false };

            Quizelement quiz3 = new Quizelement();
            quiz3.question = "In Welchem Spiel spielt man die Hauptheldin 2B ?";
            quiz3.answers = new Answer[6];
            quiz3.answers[0] = new Answer { text = "Yakuza Kiwami", truth = false };
            quiz3.answers[1] = new Answer { text = "DragonQuest 11", truth = false };
            quiz3.answers[2] = new Answer { text = "Final fantasy 15", truth = false };
            quiz3.answers[3] = new Answer { text = "Nier: Automata", truth = true };
            quiz3.answers[4] = new Answer { text = "Persona 5", truth = false };
            quiz3.answers[5] = new Answer { text = "Yakuza 6", truth = false };

            listWithAllQuestionsAndAnswers.Add(quiz);
            listWithAllQuestionsAndAnswers.Add(quiz2);
            listWithAllQuestionsAndAnswers.Add(quiz3);

            Quizelement questionToDisplay = GetRandomQuestion(listWithAllQuestionsAndAnswers);

            return questionToDisplay;

        }

        public static Quizelement GetRandomQuestion(List<Quizelement> _listWithAllQuestionsAndAnswers)
        {

            Random rnd = new Random();
            int randomNumber = rnd.Next(_listWithAllQuestionsAndAnswers.Count);
            Quizelement randomQuestion = _listWithAllQuestionsAndAnswers[randomNumber];

            return randomQuestion;
        }

        public static void CreateOwnQuestions()
        {
            Quizelement newQuiz = new Quizelement();

            Console.WriteLine("Please write down your question");
            string newQuestion = Console.ReadLine();
             newQuiz.question = newQuestion;

            Console.WriteLine("How many answers would you like to add ?");
            int amountOfAnswers = Int32.Parse(Console.ReadLine());
            newQuiz.answers = new Answer[amountOfAnswers];

            for (int i = 0; i < amountOfAnswers; i++)
            {
                Console.WriteLine("Please insert an answer");
                string userAnswer = Console.ReadLine();
                Console.WriteLine("Is this Answer correct ? Please insert Yes or No");
                string userAnswerTruth = Console.ReadLine();
                bool finalTruth;
                if (userAnswerTruth == "yes")
                {
                    finalTruth = true;
                }
                else
                {
                    finalTruth = false;
                }
                newQuiz.answers[i] = new Answer { text = userAnswer, truth = finalTruth };
            }
            listWithAllQuestionsAndAnswers.Add(newQuiz);
        }
    }
}
