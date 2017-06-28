/// <reference path="../typings/jquery.d.ts"/>
/// <reference path="../typings/hammerjs.d.ts"/>
/// <reference path="../typings/winrt.d.ts"/>
/// <reference path="../js/temp/builder.ts"/>

var lastScrollTop: number = 0;

$(() => {
    $(window).scroll(() => {
        const offsetY = window.pageYOffset;
        if (offsetY > lastScrollTop) {
            window.external.notify("?action=scrollDown");
        } else if (offsetY < lastScrollTop) {
            window.external.notify("?action=scrollUp");
        }
        lastScrollTop = offsetY;
    });
});

function setArticleDetail(json: string, strPage: string): void {
    const articleDetail = JSON.parse(json) as ArticleDetail;
    const page = parseInt(strPage);
    let str = "";
    str = str + createUserBox(articleDetail);
    str = str + createArticle(articleDetail, page);
    str = str + createArticleHotComments(articleDetail);
    $("body").html(str);
}

function scrollToTop(): void {
    $("body").animate({
        scrollTop: 0
    }, "fast");
}

$(() => {
    $(document)
        .on("click", ".vgapp_user_box img,.vgapp_user_box .vgapp_ub_info .name", function () {
            const vgappUserBox = $(this).parents(".vgapp_user_box");
            const userId = vgappUserBox.attr("data-userid");
            const username = vgappUserBox.attr("data-username");
            // TODO parameter name.
            window.external.notify(`?action=showUserDetail&userId=${userId}&username=${username}`);
        })
        .on("click", ".vgapp_user_box .vgapp_ub_op", function () {
            const targetId = $(this).parents(".vgapp_user_box").attr("data-userid");
            const relationState = $(this).attr("data-state");
            // TODO parameter name.
            window.external.notify(`?action=followAuthor&relationState=${relationState}&targetId=${targetId}`);
        })
        .on("click", ".vgapp_game_item", function () {
            const gameId = $(this).attr("data-gameid");
            // TODO parameter name.
            window.external.notify(`?action=showRelationGame&gameId=${gameId}`);
        })
        .on("click", ".vgapp_comment_item .vgapp_ci_content , .vgapp_comment_item .vgapp_ci_info .vgapp_ci_detail", function () {
            const vgappCommentItem = $(this).parents(".vgapp_comment_item");
            const commentPostId = vgappCommentItem.attr("data-postid");
            const commentDetailType = vgappCommentItem.attr("data-detailtype");
            // TODO parameter name.
            window.external.notify(`?action=showCommentDetail&commentPostId=${commentPostId}&commentDetailType=${commentDetailType}`);
        })
        .on("click", ".vgapp_comment_item .vgapp_ci_info img", function () {
            const vgappCommentItem = $(this).parents(".vgapp_comment_item");
            const commentUserId = vgappCommentItem.attr("data-userid");
            const commentUsername = vgappCommentItem.attr("data-username");
            // TODO parameter name.
            window.external.notify(`?action=showUserDetail&commentUserId=${commentUserId}&commentUsername=${commentUsername}`);
        })
        .on("click", ".vgapp_comment_item .vgapp_ci_info .vgapp_ci_op .replay", function () {
            const vgappCommentItem = $(this).parents(".vgapp_comment_item");
            const commentPostId = vgappCommentItem.attr("data-postid");
            const commentDetailType = vgappCommentItem.attr("data-detailtype");
            const commentContent = $(this).text();
            // TODO parameter name.
            window.external.notify(`?action=showCommentEditor&commentPostId=${commentPostId}&commentDetailType=${commentDetailType}&commentContent=${commentContent}`);
        })
        .on("click", ".vgapp_comment_item .vgapp_ci_info .vgapp_ci_op .praise", function () {
            const vgappCommentItem = $(this).parents(".vgapp_comment_item");
            const commentPostId = vgappCommentItem.attr("data-postid");
            const commentDetailType = vgappCommentItem.attr("data-detailtype");

            if ($(this).hasClass("onit")) {
                window.external.notify(`?action=commentPraise&isLike=1&postId=${commentPostId}&type=${commentDetailType}`);
            } else {
                window.external.notify(`?action=commentPraise&isLike=0&postId=${commentPostId}&type=${commentDetailType}`);
            }
        });

    // TODO

    $(".vgapp_comment_more").click(() => {
        window.external.notify("?action=moreComment");
    });

    const hammertime = new Hammer(document.querySelector("html"));
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