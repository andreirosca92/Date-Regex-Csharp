using System;


namespace DateRegex{
    class Program{
        static void Main(string[] args){
            Date d1 = new Date(20,4,23, TimeZone.USA);
            try{
                Date d2 = new Date("15-10-23", TimeZone.IT);
                Date d3 = new Date("15/10/23", TimeZone.IT);
                Console.WriteLine(d1);
                Console.WriteLine(d2);
                Console.WriteLine(d3);

            }catch(InvalidOperationException errore){
                Console.WriteLine(errore.Message);
            }finally{
                Console.WriteLine("Fine Programma!");
            }
            
           
           
            
        }
    }
}