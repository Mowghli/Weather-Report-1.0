using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace TryItWeather
{
    public partial class GeoCoderTryIt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)        // button clicked to invoke GeoCoder Service
        {
            WebClient wc = new WebClient();     // WebClient object
            try                 // try catch statement to catch exception errors
            {
                string xml = wc.DownloadString("http://webstrar3.fulton.asu.edu/page4/Service1.svc/GeoCoder?address=" + Address.Text); // downloads the REST API response into string variable
                string[] thing;         // string array
                thing = xml.Split(new[] { '|' });       // splitting the REST API response and storing each string to "thing"
                if (thing.Length > 1)       // checking if there are no errors. If the size of thing is 1, there an error has occured. "thing" must have a size of 3 for no errors
                {
                    Zip.Text = thing[0].ToString();     // displaying Zipcode
                    Lat.Text = thing[1].ToString();     // displaying Latitude 
                    Lon.Text = thing[2].ToString();     // displaying Longitude
                    ErrorCode.Text = "No Errors";       // displaying no errors
                }
                else if (thing[0].Contains("Index"))      // if the zipcode is incorrect
                {
                    Lat.Text = "";              // setting latitude to ""
                    Lon.Text = "";              // setting longitde to ""
                    Zip.Text = "";              // setting zipcode to ""
                    ErrorCode.Text = "Error, please input the correct and complete address";     // displaying error message
                }
                else if (thing[0].Contains("400"))      // if there is a 400 error
                {
                    Lat.Text = "";              // setting latitude to ""
                    Lon.Text = "";              // setting longitde to ""
                    Zip.Text = "";              // setting zipcode to ""
                    ErrorCode.Text = "Error, please input the correct and complete address";     // displaying error message
                }
                else                                // if there are errors
                {
                    Lat.Text = "";              // setting latitude to ""
                    Lon.Text = "";              // setting longitde to ""
                    Zip.Text = "";              // setting zipcode to ""
                    ErrorCode.Text = thing[0];     // displaying error code
                }
            }
            catch (Exception g)     // catch statement to catch exepctions
            {
                Lat.Text = "";      // setting latitude to ""
                Lon.Text = "";      // setting longitde to ""
                Zip.Text = "";          // setting zipcode to ""
                ErrorCode.Text = g.Message;     // displaying error message
            }
        }
    }
}