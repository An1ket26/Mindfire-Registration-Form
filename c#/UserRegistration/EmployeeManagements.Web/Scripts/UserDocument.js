$(document).ready(function () {

    function displaywErrorModal(message) {
        var modal = document.getElementById("myModal");
        var p = document.getElementById("errorMessage");
        var btn = document.getElementById("CloseModal");

        console.log(message);
        modal.style.display = "block";
        p.innerHTML = message;

        btn.onclick = function () {
            modal.style.display = "none";
        }
    }
    const queryString = window.location.search;
    const urlParams = new URLSearchParams(queryString);
    var userId;
    if (urlParams.get('UserId') !== null) {
        userId = urlParams.get('UserId')
        $("#loading-div").css('display', "block");
        $.ajax({
            type: "POST",
            url: "UserDetails.aspx/GetFileName",
            data: JSON.stringify({ id: userId }),
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                if (response.d === null) {
                    displaywErrorModal("Something went Wrong Please try again!!!")
                    return;
                }
                displayAllFiles(response.d);
                $("#loading-div").css('display', "none");
            },
            error: function (err) {
                alert(err.statusText);
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
        $("#loading-div").css('display', "block");
        $.ajax({
            type: "POST",
            url: "FileUploadHandler.ashx",
            data: fileData,
            contentType: false,
            processData: false,
            success: function (response) {
                if (response.d === null) {
                    displaywErrorModal("Something went Wrong Please try again!!!")
                    return;
                }
                $("#loading-div").css('display', "none");
                location.reload();
            },
            error: function (err) {
                alert(err.statusText)
            }
        })
    })
    function createTemplate(file) {
        var pdf = "../Images/pdf.png";
        var doc = "../Images/doc.png"
        var img = "../Images/img.png"
        var unknown = "../Images/unknown.png"
        var extension = file.FileName.split('.')[1];
        if (extension == "pdf") {
            ext = pdf;
        }
        else if (extension == "txt" || extension == "doc" || extension == "word") {
            ext = doc;
        } else if (extension == "png" || extension == "jpg" || extension == "jpeg" || extension == "jfif" || extension == "gif") {
            ext = img;
        } else {
            ext = unknown;
        }
        var template = `<div class="single-li-file-div">
                            <div class="text-file">
                                <p>
                                    <img class="extension-img" src="${ext}" alt="extension image">
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
    }

})