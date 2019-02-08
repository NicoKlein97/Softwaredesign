using System;
using System.Collections.Generic;

namespace Abschlussaufgabe
{
    class Dozenti 
    {
        public string name;
        public Courses[] courses;
        public string[] unavailable;
        public Dozenti(Dozenti f){
            
            
        }
        public void print(){
            Console.WriteLine(this.name);
        }
    }
}
