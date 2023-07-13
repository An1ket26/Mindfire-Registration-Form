$(document).ready(function(){
    let formData= JSON.parse($.cookie("formData"));
    console.log(formData);
    $("#resultDiv span").each(function(){
        $(this).html(formData[$(this).attr("objectName")]);
    })
    $("#profileImageDisplay").attr("src",formData["imageSrc"])
})