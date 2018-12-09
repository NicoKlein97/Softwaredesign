using System;
using System.Collections.Generic;

namespace Aufgabe7
{
    class QuizElement
    {
        public string question;
        public string callToAction;

        public virtual void show(){
            Console.WriteLine(this.question);
            Console.WriteLine(this.callToAction);
        }

        public virtual void ShowOptions(){
            
        }

        public virtual bool CheckAnswer(string _answer){
            return true;
        }

        public virtual bool SetupByUserInput(){
            return true;
        }

    }
}