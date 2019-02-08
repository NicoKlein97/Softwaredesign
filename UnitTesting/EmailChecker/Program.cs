using System;

namespace EmailChecker
{
    class Program
    {
        static void Main(string[] args)
        {
/* 
            Bis Umgang UnitTest
            Console.WriteLine(IsEmailAddress("nico.klein@hs-furtwangen.de"));
            Console.WriteLine(IsEmailAddress("nico.@gmx.de"));
            Console.WriteLine(IsEmailAddress("nico.klEin@hs-furtWangende"));
            Console.WriteLine(IsEmailAddress("nico.klein@hs-furtwangen.Fuwa.de"));
            Console.WriteLine(IsEmailAddress("nico.@."));
            Console.WriteLine(IsEmailAddress("nico.klein@hs-furtwangen.Fuwade"));
            Console.WriteLine(IsEmailAddress("nico.klein@hs-furtwan@gen.Fuwade"));
*/
            string mailaddress = "nicojack@gmx.de";
            if (IsEmailAddress(mailaddress))
                Console.WriteLine("TEST PASSED: " + mailaddress + " korrekt als Email-Adresse erkannt");
            else
                Console.WriteLine("TEST FAILED: " + mailaddress + " nicht als Email-Adresse erkannt, obwohl korrekt.");
        }

        public static bool IsEmailAddress(string emailAddress)
        {
            int iAt = emailAddress.IndexOf('@');
            int iDot = emailAddress.LastIndexOf('.');
            return (iAt > 0 && iDot > iAt);
        }
    }
}
