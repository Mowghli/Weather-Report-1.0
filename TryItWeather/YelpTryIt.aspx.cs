using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TryItWeather
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)        // button click to invoke the Yelp Service
        {
            string temp;                // temporary string
            YelpService.Service1Client yelpservice = new YelpService.Service1Client();      // creatinga a ServiceClient object
            temp = yelpservice.YelpStoreFinder(placename.Text, location.Text);              // calling the YelpStoreFinder(placename.Text, location.Text); method, and storing the address into temp
            if (temp.Contains("Error"))         // checking if temp contains an error message
            {
                if (temp.Contains("bounds"))        // checking if the error is an array out of bounds error
                {
                    StoreNameAndLocation.Text = "";
                    ErrorLabel.Text = "Please specify a proper store name. No such store found nearby";     // displaying the error
                }
                else if (temp.Contains("400"))  // checking if error was a bad request
                {
                    StoreNameAndLocation.Text = "";
                    ErrorLabel.Text = "Please specify your specific location. No such store found nearby";  // displaying the error
                }
                else
                {
                    StoreNameAndLocation.Text = "";
                    ErrorLabel.Text = temp;     // displaying the error
                }

            }
            else if (String.IsNullOrEmpty(placename.Text))      // checking if the store name text is empty, in which case the APi will return the nearest store
            {
                StoreNameAndLocation.Text = temp;       // displaying store name and address
                ErrorLabel.Text = "Please specify a proper store name. The above result is the closest store";  // displaying an error
            }
            else                // if there are no errors
            {

                StoreNameAndLocation.Text = temp;       // displaying store name and address 
                ErrorLabel.Text = "No Errors";              // displaying no errors
            }
        }
    }
}