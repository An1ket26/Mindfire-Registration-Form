<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserNotesControl.ascx.cs" Inherits="UserRegistration.WebUserControl1" %>
<div id="NotesDivControl" class="Notes-div-control">
    <h1 class="Notes-Heading"><u>Notes</u></h1>
    <br/>
    <div id="MainNoteDiv">

    </div>


    <%--Notes Add Part--%>

    <br/><br />
    <div id="AddNotesDiv">
        <h2>Add Notes :</h2>
        <asp:Label runat="server" ID="noteErrorSpan" ClientIDMode="Static" 
            CssClass="note-error-hide">*Please Enter A Note</asp:Label>
        <br />
        <textarea name="Addnote" rows="5" cols="70" id="txtAddnote" placeholder="Enter your Notes"></textarea>
       <br /><br />
        <div id="isPrivateDiv" style="display:inline" runat="server">
            
            <input id="PrivateChkbox" type="checkbox" name="ctl11$isPrivateChkbox">
            <label for="isPrivateChkbox" id="isPrivateLbl">
                Set as Private
            </label>
         </div><br /><br/>
        <button id="btnNotesAdd" class="AddNote-btn">Add</button>
        <br/>
    </div>
</div>





