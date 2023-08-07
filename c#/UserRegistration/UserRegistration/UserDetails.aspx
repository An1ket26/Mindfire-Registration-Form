<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserDetails.aspx.cs" Inherits="UserRegistration.WebForm1" EnableEventValidation="true" MaintainScrollPositionOnPostback="true" %>

<!DOCTYPE html>
<%@ Register Src="~/UserNotesControl.ascx"  TagPrefix="uc" TagName="Notes"%>
<%@ Register Src="~/UserDocumentControl.ascx" TagPrefix="uc" TagName="Document" %>
<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <meta charset="UTF-8" />
        <meta http-equiv="X-UA-Compatible" content="IE=edge" />
        <meta name="viewport" content="width=device-width, initial-scale=1.0" />
        <link rel="stylesheet" href="Content/UserDetails.css" />
        <link rel="stylesheet" href="Content/UserDocument.css" />
        <link rel="preconnect" href="https://fonts.googleapis.com" />
        <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin="crossorigin" />
        <link
            href="https://fonts.googleapis.com/css2?family=Tinos:ital@0;1&display=swap"
            rel="stylesheet" />

        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.4/jquery.min.js"></script>
        <title>Registration Form</title>
    </head>
    <body>
        <form runat="server">
            <div class="div-hide" id="navbar">
                <button  id="detailsLink" class="nav-links" >Basic Details</button>
                <button  id="NotesLink" class="nav-links"  >Notes</button>
                <button  id="documentLink" class="nav-links"  >Documents</button>
                <button  id="logout" class="nav-links"  >Logout</button>
            </div>
            <div class="container" id="container" >
                <div class="form-main" id="formMain">
                    <div class="form-header">
                        <h1><ins>Registration Form </ins></h1>
                        <asp:Image runat="server" 
                            AlternateText="Profile photo"
                            CssClass="profile-image-display"
                            ID="profileImageDisplay" ClientIDMode="Static"/>
                    </div>
                    <div class="form-body">
                        <div class="div-col-20">
                            <label for="firstNameInput">
                                First Name :<br />
                                <span id="firstNameError">*required</span>
                            </label>
                        </div>
                        <div class="div-col-30">
                            <input
                                class="input-width"
                                type="text"
                                name="firstNameInput"
                                id="firstNameInput"
                                autofocus="autofocus"
                                placeholder="First Name"
                                displayid="enteredFirstName"
                                validation-data="notEmpty"
                                error-id="#firstNameError"
                                filldata="FirstName"/>
                        </div>

                        <div class="div-col-20">
                            <label for="lastNameInput">
                                Last Name :<br />
                                <span id="lastNameError">*required</span>
                            </label>
                        </div>
                        <div class="div-col-30">
                            <input
                                class="input-width"
                                type="text"
                                name="lastNameInput"
                                id="lastNameInput"
                                placeholder="Last Name"
                                displayid="enteredLastName"
                                validation-data="notEmpty"
                                error-id="#lastNameError"
                                filldata="LastName"
                                />
                        </div>
                        <div class="div-col-20">
                            <label for="emailInput">
                                Personal Email :
                                <br />
                                <span id="emailError">*Please enter valid mail</span>
                            </label>
                        </div>

                        <div class="div-col-30">
                            <input
                                class="input-width"
                                type="email"
                                name="emailInput"
                                id="emailInput"
                                size="30"
                                placeholder="something@xyz.com"
                                displayid="enteredEmail"
                                validation-data="email"
                                error-id="#emailError"
                                filldata="Email"/>
                        </div>
                        <div class="div-col-20">
                            <label for="dateofBirthInput">
                                Date of Birth :
                                <br />
                                <span id="dobError">*Must be 18 year older</span>
                            </label>
                        </div>

                        <div class="div-col-30">
                            <input
                                class="input-width"
                                type="date"
                                name="dateofBirthInput"
                                id="dateofBirthInput"
                                displayid="enteredDOB"
                                validation-data="dob>18"
                                error-id="#dobError"
                                filldata="DateofBirth"
                                />
                        </div>

                        <div class="div-col-20">
                            <label for="genderInput">
                                Select your gender :<br />
                                <span id="genderError">*required</span></label>
                        </div>
                        <div class="div-col-30">
                            <select
                                id="genderInput"
                                name="genderInput"
                                displayid="enteredGender"
                                validation-data="notEmpty"
                                error-id="#genderError"
                                filldata="Gender"
                                >
                                <option value="none" selected="selected" disabled="disabled" hidden="hidden">Select an Option
                                </option>
                                <option value="Male">Male</option>
                                <option value="Female">Female</option>
                                <option value="other">Other</option>
                            </select>
                        </div>

                        <div class="div-col-20">
                            <label for="profileImageInput">Profile Picture :</label>
                        </div>
                        <div class="div-col-30">
                            <asp:FileUpload runat="server" ID="profileImageInput" ClientIDMode="Static" accept=".jpg, .png, .jpeg, .gif"/>
                        </div>
                        <div class="div-col-20">
                            <label for="passwordInput">
                                Password :
                                <br />
                                <span id="passwordError">*Required</span>
                            </label>
                        </div>

                        <div class="div-col-30">
                            <input
                                class="input-width"
                                type="password"
                                name="passwordInput"
                                id="passwordInput"
                                size="30"
                                placeholder="Password"
                                displayid="enteredPassword"
                                validation-data="notEmpty"
                                error-id="#passwordError"
                                filldata="Password"/>
                        </div>

               

                        <div class="div-col-20">
                            <label for="cnfPasswordInput">
                                Confirm Password :
                                <br />
                                <span id="cnfPasswordError">*Password does not match</span>
                            </label>
                        </div>

                        <div class="div-col-30">
                            <input
                                class="input-width"
                                type="password"
                                name="cnfPasswordInput"
                                id="cnfPasswordInput"
                                size="30"
                                placeholder="Confirm Password"
                                displayid="enteredCnfPassword"
                                validation-data="matchPassword"
                                error-id="#cnfPasswordError"
                                filldata="Password"/>
                        </div>
                        <fieldset id="presentAddress">
                            <legend>Present Address :</legend>
                            <div class="div-col-20">
                                <label for="presentAddressLine1">
                                    Address line 1 :
                                    <br />
                                    <span id="presentAddressl1Error">*required</span></label>
                            </div>
                            <div class="div-col-30">
                                <input
                                    class="input-width"
                                    id="presentAddressLine1"
                                    type="text"
                                    placeholder="Address line 1"
                                    displayid="enteredPresentAddressLine1"
                                    validation-data="notEmpty"
                                    error-id="#presentAddressl1Error"
                                    filldata="PresentAddressLine1"/>
                            </div>

                            <div class="div-col-20">
                                <label for="presentAddressLine2">Address line 2 : </label>
                            </div>
                            <div class="div-col-30">
                                <input
                                    class="input-width"
                                    id="presentAddressLine2"
                                    type="text"
                                    placeholder="Address line 2"
                                    displayid="enteredPresentAddressLine2" filldata="PresentAddressLine2"/>
                            </div>
                            <div class="div-col-20">
                                <label for="presentPostalCode">
                                    Postal Code :<br />
                                    <span id="presentPostalCodeError">*required</span>
                                </label>
                            </div>
                            <div class="div-col-30">
                                <input
                                    class="input-width"
                                    id="presentPostalCode"
                                    type="number"
                                    placeholder="Postal Code"
                                    displayid="enteredPresentPostalCode"
                                    validation-data="notEmpty"
                                    error-id="#presentPostalCodeError"
                                    filldata="PresentPostalCode"
                                    />
                            </div>

                            <div class="div-col-20">
                                <label for="presentCountry">
                                    Country :<br />
                                    <span id="presentCountryError">*required</span>
                                </label>
                            </div>
                            <div class="div-col-30">
                                <select
                                    id="presentCountry"
                                    value=""
                                    displayid="enteredPresentCountry"
                                    validation-data="notEmpty"
                                    error-id="#presentCountryError"
                                    filldata="PresentCountry">
                                    <option value="none" selected="selected" disabled="disabled" hidden="hidden">Select an Option
                                    </option>
                                </select>
                            </div>
                            <div class="div-col-20">
                                <label for="presentState">
                                    State :
                                    <br />
                                    <span id="presentStateError">*Please select Country first</span></label>
                            </div>
                            <div class="div-col-30">
                                <select
                                    id="presentState"
                                    displayid="enteredPresentState"
                                    validation-data="parentCheck notEmpty"
                                    error-id="#presentStateError"
                                    parent-id="#presentCountry"
                                    filldata="PresentState"
                                    state-load="true"
                                    >
                                    <option value="none" selected="selected" disabled="disabled" hidden="hidden">Select an Option
                                    </option>
                                </select>
                            </div>
                            <div class="div-col-20">
                                <label for="presentCity">
                                    City :
                                    <br />
                                    <span id="presentCityError">*Please select state first</span></label>
                            </div>

                            <div class="div-col-30">
                                <input type="text" id="presentCity" displayid="enteredPresentCity"
                                    class="input-width"
                                    validation-data="parentCheck notEmpty"
                                    error-id="#presentCityError"
                                    parent-id="#presentState"
                                    filldata="PresentCity"/>

                            </div>
                        </fieldset>

                        <fieldset id="permanentAddress">
                            <legend>Permanent Address :</legend>
                            <input
                                type="checkbox"
                                name="copyFromPresentToPermanentCheckbox"
                                id="copyFromPresentToPermanentCheckbox"
                                class="checkbox-width" />
                            <label for="copyFromPresentToPermanentCheckbox">
                                Same as present address</label><br />
                            <br />
                            <div class="div-col-20">
                                <label for="permanentAddressLine1">
                                    Address line 1 :<br />
                                    <span id="permanentAddressl1Error">*required</span>
                                </label>
                            </div>
                            <div class="div-col-30">
                                <input
                                    class="input-width"
                                    id="permanentAddressLine1"
                                    type="text"
                                    placeholder="Address line 1"
                                    displayid="enteredPermanentAddressLine1"
                                    validation-data="notEmpty"
                                    error-id="#permanentAddressl1Error"
                                    copy-val-id="#presentAddressLine1" 
                                    filldata="PermanentAddressLine1"/>
                            </div>

                            <div class="div-col-20">
                                <label for="permanentAddressLine2">Address line 2 : </label>
                            </div>
                            <div class="div-col-30">
                                <input
                                    id="permanentAddressLine2"
                                    type="text"
                                    class="input-width"
                                    placeholder="Address line 2"
                                    displayid="enteredPermanentAddressLine2"
                                    copy-val-id="#presentAddressLine2"
                                    filldata="PermanentAddressLine2"/>
                            </div>
                            <div class="div-col-20">
                                <label for="permanentPostalCode">
                                    Postal Code :<br />
                                    <span id="permanentPostalCodeError">*required</span>
                                </label>
                            </div>
                            <div class="div-col-30">
                                <input
                                    id="permanentPostalCode"
                                    type="number"
                                    class="input-width"
                                    placeholder="Postal Code"
                                    displayid="enteredPermanentPostalCode"
                                    validation-data="notEmpty"
                                    error-id="#permanentPostalCodeError"
                                    copy-val-id="#presentPostalCode"
                                    filldata="PermanentPostalCode"/>
                            </div>

                            <div class="div-col-20">
                                <label for="permanentCountry">
                                    Country :<br />
                                    <span id="permanentCountryError">*required</span>
                                </label>
                            </div>
                            <div class="div-col-30">
                                <select
                                    id="permanentCountry"
                                    displayid="enteredPermanentCountry"
                                    validation-data="notEmpty"
                                    error-id="#permanentCountryError"
                                    copy-val-id="#presentCountry"
                                    filldata="PermanentCountry">
                                    <option value="none" selected="selected" disabled="disabled" hidden="hidden">Select an Option
                                    </option>
                                </select>
                            </div>
                            <div class="div-col-20">
                                <label for="permanentState">
                                    State :<br />
                                    <span id="permanentStateError">*Please select Country first</span>
                                </label>
                            </div>
                            <div class="div-col-30">
                                <select
                                    id="permanentState"
                                    displayid="enteredPermanentState"
                                    validation-data="parentCheck notEmpty"
                                    error-id="#permanentStateError"
                                    parent-id="#permanentCountry"
                                    copy-val-id="#presentState"
                                    load-state-first="true"
                                    filldata="PermanentState"
                                    state-load="true">
                                    <option value="none" selected="selected" disabled="disabled" hidden="hidden">Select an Option
                                    </option>
                                </select>
                            </div>
                            <div class="div-col-20">
                                <label for="permanentCity">
                                    City :<br />
                                    <span id="permanentCityError">*Please select state first</span>
                                </label>
                            </div>

                            <div class="div-col-30">
                                <input type="text" id="permanentCity" displayid="enteredPermanentCity"
                                    class="input-width"
                                    validation-data="parentCheck notEmpty"
                                    error-id="#permanentCityError"
                                    parent-id="#permanentState"
                                    copy-val-id="#presentCity"
                                    filldata="PermanentCity"/>
                            </div>
                        </fieldset>

                        <br />
                        <div class="div-col-20">
                            <label for="hobbyInput">
                                Enter your Hobbies :<br />
                                <span id="hobbyError">*Please enter 1 hobbies</span></label>
                        </div>
                        <div class="div-col-80">
                            <input
                                class="input-width"
                                id="hobbyInput"
                                type="text"
                                placeholder="Enter Hobby separated by comma"
                                list="hobbies"
                                name="hobbies"
                                style="width: 210px"
                                multiple="multiple"
                                displayid="enteredHobbies"
                                error-id="#hobbyError"
                                filldata="Hobby"/>
                            <datalist id="hobbies">
                                <option value="Playing games"></option>
                                <option value="Gardening"></option>
                                <option value="Chess"></option>
                                <option value="Watching Movies"></option>
                                <option value="Reading Books"></option>
                            </datalist>
                            <br />
                            <br />
                        </div>
                        <button id="roleDisplay">Select Role</button>
                        <div id="RoleListdiv" style="display: none;">
                            <asp:CheckBoxList ID="RoleList" runat="server"></asp:CheckBoxList>
                        </div>

                        <br />
                        <br />
                        <input
                            type="checkbox"
                            name="subscribe"
                            id="subscribeCheckbox"
                            class="checkbox-width"
                            displayid="isSubscribed" 
                            filldata="IsSubscribed"/>
                        <label for="subscribeCheckbox">Subscribe to Newsletter</label><br />
                        <br />
                    </div>
                    <div class="form-footer">
                        <input
                            type="submit"
                            value="Submit"
                            class="btn-submit"
                            id="submitBtn" />
                        <asp:Button
                            runat="server"
                            Text="Login"
                            CssClass="btn-submit btn-cancel"
                            ID="cancelBtn" OnClick="CancelLogoutBtn" />
                    </div>
            
                </div>


                <div id="resultDiv" class="result-div">
                    <div class="result-header">
                        <h1><ins>Form Details</ins></h1>
                    </div>
                    <div class="details">
                        <div class="personal-details-header">
                            <h2>Personal Details :</h2>
                        </div>
                        <div id="personalDetails" class="personal-details">
                            <div class="div-col-20">First Name :</div>
                            <div class="div-col-30">
                                <span id="enteredFirstName" objectname="FirstName"></span>
                            </div>
                            <div class="div-col-20">Last Name :</div>
                            <div class="div-col-30">
                                <span id="enteredLastName" objectname="LastName"></span>
                            </div>
                            <div class="div-col-20">Email :</div>
                            <div class="div-col-30">
                                <span id="enteredEmail" objectname="Email"></span>
                            </div>
                            <div class="div-col-20">Date of Birth :</div>
                            <div class="div-col-30">
                                <span id="enteredDOB" objectname="DateofBirth"></span>
                            </div>
                            <div class="div-col-20">Email :</div>
                            <div class="div-col-30">
                                <span id="enteredPassword" objectname="Password"></span>
                            </div>
                            <div class="div-col-20">Email :</div>
                            <div class="div-col-30">
                                <span id="enteredCnfPassword" objectname="ConfirmPassword"></span>
                            </div>
                            <div class="div-col-50">Gender :</div>
                            <div class="div-col-50">
                                <span id="enteredGender" objectname="Gender"></span>
                            </div>
                        </div>
                        <br />
                        <div class="present-address-header">
                            <h2>Present Address :</h2>
                        </div>
                        <br />
                        <div id="presentAddresss" class="present-address">
                            <div class="div-col-20">Address Line 1 :</div>
                            <div class="div-col-30">
                                <span
                                    id="enteredPresentAddressLine1"
                                    objectname="PresentAddressLine1"></span>
                            </div>

                            <div class="div-col-20">Address Line 2 :</div>
                            <div class="div-col-30">
                                <span
                                    id="enteredPresentAddressLine2"
                                    objectname="PresentAddressLine2"></span>
                            </div>

                            <div class="div-col-20">Postal Code :</div>
                            <div class="div-col-30">
                                <span
                                    id="enteredPresentPostalCode"
                                    objectname="PresentPostalCode"></span>
                            </div>

                            <div class="div-col-20">Country :</div>
                            <div class="div-col-30">
                                <span
                                    id="enteredPresentCountry"
                                    objectname="PresentCountry"></span>
                            </div>

                            <div class="div-col-20">State :</div>
                            <div class="div-col-30">
                                <span id="enteredPresentState" objectname="PresentState"></span>
                            </div>

                            <div class="div-col-20">City :</div>
                            <div class="div-col-30">
                                <span id="enteredPresentCity" objectname="PresentCity"></span>
                            </div>
                        </div>

                        <div class="permanent-address-header">
                            <h2>Permanent Address :</h2>
                        </div>
                        <br />
                        <div id="permanentAddresss" class="permanent-address">
                            <div class="div-col-20">Address Line 1 :</div>
                            <div class="div-col-30">
                                <span
                                    id="enteredPermanentAddressLine1"
                                    objectname="PermanentAddressLine1"></span>
                            </div>

                            <div class="div-col-20">Address Line 2 :</div>
                            <div class="div-col-30">
                                <span
                                    id="enteredPermanentAddressLine2"
                                    objectname="PermanentAddressLine2"></span>
                            </div>

                            <div class="div-col-20">Postal Code :</div>
                            <div class="div-col-30">
                                <span
                                    id="enteredPermanentPostalCode"
                                    objectname="PermanentPostalCode"></span>
                            </div>
                            <div class="div-col-20">Country :</div>
                            <div class="div-col-30">
                                <span
                                    id="enteredPermanentCountry"
                                    objectname="PermanentCountry"></span>
                            </div>
                            <div class="div-col-20">State :</div>
                            <div class="div-col-30">
                                <span
                                    id="enteredPermanentState"
                                    objectname="PermanentState"></span>
                            </div>
                            <div class="div-col-20">City :</div>
                            <div class="div-col-30">
                                <span id="enteredPermanentCity" objectname="PermanentCity"></span>
                            </div>
                        </div>
                        <div class="div-col-20">Hobbies :</div>
                        <div class="div-col-80">
                            <span id="enteredHobbies" objectname="Hobby"></span>
                        </div>
                        <div class="div-col-100">
                            Subscribed to Newsletter :
                    <span id="isSubscribed" objectname="IsSubscribed"></span>
                        </div>
                    </div>
                </div> 

            </div>
            <div id="notesDiv" class="div-hide">
                <uc:Notes runat="server" ObjectType="User"/>
            </div>
            
            <div id="documentDiv" class="div-hide" >
                <uc:Document runat="server" class="div-hide"></uc:Document>
            </div>
        </form>
       <script src="Scripts/UserDetails.js"></script>
    </body>
</html>

