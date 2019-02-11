using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Abschlussaufgabe
{
    class Program
    {
        public static List<Dozenti> allDozentiObjects = new List<Dozenti>();
        public static List<Courses> allRegularCourseObjects = new List<Courses>();
        public static List<Rooms> allRoomsObjects = new List<Rooms>();
        public static List<WPVs> allWPVObjects = new List<WPVs>();
        
        static void Main(string[] args)
        {
            fillListsWithJsonData();

            TimetableWPVs tableWPVs = new TimetableWPVs(allWPVObjects);
            TimetableDozenti tableDozenti = new TimetableDozenti(allDozentiObjects, tableWPVs);
            TimetableCourses tableCourses = new TimetableCourses(allRegularCourseObjects, tableDozenti);
            TimetableRooms tableRooms = new TimetableRooms(allRoomsObjects, tableCourses, tableWPVs);
            
            bool runProgram = true;
            Console.WriteLine("Gooday Day, what would you like to do ?");

            while (runProgram == true)
            {
                Console.WriteLine("You can choose between 4 kinds Timetables");
                Console.WriteLine("1. Specific course of Study");
                Console.WriteLine("2. All Courses");
                Console.WriteLine("3. Professor");
                Console.WriteLine("4. Rooms");
                Console.WriteLine("5. Exit");
                Console.WriteLine("Please type in the number you want");
                string mode = Console.ReadLine();

                switch (mode)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Please, enter the name of the course of study you would like to see (MIB, OMB, MKB)");
                        string course = Console.ReadLine();
                        Console.WriteLine("Which Semester are you interested in ?");
                        string semesterString = Console.ReadLine();
                        int semesterNumber = Int32.Parse(semesterString);
                        Console.Clear();
                        tableCourses.printTimetable(course, semesterNumber, tableWPVs);
                        break;

                    case "2":
                        Console.Clear();
                        tableCourses.printAllCoursesTimetable(tableRooms);
                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine("Please, enter the name of the professor you are interested in");
                        string professorName = Console.ReadLine();
                        tableDozenti.printTimetable(professorName, tableCourses, tableRooms);
                        break;

                    case "4":
                        Console.Clear();
                        Console.WriteLine("Please, enter the roomname you are interested in");
                        string roomName = Console.ReadLine();
                        tableRooms.printTimetable(roomName, tableCourses, tableDozenti);
                        break;

                    case "5":
                        Console.Clear();
                        runProgram = false;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Please, enter a valid number");
                        break;
                }
            }
        }

        private static void fillListsWithJsonData()
        {
            StreamReader readerCourses = new StreamReader("Courses.json");
            {
                string json = readerCourses.ReadToEnd();
                List<Courses> deserializedCourses = JsonConvert.DeserializeObject<List<Courses>>(json);
                for (int i = 0; i < deserializedCourses.Count; i++)
                {
                    allRegularCourseObjects.Add(deserializedCourses[i]);
                }
            }

            StreamReader readerDozenti = new StreamReader("Dozenti.json");
            {
                string json = readerDozenti.ReadToEnd();
                List<Dozenti> deserializedDozenti = JsonConvert.DeserializeObject<List<Dozenti>>(json);
                for (int i = 0; i < deserializedDozenti.Count; i++)
                {
                    allDozentiObjects.Add(deserializedDozenti[i]);
                }
            }

            StreamReader readerRooms = new StreamReader("Rooms.json");
            {
                string json = readerRooms.ReadToEnd();
                List<Rooms> deserializedRooms = JsonConvert.DeserializeObject<List<Rooms>>(json);
                for (int i = 0; i < deserializedRooms.Count; i++)
                {
                    allRoomsObjects.Add(deserializedRooms[i]);
                }
            }

            StreamReader readerWPVs = new StreamReader("WPVs.json");
            {
                string json = readerWPVs.ReadToEnd();
                List<WPVs> deserializedWPVs = JsonConvert.DeserializeObject<List<WPVs>>(json);
                for (int i = 0; i < deserializedWPVs.Count; i++)
                {
                    allWPVObjects.Add(deserializedWPVs[i]);
                }
            }
        }
    }
}
