using System;

namespace Aufgabe2
{
    class Program
    {

        public class Person
  {
      public string Name;
      public int Personalnummer;  
  }
        static void Main(string[] args)
        { 
            int i = 42;
            double pi = 3.1415;
            string salute = "Hello, World";
            var test = 3D;
          
            Console.WriteLine(test);


            //Array----------------------------------------------------------------------------------------------

            int[] ia = new int[10]; //Typ = integer Array, Variable = ia, Speicherplätze = 10
            char[] ca = new char[30]; //Typ = character Array, Variable = ca, Speicherplätze = 30
            double[] da = new double[12]; // Typ = double array, Variable = da Speicherplätze = 12

            int[] array = {1, 0, 2, 9, 3, 8, 4, 7, 5, 6};
            int ergebnis =array[2] * array[8] + array[4]; //Prognose 13
            Console.WriteLine("Das Ergebnis ist " + ergebnis); //Ergebnis = 13
            
            double e = Math.Exp(1);
            double kepler = 2.97 * Math.Pow(10,-19);
            double[] arrayD = {pi,e, kepler, 5}; // 5 Nachträglich hinzugefügt um änderung der Länge zu testen
            Console.WriteLine("Array = " + arrayD);

            Console.WriteLine("Länge des Array" + arrayD.Length);

            //Strings-----------------------------------------------------------------------------------------------

            string meinString = "Dies ist ein String";
            char zeichen = meinString[5];
            string a = "eins";
            string b = "zwei";
            string c = "eins";
            bool a_eq_b = (a == b);
            bool a_eq_c = (a == c);

            Console.WriteLine("Inhalt von meinString = " + meinString + ", Inhalt von zeichen = " + zeichen + ", Inhalt von c = "+  c + ", Inhalt von a_eq_b = " + a_eq_b + ", Inhalt von a_eq_c = " + a_eq_c);

            //Klassen----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

                Person jemand = new Person();
                jemand.Name = "Horst";
                jemand.Personalnummer = 42; 
                //Oder kürzer
                //Person jemand = new Person {Name="Horst", Personalnummer=42};

                //Verzweigungen-----------------------------------------------------------------------------------------------------------------------------------

               /*  int input1 = int.Parse(Console.ReadLine());
                int input2 = int.Parse(Console.ReadLine());

                if(input1 > 3 && input2 == 6){
                    Console.WriteLine("Du hast gewonnen");
                }else{
                    Console.WriteLine("Du hast verloren");
                }*/


                String k = Console.ReadLine();
                switch (k)
                {
                case "Apfel":
                    Console.WriteLine("Du hast EINS eingegeben");
                    break;
                case "Banane":
                    Console.WriteLine("ZWEI war Deine Wahl");
                    break;
                case "Kiwi":
                    Console.WriteLine("Du tipptest eine DREI");
                    break;
                case "Erdbeere":
                    Console.WriteLine("Du hast eine 4 gewählt");
                    break;
                default:
                    Console.WriteLine("Die Zahl " + i + " kenne ich nicht");   
                    break; 
                }

                if(k == "Apfel"){
                    Console.WriteLine("Du hast EINS eingegeben");
                }else if(k == "Banane"){
                    Console.WriteLine("ZWEI war Deine Wahl");
                }else if(k == "Kiwi"){
                    Console.WriteLine("Du tipptest eine DREI");
                }else if(k == "Erdbeere"){
                    Console.WriteLine("Du hast eine 4 gewählt");
                }else{
                    Console.WriteLine("Die Zahl " + i + " kenne ich nicht"); 
                }

                //Schleifen----------------------------------------------------------------------------------------------

                int n = 1;
                while (n < 11)
                {
                    Console.WriteLine(n);
                    n++;
                }
                //Initialisierung = n=1
                //Bedingung = n<11
                //inkrement = n++


                string[] someStrings = 
                {
                    "Hier",
                    "sehen",
                    "wir",
                    "einen",
                    "Array",
                    "von",
                    "Strings"
                };
                
                for (int z = 0; z < 5; z++)
                {
                    Console.WriteLine(someStrings[z]);
                }

                //Die Schleife gibt die einzelnen Inhalte des someStrings Arrays nacheinander aus

                int nn = 1;
                while (nn < someStrings.Length)
                {
                    Console.WriteLine(someStrings[nn]);
                    nn++;
                }

                //for each-Schleifen sind schneller zu schreiben und sehen schlanker aus,
                //sind aber undurchsichtiger, weil man wissen muss wie groß die zu durchlaufenden Arrays sind
                //um zu wissen wie oft die Schleife läuft


        }
        
    }
}
