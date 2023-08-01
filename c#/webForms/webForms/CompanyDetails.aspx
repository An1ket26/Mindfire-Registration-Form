<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyDetails.aspx.cs" Inherits="webForms.CompanyDetails" %>

<!DOCTYPE html>
<%@ Register Src="~/NotesControl.ascx" TagPrefix="nc" TagName="Notes" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblCompanyId" AssociatedControlID="txtCompanyId" runat="server">CompanyId : </asp:Label>
            <asp:TextBox ID="txtCompanyId" runat="server"></asp:TextBox>
            <asp:Button ID="btnSubmit" runat="server" OnClick="LoadUserControl" Text="Submit"/>
             <br/><br/>
            <h5>Notes :</h5>
            <nc:Notes runat="server" ID="NotesControl" ObjectType="Company" />
        </div>
    </form>
</body>
</html>
