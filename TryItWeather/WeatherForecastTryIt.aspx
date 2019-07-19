<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WeatherForecastTryIt.aspx.cs" Inherits="TryItWeather.WeatherForecastTryIt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Weather Forcast TryIt page</h1>
   
    <p>
        <b>Description: </b>The Weather service takes in the zipcode of the place, given by the user. It then gets the weather forecast data for 5 days.
    </p>
    <p>
        Some features of this data is then displayed in the associated labels and the table. The row highlighted in green denotes the best time to be out, in that area, based on temperature, humidity and wind speed.
    </p>
    <p>
        <b>URL of the service: </b><a href="http://webstrar3.fulton.asu.edu/page1/Service1.svc">http://webstrar3.fulton.asu.edu/page1/Service1.svc</a>
    </p>
    <p>
        <b>Method name: </b>"public string[] Weather5day(string zipcode)"  Takes in a string containing the zipcode. Returns string array containing weather forecast data
    </p>
    <p>
        To go back to default page: <a href="http://webstrar3.fulton.asu.edu/index.html">http://webstrar3.fulton.asu.edu/index.html</a>
    </p>
    <p>
    Enter the ZIP code here: <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </p>
    <p>
    Click here to check the weather: <asp:Button ID="Button1" runat="server" Text="Check Weather" OnClick="Button1_Click" />
    </p>
    <p>
        City: <asp:Label ID="City" runat="server" Text=""></asp:Label>
        
    </p>
   <p>
       Lattitude: <asp:Label ID="Lat" runat="server" Text=""></asp:Label>
   </p>
    <p>

        Longitude: <asp:Label ID="Long" runat="server" Text=""></asp:Label>

    </p>
    <p>

        Country: <asp:Label ID="Country" runat="server" Text=""></asp:Label>

    </p>
    <p>

        Errors: <asp:Label ID="ErrorLabel" runat="server" Text=""></asp:Label>

    </p>

    <asp:Table ID="myTable" runat="server" BorderColor="Black" BorderWidth="1" BorderStyle="Solid"> 
    <asp:TableHeaderRow ID="headertable" BorderColor="Black" BorderWidth="1" BorderStyle="Solid">
        <asp:TableCell BorderColor="Black" BorderWidth="1" >Date and Time</asp:TableCell>
        <asp:TableCell BorderColor="Black" BorderWidth="1" >Temperature</asp:TableCell>
        <asp:TableCell BorderColor="Black" BorderWidth="1" >Pressure</asp:TableCell>
        <asp:TableCell BorderColor="Black" BorderWidth="1" >Sea Level</asp:TableCell>
        <asp:TableCell BorderColor="Black" BorderWidth="1" >Wind Direction</asp:TableCell>        
        <asp:TableCell  >Wind Speed</asp:TableCell>
        <asp:TableCell BorderColor="Black" BorderWidth="1" >Humidity</asp:TableCell>
    </asp:TableHeaderRow>
        
    </asp:Table>

    <p>
        &nbsp;</p>
</asp:Content>
