<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="UserRegistration.UserDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Details</title>
    <link rel="stylesheet" href="Content/UserList.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.4/jquery.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 class="heading"><u>User Details</u></h1>
            <asp:GridView 
                ID="GridView1" 
                runat="server"  
                DataKeyNames="Id" 
                AutoGenerateColumns="false" 
                EmptyDataText="No records has been added."
                OnRowEditing="OnRowEditing"
                OnRowCancelingEdit="OnRowCancelingEdit" 
                OnRowDeleting="OnRowDeleting" 
                CssClass="UserList-Table" 
                HeaderStyle-CssClass="UserList-Header" RowStyle-CssClass="UserList-Rows"
                >
                <Columns>
                    <asp:TemplateField HeaderText="UserId" ItemStyle-CssClass="width-70" >
                        <ItemTemplate>
                            <asp:Label ID="lblId" runat="server" Text='<%# Eval("Id") %>' ></asp:Label>
                        </ItemTemplate>
                        <%--<EditItemTemplate>
                            <asp:Label ID="lblId" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                        </EditItemTemplate>--%>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="FirstName" ItemStyle-CssClass="width-150">
                        <ItemTemplate>
                            <asp:Label ID="lblFirstname" runat="server" Text='<%# Eval("FirstName") %>'></asp:Label>
                        </ItemTemplate>
                        <%--<EditItemTemplate>
                            <asp:TextBox ID="txtFirstname" runat="server" Text='<%# Eval("FirstName") %>'></asp:TextBox>
                        </EditItemTemplate>--%>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="LastName" ItemStyle-CssClass="width-150">
                        <ItemTemplate>
                            <asp:Label ID="lblLastName" runat="server" Text='<%# Eval("LastName") %>'></asp:Label>
                        </ItemTemplate>
                        <%--<EditItemTemplate>
                            <asp:TextBox ID="txtLastName" runat="server" Text='<%# Eval("LastName") %>'></asp:TextBox>
                        </EditItemTemplate>--%>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Email" ItemStyle-CssClass="width-250">
                        <ItemTemplate>
                            <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                        </ItemTemplate>
                        <%--<EditItemTemplate>
                            <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" Text='<%# Eval("Email") %>'></asp:TextBox>
                        </EditItemTemplate>--%>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Dob" ItemStyle-CssClass="width-150">
                        <ItemTemplate>
                            <asp:Label ID="lblDob" runat="server" Text='<%# Eval("Dob") %>'></asp:Label>
                        </ItemTemplate>
                        <%--<EditItemTemplate>
                            <asp:TextBox ID="txtDob" runat="server" TextMode="Date" Text='<%# Eval("Dob") %>'></asp:TextBox>
                        </EditItemTemplate>--%>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Gender" ItemStyle-CssClass="width-70">
                        <ItemTemplate>
                            <asp:Label ID="lblGender" runat="server" Text='<%# Eval("Gender") %>'></asp:Label>
                        </ItemTemplate>
                        <%--<EditItemTemplate>
                            <asp:DropDownList ID="txtGender" runat="server">
                                <asp:ListItem Value="Male">Male</asp:ListItem>
                                <asp:ListItem Value="Female">Female</asp:ListItem>
                                <asp:ListItem Value="Other">Other</asp:ListItem>
                            </asp:DropDownList>
                        </EditItemTemplate>--%>
                    </asp:TemplateField>
                    <%--<asp:TemplateField HeaderText="PresentAddrL1" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label ID="lblPresentAddrL1" runat="server" Text='<%# Eval("PresentAddrL1") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtPresentAddrL1" runat="server" Text='<%# Eval("PresentAddrL1") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="PresentAddrL2" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label ID="lblPresentAddrL2" runat="server" Text='<%# Eval("PresentAddrL2") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtPresentAddrL2" runat="server" Text='<%# Eval("PresentAddrL2") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="PresentPcode" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label ID="lblPresentPcode" runat="server" Text='<%# Eval("PresentPcode") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtPresentPcode" runat="server" Text='<%# Eval("PresentPcode") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="PresentCountry" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label ID="lblPresentCountry" runat="server" Text='<%# Eval("PresentCountry") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            
                            <asp:DropDownList ID="txtPresentCountry" runat="server" ClientIDMode="Static" AutoPostBack="true" OnSelectedIndexChanged="LoadState"></asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="PresentState" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label ID="lblPresentState" runat="server" Text='<%# Eval("PresentState") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            
                            <asp:DropDownList ID="txtPresentState" runat="server" ClientIDMode="Static"></asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="PresentCity" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label ID="lblPresentCity" runat="server" Text='<%# Eval("PresentCity") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtPresentCity" runat="server" Text='<%# Eval("PresentCity") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="PermanentAddrL1" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label ID="lblPermanentAddrL1" runat="server" Text='<%# Eval("PermanentAddrL1") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtPermanentAddrL1" runat="server" Text='<%# Eval("PermanentAddrL1") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="PermanentAddrL2" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label ID="lblPermanentAddrL2" runat="server" Text='<%# Eval("PermanentAddrL2") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtPermanentAddrL2" runat="server" Text='<%# Eval("PermanentAddrL2") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="PermanentPcode" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label ID="lblPermanentPcode" runat="server" Text='<%# Eval("PermanentPcode") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtPermanentPcode" runat="server" Text='<%# Eval("PermanentPcode") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="PermanentCountry" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label ID="lblPermanentCountry" runat="server" Text='<%# Eval("PermanentCountry") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            
                            <asp:DropDownList ID="txtPermanentCountry" runat="server" ClientIDMode="Static" AutoPostBack="true" OnSelectedIndexChanged="LoadState2">
                            </asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="PermanentState" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label ID="lblPermanentState" runat="server" Text='<%# Eval("PermanentState") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            
                            <asp:DropDownList ID="txtPermanentState" runat="server"></asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="PermanentCity" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label ID="lblPermanentCity" runat="server" Text='<%# Eval("PermanentCity") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtPermanentCity" runat="server" Text='<%# Eval("PermanentCity") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Hobby" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label ID="lblHobby" runat="server" Text='<%# Eval("Hobby") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtHobby" runat="server" Text='<%# Eval("Hobby") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="IsSubscribed" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label ID="lblIsSubscribed" runat="server" Text='<%# Eval("IsSubscribed") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            
                            <asp:CheckBox ID="txtIsSubscribed" runat="server" />
                        </EditItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="Roles" ItemStyle-CssClass="width-250" >
                        <ItemTemplate>
                            <asp:Label ID="lblRoles" runat="server" Text='<%# Eval("Roles") %>'></asp:Label>
                        </ItemTemplate>
                        <%--<EditItemTemplate>
                            <asp:CheckBoxList ID="txtRoles" runat="server">
                            </asp:CheckBoxList>
                        </EditItemTemplate>--%>
                    </asp:TemplateField>
                    <%--<asp:CommandField ButtonType="Button" ShowEditButton="true" ShowDeleteButton="true" ItemStyle-CssClass="width-150" />--%>
                    <asp:TemplateField HeaderText="Configure" ItemStyle-CssClass="width-150">
                        <ItemTemplate>
                            <asp:Button ID="AddUserBtn" runat="server" Text="Edit" CommandName="Edit" CssClass="EditUser-btn" />
                            <asp:Button ID="Button1" runat="server" Text="Delete" CommandName="Delete" CssClass="DeleteUser-btn"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br/>
            <asp:Button ID="AddUserBtn" runat="server" Text="Add User" OnClick="AddUser" CssClass="AddUser-btn"/>
        </div>
    </form>
    
</body>
</html>
