using System;


namespace DateRegex{
    class Program{
        static void Main(string[] args){
            Date d1 = new Date(20,4,23, TimeZone.USA);
            try{
                Date d2 = new Date("15-10-23", TimeZone.IT);
                Date d3 = new Date("15/10/23", TimeZone.IT);
                Date d4 = new Date(15, "Febbraio", 20, TimeZone.IT);
                // Data d5 = new Data(15, "", 20, TimeZone.IT);
                Date d6 = new Date(20, "Marzo", 30, TimeZone.IT);
                Date d7 = new Date(20, "gennaio", 30, TimeZone.IT);
                Date d8 = new Date(20, "dicembre", 30, TimeZone.IT);
                Date d9 = new Date(20, "DICEMBRE", 23, TimeZone.IT);
                Console.WriteLine(d1);
                Console.WriteLine(d2);
                Console.WriteLine(d3);
                Console.WriteLine(d4);
                // Console.WriteLine(d5);
                Console.WriteLine(d6);
                Console.WriteLine(d7);
                Console.WriteLine(d8);
                Console.WriteLine(d9);

            }catch(InvalidOperationException errore){
                Console.WriteLine(errore.Message);
            }catch(IndexOutOfRangeException errore){
                Console.WriteLine(errore.Message);
            }
            catch(Exception errore){
                Console.WriteLine(errore.Message);
            }
            finally{
                Console.WriteLine("Fine Programma!");
            }
            
           
           
            
        }
    }
}