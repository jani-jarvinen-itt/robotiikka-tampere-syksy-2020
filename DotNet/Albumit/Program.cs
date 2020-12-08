using System;
using System.Net.Http;
using Newtonsoft.Json;

namespace Albumit
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // haetaan data JSON-muodossa palvelimelta
            HttpClient client = new HttpClient();
            string url = "http://jsonplaceholder.typicode.com/albums";
            string data = client.GetAsync(url).Result.
                            Content.ReadAsStringAsync().Result;
            // Console.WriteLine(data);

            // kysytään käyttäjältä userId-arvo
            Console.WriteLine("Anna User Id -numero:");
            int userId = int.Parse(Console.ReadLine());

            // muunnetaan JSON-data olioksi ja tulostetaan otsikot
            // komento: "dotnet add package Newtonsoft.Json"
            AlbuminTiedot[] albumit = JsonConvert.DeserializeObject<AlbuminTiedot[]>(data);
            foreach (AlbuminTiedot albumi in albumit)
            {
                if (albumi.userId == userId)
                {
                    Console.WriteLine(albumi.title);
                }
            }
        }
    }

    public class AlbuminTiedot
    {
        public int userId { get; set; }

        public int id { get; set; }

        public string title { get; set; }
    }
}
