using System;
using System.IO;

namespace Henkilöt
{
    class Program
    {
        static void Main(string[] args)
        {
            bool lopeta = false;
            string data = "";
            while (!lopeta)
            {
                // kysytään henkilön tiedot
                Console.WriteLine("Anna henkilön nimi:");
                string nimi = Console.ReadLine();

                if (nimi == "")
                {
                    lopeta = true;
                }
                else
                {
                    Console.WriteLine("Anna henkilön ikä:");
                    string ikä = Console.ReadLine();

                    data += nimi + ";" + ikä + "\r\n";
                }
            }

            // kirjoitetaan tiedot tiedostoon
            string tiedosto = @"C:\Robotiikka\DotNet\Henkilöt\Nimet.txt";
            File.WriteAllText(tiedosto, data);
            Console.WriteLine("Nimi kirjoitettu tiedostoon.");

            // vaihe 2: luetaan nimet tiedostosta
            string[] rivit = File.ReadAllLines(tiedosto);
            foreach (string rivi in rivit)
            {
                int indeksi = rivi.IndexOf(";");
                string ikäTekstinä = rivi.Substring(indeksi + 1);
                int ikäNumerona = int.Parse(ikäTekstinä);

                if (ikäNumerona > 30)
                {
                    string henkilöNimi = rivi.Substring(0, indeksi);
                    Console.WriteLine(henkilöNimi);
                }
            }
        }
    }
}
