function onTheOneButtonClick(event, args) {
    var deviceWindow = window,
        browser = deviceWindow.navigator.appCodeName,
        isMozilla = browser == "Mozilla";

    if (isMozilla) {
        alert("Yes");
    } else {
        alert("No");
    }
}