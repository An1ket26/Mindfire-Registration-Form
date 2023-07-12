const profileImageDisplay = document.getElementById("profileImageDisplay");
const profileImageInput = document.getElementById("profileImageInput");

profileImageInput.addEventListener("change", (e) => {
  const imgSrc = URL.createObjectURL(e.target.files[0]);
  profileImageDisplay.setAttribute("src", imgSrc);
});