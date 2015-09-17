<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Assignment2_2.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Content/bootstrap.min.css" />
    <script src="Scripts/jquery-1.9.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
</head>
<body>
    <br />
    <br />
    <form id="form1" runat="server">
        <div class="container">
            <div class="jumbotron">
                <h2>Cineplex Web Application</h2>
                <h3>Login for Administrators</h3>
                <div class="form-group">
                    <label for="usr">Name:</label>
                    <input type="text" class="form-control" id="usr" runat="server" />
                </div>
                <div class="form-group">
                    <label for="pwd">Password:</label>
                    <input type="password" class="form-control" id="pwd" runat="server" />
                </div>

                <asp:Button ID="Button1" runat="server" OnClick="LoginButtonClick" CssClass="btn btn-primary" Text="Login" />
                <asp:Label ID="message" runat="server"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
