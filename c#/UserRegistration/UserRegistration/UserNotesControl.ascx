<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserNotesControl.ascx.cs" Inherits="UserRegistration.WebUserControl1" %>
<div id="NotesDiv" class="hide-notes">
    <h2 class="Notes-Heading">Notes :</h2>
    <br/>
<asp:GridView 
                ID="GridView2" 
                runat="server"  
                DataKeyNames="Id" 
                AutoGenerateColumns="false" 
                EmptyDataText="No records has been added."
                OnRowEditing="OnRowEditing" 
                OnRowCancelingEdit="OnRowCancelingEdit" 
                OnRowDeleting="OnRowDeleting"  OnRowUpdating="OnRowUpdating"
                CssClass="Notes-Table" HeaderStyle-CssClass="UserNotes-Header" RowStyle-CssClass="UserNotes-Rows"
    >
              
                <Columns>
                    <asp:TemplateField HeaderText="NoteId" ItemStyle-CssClass="width-70">
                        <ItemTemplate>
                            <asp:Label ID="lblNoteId" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="lblNoteId" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Note" ItemStyle-CssClass="width-250">
                        <ItemTemplate>
                            <asp:Label ID="lblNote" runat="server" Text='<%# Eval("Notes") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtNote" runat="server" Text='<%# Eval("Notes") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Configure" ItemStyle-CssClass="width-150">
                        <ItemTemplate>
                            <asp:Button runat="server" CommandName="Edit" Text="Edit" CssClass="EditNote-btn"/>
                            <asp:Button runat="server" CommandName="Delete" Text="Delete" CssClass="DeleteNote-btn"/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Button runat="server" CommandName="Update" Text="Update" CssClass="EditNote-btn"/>
                            <asp:Button runat="server" CommandName="Cancel" Text="Cancel" CssClass="DeleteNote-btn"/>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true" ItemStyle-CssClass="width-150"/>--%>
                </Columns>
            </asp:GridView>
            <br/>
            <h2>Add Notes :</h2>
    <br/>
            <table cellpadding="1" cellspacing="1" style="border-collapse: collapse;padding:10px">
            <tr>
                <td class="width-250">
                    <asp:TextBox ID="txtAddnote" runat="server" placeholder="Enter your Notes" ClientIDMode="Static" />
                </td>
                
                <td>
                    <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="AddNote" CssClass="AddNote-btn"/>
                </td>
            </tr>
            </table>
    <br/>
</div>