using System;

namespace Aufgabe1
{
    class RomanNumber
    {
        static void Main(string[] args)
        {
      
                RomanNumber.GetRomanNumber(args);
        }

        static void GetRomanNumber(string[] _number){
            String units;
            String tens;
            String hundreds;
            int _numberLength = _number[0].Length;
            
            if (_numberLength == 1){
                units = RomanNumber.calculateUnits(_number[0][0]);
                Console.WriteLine(_number[0] + " umgerechnet ist : " + units);
            }else if(_numberLength == 2){
                units = RomanNumber.calculateUnits(_number[0][1]);
                tens = RomanNumber.calculateTens(_number[0][0]);
                Console.WriteLine(_number[0] + " umgerechnet ist : " + tens + units);
            }else if(_numberLength == 3){
                units = RomanNumber.calculateUnits(_number[0][2]);
                tens = RomanNumber.calculateTens(_number[0][1]);
                hundreds = RomanNumber.calculateHundreds(_number[0][0]);
                Console.WriteLine(_number[0] + " umgerechnet ist : "+ hundreds + tens + units);
            }else{
                Console.WriteLine("Ihre Zahl darf maximal drei Stellen besitzen");
            }
            
        }

        static String calculateUnits(char _number){
            String  romanNumber = "";
            switch(_number){
                case '1':
                    romanNumber = "I";
                    break;
                case '2':    
                    romanNumber = "II";
                    break;
                case '3':
                    romanNumber = "III";
                    break;
                case '4':
                    romanNumber = "IV";
                    break;
                case '5':
                    romanNumber = "V";
                    break;
                case '6':
                    romanNumber = "VI";
                    break;
                case '7': 
                    romanNumber = "VII";
                    break;
                case '8':                    
                    romanNumber = "VIII";
                    break;
                case '9':
                    romanNumber = "IX"; 
                    break;  
                default:
                         Console.WriteLine("Bitte geben Sie eine ganze Zahl ein");
                        break;
            }

            return romanNumber;
        }

        static String calculateTens(char _numberTens){
            String  romanNumber = "";
            switch(_numberTens){
                case '1':
                    romanNumber = "X";
                    break;
                case '2':    
                    romanNumber = "XX";
                    break;
                case '3':
                    romanNumber = "XXX";
                    break;
                case '4':
                    romanNumber = "XL";
                    break;
                case '5':
                    romanNumber = "L";
                    break;
                case '6':
                    romanNumber = "LX";
                    break;
                case '7': 
                    romanNumber = "LXX";
                    break;
                case '8':                    
                    romanNumber = "LXXX";
                    break;
                case '9':
                    romanNumber = "XC"; 
                    break;  
                default:
                         Console.WriteLine("Bitte geben Sie eine ganze Zahl ein");
                        break;
            }
            return romanNumber;
        }

        static String calculateHundreds(char _number){
            String  romanNumber = "";
            switch(_number){
                case '1':
                    romanNumber = "C";
                    break;
                case '2':    
                    romanNumber = "CC";
                    break;
                case '3':
                    romanNumber = "CCC";
                    break;
                case '4':
                    romanNumber = "CD";
                    break;
                case '5':
                    romanNumber = "D";
                    break;
                case '6':
                    romanNumber = "DC";
                    break;
                case '7': 
                    romanNumber = "DCC";
                    break;
                case '8':                    
                    romanNumber = "DCCC";
                    break;
                case '9':
                    romanNumber = "CM"; 
                    break;  
                default:
                         Console.WriteLine("Bitte geben Sie eine ganze Zahl ein");
                        break;
            }

            return romanNumber;
        }
    }
}
