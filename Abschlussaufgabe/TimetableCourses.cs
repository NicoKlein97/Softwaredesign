using System;
using System.Collections.Generic;

namespace Abschlussaufgabe
{
    class TimetableCourses : Timetable
    {
        public Dictionary<string, Courses> timesMonday = new Dictionary<string, Courses>();
        public Dictionary<string, Courses> timesThuesday = new Dictionary<string, Courses>();
        public Dictionary<string, Courses> timesWednesday = new Dictionary<string, Courses>();
        public Dictionary<string, Courses> timesThursday = new Dictionary<string, Courses>();
        public Dictionary<string, Courses> timesFriday = new Dictionary<string, Courses>();
        public Dictionary<string, Dictionary<string, Courses>> days = new Dictionary<string, Dictionary<string, Courses>>();

        public TimetableCourses(List<Courses> _listCourses, TimetableDozenti _timetableDozenti)
        {

            fillTimesDictionaries();

            days.Add("Monday", timesMonday);
            days.Add("Thuesday", timesThuesday);
            days.Add("Wednesday", timesWednesday);
            days.Add("Thursday", timesThursday);
            days.Add("Friday", timesFriday);

            insertObjectsInCoursesTimetable(_listCourses, _timetableDozenti);
        }

        public override void fillTimesDictionaries()
        {
            Dictionary<string, Courses>[] timesOfDays = { timesMonday, timesThuesday, timesWednesday, timesThursday, timesFriday };

            for (int i = 0; i < 5; i++)
            {
                for (int j = 1; j < 7; j++)
                {
                    timesOfDays[i].Add(j + ".Block", null);
                }
            }
        }
        public void insertObjectsInCoursesTimetable(List<Courses> _listCourses, TimetableDozenti _timetableDozenti)
        {
            Dictionary<string, Courses>[] timesOfDaysCourses = {this.timesMonday, this.timesThuesday, this.timesWednesday, this.timesThursday, this.timesFriday };
            Dictionary<string, Dozenti>[] timesOfDaysDozenti = { _timetableDozenti.timesMonday, _timetableDozenti.timesThuesday, _timetableDozenti.timesWednesday, _timetableDozenti.timesThursday, _timetableDozenti.timesFriday };
            
            for (int i = 0; i < timesOfDaysDozenti.Length; i++)
            {
                for (int j = 1; j < 7; j++)
                {
                    Dozenti dozent = timesOfDaysDozenti[i][j + ".Block"];
                    if (dozent != null)
                    {
                        for(int k = 0; k < _listCourses.Count; k++){
                            if(_listCourses[k].professor == dozent.name){
                                timesOfDaysCourses[i][j + ".Block"] = _listCourses[k];
                            }
                        }
                    }
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
