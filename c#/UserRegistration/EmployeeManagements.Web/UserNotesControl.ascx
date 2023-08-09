<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserNotesControl.ascx.cs" Inherits="UserRegistration.WebUserControl1" %>
<div id="NotesDivControl" class="Notes-div-control">
    <h2 class="Notes-Heading">Notes</h2>
    <br/>
    <div>
	<table class="Notes-Table" rules="all" border="1" id="GridView2">
		<thead>
            <tr class="UserNotes-Header">
                <th scope="col">Note</th>
                <th scope="col">Created By</th>
                <th scope="col">Created On</th>
                <th scope="col">Configure</th>
		    </tr>
        </thead>
        <tbody id="NoteBody">   
	    </tbody>
	</table>
</div>
    <br/><br />
    <div id="AddNotesDiv">
        <h2>Add Notes :</h2>
        <br/>
        <asp:Label runat="server" ID="noteErrorSpan" ClientIDMode="Static" 
            CssClass="note-error-hide">*Please Enter A Note</asp:Label>
        <br/><br/>
        <textarea name="ctl11$txtAddnote" rows="2" cols="20" id="txtAddnote" placeholder="Enter your Notes"></textarea>
       <br /><br />
        <div id="isPrivateDiv" style="display:inline" runat="server">
            
            <input id="PrivateChkbox" type="checkbox" name="ctl11$isPrivateChkbox">
            <label for="ctl11_isPrivateChkbox" id="ctl11_isPrivateLbl">
                Set as Private
            </label>
         </div><br /><br/>
        <button id="btnNotesAdd" class="AddNote-btn">Add</button>
        <br/>
    </div>
</div>





