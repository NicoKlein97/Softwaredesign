using System;
using System.Collections.Generic;

namespace Abschlussaufgabe
{
    class TimetableWPVs : Timetable
    {
        public Dictionary<string, List<WPVs>> blocksOfMonday = new Dictionary<string, List<WPVs>>();
        public Dictionary<string, List<WPVs>> blocksOfThuesday = new Dictionary<string, List<WPVs>>();
        public Dictionary<string, List<WPVs>> blocksOfWednesday = new Dictionary<string, List<WPVs>>();
        public Dictionary<string, List<WPVs>> blocksOfThursday = new Dictionary<string, List<WPVs>>();
        public Dictionary<string, List<WPVs>> blocksOfFriday = new Dictionary<string, List<WPVs>>();
        public Dictionary<string, Dictionary<string, List<WPVs>>> days = new Dictionary<string, Dictionary<string, List<WPVs>>>();

        public TimetableWPVs(List<WPVs> _iList)
        {

            fillDictionaries();

            days.Add("Monday", blocksOfMonday);
            days.Add("Thuesday", blocksOfThuesday);
            days.Add("Wednesday", blocksOfWednesday);
            days.Add("Thursday", blocksOfThursday);
            days.Add("Friday", blocksOfFriday);

            insertWPVsInTimetable(_iList);

        }

        public override void fillDictionaries()
        {
            Dictionary<string, List<WPVs>>[] dayNames = { blocksOfMonday, blocksOfThuesday, blocksOfWednesday, blocksOfThursday, blocksOfFriday };

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
