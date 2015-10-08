<%@ Page Title="Manage Account" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="CineplexAdministration.Account.Manage" %>

<%@ MasterType VirtualPath="~/Site.Master" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">

    <section id="passwordForm">
        <asp:PlaceHolder runat="server" ID="successMessage" Visible="false" ViewStateMode="Disabled">
            <p class="message-success"><%: SuccessMessage %></p>
        </asp:PlaceHolder>

        <p>You're logged in as <strong><%: User.Identity.Name %></strong>.</p>
        <div class="jumbotron">
            <asp:PlaceHolder runat="server" ID="changePassword">
                <asp:ChangePassword runat="server" CancelDestinationPageUrl="~/" ViewStateMode="Disabled" RenderOuterTable="false" SuccessPageUrl="Manage?m=ChangePwdSuccess">
                    <ChangePasswordTemplate>
                        <p class="validation-summary-errors">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                        <fieldset class="changePassword">
                            <legend>Change password details</legend>
                            <div class="form-group">
                                <asp:Label runat="server" ID="CurrentPasswordLabel" AssociatedControlID="CurrentPassword">Current password</asp:Label><br />
                                <asp:TextBox class="form-control" runat="server" ID="CurrentPassword" TextMode="Password" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="CurrentPassword" CssClass="field-validation-error" ErrorMessage="The current password field is required." ValidationGroup="ChangePassword" />
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" ID="NewPasswordLabel" AssociatedControlID="NewPassword">New password</asp:Label><br />
                                <asp:TextBox class="form-control" runat="server" ID="NewPassword" TextMode="Password" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="NewPassword" CssClass="field-validation-error" ErrorMessage="The new password is required." ValidationGroup="ChangePassword" />
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" ID="ConfirmNewPasswordLabel" AssociatedControlID="ConfirmNewPassword">Confirm new password</asp:Label><br />
                                <asp:TextBox class="form-control" runat="server" ID="ConfirmNewPassword" TextMode="Password" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmNewPassword" CssClass="field-validation-error" Display="Dynamic" ErrorMessage="Confirm new password is required." ValidationGroup="ChangePassword" />
                                <asp:CompareValidator runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword" CssClass="field-validation-error" Display="Dynamic" ErrorMessage="The new password and confirmation password do not match." ValidationGroup="ChangePassword" />
                            </div>
                            <asp:Button runat="server" class="btn btn-default" CommandName="ChangePassword" Text="Change password" ValidationGroup="ChangePassword" />
                        </fieldset>
                    </ChangePasswordTemplate>
                </asp:ChangePassword>
            </asp:PlaceHolder>
        </div>
    </section>
</asp:Content>
