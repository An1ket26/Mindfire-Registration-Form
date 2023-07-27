$(document).ready(function () {
    $("#CheckMethodbtn").on('click', function (event) {
        event.preventDefault();
        $.ajax({
            type: "POST",
            url: '/MyForm/WebForm2.aspx/TestMethod',
            data: '{msg: "HII" }',
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                console.log(data);
            },
            failure: function (response) {
                alert(response.d);
            }
        });
    });
});

