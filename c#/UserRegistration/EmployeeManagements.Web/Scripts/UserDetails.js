$(document).ready(function () {
    function showErrorModal(message) {
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


    function ToRemoveClass(id, className) {
        $(id).removeClass(className);
    }
    function ToAddClass(id, className) {
        $(id).addClass(className);
    }

    var update = false;
    var userId;
    const queryString = window.location.search;
    const urlParams = new URLSearchParams(queryString);
    if (urlParams.get('tab') !== null) {
        var tab = urlParams.get('tab');
        if (tab === "detailsLink") {
            ToRemoveClass("#container", "div-hide");
            ToAddClass("#documentDiv", "div-hide");
            ToAddClass("#notesDiv", "div-hide");
            $("#detailsLink").css("background-color", "Green");
            document.title = "User Details";

        } else if (tab === "NotesLink") {
            ToAddClass("#container", "div-hide");
            ToAddClass("#documentDiv", "div-hide");
            ToRemoveClass("#notesDiv", "div-hide");
            $("#NotesLink").css("background-color", "Green");
            populateNoteAjaxCall();
            document.title = "Notes"
        }
        else if (tab === "documentLink") {
            ToAddClass("#container", "div-hide");
            ToRemoveClass("#documentDiv", "div-hide");
            ToAddClass("#notesDiv", "div-hide");
            $("#documentLink").css("background-color", "Green");
            populateDocumnetAjaxCall()
            document.title = "Documents"
        }
    } else {
        ToRemoveClass("#container", "div-hide");
        ToAddClass("#documentDiv", "div-hide");
        ToAddClass("#notesDiv", "div-hide");
    }


    $("#detailsLink").on('click', function (e) {
        e.preventDefault();
        history.pushState("userdetails", 'Title',
            location.href.split('?')[0] + `?UserId=${userId}&tab=detailsLink`);
        populateDataAjaxCall(userId);
        ToRemoveClass("#container", "div-hide");
        ToAddClass("#documentDiv", "div-hide");
        ToAddClass("#notesDiv", "div-hide");
        $("#detailsLink").css("background-color", "Green");
        $("#NotesLink").css("background-color", "Blue");
        $("#documentLink").css("background-color", "Blue");
        document.title = "User Details";
    });
    $("#NotesLink").on('click', function (e) {
        e.preventDefault();
        history.pushState("userdetails", 'Title',
            location.href.split('?')[0] + `?UserId=${userId}&tab=NotesLink`);
        populateNoteAjaxCall(userId);
        ToAddClass("#container", "div-hide");
        ToAddClass("#documentDiv", "div-hide");
        ToRemoveClass("#notesDiv", "div-hide");
        $("#detailsLink").css("background-color", "Blue");
        $("#NotesLink").css("background-color", "Green");
        $("#documentLink").css("background-color", "Blue");
        document.title = "Notes"

    })
    $("#documentLink").on('click', function (e) {
        e.preventDefault();
        history.pushState("userdetails", 'Title',
            location.href.split('?')[0] + `?UserId=${userId}&tab=documentLink`);
        populateDocumnetAjaxCall();
        displayAllDocumentsAjaxCall(userId)
        ToAddClass("#container", "div-hide");
        ToRemoveClass("#documentDiv", "div-hide");
        ToAddClass("#notesDiv", "div-hide");
        $("#detailsLink").css("background-color", "Blue");
        $("#NotesLink").css("background-color", "Blue");
        $("#documentLink").css("background-color", "Green");
        document.title = "Documents"
    })



    //Initial Loading of Country 
    ajaxCallsForStateAndCountry("FetchCountry", "message", "hi", "#permanentCountry", null);
    ajaxCallsForStateAndCountry("FetchCountry", "message", "hi", "#presentCountry", null);


    //Checking if it is update call or Not
    if (urlParams.get('UserId') !== null) {
        $("#navbar").removeClass("div-hide");
        $("#navbar").addClass("navbar");
        update = true;

        userId = urlParams.get('UserId');
        populateDataAjaxCall(userId);
        $("#submitBtn").val("Update");
    }

    function populateDataAjaxCall(userId) {
        $("#loading-div").css('display', "block");
        $.ajax({
            type: "POST",
            url: 'UserDetails.aspx/FetchUser',
            data: JSON.stringify({ userId: userId }),
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                //check
                if (data.d == null) {
                    showErrorModal("Please try Again");
                    return;
                }
                populateData(data.d);
                $("#RegistrationFormHeading").text("Basic Details");
                $("#loading-div").css('display', "none");
            },
            failure: function (response) {
                alert(response.d);
                $("#loading-div").css('display', "none");
            }
        });
        

    }

    function populateNoteAjaxCall(userId) {
        $("#loading-div").css('display', "block");
        $.ajax({
            type: "POST",
            url: 'UserDetails.aspx/GetUserNote',
            data: JSON.stringify({ userId: userId }),
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.d == null) {
                    showErrorModal();
                    return;
                }
                populateNotesTable(data.d);
                $("#loading-div").css('display', "none");
            },
            failure: function (response) {
                alert(response.d);
            }
        });
    }

    function populateData(data) {
        $("input").each(function () {
            if ($(this).attr("filldata")) {
                var key = $(this).attr("filldata")
                if ($(this).attr("name") === "subscribe") {
                    this.checked = data[key] === "YES";
                }
                else {
                    $(this).val(data[key]);
                }
            }
        })
        $("select").each(function () {
            if ($(this).attr("filldata")) {
                var key = $(this).attr("filldata");

                if ($(this).attr("state-load")) {


                    fetchState($($(this).attr("parent-id")).val(), data[key], `#${$(this).attr("id")}`);
                } else {
                    $(this).val(data[key]);
                }
            }
        })
        $("#RoleListdiv input").each(function () {
            UserRole = data.UserRoles.split(",");
            if (UserRole.includes($(this).val())) {
                this.checked = true;
            }
        })


    }


    //COuntry on Change Load State
    $("#permanentCountry").on("change", function () {

        var val = $(this).val();
        ajaxCallsForStateAndCountry("FetchState", "country", val, "#permanentState", null);
    });
    $("#presentCountry").on("change", function () {
        var val = $(this).val();
        ajaxCallsForStateAndCountry("FetchState", "country", val, "#presentState", null);
    });
    async function fetchState(countryVal, selectedState, stateId) {
        ajaxCallsForStateAndCountry("FetchState", "country", countryVal, stateId, selectedState);
        return true;
    }

    function ajaxCallsForStateAndCountry(urlExtension, keyValue, dataValue, countryOrStateId, selectedState) {
        $("#loading-div").css('display', "block");
        $.ajax({
            type: "POST",
            url: `UserDetails.aspx/${urlExtension}`,
            data: `{${keyValue}:${JSON.stringify(dataValue)}}`,
            contentType: "application/json; charset=utf-8",
            async: false,
            success: function (data) {
                if (data.d == null && urlParams.get('tab') ==="detailsLink") {
                    showErrorModal("Could Not Load State Please Try Again");
                    return;
                }
                LoadOptionsForCountryAndState(data.d, countryOrStateId, selectedState);
                $("#loading-div").css('display', "none");
            },
            failure: function (response) {
                alert(response.d);
                $("#loading-div").css('display', "none");
            }
        });
        
    }
    function LoadOptionsForCountryAndState(apiData, selectId, selectedState) {

        $(selectId)
            .children()
            .remove()
            .end()
            .append(
                '<option value="none" selected disabled hidden>Select an Option</option>'
            );
        if (apiData==null || apiData.length === 0) {
            $(selectId).append(
                createOption(
                    $($(selectId).attr("parent-id")).val(),
                    $($(selectId).attr("parent-id")).val()
                )
            );
        } else {
            for (const data of apiData) {
                $(selectId).append(createOption(data.trim(), data.trim()));
            }
        }
        if (selectedState != null)
            $(selectId).val(selectedState);
    }

    $("#roleDisplay").click(function (event) {
        event.preventDefault();
        var dim = $('#RoleListdiv').is(":visible");
        if(dim==false)
            $("#RoleListdiv").show();
        else
            $("#RoleListdiv").hide();
    })



    //validation
    function checkEmpty(value) {
        if (value.length > 0) {
            return true;
        }
        return false;
    }
    function checkEmail(value) {
        const regex = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
        if (value.length > 0 && regex.test(value) === true) {
            return true;
        }
        return false;
    }
    function checkDob(value) {
        let todayDate = new Date();
        let inputDate = new Date(value);
        const differenceYear =
            (todayDate - inputDate) / (1000 * 60 * 60 * 24 * 365);
        if (differenceYear < 18) {
            return false;
        }
        return true;
    }
    function checkSelectNotNone(value) {
        if (value === null) {
            return false;
        }
        return true;
    }
    function inputValidate(inputTag) {
        if (!inputTag.attr("validation-data")) {
            return false;
        }
        let isError = false;
        const validationTypes = inputTag.attr("validation-data").split(" ");
        for (type of validationTypes) {
            let fl = true;
            if (type === "notEmpty") {
                fl = checkEmpty(inputTag.val().trim());
                $(inputTag.attr("error-id"))
                    .text("*required")
                    .css("display", fl ? "none" : "block");

                if (!fl) {
                    isError = true;
                    break;
                }
            }
            if (type === "email") {
                fl = checkEmail(inputTag.val().trim());
                $(inputTag.attr("error-id"))
                    .text("*enter valid email")
                    .css("display", fl ? "none" : "block");
                if (!fl) {
                    isError = true;
                    break;
                }
            }
            if (type === "dob>18") {
                fl = checkDob(inputTag.val() === "" ? new Date() : inputTag.val());
                $(inputTag.attr("error-id"))
                    .text("*must be 18 years old")
                    .css("display", fl ? "none" : "block");
                if (!fl) {
                    isError = true;
                    break;
                }
            }
            if (type == "matchPassword") {
                fl = inputTag.val().trim() === $("#passwordInput").val().trim();
                $(inputTag.attr("error-id"))
                    .text("*Password does not match")
                    .css("display", fl ? "none" : "block");
                if (!fl) {
                    isError = true;
                    break;
                }
            }
        }
        return isError;
    }

    function selectValidate(selectTag) {
        if (!selectTag.attr("validation-data")) {
            return false;
        }
        let isError = false;
        const validationTypes = selectTag.attr("validation-data").split(" ");
        for (type of validationTypes) {
            let fl = true;
            if (type === "parentCheck") {
                fl = checkSelectNotNone($(selectTag.attr("parent-id")).val());
                $(selectTag.attr("error-id"))
                    .text(`please select ${selectTag.attr("id").includes("State") ? "country" : "state"} first`)
                    .css("display", fl ? "none" : "block");
                if (!fl) {
                    isError = true;
                    break;
                }
            }
            if (type === "notEmpty") {
                fl = checkSelectNotNone(selectTag.val());
                $(selectTag.attr("error-id"))
                    .text("*required")
                    .css("display", fl ? "none" : "block");
                if (!fl) {
                    isError = true;
                    break;
                }
            }
        }
        return isError;
    }

    $("input").on("input change", function () {
        inputValidate($(this));
    });

    $("select").on("click change", function () {
        selectValidate($(this));
    });

    //copy from present to permanent

    $("#copyFromPresentToPermanentCheckbox").click(async function () {
        let isError = false;
        $("#presentAddress input").each(function () {
            isError = isError | inputValidate($(this));
        });
        $("#presentAddress select").each(function () {
            isError = isError | selectValidate($(this));
        });
        if (isError) {
            $(this).prop("checked", false);
            return;
        }
        if (this.checked) {
            $("#permanentAddress input").each(function () {
                if ($(this).attr("copy-val-id"))
                    $(this).val($($(this).attr("copy-val-id")).val());
                inputValidate($(this));
            });
            $("#permanentAddress select").each(async function () {
                if ($(this).attr("load-state-first")) {
                    const res = await fetchState($("#permanentCountry").val(), $($(this).attr("copy-val-id")).val(), `#${$(this).attr("id")}`);

                } else {
                    if ($(this).attr("copy-val-id")) {
                        $(this).val($($(this).attr("copy-val-id")).val());
                        selectValidate($(this));
                    }
                }
            });
        } else {
            $("#permanentAddress input").val("");
            $("#permanentAddress select").html();
            var newOption = $("<option>");
            newOption.val("none");
            newOption.text("Select an Option");
            newOption.attr("selected", true);
            newOption.attr("disabled", true);
            newOption.attr("hidden", true);
            $("#permanentAddress select").append(newOption);
        }
    });
    function createOption(value, text) {
        var newOption = $("<option>");
        newOption.val(value);
        newOption.text(text);
        return newOption;
    }

    //HOBBY

    const initialHobbyOptions = [];
    $("#" + $("#hobbyInput").attr("list") + " option").each(function () {
        initialHobbyOptions.push($(this).val());
    });
    $("#hobbyInput").on("input", function () {
        const lastIndexofComma = $(this).val().lastIndexOf(",");
        let newHobbyOptions = "";
        if (lastIndexofComma !== -1) {
            newHobbyOptions = $(this).val().substr(0, lastIndexofComma) + ",";
        }
        const usedHobbyOptions = newHobbyOptions
            .split(",")
            .map((value) => value.trim());
        if ($(this)[0].list && initialHobbyOptions.length > 0) {
            $("#" + $("#hobbyInput").attr("list")).html("");

            for (const alloption of initialHobbyOptions) {
                if (usedHobbyOptions.indexOf(alloption) < 0) {
                    $("#" + $("#hobbyInput").attr("list")).append(
                        `<option>${newHobbyOptions + alloption}</option>`
                    );
                }
            }
        }
    });

    // image

    $("#profileImageInput").change(function (e) {
        const imgSrc = URL.createObjectURL(e.target.files[0]);
        $("#profileImageDisplay").attr("src", imgSrc);

    })

    //submit action

    const displayResultDiv = (formData) => {
        $("#container input").each(function () {
            if ($(this).attr("displayid")) {

                if (this.id === "subscribeCheckbox") {
                    var x = $("#" + $(this).attr("displayid")).attr("objectName")
                    formData[x] = $(
                        "#subscribeCheckbox"
                    ).is(":checked")
                        ? "YES"
                        : "NO";
                } else {
                    var x = $("#" + $(this).attr("displayid")).attr("objectName");
                    formData[x] = $(this).val() === "" || $(this).val()==null ? "NA" : $(this).val();
                }
            }
        });
        $("#container select").each(function () {
            if ($(this).attr("displayid")) {
                var x = $("#" + $(this).attr("displayid")).attr("objectName")
                formData[x] = $(this).val() === null ? "NA" : $(this).val();
            }
        });
        Roles = "";
        $("#RoleListdiv input").each(function () {
            if (this.checked) {
                Roles += this.value + ",";
            }
        })
        formData.UserRoles = Roles;

    };

    $("#submitBtn").click(function (event) {
        event.preventDefault();
        let isError = false;
        $("#container input").each(function () {
            isError = isError | inputValidate($(this));
        });
        $("#container select").each(function () {
            isError = isError | selectValidate($(this));
        });
        if (isError) {
            return false;
        }
        const formData = {};
        displayResultDiv(formData);
        var files = $("#profileImageInput").get(0).files;
        if (files.length > 0) {
            formData.ImageSrc = files[0].name;
        }
        else {
            formData.ImageSrc = "NA";
        }
        console.log(formData);
        if (update) {
            formData.userId = userId;
            sendToAddOrUpdate("UpdateData", "item", formData)
            populateDataAjaxCall(userId);
        } else {
            sendToAddOrUpdate("StoreData", "user", formData)
            window.location.href = "userlist";
        }
    });
    async function sendToAddOrUpdate(urlExtension, keyValue, formData) {
        $("#loading-div").css('display', "block");
        $.ajax({
            type: "POST",
            url: `UserDetails.aspx/${urlExtension}`,
            data: `{${keyValue}:${JSON.stringify(formData)}}`,
            contentType: "application/json; charset=utf-8",
            async: false,
            success: function (data) {
                if (data.d === null) {
                    showErrorModal("Something Went Wrong,Please try again!!!");
                    return;
                }
                $("#loading-div").css('display', "none");
                console.log(data.d);
            },
            failure: function (response) {
                alert(response.d);
                $("#loading-div").css('display', "none");
            }
        });

        var files = $("#profileImageInput").get(0).files;
        if (files.length == 0) {
            return;
        }
        var fileData = new FormData();
        fileData.append("Email", formData.Email);
        fileData.append(files[0].name, files[0]);
        $("#loading-div").css('display', "block");
        $.ajax({
            type: "POST",
            url: 'ImageUploadHandler.ashx',
            data: fileData,
            contentType: false,
            processData: false,
            success: function (response) {
                if (data.d === null) {
                    showErrorModal("Something Went Wrong,Please try again!!!");
                    return;
                }
                $("#loading-div").css('display', "none");
                console.log(response);
            },
            error: function (err) {
                alert(err.statusText)
                $("#loading-div").css('display', "none");
            }
        })
    }


    //Notes.js

    $("#btnNotesAdd").on('click', function (e) {
        e.preventDefault();
        if ($("#txtAddnote").val().length == 0) {
            $("#noteErrorSpan").removeClass("note-error-hide");
            
        } else {
            $("#noteErrorSpan").addClass("note-error-hide");
            formData = {};
            formData.Notes = $("#txtAddnote").val();
            formData.IsPrivate = $("#PrivateChkbox").get(0).checked ? "YES" : "NO";
            formData.ObjectId = userId;
            $("#loading-div").css('display', "block");
            $.ajax({
                type: "POST",
                url: 'UserDetails.aspx/AddUserNotes',
                data: `{note:${JSON.stringify(formData)}}`,
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d == null) {
                        showErrorModal("Please Try Again");
                        return;
                    }
                    populateNoteAjaxCall(userId)
                    $("#loading-div").css('display', "none");
                },
                failure: function (response) {
                    alert(response.d);
                }
            });
        }
    });

    function afterNotePopulate() {

        $("#Notes-Configure-Div .DeleteNote-btn").each(function () {
            
            $(this).on('click', function (e) {
                if ($(this).attr("src") == "../Images/cancel.png") {
                    //location.reload();
                    populateDataAjaxCall(userId);
                } else {
                    e.preventDefault();
                    console.log($(this).attr("noteId"))
                    var id = $(this).attr("noteId");
                    $("#loading-div").css('display', "block");
                    $.ajax({
                        type: "POST",
                        url: 'UserDetails.aspx/DeleteUserNote',
                        data: JSON.stringify({ noteId: id }),
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            if (data.d === null) {
                                showErrorModal("Please Try Again");
                                return;
                            }
                            populateNoteAjaxCall(userId)
                            $("#loading-div").css('display', "none");
                        },
                        failure: function (response) {
                            alert(response.d);
                            $("#loading-div").css('display', "none");
                        }
                    });}
                })
            
        })


        $("#Notes-Configure-Div .EditNote-btn").each(function () {
            
            $(this).on('click', function (e) {
                e.preventDefault();
                var x = $(this).attr("bt");
                    if (x === "edit") {
                        editBtnClick($(this).attr("id"));
                    }
                })
            
        })
    }

    function editBtnClick(id) {
        $(`#${id}`).attr("bt", "update");
        $(`#${id}`).attr("src", "../Images/update.gif");
        var delId = $(`#${id}`).attr("delId");
        $(delId).attr("src", "../Images/cancel.png");
        
        
        $($(`#${id}`).attr("pId")).html(`<input type="text" id="noteInput${$(`#${id}`).attr("noteId")}" value="${$(`#${id}`).attr("notes")}">`);

        $(`#${id}`).on('click', function (e) {
            e.preventDefault();
            var inputId = `noteInput${$(this).attr("noteId")}`;
            if ($(`#${inputId}`).val().length == 0) {
                alert("Cannot be empty");
                return;
            }
            
            formData = {};
            formData.Notes = $(`#${inputId}`).val();
            formData.NoteId =$(this).attr("noteId");
            console.log(formData);
            $("#loading-div").css('display', "block");
            $.ajax({
                type: "POST",
                url: 'UserDetails.aspx/EditUserNotes',
                data: `{note:${JSON.stringify(formData)}}`,
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d === null) {
                        showErrorModal("Please Try Again");
                        return;
                    }
                    populateNoteAjaxCall(userId)
                    $("#loading-div").css('display', "none");
                },
                failure: function (response) {
                    alert(response.d);
                    $("#loading-div").css('display', "none");
                }
            });
        })
    }

    function CreateNoteTemplate(note) {
        
        var template = `<div class="single-note-div">
                            <p id="p${note.NoteId}" class="note"><img class="note-image" src="../Images/note.png">${ note.Notes}</p>
                            <p class="created">Created By <b>${note.CreatedBy}</b></p>
                            <p class="created"> On <b><i>${note.CreatedOn}</b></i></p>
                            <div id="Notes-Configure-Div" class="NotesButtonDiv">
                             <img src="../Images/edit.png" bt="edit" id="editbtn${note.NoteId}"" class="EditNote-btn" title="update" 
                                pId="#p${note.NoteId}" noteId=${note.NoteId} notes="${note.Notes}" delId="#del${note.NoteId}"/>
                             <img src="../Images/delete.png" class="DeleteNote-btn" title="delete" noteId=${note.NoteId} id="del${note.NoteId}"/>
                            </div>
                        </div> 
                        
        `;
        return template;
    }


    function populateNotesTable(data)
    {
        $("#MainNoteDiv").html("");
        for (var note of data) {
            $("#MainNoteDiv").append(CreateNoteTemplate(note));
        }
        afterNotePopulate();
    }



    //documents

    function displayAllDocumentsAjaxCall(userId) {
        $.ajax({
            type: "POST",
            url: "UserDetails.aspx/GetFileName",
            data: JSON.stringify({ id: userId }),
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                if (response.d === null) {

                    showErrorModal("Something went Wrong Please try again!!!")
                    return;
                }
                displayAllFiles(response.d);
                $("#loading-div").css('display', "none");
            },
            error: function (err) {
                alert(err.statusText);
                $("#loading-div").css('display', "none");
            }
        })
    }

    function populateDocumnetAjaxCall() {
        if (urlParams.get('UserId') !== null) {
            userId = urlParams.get('UserId')
            $("#loading-div").css('display', "block");
            displayAllDocumentsAjaxCall(userId);
        }
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
                    showErrorModal("Something went Wrong Please try again!!!")
                    return;
                }
                $("#loading-div").css('display', "none");
                location.reload();
            },
            error: function (err) {
                alert(err.statusText)
                $("#loading-div").css('display', "none");
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
                                        <img class="download-img" src="../Images/download.gif" title="Download">
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
        $("#DisplayAllFilesDiv").html("");
        for (var file of data) {
            $("#DisplayAllFilesDiv").append(createTemplate(file));
        }
    }
});