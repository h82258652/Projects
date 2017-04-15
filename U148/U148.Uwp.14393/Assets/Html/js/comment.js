"use strict";

function setContent(content) {
    $("#container").html(content);
}

setInterval(function () {
    window.external.notify("?action=heightChanged&height=" + document.body.offsetHeight.toString());
}, 500);