<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserDetails.aspx.cs" Inherits="webForms.UserDetails1" %>

<!DOCTYPE html>
<%@ Register Src="~/NotesControl.ascx" TagPrefix="nc" TagName="Notes" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" >
        <div>
            <asp:Label ID="lblUserId" AssociatedControlID="txtUserId" runat="server">UserId : </asp:Label>
            <asp:TextBox ID="txtUserId" runat="server"></asp:TextBox>
            <asp:Button ID="btnSubmit" runat="server" OnClick="LoadUserControl" Text="Submit"/>
            <br/><br/>
            <h5>Notes :</h5>
            <nc:Notes runat="server" ID="NotesControl" ObjectType="User" />
        </div>
    </form>
</body>
</html>
