<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="UserRegistration.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>
    <link rel="stylesheet" href="Content/LoginPage.css" />
</head>
<body>
    <div id="container" class="container">
        <form id="form1" runat="server" class="form-main">
            
            <div class="form-header">
                <h1><ins>Login </ins></h1>
            </div>
            <div class="form-body">

                <div class="div-col-20">
                    <asp:Label runat="server" Text="Email" AssociatedControlID="EmailInput"></asp:Label>
                </div>
                <div class="div-col-80">
                    <asp:TextBox runat="server" placeholder="Enter your Mail" ID="EmailInput"></asp:TextBox> 
                </div>
                <br/>
                <div class="div-col-20">
                    <asp:Label runat="server" Text="Password" AssociatedControlID="PasswordInput"></asp:Label>
                </div>
                <div class="div-col-80">
                    <asp:TextBox TextMode="Password" runat="server" placeholder="Enter your Password" ID="PasswordInput"></asp:TextBox>
                </div>
            </div>
             <div class="form-footer">
                 <asp:Button Id="submitBtn" runat="server" class="btn-submit" Text="Login" OnClick="LoginClick"/>
                 <asp:Button ID="RegisterBtn" runat="server" CssClass="btn-submit" Text="Register" OnClick="RegisterClick" />
            </div>
        </form>
    </div>
</body>
</html>
