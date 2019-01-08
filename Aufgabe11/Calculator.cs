using System;

namespace Aufgabe11
{
    delegate void ReportProgressMethod(int progress);
    class Calculator
    {
        public event ReportProgressMethod ProgressMethod;
        public Calculator(){
            ProgressMethod += ConsoleOutputProgressInPercent;
            ProgressMethod += ConsoleOutputProgressInfo;
        }
        public void CalculateSomething(){
            for(int i = 0; i <= 100; i++){
               if(i == 20 || i == 40 || i == 60 || i == 80 || i == 100){
                   ProgressMethod(i);
               }
            }
        }
        public void ConsoleOutputProgressInPercent(int _progress){
            Console.WriteLine(_progress + " %");
        }
        public void ConsoleOutputProgressInfo(int _progress){
            if(_progress == 100){
                Console.WriteLine("Done");
            }else{
                Console.WriteLine("Loading...");
            }
        }
    }
}
