
$(document).ready(function () {
    $.ajax({
        type: "POST",
        url: 'UserList2.aspx/GetUserDetails',
        data: JSON.stringify({ message: "hi" }),
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            populateData(data.d);
            edit();
        },
        failure: function (response) {
            alert(response.d);
        }
    })


    function createTemplate(user) {
        
        var rowTemplate = `
        <div class="container">
            <div class="width-70 border-left">${user.userId}</div>
            <div class="width-150 border-left">${user.FirstName}</div>
            <div class="width-150 border-left">${user.LastName}</div>
            <div class="width-150 border-left">${user.Email}</div>
            <div class="width-150 border-left">${user.DateofBirth}</div>
            <div class="width-250 border-left">${user.Hobby}</div>
            <div class="width-250 border-left">${user.UserRoles}</div>
            <div class="width-70 border-left" class="editbtndiv"">
            <button class="editbtn" data-userId="${user.userId }">EDIT</button>
            <button class="deletebtn" data-userId="${user.userId }">DELETE</button>
            </div>
        </div>
        `;
        return rowTemplate;
    }
    

    function populateData(DataList)
    {
        for (var user of DataList) {
            console.log(user);
            //var btn = document.createElement("button");
            //btn.id = `btn${user.userId}`;
            var tempTemplate = createTemplate(user);
            $("#main").append(tempTemplate);
            //$("#main").append(btn);
            //$(`#btn${user.userId}`).on('click', function () {
            //    console.log(user.userId);
            //})
            
        }
    }
    function edit() {
        $("div .editbtn").each(function () {
            $(this).on("click", function () {
                var id = $(this).attr("data-userId");   
                window.location.href = `UserDetails?UserId=${id}`;
            })
        })
        $("div .deletebtn").each(function () {
            $(this).on("click", function () {
                var id = $(this).attr("data-userId");
                $.ajax({
                    type: "POST",
                    url: 'UserList2.aspx/DeleteUser',
                    data: JSON.stringify({ userId: id }),
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        location.reload();
                    },
                    failure: function (response) {
                        alert(response.d);
                    }
                })
            })
        })
            
    }
    $("#addUser").on('click', function () {
        window.location.href = `UserDetails`;
    })


    
    
})