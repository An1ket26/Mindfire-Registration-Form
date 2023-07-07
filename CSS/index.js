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

//validations
fname.addEventListener("input",()=>{
  const fnameData=fname.value.trim();
  // console.log(fnameData);
  if(fnameData.length===0)
  {
    fname.style.borderColor="red";
  }
  else
  {
    fname.style.borderColor="black";
  }
})

lname.addEventListener("input",()=>{
  const lnameData=lname.value.trim();
  // console.log(lnameData);
  if(lnameData.length===0)
  {
    lname.style.borderColor="red";
  }
  else
  {
    lname.style.borderColor="black";
  }
})

email.addEventListener("input",()=>{
  const emailData=email.value.trim();
  // console.log(lnameData);

  if(emailData.length===0)
  {
    email.style.borderColor="red";
  }
  else
  {
    email.style.borderColor="black";
  }
})

//present address

paddr1.addEventListener("input", () => {
  const addr1Data = paddr1.value.trim();
  if (addr1Data.length === 0) {
  }
});

paddr2.addEventListener("input", () => {
  const addr2Data = paddr2.value.trim();
  if (addr2Data.length === 0) {
  }
});

ppcode.addEventListener("input", () => {
  const postalCode = ppcode.value.trim();
  if (postalCode.length === 0) {
  }
});

//permanent address

addr1.addEventListener("input", () => {
  const addr1Data = addr1.value.trim();
  if (addr1Data.length === 0) {
  }
});

addr2.addEventListener("input", () => {
  const addr2Data = addr2.value.trim();
  if (addr2Data.length === 0) {
  }
});

pcode.addEventListener("input", () => {
  const postalCode = pcode.value.trim();
  if (postalCode.length === 0) {
  }
});


profilePic.addEventListener("change", (e) => {
  // console.log(e.target.files[0].name);
  const imgSrc = e.target.files[0].name;
  profileImage.setAttribute("src", imgSrc);
});

const presentToPermanent = () => {
  if (checkAddress.checked) {
    addr1.value = paddr1.value;
    addr2.value = paddr2.value;
    pcode.value = ppcode.value;
    country.value = pcountry.value;
    state.value = pstate.value;
    city.value = pcity.value;
  } else {
    addr1.value = "";
    addr2.value = "";
    pcode.value = "";
    country.value = country.options[0].value;
    state.value = state.options[0].value;
    city.value = city.options[0].value;
  }
};
const alloptions = Array.from(hobby.list.options).map((opt) => opt.value);
hobby.addEventListener("input", () => {
  const lsIndex = hobby.value.lastIndexOf(",");
  //   console.log(lsIndex);
  let newHobby = "";
  if (lsIndex !== -1) {
    newHobby = hobby.value.substr(0, lsIndex) + ",";
  }
  const usedOptions = newHobby.split(",").map((value) => value.trim());

  if (hobby.list && alloptions.length > 0) {
    hobby.list.innerHTML = "";
    // console.log(hobby.list);
    for (const alloption of alloptions) {
      if (usedOptions.indexOf(alloption) < 0) {
        console.log(alloption);
        const option = document.createElement("option");
        option.value = newHobby + alloption;
        hobby.list.append(option);
      }
    }
  }
});
let authToken="";
const fetchCountries = async () => {
  const res=await fetch("https://www.universal-tutorial.com/api/getaccesstoken",{
    headers:{
      "Accept": "application/json",
    "api-token": "DP-xCbqqy0OnZp9sKEYOyT40C_GA3jBqbToYdAO26juveWeTAfQojElWKqDttEzkrEs",
    "user-email": "somehrlp@gmail.com"
    }
  })
  const resToken= await res.json();
  authToken= await resToken.auth_token;
  // console.log(authToken);


  const response=await fetch("https://www.universal-tutorial.com/api/countries",{
    headers:{
      "Authorization": `Bearer ${authToken}`,
      "Accept": "application/json"
    }
  })
  const data = await response.json();
  // console.log(data);
  for (const countries of data) {
    var option = document.createElement("option");
    option.value = countries.country_name;
    option.text = countries.country_name;
    country.add(option);
    var option2 = document.createElement("option");
    option2.value = countries.country_name;
    option2.text = countries.country_name;
    pcountry.add(option2);
  }
};

//xCbqqy0OnZp9sKEYOyT40C_GA3jBqbToYdAO26juveWeTAfQojElWKqDttEzkrEs

fetchCountries();
const fetchState = async (cntry) => {
  const response = await fetch(
    "https://www.universal-tutorial.com/api/states/United States",{
      headers:{
        "Authorization": `Bearer ${authToken}`,
        "Accept": "application/json"
      }
    }
  );
  const res = await response.json();
  console.log(res);
  return res;
};

country.addEventListener("change", async () => {
  const cntry = country.value;
  const states = await fetchState(cntry);
  state.innerHTML = "";
  for (const st of states) {
    var option2 = document.createElement("option");
    option2.value = st.state_name;
    option2.text = st.state_name;
    state.add(option2);
  }
});
pcountry.addEventListener("change", async () => {
  const cntry = pcountry.value;
  const states = await fetchState(cntry);
  pstate.innerHTML = "";
  for (const st of states) {
    var option2 = document.createElement("option");
    option2.value = st.state_name;
    option2.text = st.state_name;
    pstate.add(option2);
  }
});

// const fetchCity=async()=>{

//     const response=await fetch("https://countriesnow.space/api/v0.1/countries/state/cities",{
//         method:'POST',
//         mode:'cors',
//         headers:{
//           "Access-Control-Allow-Origin":'*',
//           "Access-Control-Allow-Headers":"*",
//             "Content-Type":"application/json",
//         },
//         body:{
//             "country": "Nigeria",
//             "state": "Lagos"
//         }
//     })
//     const data=await response.json();
//     console.log(data)

// }
// fetchCity();
