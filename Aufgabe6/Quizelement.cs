using System;

namespace Aufgabe6
{
    class Quizelement
    {
        public string question;
        public Answer[] answers;
        public void IsAnswerCorrect(int choice, Player _player){

            if(answers[choice - 1].truth == true){
                Console.WriteLine("Ihre Antwort ist korrekt");
                _player.calculateScore(true);
            }else{
                Console.WriteLine("Ihre Antwort ist falsch");
                _player.calculateScore(false);
            }

        }
       public void show(){
            Console.WriteLine(question);
            for(int i = 0; i < this.answers.Length; i++){
                int displayedNumberOfQuestion = i+1;
                Console.WriteLine(displayedNumberOfQuestion + ". " + this.answers[i].text);
            }
        }
    }

    
}
