/// <reference path="../typings/jquery.d.ts"/>
/// <reference path="../typings/hammerjs.d.ts"/>
/// <reference path="../typings/winrt.d.ts"/>
function setArticleDetail(json) {
    var articleDetail = JSON.parse(json);
    var user = articleDetail.user;
    $(".vgapp_user_box > img").attr("src", user.avatarUrl);
    $(".vgapp_ub_info > .name").text(user.name);
    var publishDate = new Date(articleDetail.publishDate * 1000);
    $(".vgapp_ub_info > .time").text(publishDate.getFullYear() + "-" + (publishDate.getMonth() + 1) + "-" + publishDate.getDate() + " " + publishDate.getHours() + ":" + publishDate.getMinutes());
    $(".vgapp_article_long > h1").text(articleDetail.title);
    $(".vgapp_article_long > article").html(articleDetail.content);
    var games = articleDetail.games;
    if (games) {
        var vgappGame = $(".vgapp_game");
        for (var _i = 0, games_1 = games; _i < games_1.length; _i++) {
            var game = games_1[_i];
            var vgappGameItem = "<div class=\"vgapp_game_item\">\n                <h3>" + game.name + "</h3>\n                <p>" + game.platform + "</p>\n                <img src=\"" + game.cover + "\">\n                <span class=\"score\">" + game.score + "</span>\n            </div>";
            vgappGame.append(vgappGameItem);
        }
    }
    var news = articleDetail.news;
    if (news) {
        var vgappAlist = $(".vgapp_alist");
        for (var _a = 0, news_1 = news; _a < news_1.length; _a++) {
            var temp = news_1[_a];
            var newsPublishDate = new Date(temp.publishDate);
            var vgappAlistItem = "<div class=\"vgapp_alist_item\">\n                <div class=\"vgapp_alist_uinfo\">\n                    <img src=\"" + temp.user.avatarUrl + "\">\n                    <span class=\"name\">" + temp.user.name + "</span>\n                    <span class=\"time\">" + newsPublishDate.getFullYear() + "-" + (newsPublishDate.getMonth() + 1) + "-" + newsPublishDate.getDate() + " " + newsPublishDate.getHours() + ":" + newsPublishDate.getMinutes() + "</span>\n                    <span class=\"type\">" + temp.category + "</span>\n                </div>\n                <h3>" + temp.title + "</h3>\n                <span class=\"replay\">" + temp.commentNum + "</span>\n                <img src=\"" + temp.thumbnail.url + "\" class=\"cover\">\n            </div>";
            vgappAlist.append(vgappAlistItem);
        }
    }
    var comments = articleDetail.comments;
    if (comments) {
        var vgappComment = $(".vgapp_comment");
        for (var _b = 0, comments_1 = comments; _b < comments_1.length; _b++) {
            var comment = comments_1[_b];
            var vgappCommentItem = "<div class=\"vgapp_comment_item\">\n                <div class=\"vgapp_ci_info\">\n                    <img src=\"" + comment.user.avatarUrl + "\">\n                    <div class=\"vgapp_ci_detail\">\n                        <span class=\"name\">" + comment.user.name + "</span>\n                        <span class=\"time\">" + comment.publishDate + "</span>\n                    </div>\n                    <div class=\"vgapp_ci_op\">\n                        <span class=\"thank\">\u611F\u8C22</span>\n                        <span class=\"replay\">" + comment.shareNum + "</span>\n                        <span class=\"praise\">" + comment.likeNum + "</span>\n                    </div>\n                </div>\n                <div class=\"vgapp_ci_content\">\n                    " + comment.content + "\n                </div>\n            </div>";
            vgappComment.append(vgappCommentItem);
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