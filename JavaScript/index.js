const firstNameInput = document.getElementById("firstNameInput");
const lastNameInput = document.getElementById("lastNameInput");
const profileImageDisplay = document.getElementById("profileImageDisplay");
const profileImageInput = document.getElementById("profileImageInput");
const emailInput = document.getElementById("emailInput");
const dateofBirthInput = document.getElementById("dateofBirthInput");
const genderInput = document.getElementById("genderInput");

const presentAddressLine1 = document.getElementById("presentAddressLine1");
const presentAddressLine2 = document.getElementById("presentAddressLine2");
const presentPostalCode = document.getElementById("presentPostalCode");
const presentCountry = document.getElementById("presentCountry");
const presentState = document.getElementById("presentState");
const presentCity = document.getElementById("presentCity");

const permanentAddressLine1 = document.getElementById("permanentAddressLine1");
const permanentAddressLine2 = document.getElementById("permanentAddressLine2");
const permanentPostalCode = document.getElementById("permanentPostalCode");
const permanentCountry = document.getElementById("permanentCountry");
const permanentState = document.getElementById("permanentState");
const permanentCity = document.getElementById("permanentCity");

const copyFromPresentToPermanentCheckbox = document.getElementById(
  "copyFromPresentToPermanentCheckbox"
);
const hobbyInput = document.getElementById("hobbyInput");

const spanErrorArray = document.getElementsByTagName("span");

const submitButton = document.getElementById("submit");
const errorSize = spanErrorArray.length;

let authToken = "";

const errors = [];
for (let i = 0; i < errorSize; i++) {
  errors[i] = true;
}

//-------------------------------------------Validations-------------------------------

firstNameInput.addEventListener("input", () => {
  const firstNameData = firstNameInput.value.trim();
  if (firstNameData.length === 0) {
    firstNameInput.style.borderColor = "red";
    spanErrorArray[0].style.display = "";
    errors[0] = true;
  } else {
    firstNameInput.style.borderColor = "black";
    spanErrorArray[0].style.display = "none";
    errors[0] = false;
  }
});

lastNameInput.addEventListener("input", () => {
  const lastNameData = lastNameInput.value.trim();
  if (lastNameData.length === 0) {
    lastNameInput.style.borderColor = "red";
    spanErrorArray[1].style.display = "";
    errors[1] = true;
  } else {
    lastNameInput.style.borderColor = "black";
    spanErrorArray[1].style.display = "none";
    errors[1] = false;
  }
});

emailInput.addEventListener("input", () => {
  const emailData = emailInput.value.trim();
  const regex = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
  if (emailData.length === 0 || regex.test(emailData) === false) {
    emailInput.style.borderColor = "red";
    spanErrorArray[2].style.display = "";
    errors[2] = true;
  } else {
    emailInput.style.borderColor = "black";
    spanErrorArray[2].style.display = "none";
    errors[2] = false;
  }
});

dateofBirthInput.addEventListener("change", () => {
  let todayDate = new Date();
  let inputDate = new Date(dateofBirthInput.value);
  const differenceYear = (todayDate - inputDate) / (1000 * 60 * 60 * 24 * 365);
  if (differenceYear < 18) {
    spanErrorArray[3].style.display = "";
    errors[3] = true;
  } else {
    errors[3] = false;
    spanErrorArray[3].style.display = "none";
  }
});

genderInput.addEventListener("change", () => {
  if (
    genderInput.value === "Male" ||
    genderInput.value === "Female" ||
    genderInput.value === "other"
  ) {
    // console.log(genderInput.value);
    errors[4] = false;
    spanErrorArray[4].style.display = "none";
  }
});

//-----------------------------------------Present address-------------------------------

presentAddressLine1.addEventListener("input", () => {
  const addr1Data = presentAddressLine1.value.trim();
  if (addr1Data.length === 0) {
    presentAddressLine1.style.borderColor = "red";
    spanErrorArray[5].style.display = "";
    errors[5] = true;
  } else {
    presentAddressLine1.style.borderColor = "black";
    spanErrorArray[5].style.display = "none";
    errors[5] = false;
  }
});

presentPostalCode.addEventListener("input", () => {
  const postalCode = presentPostalCode.value.trim();
  if (postalCode.length === 0) {
    presentPostalCode.style.borderColor = "red";
    spanErrorArray[6].style.display = "";
    errors[6] = true;
  } else {
    presentPostalCode.style.borderColor = "black";
    spanErrorArray[6].style.display = "none";
    errors[6] = false;
  }
});

presentState.addEventListener("click", () => {
  if (presentCountry.value === "none") {
    spanErrorArray[8].style.display = "";
    errors[8] = true;
  } else {
    spanErrorArray[8].style.display = "none";
    errors[8] = false;
  }
});

presentCity.addEventListener("click", () => {
  if (presentState.value === "none") {
    spanErrorArray[9].style.display = "";
    errors[9] = true;
  } else {
    spanErrorArray[9].style.display = "none";
    errors[9] = false;
  }
});

//---------------------------------------------Permanent address-------------------------------------

permanentAddressLine1.addEventListener("input", () => {
  const addr1Data = permanentAddressLine1.value.trim();
  if (addr1Data.length === 0) {
    permanentAddressLine1.style.borderColor = "red";
    spanErrorArray[10].style.display = "";
    errors[10] = true;
  } else {
    permanentAddressLine1.style.borderColor = "black";
    spanErrorArray[10].style.display = "none";
    errors[10] = false;
  }
});

permanentPostalCode.addEventListener("input", () => {
  const postalCode = permanentPostalCode.value.trim();
  if (postalCode.length === 0) {
    permanentPostalCode.style.borderColor = "red";
    spanErrorArray[11].style.display = "";
    errors[11] = true;
  } else {
    permanentPostalCode.style.borderColor = "black";
    spanErrorArray[11].style.display = "none";
    errors[11] = false;
  }
});

permanentState.addEventListener("click", () => {
  if (permanentCountry.value === "none") {
    spanErrorArray[13].style.display = "";
    errors[13] = true;
  } else {
    spanErrorArray[13].style.display = "none";
    errors[13] = false;
  }
});

permanentCity.addEventListener("click", () => {
  if (permanentState.value === "none") {
    spanErrorArray[14].style.display = "";
    errors[14] = true;
  } else {
    spanErrorArray[14].style.display = "none";
    errors[14] = false;
  }
});

//--------------------------------------------profileImageDisplay------------------------------

profileImageInput.addEventListener("change", (e) => {
  const imgSrc = URL.createObjectURL(e.target.files[0]);
  profileImageDisplay.setAttribute("src", imgSrc);
});

// --------------------------Copy from present to permanent address---------------------------------

const checkPresentAddressData = () => {
  let isError = false;
  for (let i = 5; i <= 9; i++) {
    if (errors[i] == true) {
      spanErrorArray[i].style.display = "";
    } else {
      spanErrorArray[i].style.display = "none";
    }
    isError = isError || errors[i];
  }
  return isError;
};

const presentToPermanent = async () => {
  if (checkPresentAddressData()) {
    return;
  }
  if (copyFromPresentToPermanentCheckbox.checked) {
    permanentAddressLine1.value = presentAddressLine1.value;
    permanentAddressLine2.value = presentAddressLine2.value;
    permanentPostalCode.value = presentPostalCode.value;
    permanentCountry.value = presentCountry.value;
    await countryChange();
    permanentState.value = presentState.value;
    await permanentFetchCity();
    permanentCity.value = presentCity.value;
    for (let i = 10; i <= 14; i++) {
      errors[i] = false;
      spanErrorArray[i].style.display = "none";
    }
  } else {
    permanentAddressLine1.value = "";
    permanentAddressLine2.value = "";
    permanentPostalCode.value = "";
    permanentCountry.value = permanentCountry.options[0].value;
    permanentState.innerHTML = "";
    var option2 = document.createElement("option");
    option2.value = "none";
    option2.text = "Select an Option";
    option2.setAttribute("selected", "selected");
    option2.setAttribute("hidden", "hidden");
    option2.setAttribute("disabled", "disabled");
    permanentState.add(option2);
    permanentCity.innerHTML = "";
    var option = document.createElement("option");
    option.setAttribute("hidden", "hidden");
    option.setAttribute("disabled", "disabled");
    option.value = "none";
    option.text = "Select an Option";
    option.setAttribute("selected", "selected");
    permanentCity.add(option);
    for (let i = 10; i <= 14; i++) {
      errors[i] = true;
      spanErrorArray[i].style.display = "";
    }
  }
};

//--------------------------------------Hobby options------------------------------------------

const initialHobbyOptions = Array.from(hobbyInput.list.options).map(
  (opt) => opt.value
);
hobbyInput.addEventListener("input", () => {
  const lastIndexofComma = hobbyInput.value.lastIndexOf(",");
  let newHobbyOptions = "";
  if (lastIndexofComma !== -1) {
    newHobbyOptions = hobbyInput.value.substr(0, lastIndexofComma) + ",";
  }
  const usedHobbyOptions = newHobbyOptions
    .split(",")
    .map((value) => value.trim());
  const validateHobbyOptions = hobbyInput.value
    .split(",")
    .map((value) => value.trim());
  if (validateHobbyOptions.length < 3 || validateHobbyOptions[2] === "") {
    spanErrorArray[15].style.display = "";
    errors[15] = true;
  } else {
    spanErrorArray[15].style.display = "none";
    errors[15] = false;
  }
  if (hobbyInput.list && initialHobbyOptions.length > 0) {
    hobbyInput.list.innerHTML = "";
    for (const alloption of initialHobbyOptions) {
      if (usedHobbyOptions.indexOf(alloption) < 0) {
        const option = document.createElement("option");
        option.value = newHobbyOptions + alloption;
        hobbyInput.list.append(option);
      }
    }
  }
});

//------------------------------------Fetch Country-----------------------------------

const fetchCountries = async () => {
  const res = await fetch(
    "https://www.universal-tutorial.com/api/getaccesstoken",
    {
      headers: {
        Accept: "application/json",
        "api-token":
          "DP-xCbqqy0OnZp9sKEYOyT40C_GA3jBqbToYdAO26juveWeTAfQojElWKqDttEzkrEs",
        "user-email": "somehrlp@gmail.com",
      },
    }
  );
  const resToken = await res.json();
  authToken = await resToken.auth_token;

  const response = await fetch(
    "https://www.universal-tutorial.com/api/countries",
    {
      headers: {
        Authorization: `Bearer ${authToken}`,
        Accept: "application/json",
      },
    }
  );

  const countryData = await response.json();
  for (const countries of countryData) {
    var option = document.createElement("option");
    option.value = countries.country_name;
    option.text = countries.country_name;
    permanentCountry.add(option);
    var option2 = document.createElement("option");
    option2.value = countries.country_name;
    option2.innerHTML = countries.country_name;
    presentCountry.add(option2);
  }
};

//----------------------------------Fetch State---------------------------------------

const fetchState = async (countryInputValue) => {
  const response = await fetch(
    `https://www.universal-tutorial.com/api/states/${countryInputValue}`,
    {
      headers: {
        Authorization: `Bearer ${authToken}`,
        Accept: "application/json",
      },
    }
  );
  const stateApiData = await response.json();
  return stateApiData;
};

const countryChange = async () => {
  errors[12] = false;
  spanErrorArray[12].style.display = "none";

  const countryInputValue = permanentCountry.value;
  const stateApiData = await fetchState(countryInputValue);

  permanentState.innerHTML = "";
  let option = document.createElement("option");
  option.setAttribute("hidden", "hidden");
  option.setAttribute("disabled", "disabled");
  option.value = "none";
  option.text = "Select an Option";
  option.setAttribute("selected", "selected");
  permanentState.add(option);

  permanentCity.innerHTML = "";
  let option3 = document.createElement("option");
  option3.setAttribute("hidden", "hidden");
  option3.setAttribute("disabled", "disabled");
  option3.value = "none";
  option3.text = "Select an Option";
  option3.setAttribute("selected", "selected");
  permanentCity.add(option3);

  errors[13] = true;

  for (const stateData of stateApiData) {
    var option2 = document.createElement("option");
    option2.value = stateData.state_name;
    option2.text = stateData.state_name;
    permanentState.add(option2);
  }
};

permanentCountry.addEventListener("change", countryChange);

presentCountry.addEventListener("change", async () => {
  errors[7] = false;
  spanErrorArray[7].style.display = "none";

  const countryInputValue = presentCountry.value;
  const stateApiData = await fetchState(countryInputValue);

  presentState.innerHTML = "";
  let option = document.createElement("option");
  option.setAttribute("hidden", "hidden");
  option.setAttribute("disabled", "disabled");
  option.value = "none";
  option.text = "Select an Option";
  option.setAttribute("selected", "selected");
  presentState.add(option);

  presentCity.innerHTML = "";
  let option3 = document.createElement("option");
  option3.setAttribute("hidden", "hidden");
  option3.setAttribute("disabled", "disabled");
  option3.value = "none";
  option3.text = "Select an Option";
  option3.setAttribute("selected", "selected");
  presentCity.add(option3);

  errors[8] = true;

  for (const stateData of stateApiData) {
    var option2 = document.createElement("option");
    option2.value = stateData.state_name;
    option2.text = stateData.state_name;
    presentState.add(option2);
  }
});

//----------------------------------Fetch City----------------------------------------------

const permanentCityChange = async () => {
  permanentFetchCity();
};
const presentCityChange = async () => {
  presentFetchCity();
};
permanentState.addEventListener("change", permanentCityChange);
presentState.addEventListener("change", presentCityChange);

const permanentFetchCity = async () => {
  errors[13] = false;
  spanErrorArray[13].style.display = "none";

  const stateName = permanentState.value;
  const response = await fetch(
    `https://www.universal-tutorial.com/api/cities/${stateName}`,
    {
      headers: {
        Authorization: `Bearer ${authToken}`,
        Accept: "application/json",
      },
    }
  );
  const cityData = await response.json();

  permanentCity.innerHTML = "";
  let option = document.createElement("option");
  option.setAttribute("hidden", "hidden");
  option.setAttribute("disabled", "disabled");
  option.value = "none";
  option.text = "Select an Option";
  option.setAttribute("selected", "selected");
  permanentCity.add(option);

  errors[14] = true;

  if (cityData.length === 0) {
    let option2 = document.createElement("option");
    option2.value = stateName;
    option2.text = stateName;
    permanentCity.add(option2);
  } else {
    for (const cit of cityData) {
      let option2 = document.createElement("option");
      option2.value = cit.city_name;
      option2.text = cit.city_name;
      permanentCity.add(option2);
    }
  }
};

const presentFetchCity = async () => {
  const stateName = presentState.value;
  const response = await fetch(
    `https://www.universal-tutorial.com/api/cities/${stateName}`,
    {
      headers: {
        Authorization: `Bearer ${authToken}`,
        Accept: "application/json",
      },
    }
  );
  const cityData = await response.json();

  presentCity.innerHTML = "";
  let option = document.createElement("option");
  option.setAttribute("hidden", "hidden");
  option.setAttribute("disabled", "disabled");
  option.value = "none";
  option.text = "Select an Option";
  option.setAttribute("selected", "selected");
  presentCity.add(option);
  errors[9] = true;

  if (cityData.length === 0) {
    let option2 = document.createElement("option");
    option2.value = stateName;
    option2.text = stateName;
    presentCity.add(option2);
  } else {
    for (const cit of cityData) {
      var option2 = document.createElement("option");
      option2.value = cit.city_name;
      option2.text = cit.city_name;
      presentCity.add(option2);
    }
  }
};

//------------------------------------------Form submit actions-------------------------------------------

const onSubmit = (e) => {
  e.preventDefault();
  let isError=false;
  for (let i = 0; i < errorSize; i++) {
    if (errors[i]) {
      spanErrorArray[i].style.display = "";
    }
    isError=isError||errors[i];
  }
  if(!isError){
    const formData = {
      "First Name":firstNameInput.value,
      "Last Name":lastNameInput.value,
      "Email ":emailInput.value,
      "Date of Birth":dateofBirthInput.value,
      "Gender":genderInput.value,
      "Present Address":{
        "Address line 1":presentAddressLine1.value,
        "Address line 2":presentAddressLine2.value,
        "Postal Code":presentPostalCode.value,
        "Country":presentCountry.value,
        "State":presentState.value,
        "City":presentCity.value,
      },
      "Permanent Address":{
        "Address line 1":permanentAddressLine1.value,
        "Address line 2":permanentAddressLine2.value,
        "Postal Code":permanentPostalCode.value,
        "Country":permanentCountry.value,
        "State":permanentState.value,
        "City":permanentCity.value,
      },
      "Hobbies":hobbyInput.value.split(','),
    };
  console.log(formData);
  }
  else{
  return false;
  }
};

submitButton.addEventListener("click", onSubmit);

//----------------------------------------Initial Function Calls-------------------------------------------

fetchCountries();
