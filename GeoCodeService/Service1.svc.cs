using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Newtonsoft.Json;
using System.Net;

namespace GeoCodeService
{

    public class Service1 : IService1
    {
        public string[] GeoCoder(string address)      // method to determine zipcode and coordinates from given address
        {
            List<string> Coordinates = new List<string>();  // string list that will store the coordinates and zipcode
            string[] temp;      // temporary string array needed to modify the given address for the api call
            string tempo;       // temporary string variable needed to modify the given address for the api call
            int t=0;        // temporary variable
            Address adddress = new Address();       // Address class object used to parse json response
            try                 // try catch statement to catch exceptions
            {
                temp = address.Split(new[] { ' ' });    // splitting the string containing address, based on whitespaces, storing each string into temp
                tempo = temp[0];            // storing the first element of temp into tempo
                for (int i = 1; i < temp.Length; i++)   // for loop for copying all elements in temp into tempo, adding in "+" for the api call format
                {
                    tempo = tempo + "+" + temp[i];
                }
                WebClient wc = new WebClient(); // creating WebClient object
                var strSearch = "https://maps.googleapis.com/maps/api/geocode/json?address=" + tempo + "&key=KEY";  // string containing api call
                var strSearchResponse = wc.DownloadString(strSearch);       // calling the api and storing json response into string variable
                adddress = JsonConvert.DeserializeObject<Address>(strSearchResponse);   // parsing json response and storing it into address object
                for (int i = 0; i < adddress.results[0].address_components.Length; i++) // for loop for traversing the address components in the address object
                {
                    if (adddress.results[0].address_components[i].types.Contains("postal_code"))    // looking for the postal code address component
                    {
                        t = i;
                        break;
                    }
                }
                Coordinates.Add(adddress.results[0].address_components[t].long_name);   // writing the zipcode into the first element of list Coordinates
                Coordinates.Add("|"+adddress.results[0].geometry.location.lat); // writing the latitude into the second element of list Coordinates
                Coordinates.Add("|" + adddress.results[0].geometry.location.lng);   // writing the longitude into the third element of list Coordinates
            }
            catch (Exception e)                 // catch statement for catching exceptions
            {
                Coordinates.Add(e.Message);     // writing the error message into the first element of list Coordinates
            }
            return Coordinates.ToArray();       // converting list Coordinates into string array and returning it
        }


        public class Address            // Address object used to parse json response
        {
            public Result[] results { get; set; }       // Class object to store results
            public string status { get; set; }          // string to store status of api call

            public class Result             // class to staore results
            {
                public Address_Component[] address_components { get; set; }     // array of address_component class objects
                public string formatted_address { get; set; }       // string containing the formatted address
                public Geometry geometry { get; set; }      // Geometry class object
                public string placeID { get; set; }     // string to store place ID
                public string[] types { get; set; }     // type of address
                public class Address_Component          // Class that contains details of the address (like postal code, route, street_number, etc)
                {
                    public string long_name { get; set; }   // full name of address 
                    public string short_name { get; set; }  // abbreviated name of address
                    public string[] types { get; set; }     // type of address
                }
                public class Geometry               // Class that contains details like coordinates
                {
                    public Location location { get; set; }      // class object that contains coordinates
                    public string location_type { get; set; }   // type of location
                    public Viewport viewport { get; set; }      // class that contains coordinates in terms of orientations

                    public class Location       // class object that contains coordinates
                    {
                        public string lat { get; set; } // general latitude
                        public string lng { get; set; } // general longitude
                    }
                    public class Viewport       // contains the recommended viewport for displaying the returned result
                    {
                        public NorthEast northeast { get; set; }        // contains coordinates from northeast corner
                        public SouthWest southwest { get; set; }        // contains coordinates from southwest corner
                        public class NorthEast      // contains coordinates from northeast corner
                        {
                            public string lat { get; set; }
                            public string lng { get; set; }
                        }
                        public class SouthWest              // contains coordinates from southwest corner
                        {
                            public string lat { get; set; }
                            public string lng { get; set; }
                        }
                    }
                }
            }


        }

    }
}
