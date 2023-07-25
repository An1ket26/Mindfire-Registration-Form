<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="webForms.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" AssociatedControlID="TextBox1" runat="server" Text="Enter Your Name : " CssClass="InputLabel" ></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBxChange"  For="Label1" ></asp:TextBox>
            <br />
            <asp:Label ID="LabelGender" AssociatedControlID="RbMale" runat="server" Text="Gender :" />
            <asp:RadioButton ID="RbMale" runat="server" Text="Male" GroupName="Gender" />
            <asp:RadioButton ID="RbFemale" runat="server" Text="Female" GroupName="Gender" />
            <asp:RadioButton ID="RbOther" runat="server" Text="Other" GroupName="Gender" />
            <br /><br />
            <asp:Calendar ID="FormCalendar" runat="server" AccessKey="c" ShowTodayButton="False" OnSelectionChanged="FormCalendar_SelectionChanged" />
            <p>Selected Date : <asp:Label ID="Label2" runat="server" Text="" CssClass="InputLabel" ></asp:Label></p>

            <br />
             <h2>Select Skills</h2>
            <asp:CheckBox ID="Checkbox1" Text="C#" runat="server" />
             <asp:CheckBox ID="Checkbox2" Text="ADO.net" runat="server"  />
             <asp:CheckBox ID="Checkbox3" Text="ASP.net" runat="server"  />
             <asp:CheckBox ID="Checkbox4" Text="SQL" runat="server"  />
            <br/><br />
            
            <asp:FileUpload ID="File1" runat="server" AllowMultiple="true"/>
            <asp:Button ID="Button2" runat="server" OnClick="FileUploadButton" Text="Upload"/>
            <br />
            <asp:Label ID="Label3" AssociatedControlID="File1" runat="server" Text="Please select a file to upload."></asp:Label><br/>
            <br/><br/>
            <asp:Button ID="Submit1" runat="server" Text="Submit" ToolTip="Submit" OnClick="Submit_Click1" style="margin-left: 77px; margin-top: 30px" Width="80px" />

        </div>
        <br/>
        <br/>

        <div>
            <asp:Button ID="Button3" runat="server" OnClick="Download_Click" Text="Download"/>
        </div>
        <p>
            <asp:HyperLink ID="Link1" runat="server" Text="Navigate to Home" NavigateUrl="~/Default.aspx" />
            <asp:HyperLink ID="Link2" runat="server" Text="Navigate to Google" NavigateUrl="http://www.google.com"/>

        </p>
    </form>
</body>
</html>
