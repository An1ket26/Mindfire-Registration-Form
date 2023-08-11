
var modal = document.getElementById("myModal");
var p = document.getElementById("errorMessage");
var btn1 = document.getElementById("CloseModal");
function displayModal(message) {
    
    console.log(message);
    modal.style.display = "block";
    p.innerHTML = message;
}
btn1.onclick = function () {
    modal.style.display = "none";
}
