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

    uwpJs();
}

function scrollToTop(): void {
    $("body").animate({
        scrollTop: 0
    }, "fast");
}

function uwpJs(): void {
    // li 保持正方形
    $(".vgapp_as_pic li").height($(".vgapp_as_pic li").width());

    // 根据图片高宽，填充 image
    $(".vgapp_as_pic li").each(function() {
        const w = $(this).find("img").width();
        const h = $(this).find("img").height();
        // 需要图片高宽比
        if (w >= h) {
            $(this).find("img").css({ "width": "auto", "height": "100%" });
        } else {
            $(this).find("img").css({ "width": "100%", "height": "auto" });
        }
    });

    var vw = $("article").width();
    $("article iframe").css({ "width": vw, "height": vw * 9 / 16 });

    // 圆桌会
    $(".roundTable_op").remove();
    $(".roundTable_add").remove();
    $("article .vg_insert_video_cover,article .vg_insert_album_cover").remove();

    var path = "http://www.vgtime.com";

    // 斗鱼直播适配
    var douyu = $(".vg_douyu");
    if (douyu.length>=1) {
        douyu.each(function() {
            var url = $(this).attr("src");
            url = path + url;
            $(this).attr("src", url);
        });
    }

    douyu = $(".douyu");
    if (douyu.length >= 1) {
        douyu.each(function() {
            var url = $(this).attr("src");
            url = path + url;
            $(this).attr("src", url);
        });
    }

    // B 站视频适配
    let bili = $(".vg_bilibili");
    if (bili.length >= 1) {
        bili.each(function() {
            const biliW = $(".vg_bilibili").width();
            const url = $(this).attr("src");
            var av: string;
            var h5Url: string;
            if (url.match("index_")) {
                av = url.replace("http://www.bilibili.com/video/av", "");
                av = av.replace(".html", "");
                av = av.replace("index_", "");
                const aa = av.split("/");
                const aid = aa[0];
                const page = aa[1];

                h5Url = path + "/resources/bili/bili.html?aid=" + aid + "&page=" + page + "#page=" + page;
                var xh = biliW * 10 / 16 + 40;
                var html5 = `<div class="bili_h5" ><iframe id="av` + av + '" data-full="0" src="' + h5Url + '" class="bili_html5" frameborder="no" scrolling="no" allowfullscreen="true" allowfullscreeninteractive="true" width="' + biliW + '" height="' + xh + '" style="min-height:auto;height:100%;"></iframe></div>';

                $(this).replaceWith(html5);
                $(".bili_h5").css({ "height": $(".bili_h5").width() * 10 / 16, "overflow": "hidden" });
                $(".bili_html5").height($(".bili_html5").width() * 10 / 16);

            }
            else {
                av = url.replace("http://www.bilibili.com/video/", "");
                av = av.replace("/", "");
                av = av.replace("av", "");

                h5Url = path + '/resources/bili/bili.html?aid=' + av + '&page=1';
                var xh = biliW * 10 / 16 + 40;
                var html5 = '<div class="bili_h5" ><iframe id="av' + av + '" data-full="0" src="' + h5Url + '" class="bili_html5" frameborder="no" scrolling="no" allowfullscreen="true" allowfullscreeninteractive="true" width="' + biliW + '" height="' + xh + '" style="min-height:auto;height:100%;"></iframe></div>';

                $(this).replaceWith(html5);
                $(".bili_h5").css({ "height": $(".bili_h5").width() * 10 / 16, "overflow": "hidden" });
                $(".bili_html5").height($(".bili_html5").width() * 10 / 16);

            }
        });
    }

    bili = $(".bilibili");
    if (bili.length >= 1) {
        bili.each(function(i) {
            var biliW = $(".bilibili").width();
            var url = $(this).attr("src");
            if (url.match("index_")) {
                var av = url.replace("http://www.bilibili.com/video/av", "");
                av = av.replace(".html", "");
                av = av.replace("index_", "");
                var aa = av.split("/");
                var aid = aa[0];
                var page = aa[1];

                var h5_url = path + '/resources/bili/bili.html?aid=' + aid + '&page=' + page + '#page=' + page;
                var xh = biliW * 10 / 16 + 40;
                var html5 = '<div class="bili_h5" ><iframe id="av' +
                    av +
                    '" data-full="0" src="' +
                    h5_url +
                    '" class="bili_html5" frameborder="no" scrolling="no" allowfullscreen="true" allowfullscreeninteractive="true" width="' +
                    biliW +
                    '" height="' +
                    xh +
                    '" style="min-height:auto;height:100%;"></iframe></div>';

                $(this).replaceWith(html5);
                $(".bili_h5").css({ "height": $(".bili_h5").width() * 10 / 16, "overflow": "hidden" });
                $(".bili_html5").height($(".bili_html5").width() * 10 / 16);

            } else {
                var av = url.replace("http://www.bilibili.com/video/", "");
                av = av.replace("/", "");
                av = av.replace("av", "");

                var h5_url = path + '/resources/bili/bili.html?aid=' + av + '&page=1';
                var xh = biliW * 10 / 16 + 40;
                var html5 = '<div class="bili_h5" ><iframe id="av' +
                    av +
                    '" data-full="0" src="' +
                    h5_url +
                    '" class="bili_html5" frameborder="no" scrolling="no" allowfullscreen="true" allowfullscreeninteractive="true" width="' +
                    biliW +
                    '" height="' +
                    xh +
                    '" style="min-height:auto;height:100%;"></iframe></div>';

                $(this).replaceWith(html5);
                $(".bili_h5").css({ "height": $(".bili_h5").width() * 10 / 16, "overflow": "hidden" });
                $(".bili_html5").height($(".bili_html5").width() * 10 / 16);

            }
            //video_width();
        });
    }

    $("*[contenteditable]").removeAttr("contenteditable");
    $("article .editable").removeClass("editable");
    $("article .editable").removeClass("editable_new");
    $("article").find("[contenteditable]").removeAttr("contenteditable");
    $("article .vg_insert_video_cover,article .vg_insert_album_cover").remove();
    $("article .roundTable_op").remove();
    $("article .editable").removeClass("editable");
    $("article .editable").removeClass("editable_new");
    $("article").find("[contenteditable]").removeAttr("contenteditable");
    $("article .vg_insert_video_cover,article .vg_insert_album_cover").remove();
    $("article .roundTable_op").remove();
    var ifr_w = $("article iframe").width();
    $("article iframe").height(ifr_w * 10 / 16);

}

$(() => {
    $(document)
        .on("click", ".vgapp_user_box img,.vgapp_user_box .vgapp_ub_info .name", function () {
            const vgappUserBox = $(this).parents(".vgapp_user_box");
            const userId = vgappUserBox.attr("data-userid");
            const userName = vgappUserBox.attr("data-username");
            window.external.notify(`?action=showUserDetail&userId=${userId}&userName=${userName}`);
        })
        .on("click", ".vgapp_user_box .vgapp_ub_op", function () {
            const targetId = $(this).parents(".vgapp_user_box").attr("data-userid");
            const relationState = $(this).attr("data-state");
            // TODO parameter name.
            window.external.notify(`?action=followAuthor&relationState=${relationState}&targetId=${targetId}`);
        })
        .on("click", ".vgapp_game_item", function () {
            const gameId = $(this).attr("data-gameid");
            window.external.notify(`?action=showRelationGame&gameId=${gameId}`);
        })
        .on("click", ".vgapp_comment_item .vgapp_ci_content , .vgapp_comment_item .vgapp_ci_info .vgapp_ci_detail", function () {
            const vgappCommentItem = $(this).parents(".vgapp_comment_item");
            const postId = vgappCommentItem.attr("data-postid");
            const detailType = vgappCommentItem.attr("data-detailtype");
            window.external.notify(`?action=showCommentDetail&postId=${postId}&detailType=${detailType}`);
        })
        .on("click", ".vgapp_comment_item .vgapp_ci_info img", function () {
            const vgappCommentItem = $(this).parents(".vgapp_comment_item");
            const userId = vgappCommentItem.attr("data-userid");
            const userName = vgappCommentItem.attr("data-username");
            window.external.notify(`?action=showUserDetail&userId=${userId}&userName=${userName}`);
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
        })
        .on("click", ".vgapp_comment_more", function () {
            const vgappComment = $(this).parents(".vgapp_comment");
            const postId = vgappComment.attr("data-postid");
            const detailType = vgappComment.attr("data-detailtype");
            window.external.notify(`?action=showCommentList&postId=${postId}&detailType=${detailType}`);
        })
        .on("click", ".vg_vote", function () {
            const voteId = $(this).attr("data-voteid");
            window.external.notify(`?action=showVote&voteId=${voteId}`);
        })
        .on("click", ".vg_album", function () {
            const albumId = $(this).attr("data-albumid");
            window.external.notify(`?action=showAlbum&albumId=${albumId}`);
        })
        .on("click", ".vg_anchor li", function () {
            const page = parseInt($(this).attr("data-page"));
            const currentPage = parseInt($(this).attr("data-currentPage"));
            const pageNum = parseInt($(this).attr("data-num"));
            if (page === currentPage) {
                const scrollTop = $("article h4").eq(pageNum - 1).offset().top - 60;
                $("body,html").animate({
                    scrollTop: scrollTop
                }, 300);
            } else {
                // TODO parameter name.
                window.external.notify(`?action=switchPage&page=${page}&pageNum=${pageNum}`);
            }
        })
        .on("click", ".vg_vlist", function () {
            const programId = $(this).attr("data-programid");
            window.external.notify(`?action=showProgramList&programId=${programId}`);
        })
        .on("click", ".vgapp_alist_item", function () {
            const newsPostId = $(this).attr("data-postid");
            const newsDetailType = $(this).attr("data-detailtype");
            // TODO parameter name.
            window.external.notify(`?action=showNews&newsPostId=${newsPostId}&newsDetailType=${newsDetailType}`);
        });

    // 防剧透
    $(document).on("click", "article u", function () {
        $(this).toggleClass("p_trailer");
    });

    // TODO

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