using System;
using System.Collections.Generic;

namespace Abschlussaufgabe
{
    class TimetableDozenti : Timetable
    {
        public Dictionary<string, List<Dozenti>> timesMonday = new Dictionary<string, List<Dozenti>>();
        public Dictionary<string, List<Dozenti>> timesThuesday = new Dictionary<string, List<Dozenti>>();
        public Dictionary<string, List<Dozenti>> timesWednesday = new Dictionary<string, List<Dozenti>>();
        public Dictionary<string, List<Dozenti>> timesThursday = new Dictionary<string, List<Dozenti>>();
        public Dictionary<string, List<Dozenti>> timesFriday = new Dictionary<string, List<Dozenti>>();
        public Dictionary<string, Dictionary<string, List<Dozenti>>> days = new Dictionary<string, Dictionary<string, List<Dozenti>>>();

        public TimetableDozenti(List<Dozenti> _iList, TimetableWPVs _tableWPVs)
        {

            fillTimesDictionaries();

            days.Add("Monday", timesMonday);
            days.Add("Thuesday", timesThuesday);
            days.Add("Wednesday", timesWednesday);
            days.Add("Thursday", timesThursday);
            days.Add("Friday", timesFriday);

            //insertWPVsInTable(_tableWPVs, _iList);
            _iList = duplicateProfessorsAcordingToCourses(_iList);
            insertDozentiInRandomTime(_iList, _tableWPVs);
        }

        public override void fillTimesDictionaries()
        {
            Dictionary<string, List<Dozenti>>[] dayNames = { timesMonday, timesThuesday, timesWednesday, timesThursday, timesFriday };

            for (int i = 0; i < 5; i++)
            {
                for (int j = 1; j < 7; j++)
                {
                    List<Dozenti> dozentiList = new List<Dozenti>();
                    dayNames[i].Add(j + ".Block", dozentiList);
                }
            }
        }
        /* 
                private void insertWPVsInTable(TimetableWPVs _tableWPVs, List<Dozenti> _listDozenti){
                    string[] dayNames = { "Monday", "Thuesday", "Wednesday", "Thursday", "Friday" };
                    for(int i= 0; i < dayNames.Length; i++){
                        for(int j = 1; j < 7; j++){
                            for (int k = 0; k < _tableWPVs.days[dayNames[i]][j + ".Block"].Count; k++){
                                WPVs wpv = _tableWPVs.days[dayNames[i]][j + ".Block"][k];
                                for(int l = 0; l < _listDozenti.Count; l++){
                                    if(_listDozenti[l].name == wpv.professor){
                                        this.days[dayNames[i]][j + ".Block"].Add(_listDozenti[l]);
                                    }
                                }
                            }
                        }
                    }
                }
        */
        private List<Dozenti> duplicateProfessorsAcordingToCourses(List<Dozenti> _iList)
        {
            int initialLength = _iList.Count;
            for (int i = 0; i < initialLength; i++)
            {
                if (_iList[i].courses.Length <= 1)
                {
                    continue;
                }
                else
                {
                    for (int j = 0; j < _iList[i].courses.Length - 1; j++)
                    {
                        _iList.Add(_iList[i]);
                    }
                }
            }
            return _iList;
        }

        private void insertDozentiInRandomTime(List<Dozenti> _iList, TimetableWPVs _tableWPVs)
        {
            while (_iList.Count != 0)
            {
                Random rand = new Random();
                List<string> keyList = new List<string>(days.Keys);
                string randomDay = keyList[rand.Next(keyList.Count)];

                Random random = new Random();
                List<string> keyListInner = new List<string>(days[randomDay].Keys);
                string randomTime = keyListInner[random.Next(keyListInner.Count)];

                if (_iList.Count != 0)
                {
                    bool placingAllowed = true;
                    foreach (Dozenti d in days[randomDay][randomTime])
                    {
                        if (d.name == _iList[0].name)
                        {
                            placingAllowed = false;
                            break;
                        }

                        for (int i = 0; i < d.unavailable.Length; i++)
                        {
                            string[] splittetUnavailability = d.unavailable[i].Split(":");
                            if (splittetUnavailability[0] == randomDay && splittetUnavailability[1] == randomTime)
                            {
                                placingAllowed = false;
                            }
                        }

                        for (int j = 0; j < _tableWPVs.days[randomDay][randomTime].Count; j++)
                        {
                            if (_tableWPVs.days[randomDay][randomTime][j].professor == d.name)
                            {
                                placingAllowed = false;
                            }
                        }
                    }

                    if (placingAllowed == true)
                    {
                        days[randomDay][randomTime].Add(_iList[0]);
                        _iList.Remove(_iList[0]);
                    }
                }
            }
        }

        public void printTimetable(string _professorName, TimetableCourses _courses, TimetableRooms _rooms)
        {
            string[] dayNames = { "Monday", "Thuesday", "Wednesday", "Thursday", "Friday" };
            Dictionary<string, List<Dozenti>>[] timesOfDaysDozenti = { this.timesMonday, this.timesThuesday, this.timesWednesday, this.timesThursday, this.timesFriday };
            for (int i = 0; i < timesOfDaysDozenti.Length; i++)
            {
                for (int j = 1; j < 7; j++)
                {
                    for (int k = 0; k < timesOfDaysDozenti[i][j + ".Block"].Count; k++)
                    {
                        Dozenti dozent = timesOfDaysDozenti[i][j + ".Block"][k];

                        if (dozent.name == _professorName)
                        {
                            Console.WriteLine(dayNames[i] + ": " + j + ".Block: " +
                             _courses.days[dayNames[i]][j + ".Block"][k].name + ": " +
                             _rooms.days[dayNames[i]][j + ".Block"][k].roomnumber);
                        }
                    }
                }
            }
        }
    }
}
