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
const enteredHobbies=document.getElementById("enteredHobbies");
const resultDiv = document.getElementById("resultDiv");

const copyFromPresentToPermanentCheckbox = document.getElementById(
  "copyFromPresentToPermanentCheckbox"
);
const hobbyInput = document.getElementById("hobbyInput");

const spanErrorArray = document
  .getElementById("formMain")
  .getElementsByTagName("span");

const submitButton = document.getElementById("submit");
const errorSize = spanErrorArray.length;

let authToken = "";

const errors = [];
for (let i = 0; i < errorSize; i++) {
  errors[i] = true;
}

//-----------------------------------------------Validations-------------------------------------------------

const inputChangeValidationWrong = (elementId, index) => {
  elementId.style.borderColor = "red";
  spanErrorArray[index].style.display = "block";
  errors[index] = true;
};
const inputChangeValidationCorrect = (elementId, index) => {
  elementId.style.borderColor = "black";
  spanErrorArray[index].style.display = "none";
  errors[index] = false;
};

firstNameInput.addEventListener("input", () => {
  const firstNameData = firstNameInput.value.trim();
  if (firstNameData.length === 0) {
    inputChangeValidationWrong(firstNameInput, 0);
  } else {
    inputChangeValidationCorrect(firstNameInput, 0);
  }
});

lastNameInput.addEventListener("input", () => {
  const lastNameData = lastNameInput.value.trim();
  if (lastNameData.length === 0) {
    inputChangeValidationWrong(lastNameInput, 1);
  } else {
    inputChangeValidationCorrect(lastNameInput, 1);
  }
});

emailInput.addEventListener("input", () => {
  const emailData = emailInput.value.trim();
  const regex = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
  if (emailData.length === 0 || regex.test(emailData) === false) {
    inputChangeValidationWrong(emailInput, 2);
  } else {
    inputChangeValidationCorrect(emailInput, 2);
  }
});

dateofBirthInput.addEventListener("change", () => {
  let todayDate = new Date();
  let inputDate = new Date(dateofBirthInput.value);
  const differenceYear = (todayDate - inputDate) / (1000 * 60 * 60 * 24 * 365);
  if (differenceYear < 18) {
    inputChangeValidationWrong(dateofBirthInput, 3);
  } else {
    inputChangeValidationCorrect(dateofBirthInput, 3);
  }
});

genderInput.addEventListener("change", () => {
  if (
    genderInput.value === "Male" ||
    genderInput.value === "Female" ||
    genderInput.value === "other"
  ) {
    inputChangeValidationCorrect(genderInput, 4);
  }
});

//--------------------------------------------Present address---------------------------------------------

presentAddressLine1.addEventListener("input", () => {
  const presentAddressLine1Data = presentAddressLine1.value.trim();
  if (presentAddressLine1Data.length === 0) {
    inputChangeValidationWrong(presentAddressLine1, 5);
  } else {
    inputChangeValidationCorrect(presentAddressLine1, 5);
  }
});

presentPostalCode.addEventListener("input", () => {
  const postalCode = presentPostalCode.value.trim();
  if (postalCode.length === 0) {
    inputChangeValidationWrong(presentPostalCode, 6);
  } else {
    inputChangeValidationCorrect(presentAddressLine1, 6);
  }
});

presentState.addEventListener("click", () => {
  if (presentCountry.value === "none") {
    inputChangeValidationWrong(presentState, 8);
  } else {
    inputChangeValidationCorrect(presentState, 8);
  }
});

presentCity.addEventListener("click", () => {
  if (presentState.value === "none") {
    inputChangeValidationWrong(presentCity, 9);
  } else {
    inputChangeValidationCorrect(presentCity, 9);
  }
});

//---------------------------------------------Permanent address-------------------------------------

permanentAddressLine1.addEventListener("input", () => {
  const permanentAddressLine1Data = permanentAddressLine1.value.trim();
  if (permanentAddressLine1Data.length === 0) {
    inputChangeValidationWrong(permanentAddressLine1, 10);
  } else {
    inputChangeValidationCorrect(permanentAddressLine1, 10);
  }
});

permanentPostalCode.addEventListener("input", () => {
  const postalCode = permanentPostalCode.value.trim();
  if (postalCode.length === 0) {
    inputChangeValidationWrong(permanentPostalCode, 11);
  } else {
    inputChangeValidationCorrect(permanentAddressLine1, 11);
  }
});

permanentState.addEventListener("click", () => {
  if (permanentCountry.value === "none") {
    inputChangeValidationWrong(permanentState, 13);
  } else {
    inputChangeValidationCorrect(permanentState, 13);
  }
});

permanentCity.addEventListener("click", () => {
  if (permanentState.value === "none") {
    inputChangeValidationWrong(permanentCity, 14);
  } else {
    inputChangeValidationCorrect(permanentCity, 14);
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
      spanErrorArray[i].style.display = "block";
    } else {
      spanErrorArray[i].style.display = "none";
    }
    isError = isError || errors[i];
  }
  return isError;
};

const createOptionSelect = () => {
  var option = document.createElement("option");
  option.value = "none";
  option.text = "Select an Option";
  option.setAttribute("selected", "selected");
  option.setAttribute("hidden", "hidden");
  option.setAttribute("disabled", "disabled");
  return option;
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
    await countryChange(
      12,
      permanentCountry,
      permanentState,
      permanentCity,
      13
    );
    permanentState.value = presentState.value;
    await fetchCity(13, permanentState, permanentCity, 14);
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
    permanentState.add(createOptionSelect());
    permanentCity.innerHTML = "";
    permanentCity.add(createOptionSelect());
    for (let i = 10; i <= 14; i++) {
      errors[i] = true;
      spanErrorArray[i].style.display = "block";
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
  if (validateHobbyOptions.length < 1 || validateHobbyOptions[0] === "") {
    spanErrorArray[15].style.display = "block";
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

const createOption = (value, text) => {
  var option = document.createElement("option");
  option.value = value;
  option.text = text;
  return option;
};

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
    permanentCountry.add(
      createOption(countries.country_name, countries.country_name)
    );
    presentCountry.add(
      createOption(countries.country_name, countries.country_name)
    );
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

const countryChange = async (index, countryId, stateId, cityId, stateIndex) => {
  errors[index] = false;
  spanErrorArray[index].style.display = "none";

  const countryInputValue = countryId.value;
  const stateApiData = await fetchState(countryInputValue);

  stateId.innerHTML = "";
  stateId.add(createOptionSelect());
  cityId.innerHTML = "";
  cityId.add(createOptionSelect());

  errors[stateIndex] = true;

  for (const stateData of stateApiData) {
    stateId.add(createOption(stateData.state_name, stateData.state_name));
  }
};

permanentCountry.addEventListener("change", () => {
  countryChange(12, permanentCountry, permanentState, permanentCity, 13);
});

presentCountry.addEventListener("change", () => {
  countryChange(7, presentCountry, presentState, presentCity, 8);
});

//----------------------------------Fetch City----------------------------------------------

const fetchCity = async (index, stateId, cityId, cityIndex) => {
  errors[index] = false;
  spanErrorArray[index].style.display = "none";

  const stateName = stateId.value;
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

  cityId.innerHTML = "";
  cityId.add(createOptionSelect());

  errors[cityIndex] = true;

  if (cityData.length === 0) {
    cityId.add(createOption(stateName, stateName));
  } else {
    for (const cit of cityData) {
      cityId.add(createOption(cit.city_name, cit.city_name));
    }
  }
};

permanentState.addEventListener("change", () => {
  fetchCity(13, permanentState, permanentCity, 14);
});
presentState.addEventListener("change", () => {
  fetchCity(8, presentState, presentCity, 9);
});

//------------------------------------------Form submit actions-------------------------------------------

const dispalyResultDiv = (formData) => {
  resultDiv.style.display = "block";
  resultDiv.scrollIntoView(false);
  const inputTags = document
    .getElementById("container")
    .getElementsByTagName("input");
  for (let i = 0; i < inputTags.length; i++) {
    if (inputTags[i].attributes.displayId) {
      document.getElementById(
        inputTags[i].attributes.displayId.value
      ).innerHTML = inputTags[i].value===""?"NA":inputTags[i].value;
    }
  }
  const selectTags = document
    .getElementById("container")
    .getElementsByTagName("select");
  for (let i = 0; i < selectTags.length; i++) {
    if (selectTags[i].attributes.displayId) {
      document.getElementById(
        selectTags[i].attributes.displayId.value
      ).innerHTML = selectTags[i].value;
    }
  }
};

const onSubmit = (e) => {
  e.preventDefault();
  let isError = false;
  for (let i = 0; i < errorSize; i++) {
    if (errors[i]) {
      spanErrorArray[i].style.display = "block";
    }
    isError = isError || errors[i];
  }
  if (!isError) {
    const formData = {
      FirstName: firstNameInput.value,
      LastName: lastNameInput.value,
      Email: emailInput.value,
      DateofBirth: dateofBirthInput.value,
      Gender: genderInput.value,
      PresentAddress: {
        Addressline1: presentAddressLine1.value,
        Addressline2: presentAddressLine2.value,
        PostalCode: presentPostalCode.value,
        Country: presentCountry.value,
        State: presentState.value,
        City: presentCity.value,
      },
      PermanentAddress: {
        Addressline1: permanentAddressLine1.value,
        Addressline2: permanentAddressLine2.value,
        PostalCode: permanentPostalCode.value,
        Country: permanentCountry.value,
        State: permanentState.value,
        City: permanentCity.value,
      },
      Hobbies: hobbyInput.value.split(","),
    };
    console.log(formData);
    dispalyResultDiv(formData);
  }
};

submitButton.addEventListener("click", onSubmit);

//----------------------------------------Initial Function Calls-------------------------------------------

document.addEventListener("DOMContentLoaded", () => {
  fetchCountries();
});
