<%@ Page Title="Movies" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Movies.aspx.cs" Inherits="CineplexAdministration.Movies" %>
<%@ MasterType VirtualPath="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
    <p>
    </p>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView ID="FormView1" runat="server" DataKeyNames="MovieID" DataSourceID="SqlDataSource1" CssClass="myFormView">
        <InsertItemTemplate>
            <div class="jumbotron">
                <legend>Movie Form</legend>
                <div class="form-group">
                    <label>Title:</label>
                    <asp:TextBox ID="title" class="form-control" runat="server" Text='<%# Bind("Title") %>' />
                    <asp:RequiredFieldValidator ControlToValidate="title" ID="RequiredFieldValidator5" runat="server" ErrorMessage="Title is required." />
                </div>
                <div class="form-group">
                    <label>Short Description:</label>
                    <asp:TextBox ID="shortDesc" class="form-control" runat="server" Text='<%# Bind("ShortDescription") %>' />
                    <asp:RequiredFieldValidator ControlToValidate="shortDesc" ID="RequiredFieldValidator4" runat="server" ErrorMessage="Short Description is required." />
                </div>
                <div class="form-group">
                    <label>Long Description:</label>
                    <asp:TextBox ID="longDesc" class="form-control" runat="server" Text='<%# Bind("LongDescription") %>' />
                    <asp:RequiredFieldValidator ControlToValidate="longDesc" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Long Description is required." />
                </div>
                <div class="form-group">
                    <label>Image:</label>
                    <asp:TextBox ID="image" class="form-control" runat="server" Text='<%# Bind("ImageUrl") %>' />
                    <asp:RequiredFieldValidator ControlToValidate="image" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Image is required." />
                </div>
                <div class="form-group">
                    <label>Price:</label>
                    <asp:TextBox ID="price" class="form-control" runat="server" Text='<%# Bind("Price") %>' />
                    <asp:RequiredFieldValidator ControlToValidate="price" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Price is required." />
                    <asp:CompareValidator ID="CheckFormat1" runat="server" ControlToValidate="price" Operator="DataTypeCheck" Type="Currency" Display="Dynamic" ErrorMessage="Invalid format for price." />
                </div>
                <asp:LinkButton class="btn btn-default" ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
                &nbsp;<asp:LinkButton class="btn btn-default" ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
            </div>
        </InsertItemTemplate>

        <ItemTemplate>
            <asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New" Text="Add Movie" />
        </ItemTemplate>
    </asp:FormView>
    <br/>
    <asp:GridView ID="GridView1" CssClass="table table-hover table-striped table-bordered" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="MovieID" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
            <asp:BoundField DataField="ShortDescription" HeaderText="Short Description" SortExpression="ShortDescription" />
            <asp:BoundField DataField="LongDescription" HeaderText="Long Description" SortExpression="LongDescription" />
            <asp:BoundField DataField="ImageUrl" HeaderText="Image" SortExpression="ImageUrl" />
            <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" DataFormatString="{0:c}" />
        </Columns>
    </asp:GridView>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AzureConnectionString %>" DeleteCommand="DeleteMovie" DeleteCommandType="StoredProcedure" InsertCommand="InsertMovie" InsertCommandType="StoredProcedure" SelectCommand="ReadMovies" SelectCommandType="StoredProcedure" UpdateCommand="UpdateMovie" UpdateCommandType="StoredProcedure">
        <DeleteParameters>
            <asp:Parameter Name="MovieID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="Title" Type="String" />
            <asp:Parameter Name="ShortDescription" Type="String" />
            <asp:Parameter Name="LongDescription" Type="String" />
            <asp:Parameter Name="ImageUrl" Type="String" />
            <asp:Parameter Name="Price" Type="Decimal" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="MovieID" Type="Int32" />
            <asp:Parameter Name="Title" Type="String" />
            <asp:Parameter Name="ShortDescription" Type="String" />
            <asp:Parameter Name="LongDescription" Type="String" />
            <asp:Parameter Name="ImageUrl" Type="String" />
            <asp:Parameter Name="Price" Type="Decimal" />
        </UpdateParameters>
    </asp:SqlDataSource>

</asp:Content>
