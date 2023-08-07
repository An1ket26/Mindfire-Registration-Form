<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserDocumentControl.ascx.cs" Inherits="UserRegistration.UserDocumentControl" %>

<div>
    <h1 class="file-heading">Documents</h1>
    <br/>
    <div id="DisplayAllFilesDiv">
        <div class="file-container file-Header">
            <div class="width-10p">S.No</div>
            <div class="width-250p">File Name</div>
            <div class="width-150p">Download</div>
            <%--<div class="width-150p">Delete</div>--%>
        </div>
    </div>
    <br/>
    <div class="upload-div">
        <input type="file" id="fileUploadInput" />
        <button id="uploadBtn">Upload</button>
    </div>
</div>
<script src="Scripts/UserDocument.js"></script>