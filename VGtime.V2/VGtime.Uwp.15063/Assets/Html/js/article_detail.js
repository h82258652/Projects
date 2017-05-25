/// <reference path="../typings/jquery.d.ts"/>
/// <reference path="../typings/hammerjs.d.ts"/>
/// <reference path="../typings/winrt.d.ts"/>
function setArticleDetail(json) {
    var articleDetail = JSON.parse(json);
    var user = articleDetail.user;
    $(".vgapp_user_box > img").attr("src", user.avatarUrl);
    $(".vgapp_ub_info > .name").text(user.name);
    $(".vgapp_ub_info > .time").text(articleDetail.publishDate);
    $(".vgapp_article_long > h1").text(articleDetail.title);
    $(".vgapp_article_long > article").html(articleDetail.content);
    var games = articleDetail.games;
    if (games) {
        var vgappGame = $(".vgapp_game");
        for (var _i = 0, games_1 = games; _i < games_1.length; _i++) {
            var game = games_1[_i];
            var vgappGameItem = "<div class=\"vgapp_game_item\">";
            vgappGameItem = vgappGameItem + "<h3>" + game.name + "</h3>";
            vgappGameItem = vgappGameItem + "</div>";
            vgappGame.append(vgappGameItem);
        }
    }
}
function scrollToTop() {
    $("body").animate({
        scrollTop: 0
    }, "fast");
}
$(function () {
    $(".vgapp_comment_more").click(function () {
        window.external.notify("?action=moreComment");
    });
    var hammertime = new Hammer(document.querySelector("html"));
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
//# sourceMappingURL=article_detail.js.map