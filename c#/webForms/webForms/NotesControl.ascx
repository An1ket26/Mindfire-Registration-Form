<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NotesControl.ascx.cs" Inherits="webForms.NotesControl" %>

<asp:GridView 
                ID="GridView1" 
                runat="server"  
                DataKeyNames="Id" 
                AutoGenerateColumns="false" 
                EmptyDataText="No records has been added."
                OnRowEditing="OnRowEditing" 
                OnRowCancelingEdit="OnRowCancelingEdit" 
                OnRowDeleting="OnRowDeleting" 
                OnRowUpdating="OnRowUpdating">
              
                <Columns>
                    <asp:TemplateField HeaderText="NoteId" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label ID="lblNoteId" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="lblNoteId" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Note" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label ID="lblNote" runat="server" Text='<%# Eval("Notes") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtNote" runat="server" Text='<%# Eval("Notes") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ButtonType="Button" ShowEditButton="true" ShowDeleteButton="true" ItemStyle-Width="150"/>
                </Columns>
            </asp:GridView>
            <br/>
            <h5>Add Notes :</h5>
            <table  border="1" cellpadding="1" cellspacing="1" style="border-collapse: collapse;padding:10px">
            <tr>
                <td style="width: 150px">
                    Note:<br />
                    <asp:TextBox ID="txtAddnote" runat="server" Width="140" />
                </td>
                
                <td style="width: 100px" >
                    <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="AddNote" Enabled="false"/>
                </td>
            </tr>
            </table>