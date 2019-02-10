using System;
using System.Collections.Generic;

namespace Abschlussaufgabe
{
    class TimetableWPVs : Timetable
    {
        public Dictionary<string, List<WPVs>> timesMonday = new Dictionary<string, List<WPVs>>();
        public Dictionary<string, List<WPVs>> timesThuesday = new Dictionary<string, List<WPVs>>();
        public Dictionary<string, List<WPVs>> timesWednesday = new Dictionary<string, List<WPVs>>();
        public Dictionary<string, List<WPVs>> timesThursday = new Dictionary<string, List<WPVs>>();
        public Dictionary<string, List<WPVs>> timesFriday = new Dictionary<string, List<WPVs>>();
        public Dictionary<string, Dictionary<string, List<WPVs>>> days = new Dictionary<string, Dictionary<string, List<WPVs>>>();

        public TimetableWPVs(List<WPVs> _iList)
        {

            fillTimesDictionaries();

            days.Add("Monday", timesMonday);
            days.Add("Thuesday", timesThuesday);
            days.Add("Wednesday", timesWednesday);
            days.Add("Thursday", timesThursday);
            days.Add("Friday", timesFriday);

            insertWPVsInTimetable(_iList);

        }

        public override void fillTimesDictionaries()
        {
            Dictionary<string, List<WPVs>>[] dayNames = { timesMonday, timesThuesday, timesWednesday, timesThursday, timesFriday };

            for (int i = 0; i < 5; i++)
            {
                for (int j = 1; j < 7; j++)
                {
                    List<WPVs> dozentiList = new List<WPVs>();
                    dayNames[i].Add(j + ".Block", dozentiList);
                }
            }
        }

        private void insertWPVsInTimetable(List<WPVs> _WPVList){
            for(int i = 0; i < _WPVList.Count; i++){
                string[] dateAndTime = _WPVList[i].dateAndTime.Split(":");
                this.days[dateAndTime[0]][dateAndTime[1]].Add(_WPVList[i]);
            }
        }
    }
}
