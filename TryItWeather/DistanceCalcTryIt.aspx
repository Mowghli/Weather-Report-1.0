<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DistanceCalcTryIt.aspx.cs" Inherits="TryItWeather.DistanceCalcTryIt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Distance Calculator TryIt Page
    </h1>
    <p>
        This service will allow the user to enter two addresses (Source and Destination)
    </p>
    <p>
        The service will then determine the distance between the two addresses, and the time taken to go either way, and will display the same. 
    </p>
    <p>
        <b>service URL =</b> <a href="http://webstrar3.fulton.asu.edu/page3/Service1.svc">http://webstrar3.fulton.asu.edu/page3/Service1.svc</a>
    </p>
    <p>
        <b>Method Name: </b>"public string[] DistanceCalculator(string source, string destination):": Gets two strings that contain source and destination addresses
    </p>
    <p>
        Method returns a string array. First element contains the distance from source and destination. Second element contains duration of going from source to destination.
    </p>
    <p>
        To go back to default page: <a href="http://webstrar3.fulton.asu.edu/index.html">http://webstrar3.fulton.asu.edu/index.html</a>
    </p>
    <p>
        Enter the place of Origin: <asp:TextBox ID="Source" runat="server"></asp:TextBox>
    </p>
    <p>
        Enter the place od Destination: <asp:TextBox ID="Destination" runat="server"></asp:TextBox>
    </p>
    <p>
        Click the button to get the distance from Origin to Destination: <asp:Button ID="Button1" runat="server" Text="Click" OnClick="Button1_Click" />
    </p>
    <p>
        Distance from Origin to Destination: <asp:Label ID="Distance" runat="server" Text=""></asp:Label>
        
    </p>
    <p>
        Least time taken to go from Origin to Destination: <asp:Label ID="Time" runat="server" Text=""></asp:Label>
        
    </p>
    <p>
        Errors: <asp:Label ID="Errors" runat="server" Text=""></asp:Label>
    </p>
</asp:Content>
