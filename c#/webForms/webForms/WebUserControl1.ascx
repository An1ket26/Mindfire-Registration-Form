<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebUserControl1.ascx.cs" Inherits="webForms.WebUserControl1" %>

<h3>User control</h3>

<asp:GridView 
                ID="GridView1" 
                runat="server"  
                DataKeyNames="Id" 
                AutoGenerateColumns="false" 
                OnRowEditing="OnRowEditing" 
                OnRowCancelingEdit="OnRowCancelingEdit"
    EmptyDataText="No records has been added."
                OnRowUpdating="OnRowUpdating" 
                OnRowDeleting="OnRowDeleting" 
                >
                <Columns>
                    <asp:TemplateField HeaderText="NoteId" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label ID="lblUserId" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="lblUserId" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Note" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtName" runat="server" Text='<%# Eval("Name") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Idea" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label ID="lblIdea" runat="server" Text='<%# Eval("Idea") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="lblLIdea" runat="server" Text='<%# Eval("Idea") %>'></asp:Label>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Date-Created" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label ID="lblDate" runat="server" Text='<%# Eval("Date") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="lblDate" runat="server" Text='<%# Eval("Date") %>'></asp:Label>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ButtonType="Button" ShowEditButton="true" ShowDeleteButton="true" ItemStyle-Width="150"/>
                </Columns>
            </asp:GridView>
            <table  border="1" cellpadding="1" cellspacing="1" style="border-collapse: collapse;padding:10px">
            <tr>
                <td style="width: 150px">
                    Idea:<br />
                    <asp:DropDownList runat="server" ID="IdeaDrpdwn" Width="140">

                    </asp:DropDownList>
                </td>
                <td style="width: 150px">
                    Note:<br />
                    <asp:TextBox ID="txtLNameInsert" runat="server" Width="140" />
                </td>
                
                <td style="width: 100px" >
                    <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="AddTask" />
                </td>
            </tr>
            </table>