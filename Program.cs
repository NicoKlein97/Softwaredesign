using System;

namespace Softwaredesign
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("dotnet run, dotnet build, ");
            //Console.WriteLine(args[0]);
            Program.calculations(123);
            

        }

        static void calculations(int _number){
            int number = _number;
            if (number.ToString().Length == 1){
                Console.WriteLine("Länge 1");
                Program.calculateUnits(number);
            }else if(number.ToString().Length == 2){
                Console.WriteLine("Länge 2");
            }else if(number.ToString().Length == 3){
                Console.WriteLine("Länge 3");
            }
            
        }

        static calculateUnits(int _number){
            String romanNumber;
            switch(_number){
                case 1:
                    romanNumber = "I";
                    break;
                case 2:    
                    romanNumber = "II";
                    break;
                case 3:
                    romanNumber = "III";
                    break;
                case 4:
                    romanNumber = "IV";
                    break;
                case 5:
                    romanNumber = "V";
                    break;
                case 6:
                    romanNumber = "VI";
                    break;
                case 7: 
                    romanNumber = "VII";
                    break;                

            }
        }
    }
}
