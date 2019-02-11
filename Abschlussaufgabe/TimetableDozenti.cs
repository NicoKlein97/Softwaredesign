using System;
using System.Collections.Generic;

namespace Abschlussaufgabe
{
    class TimetableDozenti : Timetable
    {
        public Dictionary<string, List<Dozenti>> blocksOfMonday = new Dictionary<string, List<Dozenti>>();
        public Dictionary<string, List<Dozenti>> blocksOfThuesday = new Dictionary<string, List<Dozenti>>();
        public Dictionary<string, List<Dozenti>> blocksOfWednesday = new Dictionary<string, List<Dozenti>>();
        public Dictionary<string, List<Dozenti>> blocksOfThursday = new Dictionary<string, List<Dozenti>>();
        public Dictionary<string, List<Dozenti>> blocksOfFriday = new Dictionary<string, List<Dozenti>>();
        public Dictionary<string, Dictionary<string, List<Dozenti>>> days = new Dictionary<string, Dictionary<string, List<Dozenti>>>();

        public TimetableDozenti(List<Dozenti> _iList, TimetableWPVs _tableWPVs)
        {

            fillDictionaries();

            days.Add("Monday", blocksOfMonday);
            days.Add("Thuesday", blocksOfThuesday);
            days.Add("Wednesday", blocksOfWednesday);
            days.Add("Thursday", blocksOfThursday);
            days.Add("Friday", blocksOfFriday);

            //insertWPVsInTable(_tableWPVs, _iList);
            _iList = duplicateProfessorsAcordingToCourses(_iList);
            insertObjectsInTimetable(_iList, _tableWPVs);
        }

        public override void fillDictionaries()
        {
            Dictionary<string, List<Dozenti>>[] dayNames = { blocksOfMonday, blocksOfThuesday, blocksOfWednesday, blocksOfThursday, blocksOfFriday };

            for (int day = 0; day < 5; day++)
            {
                for (int block = 1; block < 7; block++)
                {
                    List<Dozenti> dozentiList = new List<Dozenti>();
                    dayNames[day].Add(block + ".Block", dozentiList);
                }
            }
        }
        
        private List<Dozenti> duplicateProfessorsAcordingToCourses(List<Dozenti> _dozentiList)
        {
            int initialLength = _dozentiList.Count;
            for (int i = 0; i < initialLength; i++)
            {
                if (_dozentiList[i].courses.Length <= 1)
                {
                    continue;
                }
                else
                {
                    for (int j = 0; j < _dozentiList[i].courses.Length - 1; j++)
                    {
                        _dozentiList.Add(_dozentiList[i]);
                    }
                }
            }
            return _dozentiList;
        }

        private void insertObjectsInTimetable(List<Dozenti> _iList, TimetableWPVs _tableWPVs)
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
            Dictionary<string, List<Dozenti>>[] timesOfDaysDozenti = { this.blocksOfMonday, this.blocksOfThuesday, this.blocksOfWednesday, this.blocksOfThursday, this.blocksOfFriday };
            for (int day = 0; day < timesOfDaysDozenti.Length; day++)
            {
                for (int block = 1; block < 7; block++)
                {
                    for (int i = 0; i < timesOfDaysDozenti[day][block + ".Block"].Count; i++)
                    {
                        Dozenti dozent = timesOfDaysDozenti[day][block + ".Block"][i];

                        if (dozent.name == _professorName)
                        {
                            Console.WriteLine(dayNames[day] + ": " + block + ".Block: " +
                             _courses.days[dayNames[day]][block + ".Block"][i].name + ": " +
                             _rooms.days[dayNames[day]][block + ".Block"][i].roomnumber);
                        }
                    }
                }
            }
        }
    }
}
