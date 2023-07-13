$(document).ready(function () {
  let formData = JSON.parse(localStorage.getItem("formData"));
  console.log(formData);
  $("#resultDiv span").each(function () {
    $(this).html(formData[$(this).attr("objectName")]);
  });
  $("#profileImageDisplay").attr("src", formData["imageSrc"]);
});
