var ArticleBuilder = (function () {
    function ArticleBuilder() {
    }
    return ArticleBuilder;
}());
function createArticle(articleDetail) {
    return "\n<div class=\"vgapp_article\">\n    <!-- \u77ED\u6587\u90E8\u5206 -->\n    " + createArticleShort(articleDetail) + "\n    <!-- \u957F\u6587\u90E8\u5206 -->\n    " + createArticleLong(articleDetail) + "\n    <!-- \u76F8\u5173\u6E38\u620F -->\n    " + createArticleRelatedGame(articleDetail.games) + "\n    <!-- \u76F8\u5173\u65B0\u95FB -->\n    " + createArticleRelatedNews(articleDetail.news) + "\n</div>";
}
function createArticleAlbum(ablum) {
    return "\n<div class=\"vg_album\" data-albumid=\"" + ablum.postId + "\">\n    <img src=\"" + ablum.cover + "\">\n    <span>" + ablum.imgCount + "</span>\n</div>";
}
function createArticleAnchor(anchors) {
    if (anchors != null && anchors.length > 0) {
        var str = "";
        for (var _i = 0, anchors_1 = anchors; _i < anchors_1.length; _i++) {
            var temp = anchors_1[_i];
            // TODO
            str = str + ("<li data-page=\"" + temp.page + "\" data-currentPage=\"" + 0 + "\" data-num=\"" + temp.num + "\">" + temp.title + "</li>");
        }
        return "\n<ul class=\"vg_anchor\">\n    " + str + "\n</ul>";
    }
    return "";
}
function createArticleEval(articleDetail) {
    if (articleDetail.reviewScore > 0) {
        var advantageList = "";
        if (articleDetail.advantageList != null && articleDetail.advantageList.length > 0) {
            for (var _i = 0, _a = JSON.parse(articleDetail.advantageList); _i < _a.length; _i++) {
                var temp = _a[_i];
                advantageList = advantageList + ("<li>" + temp.merit + "</li>");
            }
        }
        var disadvantageList = "";
        if (articleDetail.disadvantageList != null && articleDetail.disadvantageList.length > 0) {
            for (var _b = 0, _c = JSON.parse(articleDetail.disadvantageList); _b < _c.length; _b++) {
                var temp = _c[_b];
                disadvantageList = disadvantageList + ("<li>" + temp.defect + "</li>");
            }
        }
        return "\n<div class=\"vg_eval_box\">\n    <div class=\"vg_eval_score\">\n        <span>" + articleDetail.reviewScore + "</span>\n        <p>\u7F16\u8F91\u8BC4\u5206</p>\n    </div>\n    <div class=\"ve_good\">\n        <h2>\u4F18 +</h2>\n        <ul>\n            " + advantageList + "\n        </ul>\n    </div>\n    <div class=\"ve_bad\">\n        <h2>\u7F3A -</h2>\n        <ul>\n            " + disadvantageList + "\n        </ul>\n    </div>\n</div>";
    }
    return "";
}
function createArticleHotComments(articleDetail) {
    return "\n<div class=\"vgapp_comment\" data-postid=\"" + articleDetail.postId + "\" data-detailtype=\"" + articleDetail.detailType + "\">\n    " + createArticleHotCommentsList(articleDetail.comments) + "\n    <div class=\"vgapp_comment_more\">\u67E5\u770B\u6240\u6709\u8BC4\u8BBA</div>\n</div>";
}
function createArticleHotCommentsItem(comment) {
    return "\n<div class=\"vgapp_comment_item\" data-postid=\"" + comment.postId + "\" data-detailtype=\"" + comment.detailType + "\" data-userid=\"" + comment.user.userId + "\" data-username=\"" + comment.user.name + "\">\n    <div class=\"vgapp_ci_info\">\n        <img src=\"" + comment.user.avatarUrl + "\">\n        <div class=\"vgapp_ci_detail\">\n            <span class=\"name\">" + (comment.user.name ? comment.user.name : "") + "</span>\n            <span class=\"time\">" + formatDate(comment.publishDate) + "</span>\n        </div>\n        <div class=\"vgapp_ci_op\">\n            <span class=\"replay\">" + (comment.commentNum === 0 ? "评论" : comment.commentNum) + "</span>\n            <span class=\"praise\">" + (comment.likeNum === 0 ? "点赞" : comment.likeNum) + "</span>\n        </div>\n    </div>\n    <div class=\"vgapp_ci_content\">" + comment.remark + "</div>\n</div>";
}
function createArticleHotCommentsItemLiked(comment) {
    return "\n<div class=\"vgapp_comment_item\" data-postid=\"" + comment.postId + "\" data-detailtype=\"" + comment.detailType + "\" data-userid=\"" + comment.user.userId + "\" data-username=\"" + comment.user.name + "\">\n    <div} class=\"vgapp_ci_info\">\n        <img src=\"" + comment.user.avatarUrl + "\">\n        <div class=\"vgapp_ci_detail\">\n            <span class=\"name\">" + comment.user.name + "</span>\n            <span class=\"time\">" + formatDate(comment.publishDate) + "</span>\n        </div>\n        <div class=\"vgapp_ci_op\">\n            <span class=\"replay\">" + comment.commentNum + "</span>\n            <span class=\"praise onit\">" + comment.likeNum + "</span>\n        </div>\n    </div>\n    <div class=\"vgapp_ci_content\">" + comment.remark + "</div>\n</div>";
}
function createArticleHotCommentsList(comments) {
    if (comments != null && comments.length > 0) {
        var str = "";
        for (var _i = 0, comments_1 = comments; _i < comments_1.length; _i++) {
            var temp = comments_1[_i];
            if (temp.isLiked) {
                str = str + createArticleHotCommentsItemLiked(temp);
            }
            else {
                str = str + createArticleHotCommentsItem(temp);
            }
        }
        return "\n<h2>\u70ED\u95E8\u8BC4\u8BBA<span>" + comments.length + "</span></h2>\n    " + str;
    }
    return "";
}
function createArticleLong(articleDetail) {
    return "\n<div class=\"vgapp_article_long\">\n    <h1>" + articleDetail.title + "</h1>\n    " + createArticleLongAuthorEditor(articleDetail) + "\n    " + createArticleQues(articleDetail) + "\n    " + createArticleAnchor(articleDetail.anchor) + "\n    <article>" + articleDetail.content + "</article>\n    " + createArticleEval(articleDetail) + "\n</div>";
}
function createArticleLongAuthorEditor(articleDetail) {
    return "<div class=\"vgapp_article_editer\">\n    <span>\u4F5C\u8005\uFF1A" + articleDetail.author + " \u7F16\u8F91\uFF1A" + articleDetail.editor + "</span>\n</div>";
}
function createArticleProgram(program) {
    return "\n<div class=\"vg_vlist\" data-programid=\"" + program.postId + "\">\n    <h2>" + program.name + "</h2>\n    <span>\u4E2A\u6570\uFF1A" + program.videoCount + "\u4E2A</span>\n</div>";
}
function createArticleQues(articleDetail) {
    if (articleDetail.isQuestion) {
        return "\n<div class=\"vgapp_article_ques\">\n    <span class=\"" + (articleDetail.isSolve ? "resolve" : "unresolve") + "\">" + articleDetail.commentNum + "</span>\n</div>";
    }
    return "";
}
function createArticleRelatedGame(games) {
    if (games != null && games.length > 0) {
        var str = "";
        for (var _i = 0, games_1 = games; _i < games_1.length; _i++) {
            var temp = games_1[_i];
            str = str + createArticleRelatedGameItem(temp);
        }
        return "\n<div class=\"vgapp_game\">\n    <h2>\u76F8\u5173\u6E38\u620F</h2>\n    " + str + "\n</div>";
    }
    return "";
}
function formatDate(date) {
    if (typeof date == "number") {
        date = new Date(date * 1000);
    }
    if (date instanceof Date) {
        return date.getFullYear() + "-" + (date.getMonth() + 1) + "-" + date.getDate() + " " + date.getHours() + ":" + date.getMinutes();
    }
    throw "not supported type.";
}
function createArticleRelatedGameItem(game) {
    return "\n<div class=\"vgapp_game_item\" data-gameid=\"" + game.id + "\">\n    <h3>" + game.name + "</h3>\n    <p>" + game.platform + "</p>\n    <img src=\"" + game.cover + "\">\n    <span class=\"score\" style=\"background:#FFFFFF; opacity:0;\">" + game.score + "</span>\n</div>";
}
function createArticleRelatedNews(news) {
    if (news != null && news.length > 0) {
        var str = "";
        for (var _i = 0, news_1 = news; _i < news_1.length; _i++) {
            var temp = news_1[_i];
            str = str + createArticleRelatedNewsItem(temp);
        }
        return "\n<div class=\"vgapp_alist\">\n    <h2>\u76F8\u5173\u65B0\u95FB</h2>\n    " + str + "\n</div>";
    }
    return "";
}
function createArticleRelatedNewsItem(news) {
    return "\n<div class=\"vgapp_alist_item\" data-postid=\"" + news.postId + "\" data-detailtype=\"" + news.detailType + "\">\n    <div class=\"vgapp_alist_uinfo\">\n        <img src=\"" + news.user.avatarUrl + "\">\n        <span class=\"name\">" + news.user.name + "</span>\n        <span class=\"time\">" + formatDate(news.publishDate) + "</span>\n        <span class=\"type\">" + news.category + "</span>\n    </div>\n    <h3>" + news.title + "</h3>\n    <span class=\"replay\">" + news.commentNum + "</span>\n    <img src=\"" + news.cover + "\" class=\"cover\">\n</div>";
}
function createArticleShort(articleDetail) {
    if (articleDetail.images != null && articleDetail.images.length > 0) {
        var str = "";
        for (var _i = 0, _a = articleDetail.images; _i < _a.length; _i++) {
            var temp = _a[_i];
            str = str + ("<li><img src=\"" + temp + "\"></li>");
        }
        return "\n<div class=\"vgapp_article_short\">\n    " + createArticleQues(articleDetail) + "\n    <div class=\"vgapp_as_content\">" + articleDetail.text + "</div>\n    <ul class=\"vgapp_as_pic\" data-size=\"" + articleDetail.images.length + "\">\n        " + str + "\n    </ul>\n</div>";
    }
    return "";
}
function createArticleSource(parentSource) {
    return "\n<div class=\"forum_source_box\">\n    <a class=\"forum_source_link\" data-id=\"" + parentSource.postId + "\" data-type=\"" + parentSource.detailType + "\">" + parentSource.title + "</a>\n    <span class=\"comm_num\">\n        <i class=\"icon\"></i>" + parentSource.commentNum + "\n    </span>\n</div>";
}
function createArticleVote(vote) {
    return "\n<div class=\"vg_vote\" data-voteid=\"" + vote.postId + "\">\n    <h2>" + vote.name + "</h2>\n    <span>\u53C2\u4E0E\u4EBA\u6570\uFF1A" + vote.userCount + "\u4EBA</span>\n</div>";
}
function createUserBox(articleDetail) {
    return "\n<div class=\"vgapp_user_box\" data-userid=\"" + articleDetail.user.userId + "\" data-username=\"" + articleDetail.user.name + "\">\n    <img src=\"" + articleDetail.user.avatarUrl + "\">\n    <div class=\"vgapp_ub_info\">\n        <span class=\"name\">" + articleDetail.user.name + "</span>\n        <span class=\"time\">" + formatDate(articleDetail.publishDate) + "</span>\n    </div>\n    " + createUserBoxUpBox(articleDetail) + "\n</div>";
}
function createUserBoxUpBox(articleDetail) {
    return "<span class=\"vgapp_ub_op\" data-state=\"" + articleDetail.user.relation + "\"></span>";
}
//# sourceMappingURL=builder.js.map