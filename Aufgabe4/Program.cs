using System;

namespace Aufgabe4
{
    class Program
    {

        public class Person
        {
            public string FirstName;
            public string LastName;
            public int Age;

            public override string ToString()
            {
                return "Person: " + FirstName + " " + LastName + " ist " + Age + " Jahre alt.";
            }

        }
        static void Main(string[] args)
        {
            Person[] people = new Person[5];
            people[0] = new Person { FirstName = "Nico", LastName = "Klein", Age = 21 };
            people[1] = new Person { FirstName = "Alexander", LastName = "Schmidt", Age = 22 };
            people[2] = new Person { FirstName = "Michelle", LastName = "Zarilli", Age = 27 };
            people[3] = new Person { FirstName = "Michael", LastName = "Klein", Age = 5 };
            people[4] = new Person { FirstName = "Der", LastName = "Dude", Age = 2 };

                for (int i = 0; i < people.Length; i++)
                {
                    if (people[i].Age > 20)
                    Console.WriteLine(people[i].ToString());
                };

                methode1();

        }

        static void methode1(){
            Console.WriteLine("Please enter the number 5");
            int insertedNumber = int.Parse(Console.ReadLine());

            if(insertedNumber == 5){
                methode2();
            }else{
                Console.WriteLine("What exactly was so hard to understand when I asked you to enter 5 ?");
            }
        }

        static void methode2(){
            Console.WriteLine("Thank you........... you can leave now");
        }
    }
}