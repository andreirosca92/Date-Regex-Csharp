using System;
using System.Text.RegularExpressions;

namespace DateRegex{
    class  Date{
        static string[] nomiMese = {"Gennaio", "Febbraio", "Marzo", "Aprile", "Maggio", "Giugno", "Luglio", "Agosto", "Settembre", "Ottobre", "Novembre", "Dicembre"};
        private int g;
        private int m;

        private int a;

        private TimeZone timezone;
        public int G 
        {
            get => g;
            set {
                if (value > GiorniMese() || value < 1)
                    throw new InvalidOperationException();
                else
                {
                        g = value; // G = value => loop infinito di chiamate => stack Overflow
                }
            }
        }
        public int M{
            get => m;
            set{
                if(value > 12 || value < 1)
                    throw new InvalidOperationException("Valore mese non valido");
                else{
                    m = value;
                }
            }
        }
        public int A{
            get => a;
            set{
                if(value < 1 )
                    throw  new InvalidOperationException("L'anno non puo' essere minore di 1");
                else{
                    a = value;
                }
            }
        }
        public TimeZone TIMEZONE{
            get => timezone;
            set {
                timezone = value;
                
            }
        }
      

        int GiorniMese(){
            // meglio usare gli attributi risparmio tempo
            switch(m){
                case 4:
                case 6:
                case 9:
                case 11:
                    return 30;
                case 2:
                    return 28 + (a % 400 == 0 || (a % 4 == 0 && a % 100 != 0)? 1 : 0);
                default:
                    return 31;
            }
        }
         public Date(int _g, int _m, int _a, TimeZone _timezone){
            G =_a; M = _m; G = _g; TIMEZONE = _timezone;
        }
        public Date():this(1,1,1, TimeZone.IT){}
        private static int MeseInt(string m){
            return Array.IndexOf(nomiMese, Char.ToUpper(m[0]) + m.Substring(1).ToLower()) + 1;
        }
        public Date(int g, string m, int a, TimeZone timezone){
            string pattern =@"\b(?i)(?:gen(?:naio)?|feb(?:braio)?|mar(?:zo)?|apr(?:ile)?|mag(?:gio)?|giu(?:gno)?|lug(?:lio)?|ago(?:sto)?|sett(?:embre)?|nov(?:embre)?|dic(?:embre))(?-i)$";
            Regex rgx = new Regex(pattern);
            if(m.Length == 0) throw new IndexOutOfRangeException("Mese vuoto");
            else if(rgx.IsMatch(m)){
                    this.g = g;
                    this.m = MeseInt(m);
                    this.a = a; 
                    this.timezone = timezone;
                }
            else if (!rgx.IsMatch(m)){
                    throw new Exception("Sbagliato formato mese");
            }
            
            
        }
        public Date(string laData, TimeZone timezone){
            string pattern =@"[-/]";
            Regex rgx = new Regex(pattern);
            
            string[] n =rgx.Split(laData);
            if(n.Length != 3 || n[0].Length == 0 || n[1].Length == 0 || n[2].Length != 2)
                throw new InvalidOperationException();
            A = int.Parse(n[2]);
            M = int.Parse(n[1]);
            G = int.Parse(n[0]);
            TIMEZONE = timezone;
            
            
            
        }
        public override string ToString()
        {
            if(timezone == TimeZone.IT){
                return $"IT: {G}/{M}/{A}";
            }else{
                return $"USA: {M}/{G}/{A}";
            }
            
        }
    }
}