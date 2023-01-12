using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

HttpClient client = new HttpClient(); //this allows us to make the requests

Console.WriteLine("************** Exercise 1 ****************");
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

Console.WriteLine("************** Exercise 2 ****************");

Console.WriteLine("Please enter a city: ");
var cityName = Console.ReadLine();

var apiKey = "93007e58e0bbde76562e598a10e07b40";

string weatherByCityURL = $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={apiKey}&units=imperial ";
string weatherResponse = client.GetStringAsync(weatherByCityURL).Result;
var currWeather = JObject.Parse(weatherResponse);

Console.WriteLine($"The current temperature in {cityName} is {currWeather["main"]["temp"]} degrees.");