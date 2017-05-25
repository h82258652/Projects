/// <reference path="../typings/jquery.d.ts"/>
/// <reference path="../typings/hammerjs.d.ts"/>
/// <reference path="../typings/winrt.d.ts"/>

function setArticleDetail(json: string): void {
    const articleDetail = JSON.parse(json) as ArticleDetail;
    const user = articleDetail.user;
    $(".vgapp_user_box > img").attr("src", user.avatarUrl);
    $(".vgapp_ub_info > .name").text(user.name);
    $(".vgapp_ub_info > .time").text(articleDetail.publishDate);
    $(".vgapp_article_long > h1").text(articleDetail.title);
    $(".vgapp_article_long > article").html(articleDetail.content);
    const games = articleDetail.games;
    if (games) {
        const vgappGame = $(".vgapp_game");
        for (let game of games) {
            let vgappGameItem = "<div class=\"vgapp_game_item\">";
            vgappGameItem = vgappGameItem + "<h3>" + game.name + "</h3>";
            vgappGameItem = vgappGameItem + "</div>";
            vgappGame.append(vgappGameItem);
        }
    }
}

function scrollToTop(): void {
    $("body").animate({
        scrollTop: 0
    }, "fast");
}

$(() => {
    $(".vgapp_comment_more").click(() => {
        window.external.notify("?action=moreComment");
    });

    var hammertime = new Hammer(document.querySelector("html"));
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
})