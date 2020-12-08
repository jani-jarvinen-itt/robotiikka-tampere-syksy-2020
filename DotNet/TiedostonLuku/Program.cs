using System;
using System.IO;

namespace TiedostonLuku
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string tiedostoNimi = @"C:\Robotiikka\DotNet\TiedostonLuku\Luvut.txt";
            string[] rivit = File.ReadAllLines(tiedostoNimi);

            int summa = 0;
            foreach (string rivi in rivit)
            {
                int luku = int.Parse(rivi);
                summa = summa + luku;
            }

            Console.WriteLine("Tiedoston lukujen summa on: " + summa);
        }
    }
}
