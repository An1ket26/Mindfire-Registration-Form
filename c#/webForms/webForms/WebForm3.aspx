<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="webForms.WebForm3" %>

<!DOCTYPE html>
<%@ Register Src="~/WebUserControl1.ascx" TagPrefix="uc" TagName="Note" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc:Note ID="Note1" runat="server" />
        </div>
    </form>
</body>
</html>
