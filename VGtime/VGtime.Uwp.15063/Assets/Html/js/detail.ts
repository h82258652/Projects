/// <reference path="../type/jquery.d.ts"/>
/// <reference path="../type/hammerjs.d.ts"/>
/// <reference path="../type/winrt.d.ts"/>

function setContent(content: string): void {
    $("#container").html(content);
}

function scrollToTop(): void {
    $("body").animate({
        scrollTop: 0
    }, "fast");
}

$(() => {
    var hammertime = new Hammer(document.getElementsByTagName("html")[0] as HTMLElement);
    hammertime.on("swipeleft", (e: HammerInput): void => {
        if (e.pointerType !== "mouse") {
            window.external.notify("?action=goForward");
        }
    });
    hammertime.on("swiperight", (e: HammerInput): void => {
        if (e.pointerType !== "mouse") {
            window.external.notify("?action=goBack");
        }
    });
});