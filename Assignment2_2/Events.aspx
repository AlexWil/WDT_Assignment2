<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Events.aspx.cs" Inherits="Assignment2_2.Events" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Content/bootstrap.min.css" />
    <script src="Scripts/jquery-1.9.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <nav class="navbar navbar-inverse ">
                <div class="container-fluid">
                    <div class="navbar-header">
                        <a class="navbar-brand" href="#">Cineplex Web Administration</a>
                    </div>
                    <div>
                        <ul class="nav navbar-nav">
                            <li><a href="Home.aspx">Home</a></li>
                            <li><a href="Movies.aspx">Movies</a></li>
                            <li class="active"><a href="Events.aspx">Events</a></li>
                            <li><a href="#">Page 3</a></li>
                        </ul>
                        <ul class="nav navbar-nav navbar-right">
                            <li><a href="Login.aspx"><span class="glyphicon glyphicon-log-in"></span>Logout</a></li>
                        </ul>
                    </div>
                </div>
            </nav>
            <div class="container">
                <div class="jumbotron">
                    <h2>Events...</h2>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
