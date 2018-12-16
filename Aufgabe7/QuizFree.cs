using System;

namespace Aufgabe7
{
    class QuizFree:QuizElement
    {
       public string correctAnswer;
       public string type = "free"; 

       public override bool CheckAnswer(string _answer){
           Console.WriteLine("Richtige Antwort: " + correctAnswer);
           Console.WriteLine("gegebene Antwort: " + _answer);
           if(_answer == correctAnswer){
               return true;
           }else{
               return false;
           }
       }

       public override bool SetupByUserInput(){
           Console.WriteLine("Please insert the question ypu want to ask");
            string userQuestion = Console.ReadLine();
            this.question = userQuestion;

            Console.WriteLine("Write down the correct answer");
            string userAnswer = Console.ReadLine();
            this.correctAnswer = userAnswer;

            return true;
       }
    }

    
}