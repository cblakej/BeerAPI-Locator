using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace BeerAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            // Made the JSON with the Data from the URL

            var client = new HttpClient();

            var beerFullAPI = "http://api.brewerydb.com/v2/beers/?key=40458894fcdedcacd895893ec611396a";
            var beerAPI = "http://api.brewerydb.com/v2/beer/random/?key=40458894fcdedcacd895893ec611396a";

            // Usable data from an http response

            var beerFullResponse = client.GetStringAsync(beerFullAPI).Result;
            JObject beerFullParsed = JObject.Parse(beerFullResponse);
            var beers = JsonConvert.DeserializeObject<BeerList>(beerFullResponse);

            foreach(var beer in beers.data)
            {
                // Key
                Console.WriteLine(beer.id);
                // Value
                Console.WriteLine(beer.name);
                Console.WriteLine();
            }

            var beerResponse = client.GetStringAsync(beerAPI).Result;
            JObject beerParsed = JObject.Parse(beerResponse);

            var fullData = beerFullParsed.SelectToken("");
            var data = beerParsed.SelectToken("");



            Console.WriteLine();


        }
    }
}
