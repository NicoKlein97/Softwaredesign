using System;
using System.Collections.Generic;

namespace Abschlussaufgabe
{
    class Rooms 
    {
        public string roomnumber;
        public int capacity;
        public string[] interior;

        public void print(){
            Console.WriteLine(this.roomnumber);
            Console.WriteLine(this.capacity);
            Console.WriteLine(this.interior[1]);
        }
    }
    
}
