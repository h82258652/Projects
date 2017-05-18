/// <reference path="../type/jquery.d.ts"/>
/// <reference path="../type/hammerjs.d.ts"/>
/// <reference path="../type/winrt.d.ts"/>
function setUser(avatar, username) {
    $(".vgapp_user_box > img").attr("src", avatar);
    $(".vgapp_user_box > .vgapp_ub_info > .name").text(username);
}
function setContent(content) {
    $("#container").html(content);
}
function scrollToTop() {
    $("body").animate({
        scrollTop: 0
    }, "fast");
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
//# sourceMappingURL=detail.js.map