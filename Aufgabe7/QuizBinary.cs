using System;

namespace Aufgabe7
{
    class QuizBinary: QuizElement
    {
        public bool correctAnswer;
        public string type = "binary";
        public override bool CheckAnswer(string _answer){
            if(_answer == "yes" && correctAnswer ==true){
                return true;
            }else if(_answer == "no" && correctAnswer == false){
                return true;
            }else{
                return false;
            }
        }

        public bool SetupByUserInput(){
            Console.WriteLine("Please insert your statement");
            string userQuestion = Console.ReadLine();
            this.question = userQuestion;

            Console.WriteLine("Is this statement correct ? yes or no");
            string userAnswer = Console.ReadLine();
            if(userAnswer == "yes"){
                this.correctAnswer = true;
            }else if(userAnswer == "no"){
                this.correctAnswer = false;
            }
            return true;
        }
    }
}