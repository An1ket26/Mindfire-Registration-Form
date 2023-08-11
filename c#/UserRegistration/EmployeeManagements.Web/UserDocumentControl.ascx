<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserDocumentControl.ascx.cs" Inherits="UserRegistration.UserDocumentControl" %>

<div>
    <h1 class="file-heading">Documents</h1>
    <br/>
    <div id="DisplayAllFilesDiv">
    </div>
    <br/>
    <span id="fileUploadError">*Please Select a file</span>
    <div class="upload-div">
        <input type="file" id="fileUploadInput" />
        <button id="uploadBtn">Upload</button>
    </div>
</div>