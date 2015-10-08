<%@ Page Title="Events" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Events.aspx.cs" Inherits="CineplexAdministration.Events" %>

<%@ MasterType VirtualPath="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AzureConnectionString %>" DeleteCommand="DeleteEvent" DeleteCommandType="StoredProcedure" InsertCommand="InsertEvent" InsertCommandType="StoredProcedure" SelectCommand="ReadEvents" SelectCommandType="StoredProcedure" UpdateCommand="UpdateEvent" UpdateCommandType="StoredProcedure">
        <DeleteParameters>
            <asp:Parameter Name="EventID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="EventTitle" Type="String" />
            <asp:Parameter Name="CineplexID" Type="Int32" />
            <asp:Parameter DbType="Date" Name="EventDay" />
            <asp:Parameter DbType="Time" Name="EventTime" />
            <asp:Parameter Name="ShortDescription" Type="String" />
            <asp:Parameter Name="LongDescription" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="EventID" Type="Int32" />
            <asp:Parameter Name="EventTitle" Type="String" />
            <asp:Parameter Name="CineplexID" Type="Int32" />
            <asp:Parameter DbType="Date" Name="EventDay" />
            <asp:Parameter DbType="Time" Name="EventTime" />
            <asp:Parameter Name="ShortDescription" Type="String" />
            <asp:Parameter Name="LongDescription" Type="String" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:GridView ID="GridView1" CssClass="table table-hover table-striped table-bordered" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="EventID" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:BoundField DataField="EventID" HeaderText="EventID" InsertVisible="False" ReadOnly="True" SortExpression="EventID" />
            <asp:BoundField DataField="EventTitle" HeaderText="Title" SortExpression="EventTitle" />
            <asp:BoundField DataField="CineplexID" HeaderText="CineplexID" SortExpression="CineplexID" />
            <asp:BoundField DataField="EventDay" HeaderText="Date of Event" SortExpression="EventDay" DataFormatString="{0:d}" />
            <asp:BoundField DataField="EventTime" HeaderText="Time of Event" SortExpression="EventTime" />
            <asp:BoundField DataField="ShortDescription" HeaderText="Short Description" SortExpression="ShortDescription" />
            <asp:BoundField DataField="LongDescription" HeaderText="Long Description" SortExpression="LongDescription" />
        </Columns>
    </asp:GridView>

    <asp:FormView ID="FormView1" runat="server" DataKeyNames="EventID" DataSourceID="SqlDataSource1">
        <InsertItemTemplate>
            <div class="jumbotron">
                <div class="form-group">
                    <label>Title:</label>
                    <asp:TextBox ID="title" class="form-control" runat="server" Text='<%# Bind("EventTitle") %>' />
                </div>
                <div class="form-group">
                    <label>CineplexID:</label>
                    <asp:TextBox ID="cineplexID" class="form-control" runat="server" Text='<%# Bind("CineplexID") %>' />
                </div>
                <div class="form-group">
                    <label>Event Day:</label>
                    <asp:TextBox ID="eventDay" class="form-control" runat="server" Text='<%# Bind("EventDay") %>' />
                </div>
                <div class="form-group">
                    <label>Event Time:</label>
                    <asp:TextBox ID="eventTime" class="form-control" runat="server" Text='<%# Bind("EventTime") %>' />
                </div>
                <div class="form-group">
                    <label>Short Description:</label>
                    <asp:TextBox ID="shortDesc" class="form-control" runat="server" Text='<%# Bind("ShortDescription") %>' />
                </div>
                <div class="form-group">
                    <label>Long Description:</label>
                    <asp:TextBox ID="longDesc" class="form-control" runat="server" Text='<%# Bind("LongDescription") %>' />
                </div>
                <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
                &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
            </div>
        </InsertItemTemplate>

        <ItemTemplate>
            <asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New" Text="New" />
        </ItemTemplate>
    </asp:FormView>

</asp:Content>
