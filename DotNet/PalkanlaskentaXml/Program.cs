using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;

namespace PalkanlaskentaXml
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Aloitetaan XML-tiedostojen käsittely.");

            // USD-valuuttakurssin haku
            float usdKurssi = 1.0f;
            XmlDocument xmldoc = new XmlDocument();
            string xmlTiedosto = @"C:\Robotiikka\DotNet\PalkanlaskentaXml\Valuuttakurssi.xml";
            FileStream fs = new FileStream(xmlTiedosto, FileMode.Open, FileAccess.Read);
            xmldoc.Load(fs);

            XmlNamespaceManager nsmgr = new XmlNamespaceManager(xmldoc.NameTable);
            nsmgr.AddNamespace("ns", "http://www.ecb.int/vocabulary/2002-08-01/eurofxref");
            XmlNodeList xNode = xmldoc.DocumentElement.SelectNodes("ns:Cube/ns:Cube/ns:Cube", nsmgr);
            // Console.WriteLine(xNode.Count);

            foreach (XmlNode xndNode in xNode)
            {
                string valuutta = xndNode.Attributes["currency"].InnerText;
                if (valuutta == "USD") {
                    string kurssi = xndNode.Attributes["rate"].InnerText;
                    CultureInfo enUs = new CultureInfo("en-US");
                    usdKurssi = float.Parse(kurssi, enUs);

                    Console.WriteLine("USD-kurssi: " + usdKurssi);
                }
            }

            // palkkatietojen haku
            xmldoc = new XmlDocument();
            xmlTiedosto = @"C:\Robotiikka\DotNet\PalkanlaskentaXml\Palkanlaskenta.xml";
            fs = new FileStream(xmlTiedosto, FileMode.Open, FileAccess.Read);
            xmldoc.Load(fs);

            List<TulosOlio> tulokset = new List<TulosOlio>();

            XmlNodeList xmlnode = xmldoc.GetElementsByTagName("palkka");
            for (int i = 0; i <= xmlnode.Count - 1; i++)
            {
                string palkka = xmlnode[i].ChildNodes.Item(0).InnerText;
                string nimi = xmlnode[i].ChildNodes.Item(1).InnerText;
                string päiväys = "";
                if (xmlnode[i].ChildNodes.Count > 2) {
                    päiväys = xmlnode[i].ChildNodes.Item(2).InnerText;
                }

                Console.WriteLine(nimi + ": " + palkka);

                float palkkUsd = float.Parse(palkka) * usdKurssi;

                tulokset.Add(new TulosOlio() {
                    personName = nimi,
                    salary = new TulosOlioPalkkatiedot() {
                        monthly = palkkUsd
                    },
                    hireDate = päiväys
                });
            }

            // JSON-tallennus
            string jsonData = JsonSerializer.Serialize(tulokset);
            // Console.WriteLine(jsonData);

            string kohdeTiedosto = @"C:\Robotiikka\DotNet\PalkanlaskentaXml\Tulokset.json";
            File.WriteAllText(kohdeTiedosto, jsonData);
        }
    }
}
