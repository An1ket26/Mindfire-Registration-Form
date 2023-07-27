<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="webForms.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     
    <main>
        <div>
            <asp:Label ID="Label1" AssociatedControlID="TextBox1" runat="server">First Number</asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" AssociatedControlID="TextBox2" runat="server">Second Number</asp:Label>
            <asp:TextBox ID="TextBox2" runat="server" ></asp:TextBox>
                <br/>
            <asp:Label ID="FnameLbl" AssociatedControlID="FnameTxt" runat="server">First Name</asp:Label>
            <asp:TextBox ID="FnameTxt" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" AssociatedControlID="TextBox3" runat="server">Age</asp:Label>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" AssociatedControlID="TextBox4" runat="server">Email</asp:Label>
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" Text="save"/>
            <asp:Button ID="Button2" runat="server" Text="Submit" CausesValidation="false"/>
            <input type="button" id="CheckMethodbtn" ClientIdMode="static" runat="server"   value="CheckMethod"  />
             <asp:CompareValidator 
                 ID="compareValidator1"
                 runat="server" 
                 ControlToCompare="TextBox2" 
                 ControlToValidate="TextBox1"
                  Display="None"
             
                 ErrorMessage="Please enter a large number" 
                 Operator="LessThan" 
                 Type="Integer" 
                 ForeColor="Red" 
                 />
            <asp:RequiredFieldValidator 
                ID="requiredValidator1" 
                runat="server" 
                ControlToValidate="FnameTxt" 
                ErrorMessage="*Required" 
                ForeColor="Red" 
                Display="None"/>
             <asp:RangeValidator
                 ID="RangeValidator1" 
                 runat="server" 
                 ControlToValidate="TextBox3"   
                 ErrorMessage="Enter value in specified range" 
                 ForeColor="Red"
                 MaximumValue="101"
                 MinimumValue="18"   
                 SetFocusOnError="True"
                 Type=" Integer"
                 Display="None">
             </asp:RangeValidator>  
            <asp:RegularExpressionValidator 
                ID="RegularExpressionValidator1" 
                runat="server"
                ControlToValidate="TextBox4"   
                ErrorMessage="Please enter valid email"
                ForeColor="Red"
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                Display="None"
                />  
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red"/>  
        </div>
       
    </main>
    <script src="Scripts/webform2.js"></script>
</asp:Content>