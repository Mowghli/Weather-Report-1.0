using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TryItWeather
{
    public partial class WeatherForecastTryIt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)        // function invoked on button click
        {
            WeatherService.Service1Client ForcastService = new WeatherService.Service1Client(); // creating a ServiceClient object to get weather forecast
            string[] data;                      // string array to get the weather forecast data
            List<string> tableIDs = new List<string>();
            int i, best;                              // integer variable
            best = 0;
            data = ForcastService.Weather5day(TextBox1.Text);        // calling Weather5day() to get weather forecast data and store it into "data"
            if (data.Length > 1)                // checking if the number of elements in "data" exceeds 1
            {
                var output = data[0].Split(new[] { '|' });      // splitting the strings in data[0], and storing them into "output" string array
                City.Text = output[0];                              // displaying the city
                Country.Text = output[2];                           // displaying the country
                output = data[1].Split(new[] { '|' });              // splitting the strings in data[1], and storing them into "output" string array
                Lat.Text = output[0];                               // displaying the latitude
                Long.Text = output[1];                              // displaying the longitude
                best = Convert.ToInt32(output[2]) + 2;
                TableItemStyle tableStyle = new TableItemStyle();   // Creating a tablestyle  
                tableStyle.HorizontalAlign = HorizontalAlign.Center;    // setting the horizontal alignment to center
                tableStyle.VerticalAlign = VerticalAlign.Middle;        // setting the vertical alignment to middle
                tableStyle.BorderColor = System.Drawing.Color.Black;    // setting the border color to black
                tableStyle.BorderWidth = 1;                             // setting the border width to 1
                tableStyle.BackColor = System.Drawing.Color.White;  // setting the table row of the best time to have a green background
                tableStyle.ForeColor = System.Drawing.Color.Black;
                tableStyle.Font.Bold = false;

                TableItemStyle tableStyleCell = new TableItemStyle();   // Creating a tablestyle  
                tableStyleCell.HorizontalAlign = HorizontalAlign.Center;    // setting the horizontal alignment to center
                tableStyleCell.VerticalAlign = VerticalAlign.Middle;        // setting the vertical alignment to middle
                tableStyleCell.BorderColor = System.Drawing.Color.Black;    // setting the border color to black
                tableStyleCell.BorderWidth = 1;                             // setting the border width to 1


                TableItemStyle tableStyleBest = new TableItemStyle();   // Creating a tablestyle  
                tableStyleBest.BackColor = System.Drawing.Color.Green;  // setting the table row of the best time to have a green background
                tableStyleBest.Font.Bold = true;                        // setting the table row of the best time to have a bold font
                tableStyleBest.ForeColor = System.Drawing.Color.White;  // setting the table row of the best time to have a white font color
                for (i = 2; i < data.Length; i++)                   // for loop to traverse "data" string array 
                {
                    output = data[i].Split(new[] { '|' });          // spliting the data[i] string, and storing all strings into "output" string array
                    TableRow tempRow = new TableRow();              // creating a new table row

                    for (int cellNum = 0; cellNum < output.Length; cellNum++)   // for loop for filling each cell in table row
                    {
                        TableCell tempCell = new TableCell();       // creating new table cell
                        tempCell.Text = output[cellNum];            // setting the value of table cell
                        tempRow.Cells.Add(tempCell);                // adding tablecell into the table row
                    }

                    tempRow.ID ="RowNo-"+i.ToString()+"-";            // setting the ID of the table row
                    tableIDs.Add(tempRow.ID);                       // storing the ID name of table row into tableIDs[]
                    myTable.Rows.Add(tempRow);                      // adding table row into table
                }
                ErrorLabel.Text = "No Errors";                      // displaying that there were no errors
                foreach (TableRow rw in myTable.Rows)               // applying the table style to each cell of the table
                {
                    foreach (TableCell cel in rw.Cells)
                        cel.ApplyStyle(tableStyleCell);
                    rw.ApplyStyle(tableStyle);
                    if (rw.ID.Contains("RowNo-"+best.ToString()+"-"))    // checking for the table row that contains the time at which the weather conditions are best to go outdoors
                    {
                        rw.ApplyStyle(tableStyleBest);          // applying a special table style to the row with the best time
                    }
                }
            }
            else                                                    // if there was an error in the weather forecast function
            {
                City.Text = "";                                 // displaying no city
                Country.Text = "";                                 // displaying no country
                Lat.Text = "";                                 // displaying no Latitude
                Long.Text = "";                                 // displaying no Longitude
                ErrorLabel.Text = "Please enter a valid zip code";                                 // displaying the error to user
            }

        }
    }
}