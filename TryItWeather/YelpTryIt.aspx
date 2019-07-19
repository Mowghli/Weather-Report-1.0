<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="YelpTryIt.aspx.cs" Inherits="TryItWeather.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>TryIt Yelp page</h1>
    <p>
        This service will allow the user to enter the store name and his or her location.
    </p>
    <p>
        The service will then find a nearby store, and will display the name and address of the nearby store.
    </p>
    <p>
        <b>service URL =</b> <a href="http://webstrar3.fulton.asu.edu/page2/Service1.svc">http://webstrar3.fulton.asu.edu/page2/Service1.svc</a>
    </p>
    <p>
        <b>Method Name: </b>"public string YelpStoreFinder(string PlaceName, string location):": Gets two strings that contain name of store and user's location
    </p>
    <p>
        Method returns the name and address of the nearest store. It uses the Yelp Fusion v3 API for getting the nearest store.
    </p>
    <p>
        To go back to default page: <a href="http://webstrar3.fulton.asu.edu/index.html">http://webstrar3.fulton.asu.edu/index.html</a>
    </p>
    <p>
        Enter the name of the store: <asp:TextBox ID="placename" runat="server"></asp:TextBox>
    </p>
    <p>
        Enter the location of your place: <asp:TextBox ID="location" runat="server"></asp:TextBox>
    </p>
    <p>
        Click the button to check where the closest store is: <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="ClickMe" />
    </p>
    <p>
        Name and closest location of the store: <asp:Label ID="StoreNameAndLocation" runat="server" Text=""></asp:Label>
        
    </p>
    <p>
        Errors: <asp:Label ID="ErrorLabel" runat="server" Text=""></asp:Label>
    </p>
</asp:Content>
