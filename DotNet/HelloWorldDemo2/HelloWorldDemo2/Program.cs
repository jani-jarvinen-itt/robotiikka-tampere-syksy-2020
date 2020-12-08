using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualBasicKirjasto;

namespace HelloWorldDemo2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Moikka Visual Studiosta!");

            Laskenta laskenta = new Laskenta();
            int summa = laskenta.Summa(100, 234);

            Console.WriteLine("Summa on: " + summa);

            Console.ReadLine();
        }
    }
}
