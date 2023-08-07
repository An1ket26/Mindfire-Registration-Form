<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserNotesControl.ascx.cs" Inherits="UserRegistration.WebUserControl1" %>
<div id="NotesDivControl" class="Notes-div-control">
    <h2 class="Notes-Heading">Notes</h2>
    <br/>
<asp:GridView 
                ID="GridView2" 
                runat="server"  
                DataKeyNames="Id" 
                AutoGenerateColumns="false" 
                EmptyDataText="No notes has been added."
                OnRowEditing="OnRowEditing" 
                OnRowCancelingEdit="OnRowCancelingEdit" 
                OnRowDeleting="OnRowDeleting"  OnRowUpdating="OnRowUpdating"
                CssClass="Notes-Table" HeaderStyle-CssClass="UserNotes-Header" RowStyle-CssClass="UserNotes-Rows"
    >
              
                <Columns>
                    <asp:TemplateField HeaderText="NoteId" ItemStyle-CssClass="width-70pp">
                        <ItemTemplate>
                            <asp:Label ID="lblNoteId" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="lblNoteId" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Note" ItemStyle-CssClass="width-250pp">
                        <ItemTemplate>
                            <asp:Label ID="lblNote" runat="server" Text='<%# Eval("Notes") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtNote" runat="server" Text='<%# Eval("Notes") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="IsPrivate" ItemStyle-CssClass="width-70pp">
                        <ItemTemplate>
                            <asp:Label ID="lblIsPrivate" runat="server" Text='<%# Eval("IsPrivate") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="lblIsPrivate" runat="server" Text='<%# Eval("IsPrivate") %>'></asp:Label>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Configure" ItemStyle-CssClass="width-150pp">
                        <ItemTemplate>
                            <asp:Button runat="server" CommandName="Edit" Text="Edit" CssClass="EditNote-btn"/>
                            <asp:Button runat="server" CommandName="Delete" Text="Delete" CssClass="DeleteNote-btn"/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Button runat="server" CommandName="Update" Text="Update" CssClass="EditNote-btn"/>
                            <asp:Button runat="server" CommandName="Cancel" Text="Cancel" CssClass="DeleteNote-btn"/>
                        </EditItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
    <br/><br />
    <div id="AddNotesDiv">
        <h2>Add Notes :</h2>
        <br/>
        <asp:Label runat="server" ID="noteErrorSpan" ClientIDMode="Static" 
            CssClass="note-error-hide">*Please Enter A Note</asp:Label>
        <br/><br/>
        <asp:TextBox ID="txtAddnote" 
            runat="server" 
            placeholder="Enter your Notes" 
            TextMode="MultiLine" 
            ClientIDMode="Static"/>
       <br /><br />
        <div id="isPrivateDiv" runat="server">
            
            <asp:CheckBox runat="server" ID="isPrivateChkbox"/>
            <asp:Label runat="server" ID="isPrivateLbl" 
                AssociatedControlID="isPrivateChkbox">
                Set as Private
            </asp:Label>
         </div><br /><br/>
        <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="AddNote" CssClass="AddNote-btn"/>
        <br/>
    </div>
</div>