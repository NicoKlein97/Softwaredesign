using System;

namespace Aufgabe7
{
    class QuizGuess: QuizElement
    {
        public int correctAnswer;
        public float tolerance;
        
        public override bool CheckAnswer(string _answer){
            int answerInInt = Int32.Parse(_answer);
            if(answerInInt >= correctAnswer - tolerance && answerInInt <= correctAnswer + tolerance){
                return true;
            }else{
                return false;
            }
        }

        public override bool SetupByUserInput(){
            Console.WriteLine("Please insert the question ypu want to ask");
            string userQuestion = Console.ReadLine();
            this.question = userQuestion;

            Console.WriteLine("Write down the correct Number");
            this.correctAnswer = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Write down the tolerance");
            this.tolerance = Int32.Parse(Console.ReadLine());

            return true;
        }
    }
}