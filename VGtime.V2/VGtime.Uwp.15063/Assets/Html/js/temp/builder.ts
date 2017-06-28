class ArticleBuilder {
}

function createArticle(articleDetail: ArticleDetail, page: number): string {
    return `
<div class="vgapp_article">
    <!-- 短文部分 -->
    ${createArticleShort(articleDetail)}
    <!-- 长文部分 -->
    ${createArticleLong(articleDetail, page)}
    <!-- 相关游戏 -->
    ${createArticleRelatedGame(articleDetail.games)}
    <!-- 相关新闻 -->
    ${createArticleRelatedNews(articleDetail.news)}
</div>`;
}

function createArticleAlbum(ablum: ArticleDetailAblum): string {
    return `
<div class="vg_album" data-albumid="${ablum.postId}">
    <img src="${ablum.cover}">
    <span>${ablum.imgCount}</span>
</div>`;
}

function createArticleAnchor(anchors: ArticleDetailAnchor[], page: number): string {
    if (anchors != null && anchors.length > 0) {
        let str = "";
        for (let temp of anchors) {
            str = str + `<li data-page="${temp.page}" data-currentPage="${page}" data-num="${temp.num}">${temp.title}</li>`;
        }
        return `
<ul class="vg_anchor">
    ${str}
</ul>`;
    }
    return "";
}

function createArticleEval(articleDetail: ArticleDetail): string {
    if (articleDetail.reviewScore > 0) {
        let advantageList = "";
        if (articleDetail.advantageList != null && articleDetail.advantageList.length > 0) {
            for (let temp of JSON.parse(articleDetail.advantageList) as ArticleDetailAdvantage[]) {
                advantageList = advantageList + `<li>${temp.merit}</li>`;
            }
        }

        let disadvantageList = "";
        if (articleDetail.disadvantageList != null && articleDetail.disadvantageList.length > 0) {
            for (let temp of JSON.parse(articleDetail.disadvantageList) as ArticleDetailDisadvantage[]) {
                disadvantageList = disadvantageList + `<li>${temp.defect}</li>`;
            }
        }

        return `
<div class="vg_eval_box">
    <div class="vg_eval_score">
        <span>${articleDetail.reviewScore}</span>
        <p>编辑评分</p>
    </div>
    <div class="ve_good">
        <h2>优 +</h2>
        <ul>
            ${advantageList}
        </ul>
    </div>
    <div class="ve_bad">
        <h2>缺 -</h2>
        <ul>
            ${disadvantageList}
        </ul>
    </div>
</div>`;
    }
    return "";
}

function createArticleHotComments(articleDetail: ArticleDetail): string {
    return `
<div class="vgapp_comment" data-postid="${articleDetail.postId}" data-detailtype="${articleDetail.detailType}">
    ${createArticleHotCommentsList(articleDetail.comments)}
    <div class="vgapp_comment_more">查看所有评论</div>
</div>`;
}

function createArticleHotCommentsItem(comment: ArticleDetail): string {
    return `
<div class="vgapp_comment_item" data-postid="${comment.postId}" data-detailtype="${comment.detailType}" data-userid="${comment.user.userId}" data-username="${comment.user.name}">
    <div class="vgapp_ci_info">
        <img src="${comment.user.avatarUrl}">
        <div class="vgapp_ci_detail">
            <span class="name">${comment.user.name ? comment.user.name : ""}</span>
            <span class="time">${formatDate(comment.publishDate)}</span>
        </div>
        <div class="vgapp_ci_op">
            <span class="replay">${comment.commentNum === 0 ? "评论" : comment.commentNum}</span>
            <span class="praise">${comment.likeNum === 0 ? "点赞" : comment.likeNum}</span>
        </div>
    </div>
    <div class="vgapp_ci_content">${comment.remark}</div>
</div>`;
}

function createArticleHotCommentsItemLiked(comment: ArticleDetail): string {
    return `
<div class="vgapp_comment_item" data-postid="${comment.postId}" data-detailtype="${comment.detailType}" data-userid="${comment.user.userId}" data-username="${comment.user.name}">
    <div} class="vgapp_ci_info">
        <img src="${comment.user.avatarUrl}">
        <div class="vgapp_ci_detail">
            <span class="name">${comment.user.name}</span>
            <span class="time">${formatDate(comment.publishDate)}</span>
        </div>
        <div class="vgapp_ci_op">
            <span class="replay">${comment.commentNum}</span>
            <span class="praise onit">${comment.likeNum}</span>
        </div>
    </div>
    <div class="vgapp_ci_content">${comment.remark}</div>
</div>`;
}

function createArticleHotCommentsList(comments: ArticleDetail[]): string {
    if (comments != null && comments.length > 0) {
        let str = "";
        for (let temp of comments) {
            if (temp.isLiked) {
                str = str + createArticleHotCommentsItemLiked(temp);
            } else {
                str = str + createArticleHotCommentsItem(temp);
            }
        }
        return `
<h2>热门评论<span>${comments.length}</span></h2>
    ${str}`;
    }
    return "";
}

function createArticleLong(articleDetail: ArticleDetail, page: number): string {
    return `
<div class="vgapp_article_long">
    <h1>${articleDetail.title}</h1>
    ${createArticleLongAuthorEditor(articleDetail)}
    ${createArticleQues(articleDetail)}
    ${createArticleAnchor(articleDetail.anchor, page)}
    <article>${articleDetail.content}</article>
    ${createArticleEval(articleDetail)}
</div>`;
}

function createArticleLongAuthorEditor(articleDetail: ArticleDetail): string {
    return `<div class="vgapp_article_editer">
    <span>作者：${articleDetail.author} 编辑：${articleDetail.editor}</span>
</div>`;
}

function createArticleProgram(program: ArticleDetailProgram): string {
    return `
<div class="vg_vlist" data-programid="${program.postId}">
    <h2>${program.name}</h2>
    <span>个数：${program.videoCount}个</span>
</div>`;
}

function createArticleQues(articleDetail: ArticleDetail): string {
    if (articleDetail.isQuestion) {
        return `
<div class="vgapp_article_ques">
    <span class="${articleDetail.isSolve ? "resolve" : "unresolve"}">${articleDetail.commentNum}</span>
</div>`;
    }
    return "";
}

function createArticleRelatedGame(games: ArticleRelatedGame[]): string {
    if (games != null && games.length > 0) {
        let str = "";
        for (let temp of games) {
            str = str + createArticleRelatedGameItem(temp);
        }
        return `
<div class="vgapp_game">
    <h2>相关游戏</h2>
    ${str}
</div>`;
    }
    return ``;
}

function formatDate(date: Date): string;
function formatDate(date: number): string;
function formatDate(date: any): string {
    if (typeof date == "number") {
        date = new Date(date * 1000);
    }
    if (date instanceof Date) {
        return `${date.getFullYear()}-${date.getMonth() + 1}-${date.getDate()} ${date.getHours()}:${date.getMinutes()}`;
    }
    throw "not supported type.";
}

function createArticleRelatedGameItem(game: ArticleRelatedGame): string {
    return `
<div class="vgapp_game_item" data-gameid="${game.id}">
    <h3>${game.name}</h3>
    <p>${game.platform}</p>
    <img src="${game.cover}">
    <span class="score" style="background:#FFFFFF; opacity:0;">${game.score}</span>
</div>`;
}

function createArticleRelatedNews(news: ArticleDetail[]): string {
    if (news != null && news.length > 0) {
        let str = "";
        for (let temp of news) {
            str = str + createArticleRelatedNewsItem(temp);
        }
        return `
<div class="vgapp_alist">
    <h2>相关新闻</h2>
    ${str}
</div>`;
    }
    return "";
}

function createArticleRelatedNewsItem(news: ArticleDetail): string {
    return `
<div class="vgapp_alist_item" data-postid="${news.postId}" data-detailtype="${news.detailType}">
    <div class="vgapp_alist_uinfo">
        <img src="${news.user.avatarUrl}">
        <span class="name">${news.user.name}</span>
        <span class="time">${formatDate(news.publishDate)}</span>
        <span class="type">${news.category}</span>
    </div>
    <h3>${news.title}</h3>
    <span class="replay">${news.commentNum}</span>
    <img src="${news.cover}" class="cover">
</div>`;
}

function createArticleShort(articleDetail: ArticleDetail): string {
    if (articleDetail.images != null && articleDetail.images.length > 0) {
        let str = "";
        for (let temp of articleDetail.images) {
            str = str + `<li><img src="${temp}"></li>`;
        }
        return `
<div class="vgapp_article_short">
    ${createArticleQues(articleDetail)}
    <div class="vgapp_as_content">${articleDetail.text}</div>
    <ul class="vgapp_as_pic" data-size="${articleDetail.images.length}">
        ${str}
    </ul>
</div>`;
    }
    return "";
}

function createArticleSource(parentSource: ArticleDetailParentSource): string {
    return `
<div class="forum_source_box">
    <a class="forum_source_link" data-id="${parentSource.postId}" data-type="${parentSource.detailType}">${parentSource.title}</a>
    <span class="comm_num">
        <i class="icon"></i>${parentSource.commentNum}
    </span>
</div>`;
}

function createArticleVote(vote: ArticleDetailVote): string {
    return `
<div class="vg_vote" data-voteid="${vote.postId}">
    <h2>${vote.name}</h2>
    <span>参与人数：${vote.userCount}人</span>
</div>`;
}

function createUserBox(articleDetail: ArticleDetail) {
    return `
<div class="vgapp_user_box" data-userid="${articleDetail.user.userId}" data-username="${articleDetail.user.name}">
    <img src="${articleDetail.user.avatarUrl}">
    <div class="vgapp_ub_info">
        <span class="name">${articleDetail.user.name}</span>
        <span class="time">${formatDate(articleDetail.publishDate)}</span>
    </div>
    ${createUserBoxUpBox(articleDetail)}
</div>`;
}

function createUserBoxUpBox(articleDetail: ArticleDetail) {
    return `<span class="vgapp_ub_op" data-state="${articleDetail.user.relation}"></span>`;
}