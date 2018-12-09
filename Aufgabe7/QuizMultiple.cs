using System;
using System.Collections.Generic;

namespace Aufgabe7
{
    class QuizMultiple: QuizSingle
    {
        public void ShowOptions(){
            
        }

        public override bool CheckAnswer(string _answer){
            bool correct = false;
            string[] allPlayerAnswers = _answer.Split(",");
            for(int i = 0; i < this.options.Length; i++){
                QuizOption option = this.options[i];
                for(int j = 0; j < allPlayerAnswers.Length; j++){
                    if(allPlayerAnswers[j] == option.text && option.correct == true){
                        correct = true;
                        continue;
                    }else if(allPlayerAnswers[j] == option.text && option.correct == false){
                        correct = false;
                        return correct;
                    }
                }
            }
            return correct;
        }

        public bool SetupByUserInput(){
            base.SetupByUserInput();
            return true;
        }
    }
}