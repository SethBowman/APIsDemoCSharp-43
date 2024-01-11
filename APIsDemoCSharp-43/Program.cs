using Newtonsoft.Json.Linq;
﻿
//Create an instance of HTTPClient, this is what actually makes the api call
var client = new HttpClient();

//Build an api url from where the api call comes from
var kanyeURL = "https://api.kanye.rest/";

//Using the HTTPClient instance we made above
//Send a GET request to the url created above, this is going to give us back a string of json
var kanyeResponse = client.GetStringAsync(kanyeURL).Result;

//Parse the JSON response we just got back into JOject, we do this so we can access certain pieces of the JSON
//In this case we will be getting the value of "quote" which we be will actual quote itself and NOT the whole JSON body
//Without ToString() it will be of type JToken, so we could never use it as a string
//var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();
var kanyeQuote = JObject.Parse(kanyeResponse)["quote"].ToString();

Console.WriteLine(kanyeQuote);

//using api key section

//Grab appsettings file
var appsettingsText = File.ReadAllText("appsettings.json");

//Get the api key from the appsettings file using it's name "apiKey"
var apiKey = JObject.Parse(appsettingsText).GetValue("apiKey").ToString();

//Build the api url using the provided params you chose (I chose the zip code option) along with the api key
var apiURL = $"http://api.openweathermap.org/data/2.5/weather?zip=35091&appid={apiKey}&units=imperial";
