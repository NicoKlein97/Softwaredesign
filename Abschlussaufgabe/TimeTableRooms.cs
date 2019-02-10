using System;
using System.Collections.Generic;

namespace Abschlussaufgabe
{
    class TimetableRooms : Timetable
    {
        public Dictionary<string, List<Rooms>> timesMonday = new Dictionary<string, List<Rooms>>();
        public Dictionary<string, List<Rooms>> timesThuesday = new Dictionary<string, List<Rooms>>();
        public Dictionary<string, List<Rooms>> timesWednesday = new Dictionary<string, List<Rooms>>();
        public Dictionary<string, List<Rooms>> timesThursday = new Dictionary<string, List<Rooms>>();
        public Dictionary<string, List<Rooms>> timesFriday = new Dictionary<string, List<Rooms>>();
        public Dictionary<string, Dictionary<string, List<Rooms>>> days = new Dictionary<string, Dictionary<string, List<Rooms>>>();

        public TimetableRooms(List<Rooms> _listRooms, TimetableCourses _tableCourses)
        {

            fillTimesDictionaries();

            days.Add("Monday", timesMonday);
            days.Add("Thuesday", timesThuesday);
            days.Add("Wednesday", timesWednesday);
            days.Add("Thursday", timesThursday);
            days.Add("Friday", timesFriday);

            insertObjectsInRoomsTimetable(_listRooms, _tableCourses);
        }
        public override void fillTimesDictionaries()
        {
            Dictionary<string, List<Rooms>>[] dayNames = { timesMonday, timesThuesday, timesWednesday, timesThursday, timesFriday };

            for (int i = 0; i < 5; i++)
            {
                for (int j = 1; j < 7; j++)
                {
                    List<Rooms> roomsList = new List<Rooms>();
                    dayNames[i].Add(j + ".Block", roomsList);
                }
            }
        }

        public void insertObjectsInRoomsTimetable(List<Rooms> _listRooms, TimetableCourses _timetableCourses)
        {
            Dictionary<string, List<Rooms>>[] timesOfDaysRooms = { this.timesMonday, this.timesThuesday, this.timesWednesday, this.timesThursday, this.timesFriday };
            Dictionary<string, List<Courses>>[] timesOfDaysCourses = { _timetableCourses.timesMonday, _timetableCourses.timesThuesday, _timetableCourses.timesWednesday, _timetableCourses.timesThursday, _timetableCourses.timesFriday };

            for (int i = 0; i < timesOfDaysCourses.Length; i++)
            {
                for (int j = 1; j < 7; j++)
                {
                    for(int k = 0; k < timesOfDaysCourses[i][j + ".Block"].Count; k++){
                        Courses course = timesOfDaysCourses[i][j + ".Block"][k];
                        for (int l = 0; l < _listRooms.Count; l++)
                        {
                            if (compareCapacity(_listRooms[l], course) && compareInterior(_listRooms[l], course))
                            {
                                timesOfDaysRooms[i][j + ".Block"].Add( _listRooms[l]);
                                _listRooms.Add(_listRooms[l]);
                                _listRooms.Remove(_listRooms[l]);
                                break;
                            }
                        }
                    }
                }
            }
        }

        private bool compareInterior(Rooms _room, Courses _course){
            for(int i = 0; i < _course.neededEquipment.Length; i++){
                if(Array.Exists(_room.interior, element => element == _course.neededEquipment[i])){
                    continue;
                }else{
                    return false;
                }
            }
            return true;
        }

        private bool compareCapacity(Rooms _room, Courses _course){
            if(_room.capacity - _course.numberOfStudents <= 25 && _room.capacity - _course.numberOfStudents >= 0){
                return true;
            }else{
                return false;
            }
        }

        public void printTimetable(string _roomNumber, TimetableCourses _courses, TimetableDozenti _dozenti)
        {
            string[] dayNames = { "Monday", "Thuesday", "Wednesday", "Thursday", "Friday" };
            Dictionary<string, List<Rooms>>[] timesOfDaysRooms = { this.timesMonday, this.timesThuesday, this.timesWednesday, this.timesThursday, this.timesFriday };
            for (int i = 0; i < timesOfDaysRooms.Length; i++)
            {
                for (int j = 1; j < 7; j++)
                {
                    for (int k = 0; k < timesOfDaysRooms[i][j + ".Block"].Count; k++)
                    {
                        Rooms room = timesOfDaysRooms[i][j + ".Block"][k];

                        if (room.roomnumber == _roomNumber)
                        {
                            Console.WriteLine(dayNames[i] + ": " + j + ".Block: " +
                             _courses.days[dayNames[i]][j + ".Block"][k].name + ": " +
                             _dozenti.days[dayNames[i]][j + ".Block"][k].name);
                        }

                    }
                }
            }
        }
    }
}
