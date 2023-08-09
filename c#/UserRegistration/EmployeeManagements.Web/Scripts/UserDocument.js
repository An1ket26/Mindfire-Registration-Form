$(document).ready(function () {
    const queryString = window.location.search;
    const urlParams = new URLSearchParams(queryString);
    if (urlParams.get('UserId') !== null) {
        userId = urlParams.get('UserId');
        $.ajax({
            type: "POST",
            url: "UserDetails.aspx/GetFileName",
            data: JSON.stringify({ id: userId }),
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                //console.log(response.d);
                displayAllFiles(response.d);
            },
            error: function (err) {
                alert(err.statusText)
            }
        })
    }

    $("#uploadBtn").on('click', function (e) {
        e.preventDefault();
        var files = $("#fileUploadInput").get(0).files;
        if (files.length == 0) {
            alert("Please select a file");  
            return false;
        }
        var fileData = new FormData();
        fileData.append("UserId", urlParams.get('UserId'));
        for (var i = 0; i < files.length; i++) {
            fileData.append(files[0].name, files[0]);
        }

        $.ajax({
            type: "POST",
            url: "FileUploadHandler.ashx",
            data: fileData,
            contentType: false,
            processData: false,
            success: function (response) {

                location.reload();
            },
            error: function (err) {
                alert(err.statusText)
            }
        })

    })
    function createTemplate(file) {
        //var template = `<div class="file-container">
        //    <div class="width-10p border-left">${sno}</div>
        //    <div class="width-250p border-left">${file.FileName}</div>
        //    <div class="width-150p border-left">${file.CreatedBy}</div>
        //    <div class="width-150p border-left">${file.CreatedTime}</div>
        //    <div class="width-150p border-left">
        //    <button filename="${userId}-${file.FileName}"">
        //    <a href="FileDownloadHandler.ashx?fileId=${file.Id}&UserId=${file.userId}">Download</a></button></div>
            
        //</div>`;

        var template = `<div class="single-li-file-div">
                            <div class="text-file">
                                <p>
                                    <img class="extension-img" src="../Images/pdf.png" alt="extension image">
                                    <span class="filename">${file.FileName}<span>
                                 </p>
                                <span class="download-link">
                                    <a href="FileDownloadHandler.ashx?fileId=${file.Id}&UserId=${file.userId}">
                                        <img class="download-img" src="../Images/download.gif">
                                    </a>
                                 </span>
                            </div>
                                <div class="author-div">
                                    Created By <b>${file.CreatedBy}</b> On <b><i>${file.CreatedTime}</i></b>
                                </div>
                        </div>
            <hr/>`;

        return template;
    }
    function displayAllFiles(data) {
  
        for (var file of data) {
            $("#DisplayAllFilesDiv").append(createTemplate(file));
           
        }
        $("#deleteBtnDiv button").on('click', function () {

        });
    }

})