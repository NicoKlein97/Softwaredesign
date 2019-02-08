using System;
using System.Collections.Generic;

namespace Abschlussaufgabe
{
    class TimetableRooms : Timetable
    {
        public Dictionary<string, Rooms> timesMonday = new Dictionary<string, Rooms>();
        public Dictionary<string, Rooms> timesThuesday = new Dictionary<string, Rooms>();
        public Dictionary<string, Rooms> timesWednesday = new Dictionary<string, Rooms>();
        public Dictionary<string, Rooms> timesThursday = new Dictionary<string, Rooms>();
        public Dictionary<string, Rooms> timesFriday = new Dictionary<string, Rooms>();
        public Dictionary<string, Dictionary<string, Rooms>> days = new Dictionary<string, Dictionary<string, Rooms>>();

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
            Dictionary<string, Rooms>[] dayNames = { timesMonday, timesThuesday, timesWednesday, timesThursday, timesFriday };

            for (int i = 0; i < 5; i++)
            {
                for (int j = 1; j < 7; j++)
                {
                    dayNames[i].Add(j + ".Block", null);
                }
            }
        }

        public void insertObjectsInRoomsTimetable(List<Rooms> _listRooms, TimetableCourses _timetableCourses)
        {
            Dictionary<string, Rooms>[] timesOfDaysRooms = { this.timesMonday, this.timesThuesday, this.timesWednesday, this.timesThursday, this.timesFriday };
            Dictionary<string, Courses>[] timesOfDaysCourses = { _timetableCourses.timesMonday, _timetableCourses.timesThuesday, _timetableCourses.timesWednesday, _timetableCourses.timesThursday, _timetableCourses.timesFriday };

            for (int i = 0; i < timesOfDaysCourses.Length; i++)
            {
                for (int j = 1; j < 7; j++)
                {
                    Courses course = timesOfDaysCourses[i][j + ".Block"];
                    if (course != null)
                    {
                        for (int k = 0; k < _listRooms.Count; k++)
                        {
                            if (compareCapacity(_listRooms[k], course) && compareInterior(_listRooms[k], course))
                            {
                                timesOfDaysRooms[i][j + ".Block"] = _listRooms[k];
                                _listRooms.Add(_listRooms[k]);
                                _listRooms.Remove(_listRooms[k]);
                            }else{
                                
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
            if(_room.capacity - _course.numberOfStudents <= 15 && _room.capacity - _course.numberOfStudents >= 0){
                return true;
            }else{
                return false;
            }
        }

        public void print(){
            for(int i = 1; i < 7; i++){
                if(this.timesMonday[i + ".Block"] == null){
                    
                }else{
                    Console.WriteLine(this.timesMonday[i + ".Block"].roomnumber + "  ---" + i);
                }
            }
            for(int i = 1; i < 7; i++){
                if(this.timesThuesday[i + ".Block"] == null){
                    
                }else{
                    Console.WriteLine(this.timesThuesday[i + ".Block"].roomnumber + "  ---" + i);
                }
            }
            for(int i = 1; i < 7; i++){
                if(this.timesWednesday[i + ".Block"] == null){
                    
                }else{
                    Console.WriteLine(this.timesWednesday[i + ".Block"].roomnumber + "  ---" + i);
                }
            }
            for(int i = 1; i < 7; i++){
                if(this.timesThursday[i + ".Block"] == null){
                    
                }else{
                    Console.WriteLine(this.timesThursday[i + ".Block"].roomnumber + "  ---" + i);
                }
            }
            for(int i = 1; i < 7; i++){
                if(this.timesFriday[i + ".Block"] == null){
                    
                }else{
                    Console.WriteLine(this.timesFriday[i + ".Block"].roomnumber + "  ---" + i);
                }
            }
        }
    }
}
