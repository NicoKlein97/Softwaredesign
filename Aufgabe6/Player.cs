using System;

namespace Aufgabe6
{
    class Player
    {
        public int score;
        public string playerName;

        public void calculateScore(bool _truth){
            if(_truth == true){
                score = score + 1;
            }else{
                score = score -1;
            }
        }
    }

    
}
