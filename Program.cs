using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

HttpClient client = new HttpClient(); //this allows us to make the requests


string ronSwansonURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
string ronResponse = client.GetStringAsync(ronSwansonURL).Result;

var ronQuote = JArray.Parse(ronResponse);

string kanyeURL = "https://api.kanye.rest/";
string kanyeResponse = client.GetStringAsync(kanyeURL).Result;

var kanyeObject = JObject.Parse(kanyeResponse).GetValue("quote").ToString();

for (int i = 0; i < 5; i++)
{
    Console.WriteLine(ronQuote[0]);
    Console.WriteLine();
    Console.WriteLine(kanyeObject);
}