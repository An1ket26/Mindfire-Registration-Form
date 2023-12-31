﻿$(document).ready(function () {

    function ToRemoveClass(id,className) {
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
            document.title = "Notes"
        }
        else if (tab === "documentLink") {
            ToAddClass("#container", "div-hide");
            ToRemoveClass("#documentDiv", "div-hide");
            ToAddClass("#notesDiv", "div-hide");
            $("#documentLink").css("background-color", "Green");
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
        populateDataAjaxCall(userId);
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
        populateDataAjaxCall(userId);
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
    if (urlParams.get('UserId') !== null)
    {
        $("#navbar").removeClass("div-hide");
        $("#navbar").addClass("navbar");
        update = true;
        
        userId = urlParams.get('UserId');
        populateDataAjaxCall(userId);
        $("#submitBtn").val("Update"); 
    }

    function populateDataAjaxCall(userId) {
        $.ajax({
            type: "POST",
            url: 'UserDetails.aspx/FetchUser',
            data: JSON.stringify({ userId: userId }),
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                /*console.log(data.d);*/
                populateData(data.d);
                $("#RegistrationFormHeading").text("Basic Details");
            },
            failure: function (response) {
                alert(response.d);
            }
        });
        $.ajax({
            type: "POST",
            url: 'UserDetails.aspx/GetUserNote',
            data: JSON.stringify({ userId: userId }),
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                console.log(data.d);
                populateNotesTable(data.d);
            },
            failure: function (response) {
                alert(response.d);
            }
        });
    }
    
    function populateData(data)
    {
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
        $("select").each(function (){
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
    async function fetchState(countryVal, selectedState, stateId)
    {
        ajaxCallsForStateAndCountry("FetchState", "country", countryVal, stateId, selectedState);
        return true;
    }

    function ajaxCallsForStateAndCountry(urlExtension,keyValue,dataValue,countryOrStateId,selectedState)
    {
        $.ajax({
            type: "POST",
            url: `UserDetails.aspx/${urlExtension}`,
            data: `{${keyValue}:${JSON.stringify( dataValue )}}`,
            contentType: "application/json; charset=utf-8",
            async:false,
            success: function (data) {
                LoadOptionsForCountryAndState(data.d, countryOrStateId, selectedState);
            },
            failure: function (response) {
                alert(response.d);
            }
        });
    }
    function LoadOptionsForCountryAndState(apiData, selectId,selectedState) {

        $(selectId)
            .children()
            .remove()
            .end()
            .append(
                '<option value="none" selected disabled hidden>Select an Option</option>'
            );
        if (apiData.length === 0) {
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
        if (selectedState!=null)
            $(selectId).val(selectedState);
    }

    $("#roleDisplay").click(function (event) {
        event.preventDefault();
;        $("#RoleListdiv").show();
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
                  
                }  else {
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
                    var x =$("#" + $(this).attr("displayid")).attr("objectName")
                    formData[x] = $(
                        "#subscribeCheckbox"
                    ).is(":checked")
                        ? "YES"
                        : "NO";
                } else {
                    var x = $("#" + $(this).attr("displayid")).attr("objectName");
                    formData[x] = $(this).val() === "" ? "NA" : $(this).val();
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
                Roles+=this.value+","; 
            }
        })
        formData.UserRoles = Roles;

    };

    $("#submitBtn").click(function (event)
    {
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
        if (files.length>0) {
            formData.ImageSrc = files[0].name;
        }
        console.log(formData);
        if (update) {
            formData.userId = userId;
            sendToAddOrUpdate("UpdateData", "item", formData)
            location.reload();
        } else {
            sendToAddOrUpdate("StoreData", "user", formData)
            window.location.href = "loginpage";
        }
    });
    async function sendToAddOrUpdate(urlExtension, keyValue, formData)
    {
        $.ajax({
            type: "POST",
            url: `UserDetails.aspx/${urlExtension}`,
            data: `{${keyValue}:${JSON.stringify(formData)}}`,
            contentType: "application/json; charset=utf-8",
            async: false,
            success: function (data) {
                console.log(data.d);
            },
            failure: function (response) {
                alert(response.d);
            }
        });

        var files = $("#profileImageInput").get(0).files;
        if (files.length == 0) {
            return;
        }
        var fileData = new FormData();
        fileData.append("Email", formData.Email);
        fileData.append(files[0].name, files[0]);
        
        $.ajax({
            type: "POST",
            url: 'ImageUploadHandler.ashx',
            data: fileData,
            contentType: false,
            processData: false,
            success: function (response) {
                console.log(response);
            },
            error: function (err) {
                alert(err.statusText)
            }
        })
    }

    $("#btnNotesAdd").on('click', function (e) {
        e.preventDefault();
        formData = {};
        formData.Notes = $("#txtAddnote").val();
        formData.IsPrivate = $("#PrivateChkbox").checked ? "YES" : "NO";
        formData.UserId = userId;
        $.ajax({
            type: "POST",
            url: 'UserDetails.aspx/AddUserNotes',
            data: `{note:${JSON.stringify(formData)}}`,
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                location.reload();
            },
            failure: function (response) {
                alert(response.d);
            }
        });
    });

    function afterNotePopulate() {
        $("#NoteBody td .DeleteNote-btn").each(function () {
            $(this).on('click', function (e) {
                e.preventDefault();
                console.log($(this).attr("noteId"))
                var id = $(this).attr("noteId");
                $.ajax({
                    type: "POST",
                    url: 'UserDetails.aspx/DeleteUserNote',
                    data: JSON.stringify({ noteId: id }),
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        location.reload();
                    },
                    failure: function (response) {
                        alert(response.d);
                    }
                });
            })
        })


        $("#NoteBody td .EditNote-btn").each(function () {
            
                $(this).on('click', function (e) {
                    e.preventDefault();
                    
                    if ($(this).val() === "Edit") {
                        editBtnClick($(this).attr("id"));
                    }
                })
            
        })
    }

    function editBtnClick(id) {
        $(`#${id}`).val("Update");
        $(`#${id}`).css('background-color', 'green');
        $($(`#${id}`).attr("tdId")).html(`<input type="text" id="noteInput${$(`#${id}`).attr("noteId")}" value="${$(`#${id}`).attr("notes")}">`);

        $(`#${id}`).on('click', function (e) {
            e.preventDefault();
            var inputId = `noteInput${$(this).attr("noteId")}`;
            
            formData = {};
            formData.Notes = $(`#${inputId}`).val();
            formData.NoteId =$(this).attr("noteId");
            console.log(formData);
            $.ajax({
                type: "POST",
                url: 'UserDetails.aspx/EditUserNotes',
                data: `{note:${JSON.stringify(formData)}}`,
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    location.reload();
                },
                failure: function (response) {
                    alert(response.d);
                }
            });
        })
    }

    function CreateNoteTemplate(note) {
        var template =`<tr class="UserNotes-Rows">
            <td class="width-250pp" id="td${note.NoteId}">
                <span>${note.Notes}</span>
            </td>
            <td class="width-70pp">
                <span>${note.IsPrivate}</span>
            </td>
            <td class="width-70pp">
                <span>${note.IsPrivate}</span>
            </td>
            <td class="width-150pp">
                <input type="submit"  value="Edit" id="editbtn${note.NoteId}"" class="EditNote-btn" 
                tdId="#td${note.NoteId}" noteId=${note.NoteId} notes="${note.Notes}">
                <input type="submit" value="Delete" class="DeleteNote-btn" noteId=${note.NoteId}>
            </td>
             <tr>`
        return template;
    }


    function populateNotesTable(data)
    {
        $("#NoteBody").html("");
        for (var note of data) {
            $("#NoteBody").append(CreateNoteTemplate(note));
        }
        afterNotePopulate();
    }






 });




