using System;
using System.Collections.Generic;

namespace Abschlussaufgabe
{
    class TimetableCourses : Timetable
    {
        public Dictionary<string, List<Courses>> timesMonday = new Dictionary<string, List<Courses>>();
        public Dictionary<string, List<Courses>> timesThuesday = new Dictionary<string, List<Courses>>();
        public Dictionary<string, List<Courses>> timesWednesday = new Dictionary<string, List<Courses>>();
        public Dictionary<string, List<Courses>> timesThursday = new Dictionary<string, List<Courses>>();
        public Dictionary<string, List<Courses>> timesFriday = new Dictionary<string, List<Courses>>();
        public Dictionary<string, Dictionary<string, List<Courses>>> days = new Dictionary<string, Dictionary<string, List<Courses>>>();

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
            Dictionary<string, List<Courses>>[] timesOfDays = { timesMonday, timesThuesday, timesWednesday, timesThursday, timesFriday };

            for (int i = 0; i < 5; i++)
            {
                for (int j = 1; j < 7; j++)
                {
                    List<Courses> coursesList = new List<Courses>();
                    timesOfDays[i].Add(j + ".Block", coursesList);
                }
            }
        }
        public void insertObjectsInCoursesTimetable(List<Courses> _listCourses, TimetableDozenti _timetableDozenti)
        {
            Dictionary<string, List<Courses>>[] timesOfDaysCourses = { this.timesMonday, this.timesThuesday, this.timesWednesday, this.timesThursday, this.timesFriday };
            Dictionary<string, List<Dozenti>>[] timesOfDaysDozenti = { _timetableDozenti.timesMonday, _timetableDozenti.timesThuesday, _timetableDozenti.timesWednesday, _timetableDozenti.timesThursday, _timetableDozenti.timesFriday };

            for (int i = 0; i < timesOfDaysDozenti.Length; i++)
            {
                for (int j = 1; j < 7; j++)
                {
                    for (int k = 0; k < timesOfDaysDozenti[i][j + ".Block"].Count; k++)
                    {
                        Dozenti dozent = timesOfDaysDozenti[i][j + ".Block"][k];
                        for (int l = 0; l < _listCourses.Count; l++)
                        {
                            if (_listCourses[l].professor == dozent.name)
                            {
                                bool existing = false;
                                for (int m = 0; m < timesOfDaysCourses[i][j + ".Block"].Count; m++)
                                {
                                    if (timesOfDaysCourses[i][j + ".Block"][m].professor == dozent.name)
                                    {
                                        existing = true;
                                        break;
                                    }
                                }
                                if (existing == false)
                                {
                                    timesOfDaysCourses[i][j + ".Block"].Add(_listCourses[l]);
                                    _listCourses.Remove(_listCourses[l]);
                                }
                            }
                        }
                    }
                }
            }
        }

        public void printTimetable(string _courseOfStudy, int _semester)
        {
            string[] dayNames = { "Monday", "Thuesday", "Wednesday", "Thursday", "Friday" };
            Dictionary<string, List<Courses>>[] timesOfDaysCourses = { this.timesMonday, this.timesThuesday, this.timesWednesday, this.timesThursday, this.timesFriday };
            for (int i = 0; i < timesOfDaysCourses.Length; i++)
            {
                for (int j = 1; j < 7; j++)
                {
                    for (int k = 0; k < timesOfDaysCourses[i][j + ".Block"].Count; k++)
                    {
                        Courses course = timesOfDaysCourses[i][j + ".Block"][k];
                        for (int l = 0; l < course.coursesOfStudy.Length; l++)
                        {
                            if (course.semester == _semester && course.coursesOfStudy[l] == _courseOfStudy)
                            {
                                Console.WriteLine(dayNames[i] + ": " + j + ".Block: " + course.name);
                            }
                        }
                    }
                }
            }
        }

        public void printAllCoursesTimetable(TimetableRooms _rooms)
        {
            string[] dayNames = { "Monday", "Thuesday", "Wednesday", "Thursday", "Friday" };
            Dictionary<string, List<Courses>>[] timesOfDaysCourses = { this.timesMonday, this.timesThuesday, this.timesWednesday, this.timesThursday, this.timesFriday };
            for (int i = 0; i < timesOfDaysCourses.Length; i++)
            {
                for (int j = 1; j < 7; j++)
                {
                    for (int k = 0; k < timesOfDaysCourses[i][j + ".Block"].Count; k++)
                    {
                        Courses course = timesOfDaysCourses[i][j + ".Block"][k];
                        Console.WriteLine(dayNames[i] + ": " + j + ".Block: " +
                        course.name + ": " + _rooms.days[dayNames[i]][j + ".Block"][k].roomnumber);
                    }
                }
            }
        }
    }
}
