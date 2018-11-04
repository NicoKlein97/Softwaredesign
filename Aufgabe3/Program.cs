using System;

namespace Aufgabe3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Greetings, this function allows you to convert a number from one numerical system to another");
            Console.WriteLine("Sep 1: Please insert the number you would like to convert.");
            int numberToConvert = int.Parse(Console.ReadLine());
            Console.WriteLine("Sep 2: Please let me know, which numerical system you number is currently from.");
            int fS = int.Parse(Console.ReadLine());
            Console.WriteLine("Sep 3: Please insert the numerical system you wish to convert to.");
            int tS = int.Parse(Console.ReadLine());
            Console.WriteLine("Converting your number: " + numberToConvert + " ...");
            Console.WriteLine("The Convertet number is: " + ConvertNumberFromSystemToSystem(numberToConvert, fS, tS));

             int ConvertNumberFromSystemToSystem(int number, int fromSystem, int toSystem)
            {
                int result = 0;
                result = OtherToDecimal(number, fromSystem);
                result = DecimalToOther(result, toSystem);
                return result;
            }

            int DecimalToOther(int dec, int system)
            {
                int result = 0;
                int factor = 1;
                while (dec != 0)
                {
                    int digit = dec % system;
                    dec /= system;
                    result += factor * digit;
                    factor *= 10;
                }
                return result;
            }

            int OtherToDecimal(int other, int system)
            {
                int result = 0;
                int factor = 1;
                while (other != 0)
                {
                    int digit = other % 10;
                    other /= 10;
                    result += factor * digit;
                    factor *= system;
                }
                return result;
            }
        }
    }
}
