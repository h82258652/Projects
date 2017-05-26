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
            const vgappGameItem = `<div class="vgapp_game_item">
                <h3>${game.name}</h3>
                <p>${game.platform}</p>
                <img src="${game.cover}">
                <span class="score">${game.score}</span>
            </div>`;
            vgappGame.append(vgappGameItem);
        }
    }
    const comments = articleDetail.comments;
    if (comments) {
        const vgappComment = $(".vgapp_comment");
        for (let comment of comments) {
            const vgappCommentItem = `<div class="vgapp_comment_item">
                <div class="vgapp_ci_info">
                    <img src="${comment.user.avatarUrl}">
                    <div class="vgapp_ci_detail">
                        <span class="name">${comment.user.name}</span>
                        <span class="time">${comment.publishDate}</span>
                    </div>
                    <div class="vgapp_ci_op">
                        <span class="thank">感谢</span>
                        <span class="replay">${comment.shareNum}</span>
                        <span class="praise">${comment.likeNum}</span>
                    </div>
                </div>
                <div class="vgapp_ci_content">
                    ${comment.content}
                </div>
            </div>`;
            vgappComment.append(vgappCommentItem);
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