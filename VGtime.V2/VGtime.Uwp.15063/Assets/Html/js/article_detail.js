/// <reference path="../typings/jquery.d.ts"/>
/// <reference path="../typings/hammerjs.d.ts"/>
/// <reference path="../typings/winrt.d.ts"/>
/// <reference path="../js/temp/builder.ts"/>
var lastScrollTop = 0;
$(function () {
    $(window).scroll(function () {
        var offsetY = window.pageYOffset;
        if (offsetY > lastScrollTop) {
            window.external.notify("?action=scrollDown");
        }
        else if (offsetY < lastScrollTop) {
            window.external.notify("?action=scrollUp");
        }
        lastScrollTop = offsetY;
    });
});
function setArticleDetail(json, strPage) {
    var articleDetail = JSON.parse(json);
    var page = parseInt(strPage);
    var str = "";
    str = str + createUserBox(articleDetail);
    str = str + createArticle(articleDetail, page);
    str = str + createArticleHotComments(articleDetail);
    $("body").html(str);
}
function scrollToTop() {
    $("body").animate({
        scrollTop: 0
    }, "fast");
}
$(function () {
    $(document)
        .on("click", ".vgapp_user_box img,.vgapp_user_box .vgapp_ub_info .name", function () {
        var vgappUserBox = $(this).parents(".vgapp_user_box");
        var userId = vgappUserBox.attr("data-userid");
        var username = vgappUserBox.attr("data-username");
        // TODO parameter name.
        window.external.notify("?action=showUserDetail&userId=" + userId + "&username=" + username);
    })
        .on("click", ".vgapp_user_box .vgapp_ub_op", function () {
        var targetId = $(this).parents(".vgapp_user_box").attr("data-userid");
        var relationState = $(this).attr("data-state");
        // TODO parameter name.
        window.external.notify("?action=followAuthor&relationState=" + relationState + "&targetId=" + targetId);
    })
        .on("click", ".vgapp_game_item", function () {
        var gameId = $(this).attr("data-gameid");
        // TODO parameter name.
        window.external.notify("?action=showRelationGame&gameId=" + gameId);
    })
        .on("click", ".vgapp_comment_item .vgapp_ci_content , .vgapp_comment_item .vgapp_ci_info .vgapp_ci_detail", function () {
        var vgappCommentItem = $(this).parents(".vgapp_comment_item");
        var commentPostId = vgappCommentItem.attr("data-postid");
        var commentDetailType = vgappCommentItem.attr("data-detailtype");
        // TODO parameter name.
        window.external.notify("?action=showCommentDetail&commentPostId=" + commentPostId + "&commentDetailType=" + commentDetailType);
    })
        .on("click", ".vgapp_comment_item .vgapp_ci_info img", function () {
        var vgappCommentItem = $(this).parents(".vgapp_comment_item");
        var commentUserId = vgappCommentItem.attr("data-userid");
        var commentUsername = vgappCommentItem.attr("data-username");
        // TODO parameter name.
        window.external.notify("?action=showUserDetail&commentUserId=" + commentUserId + "&commentUsername=" + commentUsername);
    })
        .on("click", ".vgapp_comment_item .vgapp_ci_info .vgapp_ci_op .replay", function () {
        var vgappCommentItem = $(this).parents(".vgapp_comment_item");
        var commentPostId = vgappCommentItem.attr("data-postid");
        var commentDetailType = vgappCommentItem.attr("data-detailtype");
        var commentContent = $(this).text();
        // TODO parameter name.
        window.external.notify("?action=showCommentEditor&commentPostId=" + commentPostId + "&commentDetailType=" + commentDetailType + "&commentContent=" + commentContent);
    })
        .on("click", ".vgapp_comment_item .vgapp_ci_info .vgapp_ci_op .praise", function () {
        var vgappCommentItem = $(this).parents(".vgapp_comment_item");
        var commentPostId = vgappCommentItem.attr("data-postid");
        var commentDetailType = vgappCommentItem.attr("data-detailtype");
        if ($(this).hasClass("onit")) {
            window.external.notify("?action=commentPraise&isLike=1&postId=" + commentPostId + "&type=" + commentDetailType);
        }
        else {
            window.external.notify("?action=commentPraise&isLike=0&postId=" + commentPostId + "&type=" + commentDetailType);
        }
    });
    // TODO
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