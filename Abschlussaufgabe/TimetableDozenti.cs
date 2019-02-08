using System;
using System.Collections.Generic;

namespace Abschlussaufgabe
{
    class TimetableDozenti : Timetable
    {
        public Dictionary<string, Dozenti> timesMonday = new Dictionary<string, Dozenti>();
        public Dictionary<string, Dozenti> timesThuesday = new Dictionary<string, Dozenti>();
        public Dictionary<string, Dozenti> timesWednesday = new Dictionary<string, Dozenti>();
        public Dictionary<string, Dozenti> timesThursday = new Dictionary<string, Dozenti>();
        public Dictionary<string, Dozenti> timesFriday = new Dictionary<string, Dozenti>();
        public Dictionary<string, Dictionary<string, Dozenti>> days = new Dictionary<string, Dictionary<string, Dozenti>>();

        public TimetableDozenti(List<Dozenti> _iList)
        {

            fillTimesDictionaries();

            days.Add("Monday", timesMonday);
            days.Add("Thuesday", timesThuesday);
            days.Add("Wednesday", timesWednesday);
            days.Add("Thursday", timesThursday);
            days.Add("Friday", timesFriday);

            insertObjectsInRandomTime(_iList);
        }

        public override void fillTimesDictionaries()
        {
            Dictionary<string, Dozenti>[] dayNames = { timesMonday, timesThuesday, timesWednesday, timesThursday, timesFriday };

            for (int i = 0; i < 5; i++)
            {
                for (int j = 1; j < 7; j++)
                {
                    dayNames[i].Add(j + ".Block", null);
                }
            }
        }

        public void insertObjectsInRandomTime(List<Dozenti> _iList)
        {
            while (_iList.Count != 0)
            {

                Random rand = new Random();
                List<string> keyList = new List<string>(days.Keys);
                string randomDay = keyList[rand.Next(keyList.Count)];

                Random random = new Random();
                List<string> keyListInner = new List<string>(days[randomDay].Keys);
                string randomTime = keyListInner[random.Next(keyListInner.Count)];

                if (days[randomDay][randomTime] != null)
                {
                    insertObjectsInRandomTime(_iList);
                }

                if (_iList.Count != 0)
                {
                    days[randomDay][randomTime] = _iList[0];
                    _iList.Remove(_iList[0]);
                }
            }
        }

        public void print(){
            for(int i = 1; i < 7; i++){
                if(this.timesMonday[i + ".Block"] == null){
                    
                }else{
                    Console.WriteLine(this.timesMonday[i + ".Block"].name + "  ---" + i);
                }
            }
            for(int i = 1; i < 7; i++){
                if(this.timesThuesday[i + ".Block"] == null){
                    
                }else{
                    Console.WriteLine(this.timesThuesday[i + ".Block"].name + "  ---" + i);
                }
            }
            for(int i = 1; i < 7; i++){
                if(this.timesWednesday[i + ".Block"] == null){
                    
                }else{
                    Console.WriteLine(this.timesWednesday[i + ".Block"].name + "  ---" + i);
                }
            }
            for(int i = 1; i < 7; i++){
                if(this.timesThursday[i + ".Block"] == null){
                    
                }else{
                    Console.WriteLine(this.timesThursday[i + ".Block"].name + "  ---" + i);
                }
            }
            for(int i = 1; i < 7; i++){
                if(this.timesFriday[i + ".Block"] == null){
                    
                }else{
                    Console.WriteLine(this.timesFriday[i + ".Block"].name + "  ---" + i);
                }
            }
        }
    }
}
