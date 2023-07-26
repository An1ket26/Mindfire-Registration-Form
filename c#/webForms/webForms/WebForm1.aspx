<%@ Page Title="Form" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="WebForm1.aspx.cs" Inherits="webForms.WebForm1" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .col-25{
            width:20%;
            float:left;
        }
    </style>
    <main>
        <div>
            <asp:Label ID="Label1" AssociatedControlID="TextBox1" runat="server" Text="Enter Your Name : " CssClass="col-25" ></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="true" OnTextChanged="TextBxChange" CssClass="col-75" ></asp:TextBox>
            <br /><br/>
            <asp:Label ID="LabelGender" AssociatedControlID="RbMale" runat="server" Text="Gender :" CssClass="col-25"/>
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
            <br /><br/>
            <asp:Label ID="Label3" AssociatedControlID="File1" runat="server" Text="Please select a file to upload."></asp:Label><br/>
            <br/><br/>
            <asp:Label ID="Label4" AssociatedControlID="DropDownList1" runat="server" >State : </asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem Value="" Selected="True">Please Select</asp:ListItem>
                <asp:ListItem Value="">New Delhi</asp:ListItem>
                <asp:ListItem Value="">Odisha</asp:ListItem>
                <asp:ListItem Value="">Bihar</asp:ListItem>
                <asp:ListItem Value="">Maharastra</asp:ListItem>
                 <asp:ListItem Value="">Changed</asp:ListItem>
            </asp:DropDownList>
            <br/><br/>
            <asp:Label ID="Label5" AssociatedControlID="Tb3" runat="server">Add State</asp:Label>
            <asp:TextBox ID="Tb3" runat="server" placeholder="Enter state"></asp:TextBox>
            <asp:Button ID="Add_State_Btn" OnClick="Add_List_Click" runat="server" Text="Add" />
            <br/><br/>
            <asp:TextBox runat="server" placeholder="Enter the the id" ID="Tb4"></asp:TextBox>
            <asp:Button ID="Button4" runat="server" OnClick="Add_To_DataList" Text="Add"/>
            <asp:DataList ID="DataList1" runat="server">
                <ItemTemplate>
                    UserID:
                    <asp:Label ID="UserIDLabel" runat="server" Text='<%# Eval("UserID1") %>' />
                    <br />
                    FirstName:
                    <asp:Label ID="FirstNameLabel" runat="server" Text='<%# Eval("FirstName") %>' />
                    <br />
                    LastName:
                    <asp:Label ID="LastNameLabel" runat="server" Text='<%# Eval("LastName") %>' />
                    <br />
                    <br />
                </ItemTemplate>
            </asp:DataList>
            <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TestDBConnectionString %>" ProviderName="<%$ ConnectionStrings:TestDBConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [GetDetails]"></asp:SqlDataSource>--%>
            <br/><br />
            <button id="Submit2">Submit</button>
             <%--<button id="Submit3" runat="server" OnClick="Test_Submit">Submit2</button>--%>
            <asp:Label ID="Label6" runat="server"></asp:Label>
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
    <script src="Scripts/WebForm1.js"></script>
    </main>
</asp:Content>
