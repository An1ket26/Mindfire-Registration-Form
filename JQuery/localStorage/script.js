$(document).ready(function () {
  //api

  async function fetchApi(extendUrl, selectId, extendName) {
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
      `https://www.universal-tutorial.com/api${extendUrl}`,
      {
        headers: {
          Authorization: `Bearer ${authToken}`,
          Accept: "application/json",
        },
      }
    );

    const apiData = await response.json();
    $(selectId)
      .children()
      .remove()
      .end()
      .append(
        '<option value="none" selected disabled hidden>Select an Option</option>'
      );
    if (apiData.length === 0) {
      $(selectId).append(
        createOption(
          $($(selectId).attr("parent-id")).val(),
          $($(selectId).attr("parent-id")).val()
        )
      );
    } else {
      for (const data of apiData) {
        $(selectId).append(createOption(data[extendName], data[extendName]));
      }
    }
    return true;
  }

  $("#permanentCountry").on("change", function () {
    fetchApi(`/states/${$(this).val()}`, "#permanentState", "state_name");
  });
  $("#presentCountry").on("change", function () {
    fetchApi(`/states/${$(this).val()}`, "#presentState", "state_name");
  });
  $("#permanentState").on("change", function () {
    fetchApi(`/cities/${$(this).val()}`, "#permanentCity", "city_name");
  });
  $("#presentState").on("change", function () {
    fetchApi(`/cities/${$(this).val()}`, "#presentCity", "city_name");
  });

  fetchApi("/countries", "#permanentCountry", "country_name");
  fetchApi("/countries", "#presentCountry", "country_name");

  //validation
  function checkEmpty(value) {
    if (value.length > 0) {
      return true;
    }
    return false;
  }
  function checkEmail(value) {
    const regex = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
    if (value.length > 0 && regex.test(value) === true) {
      return true;
    }
    return false;
  }
  function checkDob(value) {
    let todayDate = new Date();
    let inputDate = new Date(value);
    const differenceYear =
      (todayDate - inputDate) / (1000 * 60 * 60 * 24 * 365);
    if (differenceYear < 18) {
      return false;
    }
    return true;
  }
  function checkSelectNotNone(value) {
    if (value === null) {
      return false;
    }
    return true;
  }
  function inputValidate(inputTag) {
    if (!inputTag.attr("validation-data")) {
      return false;
    }
    let isError = false;
    const validationTypes = inputTag.attr("validation-data").split(" ");
    for (type of validationTypes) {
      let fl = true;
      if (type === "notEmpty") {
        fl = checkEmpty(inputTag.val().trim());
        $(inputTag.attr("error-id"))
          .text("*required")
          .css("display", fl ? "none" : "block");

        if (!fl) {
          isError = true;
          break;
        }
      }
      if (type === "email") {
        fl = checkEmail(inputTag.val().trim());
        $(inputTag.attr("error-id"))
          .text("*enter valid email")
          .css("display", fl ? "none" : "block");
        if (!fl) {
          isError = true;
          break;
        }
      }
      if (type === "dob>18") {
        fl = checkDob(inputTag.val() === "" ? new Date() : inputTag.val());
        $(inputTag.attr("error-id"))
          .text("*must be 18 years old")
          .css("display", fl ? "none" : "block");
        if (!fl) {
          isError = true;
          break;
        }
      }
    }
    return isError;
  }

  function selectValidate(selectTag) {
    if (!selectTag.attr("validation-data")) {
      return false;
    }
    let isError = false;
    const validationTypes = selectTag.attr("validation-data").split(" ");
    for (type of validationTypes) {
      let fl = true;
      if (type === "parentCheck") {
        fl = checkSelectNotNone($(selectTag.attr("parent-id")).val());
        $(selectTag.attr("error-id"))
          .text(`please select ${selectTag.attr("id").includes("State")?"country":"state"} first`)
          .css("display", fl ? "none" : "block");
        if (!fl) {
          isError = true;
          break;
        }
      }
      if (type === "notEmpty") {
        fl = checkSelectNotNone(selectTag.val());
        $(selectTag.attr("error-id"))
          .text("*required")
          .css("display", fl ? "none" : "block");
        if (!fl) {
          isError = true;
          break;
        }
      }
    }
    return isError;
  }

  $("input").on("input change", function () {
    inputValidate($(this));
  });

  $("select").on("click change", function () {
    selectValidate($(this));
  });

  //copy from present to permanent

  $("#copyFromPresentToPermanentCheckbox").click(async function () {
    let isError = false;
    $("#presentAddress input").each(function () {
      isError = isError | inputValidate($(this));
    });
    $("#presentAddress select").each(function () {
      isError = isError | selectValidate($(this));
    });
    if (isError) {
      $(this).prop("checked", false);
      return;
    }
    if (this.checked) {
      $("#permanentAddress input").each(function () {
        if ($(this).attr("copy-val-id"))
          $(this).val($($(this).attr("copy-val-id")).val());
        inputValidate($(this));
      });
      $("#permanentAddress select").each(async function () {
        if ($(this).attr("load-state-first")) {
          const res = await fetchApi(
            `/states/${$("#permanentCountry").val()}`,
            "#permanentState",
            "state_name"
          );
          if (res) {
            if ($(this).attr("copy-val-id")) {
              $(this).val($($(this).attr("copy-val-id")).val());
            }
          }
          selectValidate($(this));
        } else if ($(this).attr("load-city-first")) {
          const value =
            $("#permanentState").val() === null
              ? $("#presentState").val()
              : $("#permanentState").val();
          const res = await fetchApi(
            `/cities/${value}`,
            "#permanentCity",
            "city_name"
          );
          if (res) {
            if ($(this).attr("copy-val-id")) {
              $(this).val($($(this).attr("copy-val-id")).val());
            }
          }
          selectValidate($(this));
        } else {
          if ($(this).attr("copy-val-id")) {
            $(this).val($($(this).attr("copy-val-id")).val());
            selectValidate($(this));
          }
        }
      });
    } else {
      $("#permanentAddress input").val("");
      $("#permanentAddress select").html();
      var newOption = $("<option>");
      newOption.val("none");
      newOption.text("Select an Option");
      newOption.attr("selected", true);
      newOption.attr("disabled", true);
      newOption.attr("hidden", true);
      $("#permanentAddress select").append(newOption);
    }
  });
  function createOption(value, text) {
    var newOption = $("<option>");
    newOption.val(value);
    newOption.text(text);
    return newOption;
  }

  //HOBBY

  const initialHobbyOptions = [];
  $("#" + $("#hobbyInput").attr("list") + " option").each(function () {
    initialHobbyOptions.push($(this).val());
  });
  $("#hobbyInput").on("input", function () {
    const lastIndexofComma = $(this).val().lastIndexOf(",");
    let newHobbyOptions = "";
    if (lastIndexofComma !== -1) {
      newHobbyOptions = $(this).val().substr(0, lastIndexofComma) + ",";
    }
    const usedHobbyOptions = newHobbyOptions
      .split(",")
      .map((value) => value.trim());
    if ($(this)[0].list && initialHobbyOptions.length > 0) {
      $("#" + $("#hobbyInput").attr("list")).html("");

      for (const alloption of initialHobbyOptions) {
        if (usedHobbyOptions.indexOf(alloption) < 0) {
          $("#" + $("#hobbyInput").attr("list")).append(
            `<option>${newHobbyOptions + alloption}</option>`
          );
        }
      }
    }
  });

  // image

  $("#profileImageInput").change(function(e){
    const imgSrc = URL.createObjectURL(e.target.files[0]);
    $("#profileImageDisplay").attr("src", imgSrc);
  })

  //submit action

  const displayResultDiv = (formData) => {
    // $("#resultDiv").css("display", "block");
    // $("#resultDiv")[0].scrollIntoView(false);
    $("#container input").each(function () {
      if ($(this).attr("displayId")) {
        if (this.id === "subscribeCheckbox") {
          formData[$("#" + $(this).attr("displayId")).attr("objectName")] = $(
            "#subscribeCheckbox"
          ).is(":checked")
            ? "YES"
            : "NO";
          $("#" + $(this).attr("displayId")).html(
            formData[$("#" + $(this).attr("displayId")).attr("objectName")]
          );
        } else {
          formData[$("#" + $(this).attr("displayId")).attr("objectName")] = $(this).val();
        }
      }
    });
    $("#container select").each(function () {
      if ($(this).attr("displayId")) {
        formData[$("#" + $(this).attr("displayId")).attr("objectName")] = $(this).val();
      }
    });
  };

  $("#submitBtn").click(function (event) {
    event.preventDefault();
    let isError = false;
    $("#container input").each(function () {
      isError = isError | inputValidate($(this));
    });
    $("#container select").each(function () {
      isError = isError | selectValidate($(this));
    });
    if (isError) {
      return false;
    }
    const formData = {};
    displayResultDiv(formData);
    formData.imageSrc=$("#profileImageDisplay").attr("src");
    localStorage.setItem("formData",JSON.stringify(formData));
    console.log(formData);

    location.href="/result.html"
  });
});




