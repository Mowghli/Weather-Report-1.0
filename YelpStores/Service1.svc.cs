using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Newtonsoft.Json;

namespace YelpStores
{
    public class Service1 : IService1
    {
        public string YelpStoreFinder(string PlaceName, string location)      // method for finding the nearest store to the provided location
        {
            // NOTE: string PlaceName contains the name of the store. The user of this service wants to find the store with the name in PlaceName that is nearest to their given location
            try             // try catch statement for catching exceptions
            {
                Businesses businesses = new Businesses();           // Business class object to store parsed json response from API
                WebClient wc = new WebClient();         // create WebClient object
                string t;           // temporary variable
                var strSearch = "https://api.yelp.com/v3/businesses/search?term=" + PlaceName + "&location=" + location + "&sort_by=distance";      // string to contain the API call
                wc.Headers.Add("Authorization", "Bearer 'APIKEY'");     // string to contain Authorization header
                var strSearchResponse = wc.DownloadString(strSearch);           // calling the api and storing the json response into a string variable
                businesses = JsonConvert.DeserializeObject<Businesses>(strSearchResponse);      // parsing json response and storing data into business objec
                t = businesses.businesses[0].location.display_address[0];       // storing the first line of address of the nearest store
                for (int i = 1; i < businesses.businesses[0].location.display_address.Length; i++)      // for loop for traversing the display_address field, to get the complete address
                {
                    t = t + ", " + businesses.businesses[0].location.display_address[i];
                }
                t = businesses.businesses[0].name+", "+ t;      // Appending the correct/official name of the store into temporary string
                return t;           // return string t, that contains name and complete address of nearest store
            }
            catch (Exception e)             // catch statement to store exceptions
            {
                 return ("Error: " + e.Message);        // retrun error message if error occurs   
            }
        }



        public class Businesses             // Class to store the parsed json data
       {
            public Business[] businesses { get; set; }  // array of class object
            public int total { get; set; }      // integer to store the total number of stores found. They are sorted in terms of distance, so we only need the first store
            public Region region { get; set; }  // Region class object to store coordinates of the store
            public class Region     // Region class to store coordinates of the store
            {
                public Center center { get; set; }      // class object to store coordinates of the store
                public class Center                 // class object to store coordinates of the store
                {
                    public string latitude { get; set; }        // latitude 
                    public string longitude { get; set; }       // longitude
                }
            }
            public class Business               // class to store details about the store
            {
                    public string id { get; set; }      // store ID
                    public string alias { get; set; }       // store alias
                    public string name { get; set; }        // store name
                    public string imgUrl { get; set; }      // store image url
                    public Boolean is_closed { get; set; }      // denotes if store is open, at the time of API call
                    public string url { get; set; }     // website of the store
                    public int review_count { get; set; }       // number of yelp reviews on the store
                    public Category[] categories { get; set; }  // class of categories of the store
                    public float rating { get; set; }       // rate of the store
                    public Coordinates coordinates { get; set; }        // coordinates of the store
                    public string[] transactions { get; set; }      // list of transactions of the store
                    public string price { get; set; }               // denotes how expensive are the items in the store
                    public Location location { get; set; }      // class object stores the location details
                    public string phone { get; set; }       // phone number of store
                    public string display_phone { get; set; }       // display phone number of store
                public float distance { get; set; }             // distance from the location to the store
                    public class Category       // List of category title and alias pairs 
                {
                        public string alias { get; set; }   // Alias of a category
                    public string title { get; set; }   // Title of a category for display purpose.
                }
                public class Coordinates    // coordinates of store
                {
                        public float latitude { get; set; }     // latitude of store
                        public float longitude { get; set; }        // longitude of store
                }
                public class Location           // location of store
                {
                        public string address1 { get; set; }        // address line 1
                        public string address2 { get; set; }        // address line 2
                        public string address3 { get; set; }        // address line 3
                        public string city { get; set; }            // city of store
                        public string zip_code { get; set; }        // zipcode of store
                        public string country { get; set; }         // country of store
                        public string state { get; set; }       // state where store is located at
                        public string[] display_address { get; set; }       // display address string array of store
                }
                

            }
        }
        
    }
}
