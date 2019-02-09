using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Abschlussaufgabe
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Dozenti> allDozentiObjects = new List<Dozenti>();
            List<Courses> allCoursesObjects = new List<Courses>();
            List<Rooms> allRoomsObjects = new List<Rooms>();

            List<Dozenti> iList = new List<Dozenti>();
            Dozenti[] dozent = { };
            string[] namen = {"Dell Oro", "Waldowski", "Lasowski", "Hottong",
             "schneider", "Pietsch", "Anders","Dittler", "Krach", "Herbstreit", "Fries",
              "Eisenbiegler" , "Müller", "Taube", "Zydorek", "Schäfer","Reusch", "Friess", "Aichele", "Ruf"};

            
            

            StreamReader readerCourses = new StreamReader("Courses.json");
            {
                string json = readerCourses.ReadToEnd();
                List<Courses> TBC = JsonConvert.DeserializeObject<List<Courses>>(json);
                for(int i = 0; i < TBC.Count; i++){
                    allCoursesObjects.Add(TBC[i]);
                }
                //allCoursesObjects[20].print();
            }

            StreamReader readerDozenti = new StreamReader("Dozenti.json");
            {
                string json = readerDozenti.ReadToEnd();
                List<Dozenti> TBD = JsonConvert.DeserializeObject<List<Dozenti>>(json);
                for(int i = 0; i < TBD.Count; i++){
                    allDozentiObjects.Add(TBD[i]);
                }
            }
            //allDozentiObjects[18].print();
            


            StreamReader readerRooms = new StreamReader("Rooms.json");
            {
                string json = readerRooms.ReadToEnd();
                List<Rooms> TBR = JsonConvert.DeserializeObject<List<Rooms>>(json);
                for(int i = 0; i < TBR.Count; i++){
                    allRoomsObjects.Add(TBR[i]);
                }
            }
            //allRoomsObjects[3].print();
            
             
            TimetableDozenti tableDozenti = new TimetableDozenti(allDozentiObjects);
            
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            
            TimetableCourses tableCourses = new TimetableCourses(allCoursesObjects, tableDozenti);
            //tableCourses.print();
            //Console.WriteLine("");
            
            
            TimetableRooms tableRooms = new TimetableRooms(allRoomsObjects, tableCourses);
            //tableRooms.print();
            /*
            TimetableDozenti tableDozenti = new TimetableDozenti(allDozentiObjects);
            TimetableCourses tableCourses = new TimetableCourses(allCoursesObjects, tableDozenti);
            TimetableRooms tableRooms = new TimetableRooms(allRoomsObjects, tableCourses);
            
            */
            tableCourses.printTimetable("MIB", 1);
            Console.WriteLine("");
            tableDozenti.printTimetable("Schneider", tableCourses, tableRooms);
            Console.WriteLine("");
            tableRooms.printTimetable("L2.10", tableCourses, tableDozenti);
        }
    }
}
