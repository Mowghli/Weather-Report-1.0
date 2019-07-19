using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TryItWeather
{
    public partial class DistanceCalcTryIt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)        // button clicked to invoke the Distance Calculator service
        {
            string[] result;                // string to store the results of using the Distance Calculator Service
            DistanceCalcService.Service1Client DistService = new DistanceCalcService.Service1Client();      // creting a ServiceClient object
            result = DistService.DistanceCalculator(Source.Text, Destination.Text);     // calling the DIstanceCalcuator() method and storing results into "result" array
            if (result.Length > 1)      // checking if the size of the result array exceeds 1, in which case it is not n error
            {
                Distance.Text = result[0];      // displaying the distance from the source location to destination location
                Time.Text = result[1];          // displaying the duration taken to go from source to destination location
                Errors.Text = "No Errors";      // displaying no errors
            }
            else                        // if the size of result array is 1, then it means that error has occured, and the error message is in result array
            {
                Distance.Text = "";     
                Time.Text = "";
                Errors.Text = result[0];    // displaying the error code
            }
        }
    }
}