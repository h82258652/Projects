"use strict";

function setContent(content) {
    $("#container").html(content);
    window.external.notify("?action=heightChanged&height=" + document.body.offsetHeight.toString());
}

function setThemeMode(theme) {
    theme = theme.toLowerCase();
    if (theme === "night" || theme === "dark") {
        document.getElementsByTagName("html")[0].setAttribute("class", "night");
    }
    else {
        document.getElementsByTagName("html")[0].setAttribute("class", "");
    }
}

setInterval(function () {
    window.external.notify("?action=heightChanged&height=" + document.body.offsetHeight.toString());
}, 500);