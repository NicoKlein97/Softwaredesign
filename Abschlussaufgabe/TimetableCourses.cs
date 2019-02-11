using System;
using System.Collections.Generic;

namespace Abschlussaufgabe
{
    class TimetableCourses : Timetable
    {
        public Dictionary<string, List<Courses>> blocksOfMonday = new Dictionary<string, List<Courses>>();
        public Dictionary<string, List<Courses>> blocksOfThuesday = new Dictionary<string, List<Courses>>();
        public Dictionary<string, List<Courses>> blocksOfWednesday = new Dictionary<string, List<Courses>>();
        public Dictionary<string, List<Courses>> blocksOfThursday = new Dictionary<string, List<Courses>>();
        public Dictionary<string, List<Courses>> blocksOfFriday = new Dictionary<string, List<Courses>>();
        public Dictionary<string, Dictionary<string, List<Courses>>> days = new Dictionary<string, Dictionary<string, List<Courses>>>();

        public TimetableCourses(List<Courses> _listCourses, TimetableDozenti _timetableDozenti)
        {

            fillDictionaries();

            days.Add("Monday", blocksOfMonday);
            days.Add("Thuesday", blocksOfThuesday);
            days.Add("Wednesday", blocksOfWednesday);
            days.Add("Thursday", blocksOfThursday);
            days.Add("Friday", blocksOfFriday);

            insertObjectsInTimetable(_listCourses, _timetableDozenti);
        }

        public override void fillDictionaries()
        {
            Dictionary<string, List<Courses>>[] timesOfDays = { blocksOfMonday, blocksOfThuesday, blocksOfWednesday, blocksOfThursday, blocksOfFriday };

            for (int day = 0; day < 5; day++)
            {
                for (int block = 1; block < 7; block++)
                {
                    List<Courses> coursesList = new List<Courses>();
                    timesOfDays[day].Add(block + ".Block", coursesList);
                }
            }
        }
        private void insertObjectsInTimetable(List<Courses> _listCourses, TimetableDozenti _timetableDozenti)
        {
            Dictionary<string, List<Courses>>[] blocksOfTheWeekCourses = { this.blocksOfMonday, this.blocksOfThuesday, this.blocksOfWednesday, this.blocksOfThursday, this.blocksOfFriday };
            Dictionary<string, List<Dozenti>>[] blocksOfTheWeekDozenti = { _timetableDozenti.blocksOfMonday, _timetableDozenti.blocksOfThuesday, _timetableDozenti.blocksOfWednesday, _timetableDozenti.blocksOfThursday, _timetableDozenti.blocksOfFriday };

            for (int day = 0; day < blocksOfTheWeekDozenti.Length; day++)
            {
                for (int block = 1; block < 7; block++)
                {
                    for (int i = 0; i < blocksOfTheWeekDozenti[day][block + ".Block"].Count; i++)
                    {
                        Dozenti dozent = blocksOfTheWeekDozenti[day][block + ".Block"][i];
                        for (int j = 0; j < _listCourses.Count; j++)
                        {
                            if (_listCourses[j].professor == dozent.name)
                            {
                                bool existing = false;
                                for (int k = 0; k < blocksOfTheWeekCourses[day][block + ".Block"].Count; k++)
                                {
                                    if (blocksOfTheWeekCourses[day][block + ".Block"][k].professor == dozent.name)
                                    {
                                        existing = true;
                                        break;
                                    }
                                }
                                if (existing == false)
                                {
                                    blocksOfTheWeekCourses[day][block + ".Block"].Add(_listCourses[j]);
                                    _listCourses.Remove(_listCourses[j]);
                                }
                            }
                        }
                    }
                }
            }
        }

        public void printTimetable(string _courseOfStudy, int _semester, TimetableWPVs _tableWPVs)
        {
            List<string> usedTimeslots = new List<string>();
            string[] dayNames = { "Monday", "Thuesday", "Wednesday", "Thursday", "Friday" };
            Dictionary<string, List<Courses>>[] blocksOfTheWeekCourses = { this.blocksOfMonday, this.blocksOfThuesday, this.blocksOfWednesday, this.blocksOfThursday, this.blocksOfFriday };
            for (int day = 0; day < blocksOfTheWeekCourses.Length; day++)
            {
                for (int block = 1; block < 7; block++)
                {
                    for (int i = 0; i < blocksOfTheWeekCourses[day][block + ".Block"].Count; i++)
                    {
                        Courses course = blocksOfTheWeekCourses[day][block + ".Block"][i];
                        for (int j = 0; j < course.coursesOfStudy.Length; j++)
                        {
                            if (course.semester == _semester && course.coursesOfStudy[j] == _courseOfStudy)
                            {
                                Console.WriteLine(dayNames[day] + ": " + block + ".Block: " + course.name);
                                usedTimeslots.Add(dayNames[day]);
                                usedTimeslots.Add(block + "Block");
                            }
                        }
                    }
                }
            }
            Console.WriteLine("");
            Console.WriteLine("For you possible WPVs: ");
            checkAndOutputPossibleWPVs(usedTimeslots, _tableWPVs);
        }

        private void checkAndOutputPossibleWPVs(List<string> _usedTimeslots, TimetableWPVs _tableWPVs)
        {
            string[] dayNames = { "Monday", "Thuesday", "Wednesday", "Thursday", "Friday" };
            for (int day = 0; day < dayNames.Length; day++)
            {
                for (int block = 1; block < 7; block++)
                {
                    for (int i = 0; i < _tableWPVs.days[dayNames[day]][block + ".Block"].Count; i++)
                    {
                        WPVs wpv = _tableWPVs.days[dayNames[day]][block + ".Block"][i];
                        bool unusedSlot = true;
                        for (int j = 0; j < _usedTimeslots.Count; j += 2)
                        {
                            if (_usedTimeslots[j] == dayNames[day] && _usedTimeslots[j + 1] == block + ".Block")
                            {
                                unusedSlot = false;
                            }
                        }
                        if (unusedSlot == true)
                        {
                            Console.WriteLine(wpv.name + ": " + dayNames[day] + ": " + block + ".block: "
                            + wpv.assignedRoom.roomnumber);
                        }
                    }
                }
            }
        }

        public void printAllCoursesTimetable(TimetableRooms _rooms)
        {
            string[] dayNames = { "Monday", "Thuesday", "Wednesday", "Thursday", "Friday" };
            Dictionary<string, List<Courses>>[] timesOfDaysCourses = { this.blocksOfMonday, this.blocksOfThuesday, this.blocksOfWednesday, this.blocksOfThursday, this.blocksOfFriday };
            for (int day = 0; day < timesOfDaysCourses.Length; day++)
            {
                for (int block = 1; block < 7; block++)
                {
                    for (int i = 0; i < timesOfDaysCourses[day][block + ".Block"].Count; i++)
                    {
                        Courses course = timesOfDaysCourses[day][block + ".Block"][i];
                        Console.WriteLine(dayNames[day] + ": " + block + ".Block: " +
                        course.name + ": " + _rooms.days[dayNames[day]][block + ".Block"][i].roomnumber);
                    }
                }
            }
        }
    }
}
