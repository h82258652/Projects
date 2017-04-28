"use strict";

function setContent(content) {
    $("#container").html(content);
}

$(function () {
    var hammertime = new Hammer(document.getElementsByTagName("html")[0]);
    hammertime.on("swipeleft", function (e) {
        if (e.pointerType !== "mouse") {
            window.external.notify("?action=goForward");
        }
    });
    hammertime.on("swiperight", function (e) {
        if (e.pointerType !== "mouse") {
            window.external.notify("?action=goBack");
        }
    });
});