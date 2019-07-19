using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace DistCalcService
{
    public class Service1 : IService1
    {
        public string[] DistanceCalculator(string source, string destination)      // method to get the distance between two given locations
        {
            List<string> Distances = new List<string>();            // string that will contain the distance and duration
            string[] temp1;                         // temporary string array needed for generating the api call link
            string[] temp2;                         // temporary string array needed for generating the api call link
            string tempo1;                          // temprorary string needed for generating the api call
            string tempo2;                          // temprorary string needed for generating the api call
            int t = 0;          // temporary variable
            MapMatrix distance = new MapMatrix();   // creating objec of class MapMatrix, needed to parse json response
            try                     // try-catch statement to catch exceptions
            {
                temp1 = source.Split(new[] { ' ' });        // splitting the source location string, based on whitespaces
                tempo1 = temp1[0];      // storing the first element in splitted string into tempo1
                for (int i = 1; i < temp1.Length; i++)      // for loop for generating the source location of proper format
                {
                    tempo1 = tempo1 + "+" + temp1[i];
                }
                temp2 = destination.Split(new[] { ' ' });   // splitting the destination location string, based on whitespaces
                tempo2 = temp2[0];                      // storing the first element in splitted string into tempo1
                for (int i = 1; i < temp2.Length; i++)  // for loop for generating the destination location of proper format
                {
                    tempo2 = tempo2 + "+" + temp2[i];
                }
                WebClient wc = new WebClient();         // creating a WebClient object
                var strSearch = "https://maps.googleapis.com/maps/api/distancematrix/json?units=imperial&origins="+tempo1+"&destinations="+tempo2+"&key='KEY'";   // generating the api call
                var strSearchResponse = wc.DownloadString(strSearch);   // calling the api, and storing the json response into a string variable
                distance = JsonConvert.DeserializeObject<MapMatrix>(strSearchResponse); // parsing the json response and storing parsed data into object distance
                Distances.Add(distance.rows[0].elements[0].distance.text);  // storing the distance information between source and destinaction locations into the first element of Distance list
                Distances.Add(distance.rows[0].elements[0].duration.text);  // storing the time taken to reach destination from source, into the second element of list Distance
            }
            catch (Exception e)         // catch statement to catch an exception
            {
                Distances.Add("You may have entered a vague or incorrect address. Please specify the complete and correct addresses."); // writing an error statement into the first element of list Distance
            }
            return Distances.ToArray(); // converting list Distance into string array, and returning it
        }

        public class MapMatrix              // class for storing details about distance and time duration to reach one location to other location
        {
            public string[] destination_addresses;      // string array containing the destination address. Not needed since we are assing the destination as an argument
            public string[] origin_addresses;   // string array containing the source address. Not needed since we are assing the source as an argument
            public string status;           // string to store status of the api call
            public Rows[] rows;         // class object to store rows
            public class Rows
            {
                public Elements[] elements;     // class object to store elements
                public class Elements           // element class to store details such as distance and duration
                {
                    public Distance distance;   // Distance class object
                    public Duration duration;   // Duration class object
                    public string status;       // string to store status of the api call
                    public class Distance       // Distance class that will provide distance between source and destination location
                    {
                        public string text; // text form of distance
                        public int value;   // integer form of distance
                    }
                    public class Duration   // Duration class that will provided time taken to reach destination location from source location
                    {
                        public string text; // text form of duration
                        public int value;   // integer form of duration
                    }
                }
            }

        }
        
    }
}
