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
    function createTemplate(sno, name) {
        userId = urlParams.get('UserId');
        var template = `<div class="file-container">
            <div class="width-10p border-left">${sno}</div>
            <div class="width-250p border-left">${name}</div>
            <div class="width-150p border-left">
            <button filename="${userId}-${name}"">
            <a href="FileDownloadHandler.ashx?filename=${userId}-${name}&UserId=${userId}">Download</a></button></div>
            
        </div>`;

        return template;
    }
    function displayAllFiles(data) {
        var sno = 1;
        for (var name of data) {
            $("#DisplayAllFilesDiv").append(createTemplate(sno, name));
            sno++;
        }
        $("#deleteBtnDiv button").on('click', function () {

        });
    }

})