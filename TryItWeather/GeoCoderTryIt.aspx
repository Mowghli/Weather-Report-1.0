<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GeoCoderTryIt.aspx.cs" Inherits="TryItWeather.GeoCoderTryIt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <h1>GeoCoder TryIt page</h1>
   
    <p>
        <b>Description: </b> This service will allow the user to input their location. The service will then display their coordinates and zip code
    </p>
    <p>
        <b>URL of the service: </b><a href="http://webstrar3.fulton.asu.edu/page4/Service1.svc">http://webstrar3.fulton.asu.edu/page4/Service1.svc</a>
    </p>
    <p>
        <b>Method name: </b>"public string[] GeoCoder(string address)"  Takes in a string containing the user's location. Returns a string array containing zipcode, latitude and longitude of the user's location
    </p>
    <p>
        To go back to default page: <a href="http://webstrar3.fulton.asu.edu/index.html">http://webstrar3.fulton.asu.edu/index.html</a>
    </p>
    <p>
        Enter the address: <asp:TextBox ID="Address" runat="server"></asp:TextBox>
    <p/>
    <p>
        Click the button to get the zipcode and coordinates: <asp:Button ID="Button1" runat="server" Text="ClickMe" OnClick="Button1_Click" />
    </p>
    <p>
        Latitude: <asp:Label ID="Lat" runat="server" Text=""></asp:Label>
    </p>
    <p>
        Longitude: <asp:Label ID="Lon" runat="server" Text=""></asp:Label>
    </p>
    <p>
        ZipCode: <asp:Label ID="Zip" runat="server" Text=""></asp:Label>
    </p>
    <p>
        Errors: <asp:Label ID="ErrorCode" runat="server" Text=""></asp:Label>
    </p>
</asp:Content>
