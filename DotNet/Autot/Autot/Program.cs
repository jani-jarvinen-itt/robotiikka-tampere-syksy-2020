using System;

namespace Autot
{
    public class Auto
    {
        public string Väri { get; set; }

        public int OvienMäärä { get; set; }

        public int Huippunopeus { get; set; }

        public string MoottorinTyyppi { get; set; }

        public void Käynnistä()
        {

        }

        public void Kiihdytä()
        {

        }

        public void Jarruta()
        {

        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Auto oma = new Auto();
            oma.Väri = "Sininen";
            oma.OvienMäärä = 5;
            oma.Huippunopeus = 210;
            oma.MoottorinTyyppi = "hybridi";
            oma.Käynnistä();

            Auto naapurin = new Auto();
            naapurin.Väri = "harmaa";
            naapurin.OvienMäärä = 4;
            naapurin.Huippunopeus = 170;
        }
    }
}
