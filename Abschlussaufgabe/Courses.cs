using System;
using System.Collections.Generic;

namespace Abschlussaufgabe
{
    class Courses 
    {
        public string name;
        public int semester;
        public int numberOfStudents;
        public string[] coursesOfStudy;
        public string professor;
        public string description;
        public string[] neededEquipment;

        public void print(){
            Console.WriteLine(this.name);
            Console.WriteLine(this.semester);
            Console.WriteLine(this.numberOfStudents);
            Console.WriteLine(this.coursesOfStudy[0]);
            Console.WriteLine(this.professor);
            Console.WriteLine(this.description);
            Console.WriteLine(this.neededEquipment[1]);
        }
    
    }
}
