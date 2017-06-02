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
    $(".vgapp_article_long > .vgapp_article_editer > span").text("\u4F5C\u8005\uFF1A" + articleDetail.author + " \u7F16\u8F91\uFF1A" + articleDetail.editor);
    $(".vgapp_article_long > article").html(articleDetail.content);
    var games = articleDetail.games;
    if (games) {
        var vgappGame = $(".vgapp_game");
        var _loop_1 = function (game) {
            vgappGameItem = $(document.createElement("div"));
            vgappGameItem.addClass("vgapp_game_item");
            vgappGameItem.html("\n                <h3>" + game.name + "</h3>\n                <p>" + game.platform + "</p>\n                <img src=\"" + game.cover + "\">\n                <span class=\"score\">" + game.score + "</span>\n            ");
            vgappGameItem.click(function () {
                window.external.notify("?action=relatedGame&gameId=" + game.id);
            });
            vgappGame.append(vgappGameItem);
        };
        var vgappGameItem;
        for (var _i = 0, games_1 = games; _i < games_1.length; _i++) {
            var game = games_1[_i];
            _loop_1(game);
        }
    }
    var news = articleDetail.news;
    if (news) {
        var vgappAlist = $(".vgapp_alist");
        for (var _a = 0, news_1 = news; _a < news_1.length; _a++) {
            var temp = news_1[_a];
            var newsPublishDate = new Date(temp.publishDate * 1000);
            var vgappAlistItem = $(document.createElement("div"));
            vgappAlistItem.addClass("vgapp_alist_item");
            vgappAlistItem.html("\n                <div class=\"vgapp_alist_uinfo\">\n                    <img src=\"" + temp.user.avatarUrl + "\">\n                    <span class=\"name\">" + temp.user.name + "</span>\n                    <span class=\"time\">" + newsPublishDate.getFullYear() + "-" + (newsPublishDate.getMonth() + 1) + "-" + newsPublishDate.getDate() + " " + newsPublishDate.getHours() + ":" + newsPublishDate.getMinutes() + "</span>\n                </div>\n            ");
            //const vgappAlistItem = `<div class="vgapp_alist_item">
            //    <div class="vgapp_alist_uinfo">
            //        <img src="${temp.user.avatarUrl}">
            //        <span class="name">${temp.user.name}</span>
            //        <span class="time">${newsPublishDate.getFullYear()}-${newsPublishDate.getMonth() + 1}-${newsPublishDate.getDate()} ${newsPublishDate.getHours()}:${newsPublishDate.getMinutes()}</span>
            //    </div>
            //    <h3>${temp.title}</h3>
            //    <span class="replay">${temp.commentNum}</span>
            //    <img src="${temp.cover}" class="cover">
            //</div>`;
            vgappAlist.append(vgappAlistItem);
        }
    }
    var comments = articleDetail.comments;
    if (comments) {
        $(".vgapp_comment > h2 > span").text(comments.length);
        var vgappCommentMore = $(".vgapp_comment_more");
        for (var _b = 0, comments_1 = comments; _b < comments_1.length; _b++) {
            var comment = comments_1[_b];
            var commentPublishDate = new Date(comment.publishDate * 1000);
            var vgappCommentItem = "<div class=\"vgapp_comment_item\">\n                <div class=\"vgapp_ci_info\">\n                    <img src=\"" + comment.user.avatarUrl + "\">\n                    <div class=\"vgapp_ci_detail\">\n                        <span class=\"name\">" + comment.user.name + "</span>\n                        <span class=\"time\">" + commentPublishDate.getFullYear() + "-" + (commentPublishDate.getMonth() + 1) + "-" + commentPublishDate.getDate() + " " + commentPublishDate.getHours() + ":" + commentPublishDate.getMinutes() + "</span>\n                    </div>\n                    <div class=\"vgapp_ci_op\">\n                        <span class=\"thank\">\u611F\u8C22</span>\n                        <span class=\"replay\">" + comment.shareNum + "</span>\n                        <span class=\"praise\">" + comment.likeNum + "</span>\n                    </div>\n                </div>\n                <div class=\"vgapp_ci_content\">\n                    " + comment.remark + "\n                </div>\n            </div>";
            vgappCommentMore.before(vgappCommentItem);
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