using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Newtonsoft.Json;

namespace WeatherCondition
{
    public class Service1 : IService1
    {
        public string[] Weather5day(string zipcode)      // method to get 5 day forecast at the given zipcode
        {
            List<string> WeatherData = new List<string>();  // string list to store weather forecast data
            Weatherforcast obj = new Weatherforcast();  // Weatherforcast object to store structured weather forecast data            // 
            WebContentDownloader.ServiceClient ContentDownloader = new WebContentDownloader.ServiceClient();    // ServiceClient object for downloading a webpage text
            int i;      // integer
            int index = 0;
            string url = "http://api.openweathermap.org/data/2.5/forecast?zip="+zipcode+"&APPID='KEY'&units=imperial";   // string that will be used to call the weather API
            {
                try                         // try catch statement for catching exceptions
                {
                    var jsonContent = ContentDownloader.GetWebContent(url); // Retrieving json object and storing it in variable "json"
                    obj = JsonConvert.DeserializeObject<Weatherforcast>(jsonContent);          // Deserializing the json data and storing it into obj
                    {
                        index = CalcBestTime(obj);
                        WeatherData.Add(obj.city.name + "|" + obj.cod + "|" + obj.city.country);        // encoding certain features of the data into the first element of WeatherData[]
                        WeatherData.Add(obj.city.coord.lat.ToString() + "|" + obj.city.coord.lon.ToString() + "|" + index.ToString());   // encoding certain features of the data into the second element of WeatherData[]
                        for (i = 0; i < obj.cnt; i++)
                        {
                            WeatherData.Add(obj.list[i].dt_txt + "|" + obj.list[i].main.temp + "F|" + obj.list[i].main.pressure // encoding certain features of the data into the each element of WeatherData[], 
                            + "hPa|" + obj.list[i].main.sea_level + "hPa|" + obj.list[i].wind.deg.ToString() + "deg|" + obj.list[i].main.humidity.ToString() + "%|"+obj.list[i].wind.speed.ToString()+"m/s|" ); //each element being the weather associated with a day and time

                        }
                        
                    }
                }
                catch(Exception e)      // catch statement in case an exception occurs
                {
                    WeatherData.Add(e.Message); // storing the error message into the WeatherData list
                }
            }
            return WeatherData.ToArray(); // converting WeatherData list into an array and returning that to the function that called it
        }
        public int CalcBestTime(Weatherforcast obj)     // method to get the index of the time at which the weather is best for going out
        {
            int size = obj.list.Length;                 // getting the number of times at which weather is recorded
            int index = 0;                          // index
            int[] points = new int[size];           // points table for each time. The greater the points for a particular time, the better it's weather is, for going out within the zipcode 
            int i;                                  // integer
            float avg_temp=0;                         // average temperature variable
            float avg_cloud_cover = 0;              // average cloud cover variable
            float avg_humidity=0;                   // average humidity variable
            for (i = 0; i < size; i++)              // setting the points table to 0
            {
                points[i] = 0;
            }
            for (i = 0; i < size; i++)      // loop for calculating the average variables
            {
                avg_temp = avg_temp + obj.list[i].main.temp;
                avg_cloud_cover = avg_cloud_cover + obj.list[i].clouds.all;
                avg_humidity = avg_humidity + obj.list[i].main.humidity;
            }
            avg_temp = avg_temp / size;         // calculating average temperature
            avg_cloud_cover = avg_cloud_cover / size;       // calculating average cloud cover
            avg_humidity = avg_humidity / size;             // calculaing average humdity
            for (i = 0; i < size; i++)
            {
                if (obj.list[i].main.temp <= 86 && obj.list[i].main.temp >= 59)         // checking if temperature is within the suitable range
                {
                    points[i]++;            // incrementing points for the particular time of forecast
                }
                if (obj.list[i].clouds.all <= avg_cloud_cover)          // checking if cloud cover is less than average, which is suitable
                {
                    points[i]++;            // incrementing points for the particular time of forecast
                }
                if (obj.list[i].main.humidity <= avg_humidity)          // checking if humidity is less than average. Assumption here is that less humidity is better
                {
                    points[i]++;                // incrementing points for the particular time of forecast
                }
                if (avg_temp < 32 && obj.list[i].main.temp > avg_temp)          // checking if average temperature is less than suitable, and that the temperature of the particular time is more than the average temperature
                {
                    points[i]++;                // incrementing points for the particular time of forecast
                }
                if (avg_temp > 91.4 && obj.list[i].main.temp < avg_temp)        // checking if average temperature is greater than is suitable, and that the temperature of the particular time is less than the average temperature
                {
                    points[i]++;                // incrementing points for the particular time of forecast
                }

            }
            int max = 0;            // setting a max variable to 0
            for (i = 0; i < size; i++)      // for loop for checking the earliest time at which the weather is best for going outdoors
            {
                if (max <= points[i])
                {
                    index = i;
                    max = points[i];
                }
            }
            return index;       // returning the index of the time at which the weather forecast is the best, among all given times 

        }

        public class Weatherforcast     // class for storing the structured json data
        {
            public string cod { get; set; }     // code
            public string message { get; set; } // message
            public int cnt { get; set; }        // number of lines of json, a line corresponding to the weather at a particular date and time
            public List[] list { get; set; }    // array object of List
            public City city { get; set; }      // object of class City

            public class List                   // stores weather condition details associated with each date and time
            {
                public float dt { get; set; }   // Date and time forecasted in unix
                public Mainn main { get; set; }     // object of class Main
                public Weather[] weather { get; set; }  // object of class Weather
                public Clouds clouds { get; set; }       // object of class Cloud
                public Wind wind { get; set; }      // object of class Wind
                public Sys sys { get; set; }        // object of class Sys
                public string dt_txt { get; set; }  // date and time forecasted
                public class Mainn                  // class for storing details of the weather, such as temperature, pressure, etc
                {
                    public float temp { get; set; } // average temperature
                    public float temp_min { get; set; } // minimum temperature
                    public float temp_max { get; set; } // maximum temperture
                    public float pressure { get; set; } // pressure
                    public float sea_level { get; set; }    // sea level
                    public float grnd_level { get; set; }   // ground level
                    public int humidity { get; set; }   // humidity
                    public float temp_kf { get; set; }  // Internal parameter

                }
                public class Weather            // class for storing weather condition details, which is not used by the function Weather5day(string zipcode)
                {
                    public int id { get; set; } // weather condition ID
                    public string main { get; set; }    // Group of weather parameters (Rain, Snow, Extreme etc.)
                    public string description { get; set; } //  Weather condition within the group
                    public string icon { get; set; }    // Weather icon id
                }
                public class Clouds     // class to store cloudiness value
                {
                    
                    public int all { get; set; }    // cloudiness value
                }
                public class Wind       // class to store wind details
                {
                    public float speed { get; set; }        // speed of wind
                    public float deg { get; set; }      // direction of wind
                }
                public class Sys    
                {
                    public string pod { get; set; }     // period of day
                }
            }
            public class City               // class for details of city
            {
                public int id { get; set; }     // id of city
                public string name { get; set; }    // name of city
                public Coord coord { get; set; }        // coordinates of city
                public string country { get; set; }     // country of city
                public int timezone { get; set; }       // timezone of city
                public class Coord
                {
                    public float lat { get; set; }  // latitude of city
                    public float lon { get; set; }  // longitude of city
                }

            }

        }

    }
}
