﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Abschlussaufgabe
{
    class Program
    {
        public static List<Dozenti> allDozentiObjects = new List<Dozenti>();
        public static List<Courses> allCoursesObjects = new List<Courses>();
        public static List<Rooms> allRoomsObjects = new List<Rooms>();
        static void Main(string[] args)
        {
            fillListsWithJsonData();

            TimetableDozenti tableDozenti = new TimetableDozenti(allDozentiObjects);
            TimetableCourses tableCourses = new TimetableCourses(allCoursesObjects, tableDozenti);
            TimetableRooms tableRooms = new TimetableRooms(allRoomsObjects, tableCourses);

            bool runProgram = true;

            Console.WriteLine("Gooday Day, what would you like to do ?");

            while (runProgram == true)
            {
                Console.Clear();
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
                        Console.WriteLine("Please, enter the name of the course of study you would like to see (MIB, OMB, MKB)");
                        string course = Console.ReadLine();
                        Console.WriteLine("Which Semester are you interested in ?");
                        string semesterString = Console.ReadLine();
                        int semesterNumber = Int32.Parse(semesterString);
                        tableCourses.printTimetable(course, semesterNumber);
                        break;

                    case "2":
                        tableCourses.printAllCoursesTimetable(tableRooms);
                        break;

                    case "3":
                        Console.WriteLine("Please, enter the name of the professor you are interested in");
                        string professorName = Console.ReadLine();
                        tableDozenti.printTimetable(professorName, tableCourses, tableRooms);
                        break;

                    case "4":
                        Console.WriteLine("Please, enter the roomname you are interested in");
                        string roomname = Console.ReadLine();
                        tableRooms.printTimetable(roomname, tableCourses, tableDozenti);
                        break;

                    case "5":
                        runProgram = false;
                        break;

                    default:
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
                List<Courses> TBC = JsonConvert.DeserializeObject<List<Courses>>(json);
                for (int i = 0; i < TBC.Count; i++)
                {
                    allCoursesObjects.Add(TBC[i]);
                }
            }

            StreamReader readerDozenti = new StreamReader("Dozenti.json");
            {
                string json = readerDozenti.ReadToEnd();
                List<Dozenti> TBD = JsonConvert.DeserializeObject<List<Dozenti>>(json);
                for (int i = 0; i < TBD.Count; i++)
                {
                    allDozentiObjects.Add(TBD[i]);
                }
            }

            StreamReader readerRooms = new StreamReader("Rooms.json");
            {
                string json = readerRooms.ReadToEnd();
                List<Rooms> TBR = JsonConvert.DeserializeObject<List<Rooms>>(json);
                for (int i = 0; i < TBR.Count; i++)
                {
                    allRoomsObjects.Add(TBR[i]);
                }
            }

        }
    }
}
