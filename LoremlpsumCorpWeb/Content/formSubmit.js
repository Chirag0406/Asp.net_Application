function OnSuccess(response) {
    alert("Thank You " + response.Name);
    document.forms["contactUsForm"].reset()
}
function OnFailure(response) {
    alert("Error occured.");
}