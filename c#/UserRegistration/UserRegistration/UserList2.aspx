<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserList2.aspx.cs" Inherits="UserRegistration.UserList2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Content/UserList2.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.4/jquery.min.js"></script>
</head>
<body>
    <div id="main">
        <h2 class="user-heading"><u>User Details</u></h2>
        <div id="container" class="container UserList-Header">
            <div class="width-70">UserId</div>
            <div class="width-150">FirstName</div>
            <div class="width-150">LastName</div>
            <div class="width-150">Email</div>
            <div class="width-150">DOB</div>
            <div class="width-250">Roles</div>
            <div class="width-250">Hobby</div>
            <div class="width-70">Configure</div>
        </div>
    </div>
    <br/>
    <input type="button" id="addUser" class="AddUser-btn" value="Add user"></input>
    <%--<asp:Image ID="Image1" runat="server" Visible="false"/>--%>
    <script src="Scripts/UserList2.js"></script>
</body>
</html>
