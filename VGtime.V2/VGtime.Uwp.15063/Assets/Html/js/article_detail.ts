/// <reference path="../typings/jquery.d.ts"/>
/// <reference path="../typings/hammerjs.d.ts"/>
/// <reference path="../typings/winrt.d.ts"/>

function setArticleDetail(json: string): void {
    const articleDetail = JSON.parse(json) as ArticleDetail;
    const user = articleDetail.user;
    $(".vgapp_user_box > img").attr("src", user.avatarUrl);
    $(".vgapp_ub_info > .name").text(user.name);
    const publishDate = new Date(articleDetail.publishDate * 1000);
    $(".vgapp_ub_info > .time").text(`${publishDate.getFullYear()}-${publishDate.getMonth() + 1}-${publishDate.getDate()} ${publishDate.getHours()}:${publishDate.getMinutes()}`);
    $(".vgapp_article_long > h1").text(articleDetail.title);
    $(".vgapp_article_long > .vgapp_article_editer > span").text(`作者：${articleDetail.author} 编辑：${articleDetail.editor}`);
    $(".vgapp_article_long > article").html(articleDetail.content);
    const games = articleDetail.games;
    if (games) {
        const vgappGame = $(".vgapp_game");
        for (let game of games) {
            let vgappGameItem = $(document.createElement("div"));
            vgappGameItem.addClass("vgapp_game_item");
            vgappGameItem.html(`
                <h3>${game.name}</h3>
                <p>${game.platform}</p>
                <img src="${game.cover}">
                <span class="score">${game.score}</span>
            `);
            vgappGameItem.click(() => {
                window.external.notify(`?action=relatedGame&gameId=${game.id}`);
            });
            vgappGame.append(vgappGameItem);
        }
    }
    const news = articleDetail.news;
    if (news) {
        const vgappAlist = $(".vgapp_alist");
        for (let temp of news) {
            const newsPublishDate = new Date(temp.publishDate * 1000);
            let vgappAlistItem = $(document.createElement("div"));
            vgappAlistItem.addClass("vgapp_alist_item");
            vgappAlistItem.html(`
                <div class="vgapp_alist_uinfo">
                    <img src="${temp.user.avatarUrl}">
                    <span class="name">${temp.user.name}</span>
                    <span class="time">${newsPublishDate.getFullYear()}-${newsPublishDate.getMonth() + 1}-${newsPublishDate.getDate()} ${newsPublishDate.getHours()}:${newsPublishDate.getMinutes()}</span>
                </div>
                <h3>${temp.title}</h3>
                <span class="replay">${temp.commentNum}</span>
                <img src="${temp.cover}" class="cover">
            `);
            vgappAlist.click(() => {
                window.external.notify(`?action=relatedNews&postId=${temp.postId}&detailType=${temp.detailType}`);
            });
            vgappAlist.append(vgappAlistItem);
        }
    }
    const comments = articleDetail.comments;
    if (comments) {
        $(".vgapp_comment > h2 > span").text(comments.length);
        const vgappCommentMore = $(".vgapp_comment_more");
        for (let comment of comments) {
            const commentPublishDate = new Date(comment.publishDate * 1000);
            const vgappCommentItem = `<div class="vgapp_comment_item">
                <div class="vgapp_ci_info">
                    <img src="${comment.user.avatarUrl}">
                    <div class="vgapp_ci_detail">
                        <span class="name">${comment.user.name}</span>
                        <span class="time">${commentPublishDate.getFullYear()}-${commentPublishDate.getMonth() + 1}-${commentPublishDate.getDate()} ${commentPublishDate.getHours()}:${commentPublishDate.getMinutes()}</span>
                    </div>
                    <div class="vgapp_ci_op">
                        <span class="thank">感谢</span>
                        <span class="replay">${comment.shareNum}</span>
                        <span class="praise">${comment.likeNum}</span>
                    </div>
                </div>
                <div class="vgapp_ci_content">
                    ${comment.remark}
                </div>
            </div>`;
            vgappCommentMore.before(vgappCommentItem);
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