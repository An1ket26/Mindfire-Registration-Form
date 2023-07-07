const fname = document.getElementById("fname");
const lname = document.getElementById("lname");
const profilePic = document.getElementById("profilePic");
const profileImage = document.getElementById("profileImage");
const email = document.getElementById("email");
const dob = document.getElementById("dob");
const gender = document.getElementById("gender");

const paddr1 = document.getElementById("paddress1");
const paddr2 = document.getElementById("paddress2");
const ppcode = document.getElementById("ppcode");
const pcountry = document.getElementById("pcountry");
const pstate = document.getElementById("pstate");
const pcity = document.getElementById("pcity");

const addr1 = document.getElementById("address1");
const addr2 = document.getElementById("address2");
const pcode = document.getElementById("pcode");
const country = document.getElementById("country");
const state = document.getElementById("state");
const city = document.getElementById("city");

const checkAddress = document.getElementById("same");
const hobby = document.getElementById("hobby");
const checkSubscribe = document.getElementById("subscribe");

const errorTag = document.getElementsByTagName("span");

const Submit = document.getElementById("submit");
// console.log(errorTag);
const errorSize = errorTag.length;
const errors = [];
for (let i = 0; i < errorSize; i++) {
  errors[i] = true;
  // errorTag[i].style.display="";
}

//-------------------------------------------Validations-------------------------------

fname.addEventListener("input", () => {
  const fnameData = fname.value.trim();
  // console.log(fnameData);
  if (fnameData.length === 0) {
    fname.style.borderColor = "red";
    errorTag[0].style.display = "";
    errors[0] = true;
  } else {
    fname.style.borderColor = "black";
    errorTag[0].style.display = "none";
    errors[0] = false;
  }
});

lname.addEventListener("input", () => {
  const lnameData = lname.value.trim();
  // console.log(lnameData);
  if (lnameData.length === 0) {
    lname.style.borderColor = "red";
    errorTag[1].style.display = "";
    errors[1] = true;
  } else {
    lname.style.borderColor = "black";
    errorTag[1].style.display = "none";
    errors[1] = false;
  }
});

email.addEventListener("input", () => {
  const emailData = email.value.trim();
  // console.log(lnameData);
  const regex = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
  if (emailData.length === 0 || regex.test(emailData) === false) {
    email.style.borderColor = "red";
    errorTag[2].style.display = "";
    errors[2] = true;
  } else {
    email.style.borderColor = "black";
    errorTag[2].style.display = "none";
    errors[2] = false;
  }
});

dob.addEventListener("change", () => {
  // console.log(dob.value);
  let today = new Date();
  let inputDate = new Date(dob.value);
  const differenceYear = (today - inputDate) / (1000 * 60 * 60 * 24 * 365);
  if (differenceYear < 18) {
    errorTag[3].style.display = "";
    errors[3] = true;
  } else {
    errors[3] = false;
    errorTag[3].style.display = "none";
  }
});

gender.addEventListener("change", () => {
  if (
    gender.value === "Male" ||
    gender.value === "Female" ||
    gender.value === "other"
  ) {
    // console.log(gender.value);
    errors[4] = false;
    errorTag[4].style.display = "none";
  }
});

//-----------------------------------------Present address-------------------------------

paddr1.addEventListener("input", () => {
  const addr1Data = paddr1.value.trim();
  if (addr1Data.length === 0) {
    paddr1.style.borderColor = "red";
    errorTag[5].style.display = "";
    errors[5] = true;
  } else {
    paddr1.style.borderColor = "black";
    errorTag[5].style.display = "none";
    errors[5] = false;
  }
});

ppcode.addEventListener("input", () => {
  const postalCode = ppcode.value.trim();
  if (postalCode.length === 0) {
    ppcode.style.borderColor = "red";
    errorTag[6].style.display = "";
    errors[6] = true;
  } else {
    ppcode.style.borderColor = "black";
    errorTag[6].style.display = "none";
    errors[6] = false;
  }
});

pstate.addEventListener("click", () => {
  if (pcountry.value === "none") {
    errorTag[8].style.display = "";
    errors[8] = true;
  } else {
    errorTag[8].style.display = "none";
    errors[8] = false;
  }
});

pcity.addEventListener("click", () => {
  if (pstate.value === "none") {
    errorTag[9].style.display = "";
    errors[9] = true;
  } else {
    errorTag[9].style.display = "none";
    errors[9] = false;
  }
});

//---------------------------------------------Permanent address-------------------------------------

addr1.addEventListener("input", () => {
  const addr1Data = addr1.value.trim();
  if (addr1Data.length === 0) {
    addr1.style.borderColor = "red";
    errorTag[10].style.display = "";
    errors[10] = true;
  } else {
    addr1.style.borderColor = "black";
    errorTag[10].style.display = "none";
    errors[10] = false;
  }
});

pcode.addEventListener("input", () => {
  const postalCode = pcode.value.trim();
  if (postalCode.length === 0) {
    pcode.style.borderColor = "red";
    errorTag[11].style.display = "";
    errors[11] = true;
  } else {
    pcode.style.borderColor = "black";
    errorTag[11].style.display = "none";
    errors[11] = false;
  }
});

state.addEventListener("click", () => {
  if (country.value === "none") {
    errorTag[13].style.display = "";
    errors[13] = true;
  } else {
    errorTag[13].style.display = "none";
    errors[13] = false;
  }
});

city.addEventListener("click", () => {
  if (state.value === "none") {
    errorTag[14].style.display = "";
    errors[14] = true;
  } else {
    errorTag[14].style.display = "none";
    errors[14] = false;
  }
});

//--------------------------------------------Profilepic------------------------------

profilePic.addEventListener("change", (e) => {
  const imgSrc = URL.createObjectURL(e.target.files[0]);
  profileImage.setAttribute("src", imgSrc);
});

// --------------------------Copy from present to permanent address---------------------------------

const checkPresent = () => {
  let x = false;
  for (let i = 5; i <= 9; i++) {
    if (errors[i] == true) {
      errorTag[i].style.display = "";
    } else {
      errorTag[i].style.display = "none";
    }
    x = x || errors[i];
  }
  return x;
};

const presentToPermanent = async () => {
  if (checkPresent()) {
    return;
  }
  if (checkAddress.checked) {
    addr1.value = paddr1.value;
    addr2.value = paddr2.value;
    pcode.value = ppcode.value;
    country.value = pcountry.value;
    await countryChange();
    state.value = pstate.value;
    await fetchCity();
    city.value = pcity.value;
    for (let i = 10; i <= 14; i++) {
      errors[i] = false;
      errorTag[i].style.display = "none";
    }
  } else {
    addr1.value = "";
    addr2.value = "";
    pcode.value = "";
    country.value = country.options[0].value;
    state.innerHTML = "";
    var option2 = document.createElement("option");
    option2.value = "none";
    option2.text = "Select an Option";
    option2.setAttribute("selected", "selected");
    option2.setAttribute("hidden", "hidden");
    option2.setAttribute("disabled", "disabled");
    state.add(option2);
    city.innerHTML = "";
    var option = document.createElement("option");
    option.setAttribute("hidden", "hidden");
    option.setAttribute("disabled", "disabled");
    option.value = "none";
    option.text = "Select an Option";
    option.setAttribute("selected", "selected");
    city.add(option);
    for (let i = 10; i <= 14; i++) {
      errors[i] = true;
      errorTag[i].style.display = "";
    }
  }
};

//--------------------------------------Hobby options------------------------------------------

const alloptions = Array.from(hobby.list.options).map((opt) => opt.value);
hobby.addEventListener("input", () => {
  const lsIndex = hobby.value.lastIndexOf(",");
  //   console.log(lsIndex);
  let newHobby = "";
  if (lsIndex !== -1) {
    newHobby = hobby.value.substr(0, lsIndex) + ",";
  }
  const usedOptions = newHobby.split(",").map((value) => value.trim());
  const checkOptions = hobby.value.split(",").map((value) => value.trim());
  if (checkOptions.length < 3 || checkOptions[2] === "") {
    errorTag[15].style.display = "";
    errors[15] = true;
  } else {
    errorTag[15].style.display = "none";
    errors[15] = false;
  }
  if (hobby.list && alloptions.length > 0) {
    hobby.list.innerHTML = "";
    // console.log(hobby.list);
    for (const alloption of alloptions) {
      if (usedOptions.indexOf(alloption) < 0) {
        // console.log(alloption);
        const option = document.createElement("option");
        option.value = newHobby + alloption;
        hobby.list.append(option);
      }
    }
  }
});

//------------------------------------Fetch country-----------------------------------

let authToken = "";
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
  // console.log(authToken);

  const response = await fetch(
    "https://www.universal-tutorial.com/api/countries",
    {
      headers: {
        Authorization: `Bearer ${authToken}`,
        Accept: "application/json",
      },
    }
  );

  const data = await response.json();
  // console.log(data);
  for (const countries of data) {
    var option = document.createElement("option");
    option.value = countries.country_name;
    option.text = countries.country_name;
    country.add(option);
    var option2 = document.createElement("option");
    option2.value = countries.country_name;
    option2.innerHTML = countries.country_name;
    pcountry.add(option2);
  }
};

/*api token

xCbqqy0OnZp9sKEYOyT40C_GA3jBqbToYdAO26juveWeTAfQojElWKqDttEzkrEs

*/

fetchCountries();

//----------------------------------Fetch state---------------------------------------

const fetchState = async (cntry) => {
  const response = await fetch(
    `https://www.universal-tutorial.com/api/states/${cntry}`,
    {
      headers: {
        Authorization: `Bearer ${authToken}`,
        Accept: "application/json",
      },
    }
  );
  const res = await response.json();
  // console.log(res);
  return res;
};

const countryChange = async () => {
  errors[12] = false;
  errorTag[12].style.display = "none";
  // console.log("called");
  const cntry = country.value;
  const states = await fetchState(cntry);
  state.innerHTML = "";
  let option = document.createElement("option");
  option.setAttribute("hidden", "hidden");
  option.setAttribute("disabled", "disabled");
  option.value = "none";
  option.text = "Select an Option";
  option.setAttribute("selected", "selected");
  state.add(option);
  city.innerHTML="";
  let option3 = document.createElement("option");
  option3.setAttribute("hidden", "hidden");
  option3.setAttribute("disabled", "disabled");
  option3.value = "none";
  option3.text = "Select an Option";
  option3.setAttribute("selected", "selected");
  city.add(option3);
  errors[13] = true;
  for (const st of states) {
    var option2 = document.createElement("option");
    option2.value = st.state_name;
    option2.text = st.state_name;
    state.add(option2);
  }
};

country.addEventListener("change", countryChange);

pcountry.addEventListener("change", async () => {
  errors[7] = false;
  errorTag[7].style.display = "none";
  const cntry = pcountry.value;
  const states = await fetchState(cntry);
  pstate.innerHTML = "";
  let option = document.createElement("option");
  option.setAttribute("hidden", "hidden");
  option.setAttribute("disabled", "disabled");
  option.value = "none";
  option.text = "Select an Option";
  option.setAttribute("selected", "selected");
  pstate.add(option);
  pcity.innerHTML="";
  let option3 = document.createElement("option");
  option3.setAttribute("hidden", "hidden");
  option3.setAttribute("disabled", "disabled");
  option3.value = "none";
  option3.text = "Select an Option";
  option3.setAttribute("selected", "selected");
  pcity.add(option3);
  errors[8] = true;
  for (const st of states) {
    var option2 = document.createElement("option");
    option2.value = st.state_name;
    option2.text = st.state_name;
    pstate.add(option2);
  }
});

//----------------------------------Fetch city----------------------------------------------

const cityChange = async () => {
  fetchCity();
};
const pcityChange = async () => {
  pfetchCity();
};
state.addEventListener("change", cityChange);
pstate.addEventListener("change", pcityChange);

const fetchCity = async () => {
  errors[13] = false;
  errorTag[13].style.display = "none";
  const stateName = state.value;
  const response = await fetch(
    `https://www.universal-tutorial.com/api/cities/${stateName}`,
    {
      headers: {
        Authorization: `Bearer ${authToken}`,
        Accept: "application/json",
      },
    }
  );
  const data = await response.json();
  // console.log(data);
  city.innerHTML = "";
  let option = document.createElement("option");
  option.setAttribute("hidden", "hidden");
  option.setAttribute("disabled", "disabled");
  option.value = "none";
  option.text = "Select an Option";
  option.setAttribute("selected", "selected");
  city.add(option);
  errors[14] = true;
  if (data.length === 0) {
    let option2 = document.createElement("option");
    option2.value = stateName;
    option2.text = stateName;
    city.add(option2);
  } else {
    for (const cit of data) {
      let option2 = document.createElement("option");
      option2.value = cit.city_name;
      option2.text = cit.city_name;
      city.add(option2);
    }
  }
};

const pfetchCity = async () => {
  const stateName = pstate.value;
  const response = await fetch(
    `https://www.universal-tutorial.com/api/cities/${stateName}`,
    {
      headers: {
        Authorization: `Bearer ${authToken}`,
        Accept: "application/json",
      },
    }
  );
  const data = await response.json();
  // console.log(data);
  // console.log(pcity.options[0]);
  pcity.innerHTML = "";
  let option = document.createElement("option");
  option.setAttribute("hidden", "hidden");
  option.setAttribute("disabled", "disabled");
  option.value = "none";
  option.text = "Select an Option";
  option.setAttribute("selected", "selected");
  pcity.add(option);
  errors[9] = true;
  if (data.length === 0) {
    let option2 = document.createElement("option");
    option2.value = stateName;
    option2.text = stateName;
    pcity.add(option2);
  } else {
    for (const city of data) {
      var option2 = document.createElement("option");
      option2.value = city.city_name;
      option2.text = city.city_name;
      pcity.add(option2);
    }
  }
};

//-------------------------------Form submit actions-------------------------------------------

const onSubmit = (e) => {
  // console.log(e);
  e.preventDefault();
  for (let i = 0; i < errorSize; i++) {
    if (errors[i]) {
      // console.log(errors[i], i);
      errorTag[i].style.display = "";
    }
  }
  return false;
};

Submit.addEventListener("click", onSubmit);
