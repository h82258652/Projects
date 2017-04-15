"use strict";

function setContent(content) {
    $("#container").html(content);
}

function scrollToTop() {
    $("body").animate({
        scrollTop: 0
    }, "fast");
}