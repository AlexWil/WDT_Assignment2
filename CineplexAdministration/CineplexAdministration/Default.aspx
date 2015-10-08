<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CineplexAdministration.Default" %>

<%@ MasterType VirtualPath="~/Site.Master" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="jumbotron">
        <h3>Welcome to Cineplex Administration</h3>
        <p>Here you can manage movies, events and administrator accounts.</p>
    </div>
</asp:Content>
