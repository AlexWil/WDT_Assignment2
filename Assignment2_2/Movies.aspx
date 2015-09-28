<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/WebAdministration.Master" CodeBehind="Movies.aspx.cs" Inherits="Assignment2_2.Movies" %>
<%@ MasterType VirtualPath="~/WebAdministration.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridView1" CssClass="table table-hover table-striped table-bordered" runat="server" AutoGenerateColumns="False" DataKeyNames="MovieID" DataSourceID="SqlDataSource1" AllowPaging="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" ShowFooter="True">
        <columns>
            <asp:CommandField ShowDeleteButton="True" DeleteText="Delete" ShowEditButton="True" EditText="Edit" CancelText="Cancel" UpdateText="Update" />
            <asp:TemplateField HeaderText="MovieID" InsertVisible="False" SortExpression="MovieID">
                <EditItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("MovieID") %>'></asp:Label>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:LinkButton ID="AddMovieButton" runat="server" OnClick="AddMovieButton_Click">Add Movie</asp:LinkButton>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("MovieID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Title" SortExpression="Title">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Title") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="TitelTextBox" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("Title") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ShortDescription" SortExpression="ShortDescription">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("ShortDescription") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="ShortDescriptionTextBox" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("ShortDescription") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="LongDescription" SortExpression="LongDescription">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("LongDescription") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="LongDescriptionTextBox" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label8" runat="server" Text='<%# Bind("LongDescription") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ImageUrl" SortExpression="ImageUrl">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("ImageUrl") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="ImageUrlTextBox" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label9" runat="server" Text='<%# Bind("ImageUrl") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Price in $" SortExpression="Price">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Price", "{0:N2}") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="PriceTextBox" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label10" runat="server" Text='<%# Bind("Price", "{0:N2}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CineplexConnectionString %>" SelectCommand="ReadMovies" SelectCommandType="StoredProcedure" DeleteCommand="DeleteMovie" DeleteCommandType="StoredProcedure" InsertCommand="InsertMovie" InsertCommandType="StoredProcedure" UpdateCommand="UpdateMovie" UpdateCommandType="StoredProcedure">
        <deleteparameters>
            <asp:Parameter Name="MovieID" Type="Int32" />
        </deleteparameters>
        <insertparameters>
            <asp:Parameter Name="MovieID" Type="Int32" />
            <asp:Parameter Name="Title" Type="String" />
            <asp:Parameter Name="ShortDescription" Type="String" />
            <asp:Parameter Name="LongDescription" Type="String" />
            <asp:Parameter Name="ImageUrl" Type="String" />
            <asp:Parameter Name="Price" Type="Decimal" />
        </insertparameters>
        <updateparameters>
            <asp:Parameter Name="MovieID" Type="Int32" />
            <asp:Parameter Name="Title" Type="String" />
            <asp:Parameter Name="ShortDescription" Type="String" />
            <asp:Parameter Name="LongDescription" Type="String" />
            <asp:Parameter Name="ImageUrl" Type="String" />
            <asp:Parameter Name="Price" Type="Decimal" />
        </updateparameters>
    </asp:SqlDataSource>
</asp:Content>
