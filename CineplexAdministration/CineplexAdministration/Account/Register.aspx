<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="CineplexAdministration.Account.Register" %>
<%@ MasterType VirtualPath="~/Site.Master" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <asp:CreateUserWizard runat="server" ID="RegisterUser" ViewStateMode="Disabled" OnCreatedUser="RegisterUser_CreatedUser">
        <LayoutTemplate>
            <asp:PlaceHolder runat="server" ID="wizardStepPlaceholder" />
            <asp:PlaceHolder runat="server" ID="navigationPlaceholder" />
        </LayoutTemplate>
        <WizardSteps>
            <asp:CreateUserWizardStep runat="server" ID="RegisterUserWizardStep">
                <ContentTemplate>
                    <p class="validation-summary-errors">
                        <asp:Literal runat="server" ID="ErrorMessage" />
                    </p>
                    <div class="jumbotron">
                        <fieldset>
                            <legend>Registration Form</legend>

                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="UserName">User name:</asp:Label><br />
                                <asp:TextBox class="form-control" runat="server" ID="UserName" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName" CssClass="field-validation-error" ErrorMessage="The user name field is required." />
                            </div>

                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="Email">Email address:</asp:Label><br />
                                <asp:TextBox class="form-control" runat="server" ID="Email" TextMode="Email" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email" CssClass="field-validation-error" ErrorMessage="The email address field is required." />
                            </div>

                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="Password">Password:</asp:Label><br />
                                <asp:TextBox class="form-control" runat="server" ID="Password" TextMode="Password" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="field-validation-error" ErrorMessage="The password field is required." />
                            </div>

                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ConfirmPassword">Confirm password:</asp:Label><br />
                                <asp:TextBox class="form-control" runat="server" ID="ConfirmPassword" TextMode="Password" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword" CssClass="field-validation-error" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword" CssClass="field-validation-error" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
                            </div>

                            <asp:Button type="button" class="btn btn-default" runat="server" CommandName="MoveNext" Text="Register" />
                        </fieldset>
                    </div>
                </ContentTemplate>
                <CustomNavigationTemplate />
            </asp:CreateUserWizardStep>
        </WizardSteps>
    </asp:CreateUserWizard>
</asp:Content>
