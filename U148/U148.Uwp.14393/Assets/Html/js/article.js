"use strict";

function setContent(content) {
    $("#container").html(content);
}

function scrollToTop() {
    $("body").animate({
        scrollTop: 0
    }, "fast");
}

$(function () {
    $("a").attr("href", "javascript:void(0);");

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