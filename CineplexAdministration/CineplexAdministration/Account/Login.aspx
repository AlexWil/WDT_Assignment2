<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CineplexAdministration.Account.Login" %>

<%@ MasterType VirtualPath="~/Site.Master" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <section id="loginForm">
        <asp:Login runat="server" ViewStateMode="Disabled" RenderOuterTable="false">
            <LayoutTemplate>
                <p class="validation-summary-errors">
                    <asp:Literal runat="server" ID="FailureText" />
                </p>
                <div class="container">
                    <div class="jumbotron">
                        <fieldset>
                            <legend>Log in Form</legend>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="UserName">User name</asp:Label>
                                <asp:TextBox class="form-control" runat="server" ID="UserName" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName" CssClass="field-validation-error" ErrorMessage="The user name field is required." />

                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="Password">Password</asp:Label>
                                <asp:TextBox class="form-control" runat="server" ID="Password" TextMode="Password" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="field-validation-error" ErrorMessage="The password field is required." />
                            </div>
                            <asp:Button class="btn btn-default" runat="server" CommandName="Login" Text="Log in" />
                        </fieldset>
                    </div>
                </div>
            </LayoutTemplate>
        </asp:Login>
    </section>

</asp:Content>
