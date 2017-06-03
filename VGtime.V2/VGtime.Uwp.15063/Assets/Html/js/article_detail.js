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
    var anchor = articleDetail.anchor;
    var vgAnchor = $(".vg_anchor");
    if (anchor && anchor.length > 0) {
        for (var _i = 0, anchor_1 = anchor; _i < anchor_1.length; _i++) {
            var temp = anchor_1[_i];
            var li = $(document.createElement("li"));
            li.text(temp.title);
            li.click(function () {
                // TODO
            });
            vgAnchor.append(li);
        }
    }
    $(".vgapp_article_long > article").html(articleDetail.content);
    var games = articleDetail.games;
    var vgappGame = $(".vgapp_game");
    if (games && games.length > 0) {
        var _loop_1 = function (game) {
            var vgappGameItem = $(document.createElement("div"));
            vgappGameItem.addClass("vgapp_game_item");
            vgappGameItem.html("\n                <h3>" + game.name + "</h3>\n                <p>" + game.platform + "</p>\n                <img src=\"" + game.cover + "\">\n                <span class=\"score\">" + game.score + "</span>\n            ");
            vgappGameItem.click(function () {
                window.external.notify("?action=relatedGame&gameId=" + game.id);
            });
            vgappGame.append(vgappGameItem);
        };
        for (var _a = 0, games_1 = games; _a < games_1.length; _a++) {
            var game = games_1[_a];
            _loop_1(game);
        }
    }
    else {
        vgappGame.remove();
    }
    var news = articleDetail.news;
    var vgappAlist = $(".vgapp_alist");
    if (news && news.length > 0) {
        var _loop_2 = function (temp) {
            var newsPublishDate = new Date(temp.publishDate * 1000);
            var vgappAlistItem = $(document.createElement("div"));
            vgappAlistItem.addClass("vgapp_alist_item");
            vgappAlistItem.html("\n                <div class=\"vgapp_alist_uinfo\">\n                    <img src=\"" + temp.user.avatarUrl + "\">\n                    <span class=\"name\">" + temp.user.name + "</span>\n                    <span class=\"time\">" + newsPublishDate.getFullYear() + "-" + (newsPublishDate.getMonth() + 1) + "-" + newsPublishDate.getDate() + " " + newsPublishDate.getHours() + ":" + newsPublishDate.getMinutes() + "</span>\n                </div>\n                <h3>" + temp.title + "</h3>\n                <span class=\"replay\">" + temp.commentNum + "</span>\n                <img src=\"" + temp.cover + "\" class=\"cover\">\n            ");
            vgappAlist.click(function () {
                window.external.notify("?action=relatedNews&postId=" + temp.postId + "&detailType=" + temp.detailType);
            });
            vgappAlist.append(vgappAlistItem);
        };
        for (var _b = 0, news_1 = news; _b < news_1.length; _b++) {
            var temp = news_1[_b];
            _loop_2(temp);
        }
    }
    else {
        vgappAlist.remove();
    }
    var comments = articleDetail.comments;
    if (comments && comments.length > 0) {
        $(".vgapp_comment > h2 > span").text(comments.length);
        var vgappCommentMore = $(".vgapp_comment_more");
        for (var _c = 0, comments_1 = comments; _c < comments_1.length; _c++) {
            var comment = comments_1[_c];
            var commentPublishDate = new Date(comment.publishDate * 1000);
            var vgappCommentItem = "<div class=\"vgapp_comment_item\">\n                <div class=\"vgapp_ci_info\">\n                    <img src=\"" + comment.user.avatarUrl + "\">\n                    <div class=\"vgapp_ci_detail\">\n                        <span class=\"name\">" + comment.user.name + "</span>\n                        <span class=\"time\">" + commentPublishDate.getFullYear() + "-" + (commentPublishDate.getMonth() + 1) + "-" + commentPublishDate.getDate() + " " + commentPublishDate.getHours() + ":" + commentPublishDate.getMinutes() + "</span>\n                    </div>\n                    <div class=\"vgapp_ci_op\">\n                        <span class=\"thank\">\u611F\u8C22</span>\n                        <span class=\"replay\">" + (comment.commentNum === 0 ? "评论" : comment.commentNum) + "</span>\n                        <span class=\"praise\">" + (comment.likeNum === 0 ? "点赞" : comment.likeNum) + "</span>\n                    </div>\n                </div>\n                <div class=\"vgapp_ci_content\">\n                    " + comment.remark + "\n                </div>\n            </div>";
            vgappCommentMore.before(vgappCommentItem);
        }
    }
    else {
        $(".vgapp_comment > h2").remove();
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