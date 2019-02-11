using System;
using System.Collections.Generic;

namespace Abschlussaufgabe
{
    class TimetableRooms : Timetable
    {
        public Dictionary<string, List<Rooms>> blocksOfMonday = new Dictionary<string, List<Rooms>>();
        public Dictionary<string, List<Rooms>> blocksOfThuesday = new Dictionary<string, List<Rooms>>();
        public Dictionary<string, List<Rooms>> blocksOfWednesday = new Dictionary<string, List<Rooms>>();
        public Dictionary<string, List<Rooms>> blocksOfThursday = new Dictionary<string, List<Rooms>>();
        public Dictionary<string, List<Rooms>> blocksOfFriday = new Dictionary<string, List<Rooms>>();
        public Dictionary<string, Dictionary<string, List<Rooms>>> days = new Dictionary<string, Dictionary<string, List<Rooms>>>();

        public TimetableRooms(List<Rooms> _listRooms, TimetableCourses _tableCourses, TimetableWPVs _tableWPVs)
        {

            fillDictionaries();

            days.Add("Monday", blocksOfMonday);
            days.Add("Thuesday", blocksOfThuesday);
            days.Add("Wednesday", blocksOfWednesday);
            days.Add("Thursday", blocksOfThursday);
            days.Add("Friday", blocksOfFriday);

            insertObjectsInTimetable(_listRooms, _tableCourses);
            assignRoomsToWPVs(_listRooms, _tableWPVs);
        }
        public override void fillDictionaries()
        {
            Dictionary<string, List<Rooms>>[] dayNames = { blocksOfMonday, blocksOfThuesday, blocksOfWednesday, blocksOfThursday, blocksOfFriday };

            for (int day = 0; day < 5; day++)
            {
                for (int block = 1; block < 7; block++)
                {
                    List<Rooms> roomsList = new List<Rooms>();
                    dayNames[day].Add(block + ".Block", roomsList);
                }
            }
        }

        private void insertObjectsInTimetable(List<Rooms> _listRooms, TimetableCourses _timetableCourses)
        {
            Dictionary<string, List<Rooms>>[] timesOfDaysRooms = { this.blocksOfMonday, this.blocksOfThuesday, this.blocksOfWednesday, this.blocksOfThursday, this.blocksOfFriday };
            Dictionary<string, List<Courses>>[] timesOfDaysCourses = { _timetableCourses.blocksOfMonday, _timetableCourses.blocksOfThuesday, _timetableCourses.blocksOfWednesday, _timetableCourses.blocksOfThursday, _timetableCourses.blocksOfFriday };

            for (int day = 0; day < timesOfDaysCourses.Length; day++)
            {
                for (int block = 1; block < 7; block++)
                {
                    for (int i = 0; i < timesOfDaysCourses[day][block + ".Block"].Count; i++)
                    {
                        Courses course = timesOfDaysCourses[day][block + ".Block"][i];
                        for (int j = 0; j < _listRooms.Count; j++)
                        {
                            if (compareCapacity(_listRooms[j], course) && compareInterior(_listRooms[j], course))
                            {
                                timesOfDaysRooms[day][block + ".Block"].Add(_listRooms[j]);
                                _listRooms.Add(_listRooms[j]);
                                _listRooms.Remove(_listRooms[j]);
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void assignRoomsToWPVs(List<Rooms> _listRooms, TimetableWPVs _tableWPVs)
        {
            string[] dayNames = { "Monday", "Thuesday", "Wednesday", "Thursday", "Friday" };
            for (int day = 0; day < dayNames.Length; day++)
            {
                for (int block = 1; block < 7; block++)
                {
                    for (int i = 0; i < _tableWPVs.days[dayNames[day]][block + ".Block"].Count; i++)
                    {
                        WPVs wpv = _tableWPVs.days[dayNames[day]][block + ".Block"][i];
                        if (this.days[dayNames[day]][block + ".Block"].Count == 0)
                        {
                            _tableWPVs.days[dayNames[day]][block + ".Block"][i].assignedRoom = _listRooms[0];
                        }
                        else
                        {
                            for (int j = 0; j < _listRooms.Count; j++)
                            {
                                if (_listRooms[j].roomnumber != this.days[dayNames[day]][block + ".Block"][0].roomnumber)
                                {
                                    wpv.assignedRoom = _listRooms[j];
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        private bool compareInterior(Rooms _room, Courses _course)
        {
            for (int i = 0; i < _course.neededEquipment.Length; i++)
            {
                if (Array.Exists(_room.interior, element => element == _course.neededEquipment[i]))
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        private bool compareCapacity(Rooms _room, Courses _course)
        {
            if (_room.capacity - _course.numberOfStudents <= 25 && _room.capacity - _course.numberOfStudents >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void printTimetable(string _roomNumber, TimetableCourses _tableCourses, TimetableDozenti _tableDozenti)
        {
            string[] dayNames = { "Monday", "Thuesday", "Wednesday", "Thursday", "Friday" };
            Dictionary<string, List<Rooms>>[] timesOfDaysRooms = { this.blocksOfMonday, this.blocksOfThuesday, this.blocksOfWednesday, this.blocksOfThursday, this.blocksOfFriday };
            for (int day = 0; day < timesOfDaysRooms.Length; day++)
            {
                for (int block = 1; block < 7; block++)
                {
                    for (int i = 0; i < timesOfDaysRooms[day][block + ".Block"].Count; i++)
                    {
                        Rooms room = timesOfDaysRooms[day][block + ".Block"][i];

                        if (room.roomnumber == _roomNumber)
                        {
                            Console.WriteLine(dayNames[day] + ": " + block + ".Block: " +
                             _tableCourses.days[dayNames[day]][block + ".Block"][i].name + ": " +
                             _tableDozenti.days[dayNames[day]][block + ".Block"][i].name);
                        }

                    }
                }
            }
        }
    }
}
