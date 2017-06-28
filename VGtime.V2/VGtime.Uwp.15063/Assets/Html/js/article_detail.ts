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

function ccc() {
    var d =
        `
{"ablumList":[],"action":null,"ad":{"advertiser":"","appPic":"http://img01.vgtime.com/game/cover/2017/05/31/170531103451660.jpg","channelId":46,"click":938,"createTime":1496198134,"id":52,"status":1,"title":"UCG419","url":"https://item.taobao.com/item.htm?spm=a1z10.1-c-s.w4004-15045831962.4.DCnXCo&id=551889119611","webPic":"http://img01.vgtime.com/game/cover/2017/05/31/170531103448240.jpg"},"advantageList":null,"anchor":[{"num":1,"page":1,"title":"电子艺术的起源"},{"num":2,"page":1,"title":"发展与改变"},{"num":3,"page":1,"title":"“软硬兼施”：3DO与EA SPORTS"},{"num":4,"page":1,"title":"波澜壮阔的收购史和开发史"},{"num":1,"page":2,"title":"从艺术家到资本家的大变革"},{"num":2,"page":2,"title":"新阶段"}],"author":"80后写稿佬","category":"VG解密","comment":null,"commentNum":64,"comments":[{"ablumList":null,"action":null,"ad":null,"advantageList":null,"anchor":null,"author":null,"category":null,"comment":null,"commentNum":2,"comments":null,"content":null,"contentPage":0,"cover":null,"detailType":3,"disadvantageList":null,"editor":null,"game":null,"games":null,"images":null,"isFavorited":false,"isLiked":false,"isQuestion":false,"isShort":false,"isSolve":false,"isVideo":false,"likeNum":19,"news":null,"originalPost":null,"parentSource":null,"postId":615742,"programList":null,"publishDate":1496632974,"relatedGame":null,"remark":"泰坦2给战地牺牲做助攻，是我认为EA最体现商人气息的举动","reviewScore":0.0,"shareNum":0,"shareUrl":null,"text":null,"thumbnail":null,"timeLineType":0,"title":null,"user":{"androidGold":0,"area":null,"avatarUrl":"http://img01.vgtime.com/article/web/1609051300360.jpg","awardCount":0,"bandCode":null,"copperAward":0,"couponCount":0,"demonValue":0,"email":null,"followCount":0,"followerCount":0,"followerDate":null,"gender":0,"goldAward":0,"heroValue":0,"inviteCode":null,"inviteCount":0,"iosgold":0,"isHighlight":false,"isPerfect":false,"isSynced":false,"isTourist":false,"level":0,"master":null,"mobile":null,"myCollectNum":0,"myScoreNum":0,"myTimeLineNum":0,"name":"IX The Hermit","password":null,"relation":1,"silverAward":0,"sinaId":null,"status":0,"tencentId":null,"token":null,"userId":4724,"vgExp":0,"vgNextLevelExp":0,"vgpoint":0,"wechatId":null},"videoList":null,"voteList":null},{"ablumList":null,"action":null,"ad":null,"advantageList":null,"anchor":null,"author":null,"category":null,"comment":null,"commentNum":9,"comments":null,"content":null,"contentPage":0,"cover":null,"detailType":3,"disadvantageList":null,"editor":null,"game":null,"games":null,"images":null,"isFavorited":false,"isLiked":false,"isQuestion":false,"isShort":false,"isSolve":false,"isVideo":false,"likeNum":6,"news":null,"originalPost":null,"parentSource":null,"postId":616168,"programList":null,"publishDate":1496647598,"relatedGame":null,"remark":"这条主题已消失在黑洞边际，再也找不回来了…","reviewScore":0.0,"shareNum":0,"shareUrl":null,"text":null,"thumbnail":null,"timeLineType":0,"title":null,"user":{"androidGold":0,"area":null,"avatarUrl":"http://static.vgtime.com/image/tou.gif","awardCount":0,"bandCode":null,"copperAward":0,"couponCount":0,"demonValue":0,"email":null,"followCount":0,"followerCount":0,"followerDate":null,"gender":0,"goldAward":0,"heroValue":0,"inviteCode":null,"inviteCount":0,"iosgold":0,"isHighlight":false,"isPerfect":false,"isSynced":false,"isTourist":false,"level":0,"master":null,"mobile":null,"myCollectNum":0,"myScoreNum":0,"myTimeLineNum":0,"name":"amotime","password":null,"relation":1,"silverAward":0,"sinaId":null,"status":0,"tencentId":null,"token":null,"userId":38455,"vgExp":0,"vgNextLevelExp":0,"vgpoint":0,"wechatId":null},"videoList":null,"voteList":null},{"ablumList":null,"action":null,"ad":null,"advantageList":null,"anchor":null,"author":null,"category":null,"comment":null,"commentNum":0,"comments":null,"content":null,"contentPage":0,"cover":null,"detailType":3,"disadvantageList":null,"editor":null,"game":null,"games":null,"images":null,"isFavorited":false,"isLiked":false,"isQuestion":false,"isShort":false,"isSolve":false,"isVideo":false,"likeNum":2,"news":null,"originalPost":null,"parentSource":null,"postId":617735,"programList":null,"publishDate":1496717932,"relatedGame":null,"remark":"EA SPORTS，册那GAME！ 懂得亮我。","reviewScore":0.0,"shareNum":0,"shareUrl":null,"text":null,"thumbnail":null,"timeLineType":0,"title":null,"user":{"androidGold":0,"area":null,"avatarUrl":"http://img01.vgtime.com/headpic/mobile/160830151737322.jpg","awardCount":0,"bandCode":null,"copperAward":0,"couponCount":0,"demonValue":0,"email":null,"followCount":0,"followerCount":0,"followerDate":null,"gender":0,"goldAward":0,"heroValue":0,"inviteCode":null,"inviteCount":0,"iosgold":0,"isHighlight":false,"isPerfect":false,"isSynced":false,"isTourist":false,"level":0,"master":null,"mobile":null,"myCollectNum":0,"myScoreNum":0,"myTimeLineNum":0,"name":"小象咪咪","password":null,"relation":1,"silverAward":0,"sinaId":null,"status":0,"tencentId":null,"token":null,"userId":104224,"vgExp":0,"vgNextLevelExp":0,"vgpoint":0,"wechatId":null},"videoList":null,"voteList":null},{"ablumList":null,"action":null,"ad":null,"advantageList":null,"anchor":null,"author":null,"category":null,"comment":null,"commentNum":1,"comments":null,"content":null,"contentPage":0,"cover":null,"detailType":3,"disadvantageList":null,"editor":null,"game":null,"games":null,"images":null,"isFavorited":false,"isLiked":false,"isQuestion":false,"isShort":false,"isSolve":false,"isVideo":false,"likeNum":2,"news":null,"originalPost":null,"parentSource":null,"postId":615894,"programList":null,"publishDate":1496637226,"relatedGame":null,"remark":"愤怒的小鸟是Rovio的厚","reviewScore":0.0,"shareNum":0,"shareUrl":null,"text":null,"thumbnail":null,"timeLineType":0,"title":null,"user":{"androidGold":0,"area":null,"avatarUrl":"http://img01.vgtime.com/article/web/160727165939371.jpg","awardCount":0,"bandCode":null,"copperAward":0,"couponCount":0,"demonValue":0,"email":null,"followCount":0,"followerCount":0,"followerDate":null,"gender":0,"goldAward":0,"heroValue":0,"inviteCode":null,"inviteCount":0,"iosgold":0,"isHighlight":false,"isPerfect":false,"isSynced":false,"isTourist":false,"level":0,"master":null,"mobile":null,"myCollectNum":0,"myScoreNum":0,"myTimeLineNum":0,"name":"嫩头青灬","password":null,"relation":1,"silverAward":0,"sinaId":null,"status":0,"tencentId":null,"token":null,"userId":44729,"vgExp":0,"vgNextLevelExp":0,"vgpoint":0,"wechatId":null},"videoList":null,"voteList":null},{"ablumList":null,"action":null,"ad":null,"advantageList":null,"anchor":null,"author":null,"category":null,"comment":null,"commentNum":0,"comments":null,"content":null,"contentPage":0,"cover":null,"detailType":3,"disadvantageList":null,"editor":null,"game":null,"games":null,"images":null,"isFavorited":false,"isLiked":false,"isQuestion":false,"isShort":false,"isSolve":false,"isVideo":false,"likeNum":2,"news":null,"originalPost":null,"parentSource":null,"postId":615864,"programList":null,"publishDate":1496635839,"relatedGame":null,"remark":"真快真快真快！这次更新真快hhh！😘","reviewScore":0.0,"shareNum":0,"shareUrl":null,"text":null,"thumbnail":null,"timeLineType":0,"title":null,"user":{"androidGold":0,"area":null,"avatarUrl":"http://img01.vgtime.com/headpic/mobile/161105123724618.jpg","awardCount":0,"bandCode":null,"copperAward":0,"couponCount":0,"demonValue":0,"email":null,"followCount":0,"followerCount":0,"followerDate":null,"gender":0,"goldAward":0,"heroValue":0,"inviteCode":null,"inviteCount":0,"iosgold":0,"isHighlight":false,"isPerfect":false,"isSynced":false,"isTourist":false,"level":0,"master":null,"mobile":null,"myCollectNum":0,"myScoreNum":0,"myTimeLineNum":0,"name":"如此甚好","password":null,"relation":1,"silverAward":0,"sinaId":null,"status":0,"tencentId":null,"token":null,"userId":19868,"vgExp":0,"vgNextLevelExp":0,"vgpoint":0,"wechatId":null},"videoList":null,"voteList":null}],"content":"<p><span style='background-color: initial; letter-spacing: 1.3px;'>　　1982年，5月28日，一个中年人走进了加州政府开设的公司登记注册部门，他要注册的公司名为“Amazin' Software”，注册的法人代表以及公司上下员工总共只有一个人。这个人名叫特里普·霍金斯，前苹果公司的营销总监。</span><br></p><p>　　霍金斯没有想到，在35年后的今天，他所创立的公司已经发展成雇员超过8500人的游戏业龙头企业之一；更没有想到的是，他以艺术理念冠名和打造的公司竟然因为过度注重商业化、忽视玩家需求而被冠以“业界毒瘤”和“全美最差公司”的称号。</p><div class='vg_insert_img'><figure contenteditable='false'><img style='width:600px;' src='http://img01.vgtime.com/game/cover/2017/06/05/170605102609958.jpg' class='vg_insert_img_onfocus'><figcaption contenteditable='true' class='vg_insert_img_notice'></figcaption></figure></div><p><span style='background-color: initial; letter-spacing: 1.3px;'>　　此间发生的种种变故可谓波澜起伏，值得我们一一回顾细味。</span><br></p><h4>电子艺术的起源</h4><p>　　和所许多“美国梦”开始时一样，创业之初的霍金斯一边在家里办公，一边寻找各种助手。从程序员到美工、从渠道到顾问，霍金斯一一给他们打电话，向他们传达了自己的经营理念：将游戏设计者包装塑造成艺术家，令游戏更具个人魅力色彩，以增加吸引力。</p><p>　　这是霍金斯在苹果工作时，与一帮充满创意和艺术家气息的程序员以及艺术工作者协作时萌生的想法，并且暗自发愿要将他实现。</p><p>　　在成立公司之前，霍金斯拜访了苹果前投资者、著名风投公司“红杉资本”的拥有者唐·瓦伦丁。后者在美国科技业起飞阶段积极参与科技厂商的组建，早期的苹果和EA，后来的谷歌、Youtube和甲骨文公司，其背后都有红杉资本和瓦伦丁的身影。可以说，红杉资本是推动美国科技发展的重要推手。</p><p>　　瓦伦丁对霍金斯的想法十分感兴趣，并且承诺只要霍金斯创业，他愿意免费借用办公场所。</p><div class='vg_insert_img'><figure contenteditable='false'><img style='width: 500px;' src='http://img01.vgtime.com/game/cover/2017/05/24/170524183944994.jpg' class=''><figcaption contenteditable='true' class=''>瓦伦丁在早期还是苹果的投资人之一</figcaption></figure></div><p><span style='background-color: initial; letter-spacing: 1.3px;'>　　直到当年秋天，霍金斯才动用了这个承诺。他拿到了位于红杉城的一家办公室，开始组建属于自己的公司，而老东家苹果，成为了他最主要的借力对象。</span><br></p><p>　　霍金斯用自己的Apple II电脑写好了公司的整体规划，并且从在苹果工作时合作过的律师那里借来了传统软件工程师的合同，再参考了音乐制作人的合同，然后根据游戏业的生态编写加入了新的条款，形成了之后多年被游戏业引用的制作人合同模板；苹果市场部的前同事里奇·梅尔蒙作为第一个被挖角的员工，成为了EA早期最重要的幕僚，并且吸引了一批苹果员工来投；霍金斯甚至说服了在苹果内部举足轻重的另一位史蒂夫 —— 史蒂夫·沃兹尼亚克，出任新公司的执行董事。</p><div class='vg_insert_img'><figure contenteditable='false'><img style='width: 550px;' src='http://img01.vgtime.com/game/cover/2017/05/24/170524184019453.jpg' class=''><figcaption contenteditable='true' class=''>霍金斯：从苹果到EA</figcaption></figure></div><p>　　尽管有了苹果的“大力支持”，但是霍金斯还是要承受经营公司的巨大风险。公司最初几个月的各种运营费用都由霍金斯一力承担，前前后后投入超过20万美元。这在80年代可是一个不小的数字，但对于一家刚刚起步、还处于试错阶段的新公司而言却是杯水车薪。</p><p>　　“那时我们尽是生产些半途而废的游戏，”霍金斯回忆最初的创业时光，不无感叹地说。</p><p>　　面对如无底洞般的投入，这位前苹果公司高管很快便感到吃不消。所幸瓦伦丁和其他风投商及时为EA注资200万美元，这才让EA度过第一个难关。</p><p>　　有了钱，自然有了更高的追求。许多员工都不喜欢Amazin这个名字，认为这并不能诠释霍金斯的理念。</p><p>　　霍金斯想要更加生动地传达自己的理念，于是想将公司名称改为“SoftArt”，但是市场上已经有一家名叫“Software Arts”的企业。这家企业的老板丹·布雷克林拒绝了霍金斯和梅尔蒙的请求，因为两个名字实在太相像。</p><p>　　霍金斯只好再寻求其他名字，这时他想起了当时在读的一本介绍美国电影工作室“United Artists ”的畅销书，他和同样对UA的崛起深感兴趣的顾问们商讨，一致认为“Artists”很能代表公司的艺术气息。再加上霍金斯十分喜爱的“Electronic”，“Electronic Artists”和“Electronic Arts”两个名字应运而生。霍金斯让公司员工在两者之间投票，最后结果是后者胜出。</p><p>　　霍金斯于是变更了公司的名称和商标，从1983年开始，“Electronic Arts”（简称“EA”或者“艺电”）开始以游戏制作者的姿态活跃于世人面前。</p><h4>发展与改变</h4><p>　　尽管如今EA在业界的名声并不好，但这和霍金斯的关系并不大。相反地，我们还得感谢霍金斯和在他治下的EA为游戏开发生态所带来的一系列改变。</p><p>　　在EA成立之时，北美从事游戏开发的公司已经有135家，EA希望能成为“特殊的那一个”。他们试图将制作人打造成艺术家和明星，让人们认识到游戏开发者并非流水线上的生产工。</p><p>　　EA采取了开发前先垫付部分开发资金的模式，并且将游戏收益的相当一部分回馈到开发者身上，这很大程度上刺激了开发者的积极性。</p><p>　　在大半年的时间内，EA利用不同的制作人或团体开发了6款游戏。开发的过程并不容易，年轻的开发者们总是难免犯错，更避免不了错过死线，这令公司的起步显得颇为艰难。霍金斯不得不采取多种措施来让这些年轻人摒除杂念，最为极端的例子是篮球游戏《1对1》（One on One），当时设计师埃里克·哈蒙德在几个月的开发期内都步履维艰，最后霍金斯将他从居住地办公室调到了自己的座位旁，并且专门弄了隔断，好让小伙子专心工作。</p><p>　　1983年6月，积攒了一年力量的EA在芝加哥的消费电子展上正式亮相。尽管只能占用一个极小的摊位，但是这6款游戏却吸引了不少人的眼球。</p><p>　　这不仅是因为游戏的品质，还在于EA用制作音像专辑的方式对自家游戏进行外包装，并请专业的设计师为其设计富有艺术性的封面，这在当时又是一个创举。令人眼前一亮的包装不仅能够吸引玩家，配合优质的游戏内容更是相得益彰。</p><p>　　为了制作人看上去更像是“艺人”和“偶像”，把他们肖像印在他们游戏的外包装以及许多全版杂志广告上，这是游戏史上第一次将开发者作为游戏宣传的核心。制作人全部换上深色上衣，在照片中摆出不同造型，看上去就像是偶像团体的宣传硬照；底下的广告语“We see farther”，透着浓浓的文艺气息。</p><div class='vg_insert_img'><figure contenteditable='false'><img style='width: 450px;' src='http://img01.vgtime.com/game/cover/2017/05/24/170524184105697.jpg' class='vg_insert_img_onfocus'><figcaption contenteditable='true' class='vg_insert_img_notice'></figcaption></figure></div><p><span style='background-color: initial; letter-spacing: 1.3px;'>　　除了制作人明星化，霍金斯还着力打造多人游戏氛围。在EA最初的6款游戏中，霍金斯最喜欢的游戏是可以支持四人对战的策略游戏《M.U.L.E》。这款游戏和堪称EA早期最重要作品的《Pinball Construction Set》在之后多年斩获了不少奖项，彻底坚定了霍金斯的“艺术”和“社交游戏”理念。</span><br></p><p>　　尽管有了不错的开局，但EA改变业界生态的过程并非一帆风顺。</p><p>　　霍金斯想要直面零售商和玩家，这样能够更直接传达他们的“艺术家”理念。但是零售商却更愿意相信那些有名气的中间商，对还是籍籍无名的EA抱有怀疑态度。EA上下经过多番努力，才让零售商认识到绕过中间商能够获得更丰厚的利润，逐渐打消零售商的疑虑，令EA的业务走上正轨。</p><p>　　另一个阻碍EA快速发展的原因便是雅达利造成的北美家用机市场大崩溃。</p><p>　　EA最早合作的是一款名为Vectrex的主机，但是却被雅达利2600压迫得几无生存空间，随后又在雅达利引发的北美游戏市场大崩溃中被迫离场。正处于起步阶段的EA也因此损失了超过3.5万美元，差点陷入财政危机，不得不推迟进军家用机行业的步伐。</p><div class='vg_insert_img'><figure contenteditable='false'><img style='width: 480px;' src='http://img01.vgtime.com/game/cover/2017/06/05/170605102838477.jpg' class=''><figcaption contenteditable='true' class=''>&nbsp; Vectrex &nbsp;</figcaption></figure></div><p><span style='background-color: initial; letter-spacing: 1.3px;'>　　塞翁失马焉知非福，另寻他法的EA瞄准了日渐兴起的PC市场，这成为了他们之后多年的主要战场。</span><br></p><p>　　在80年代中期，EA和雅达利集团的母公司、个人电脑产业巨头Commdore建立了紧密的合作关系，后者在自家新一代旗舰产品“Amiga”面世之前，优先向EA提供了原型机和完整的开发工具。作为回报，EA不仅为对方制作了一批优质游戏，还开发了一系列以“Deluxe”为前缀的软件，涵盖绘画、动画制作和音乐等领域。只可惜IBM PC的出世令Commdore最终饮恨，但EA还是迅速从失意中振作。毕竟，游戏才是EA主业。</p><p>　　在整个80年代，EA每年都会推出数款游戏，这些游戏大多横跨Amiga、APPLE II、DOS、Commodore 64和Atari ST等市面主流PC平台，成功拓展了EA在PC端的影响力。</p><p>　　1988年，EA更是发行了由牛蛙工作室（ Bullfrog Productions）开发、以其开创性和独特的影响力而被后世称为“神之游戏”的《上帝也疯狂》。良好的口碑和销量，令他们比其他游戏厂商更早一步，打开了更广阔的发展空间。</p><div class='vg_insert_img'><figure contenteditable='false'><img style='width: 400px;' src='http://img01.vgtime.com/game/cover/2017/05/24/170524184215471.jpg' class=''><figcaption contenteditable='true' class=''>上帝也疯狂</figcaption></figure></div><p><span style='background-color: initial; letter-spacing: 1.3px;'>　　当寒冬逐渐过去，EA向家用机领域全面进军的计划被提上了议事日程。</span><br></p><p>　　Tengen逆向破解NES卡带芯片的官司引起了一时热话，无数人都在密切关注这件足以改变游戏业的大事件，其中就包括霍金斯。</p><p>　　Tengen的做法虽然有违商业道德，但却启发了霍金斯，他在思考之后，将目标锁定了游戏市场的另一个巨头 —— 世嘉。</p><p>　　1989年，EA完成了对世嘉MD的逆向破解。和Tengen通过欺骗手段获取资料不同，随着破解技术的进步，EA使用了新的方式，用了近一年的时间，终于将完成了游戏史上颇具意义的一次逆向破解。</p><p>　　当霍金斯带着万全的准备找到世嘉总部时，世嘉总裁中山隼雄不得不面对眼前比任天堂更为严峻的境况。幸好霍金斯抱着合作的诚意而来，他带来的不止是要挟的筹码，还有世嘉当时最为缺乏的第三方游戏。</p><p>　　于是双方坐到了谈判桌的两端，商讨出一个令大家都能够接受的方案。EA因此省下了3500万美元的权利金，并且拥有在MD平台无限发布自己游戏的权利。趁此利好消息，霍金斯一鼓作气推动EA的上市计划并大获成功。</p><p>　　攀上世嘉这样的龙头企业，令上市不到两年的EA，市值呈现几何级跃升，仅用了两三年时间便从6000万美元一跃成为市值超过20亿美元的大鳄。</p><p>　　有了大量的资金，加入游戏界不足十年的EA，开始了新一轮的爆发式发展。</p><h4>“软硬兼施”：3DO与EA SPORTS</h4><p>　　进入90年代后，EA不安于做一个纯粹的开发商或是发行商，他们决意打造自己的品牌。</p><p>　　1991年，EA成立了子品牌“EA Sports”，其口号“It's in the game!”这句广告语也成了不少体育游戏玩家苦练听力多年却还是没能听清的“百年谜题”和美好回忆。</p><p>　　北美作为全球体育产业最发达的地区之一，早在EA之前，就有不少小型开发商已经着手将各种受欢迎的体育项目搬到游戏平台了。</p><p>　　EA通过各种方式将这些品牌都收归旗下，并且统一冠以“EA Sports”的名义。不仅如此，EA还凭借雄厚的财力和FIFA、NBA、NFL、PGA和NHL等知名体育联盟签订了长期合作协议，并且请来相应体育明星进行代言，这些打上“EA Sports”片头Logo的作品无不成为同类游戏的霸主，品牌影响力急速蹿升。而从利益角度，体育游戏因其特殊性而极具商业潜力，每年甚至每个季度都在变更的人员和阵容，不断改变的球衣外观和球员外形，都是吸引大量具有体育情结的玩家一次又一次打开腰包的最佳法门。</p><div class='vg_insert_img'><figure contenteditable='false'><img style='width:600px;' src='http://img01.vgtime.com/game/cover/2017/05/24/170524184304929.jpg' class=''><figcaption contenteditable='true' class=''>每年一度的更新是体育游戏玩家们的盛宴</figcaption></figure></div><p><span style='background-color: initial; letter-spacing: 1.3px;'>　　而在EA Sports众多品牌当中，最著名的莫过于《FIFA》和《NBA Live》系列。不仅在于两大体育项目的影响力，更在于游戏的话题性。</span><br></p><p>　　《FIFA》作为EA Sports旗下最为畅销的系列，在2010年时累计销量已经突破1亿份。在完成了对《实况足球》系列的逆袭之后，2010年后的《FIFA》更是迎来了新的巅峰；与之相反，《NBA Live》作为曾经篮球游戏领域当之无愧的霸主，却在《NBA 2K》系列的挑战下节节败退，最后落到一边冷藏着项目、一边还要白交NBA版权费的尴尬境地。当然，这些都是后话了。</p><p>　　在尽领风骚的体育游戏之外，EA也在不断扩大其品牌阵营，尽管和世嘉有着紧密的合作关系，但这已经不能满足EA的胃口。从90年代开始，他们将大量的电脑游戏移植到任天堂的SNES上，却没有换回任天堂游戏的PC代理权；于是在PS面世之后，EA也将不少游戏搬上了索尼的主机。</p><p>　　在这一系列举动的背后，霍金斯的不安和野心十分明显：依靠主机厂商作为平台，终究有寄人篱下的感觉。“如果日后任天堂和世嘉联系起来，EA就无法享受自由发布权，”霍金斯如是说。</p><p>　　未雨绸缪，霍金斯决定在主机平台开发上下功夫。他力主在EA内部开展了特殊的主机实验计划，计划命名为“3DO”。霍金斯想将3DO打造成像“杜比认证”授权模式那样慢慢占据市场、并且进占其他设备平台并成为事实标准的项目。</p><div class='vg_insert_img'><figure contenteditable='false'><img style='width: 550px;' src='http://img01.vgtime.com/game/cover/2017/05/24/170524184321514.jpg' class=''><figcaption contenteditable='true' class=''>3DO承载了霍金斯对于软硬件的野心</figcaption></figure></div><p><span style='background-color: initial; letter-spacing: 1.3px;'>　　当计划逐渐成型，霍金斯决定将其独立成新的企业，他以独立的身份注资成立了“3DO”，随后又稀释股权，吸引了LG、松下、AT&amp;T、时代华纳加上EA联合组建了新的企业，意欲一展拳脚。</span><br></p><p>　　然而霍金斯和3DO还是错估了家用机硬件市场。诸如杜比环回立体声、FLASH和MEPG等授权格式对于软硬件的要求并不严格，而且占领市场需要一个过程，但家用机游戏市场并不会有这样的时间和空间。</p><p>　　霍金斯后来总结自己经营3DO的两大失误：首先是资金缺口，霍金斯认为同样是第一次进入家用机市场的初哥，索尼投入超过20亿美元来进行研发和推广新主机是其成功的关键，而3DO尽管有多个厂商投资，但是都没有倾尽全力。高达10亿美元的资金缺口使3DO在家用机第五世代，硬件性能完败于索尼、世嘉和任天堂的主机。</p><p>　　另一个败因，在于家用游戏机成功的关键并不在于授权方，而是大量的游戏开发商。</p><p>　　在霍金斯的计划中，EA和3DO是相互独立而又紧密合作的存在。但EA终究不像任天堂第一方游戏开发部那样纯粹为自家主机服务，无论是拥有紧密合作关系的世嘉、积威犹存的任天堂还是初露锋芒的索尼，都是EA不愿放弃的对象。</p><p>　　3DO所创造的市场需求也不足以让EA让其独占，同时又无法吸引足够的第三方厂商。随着开发的深入，在日程上和利益分配上双方的分歧越来越多，最终令3DO和EA渐行渐远，也使前者的失败成为必然。</p><p>　　霍金斯的经营理念受到了强烈的冲击，两面受困的他在1994年离开EA董事长岗位，全身心投入3DO的市场开拓，但还是没能拯救3DO的家用机事业。3DO后来更是转型成游戏发行商，成为了EA的竞争对手。而后霍金斯世代的EA，即将会迎来重大改变。</p><h4>波澜壮阔的收购史和开发史</h4><p><span style='background-color: initial; letter-spacing: 1.3px;'>　　除了自家的体育游戏和曾经引起一定话题的3DO，EA更为人所记得的是他对各种企业和IP的“买买买”。</span><br></p><p>　　上世纪90年代初期，当霍金斯逐步将工作重心从EA转向3DO的时候，拉里·普罗布斯特接任了CEO的职位。这位1984年加盟的EA副总裁，通过一系列的商业手腕，使得EA在第三年就收获了1800万美元的业绩。霍金斯盘算许久绕过中间商直接联系零售商的理念，正是在普罗斯特手上得以实现。</p><p>　　和注重玩家购买热情和打造艺术气息的霍金斯相比，普罗斯特以更纯商业的手段来经营EA，虽然这从某种意义上代表着艺术化向商业化低头，但这种新的经营策略的确让EA来到了新的高度。</p><p>　　普罗布斯特认识到，在新的游戏世代，EA如果单纯地做一个发行商迟早会被淘汰，只有控制那些拥有非凡影响力的IP并不断加以深挖，才能令死忠们不断打开钱包，将利益最大化。要达成这样的愿景，光靠他们自家的生产力显然远远不够，不过这对于财大气粗的EA来说，能够用钱收购的问题就不算问题。</p><p>　　当EA打开支票本，那些曾经和EA合作过的或是在市场表现出色的大中小型厂商纷纷进入了“购物车”：Origin、牛蛙、MAXIS、Bioware、DICE、宝开、WESTWOOD……一个响当当的名字，伴随了玩家们无数的游戏时光，而这不过是EA版图中的其中一部分。EA旗下工作室之多，金牌工作室俯拾皆是；成果之巨，百万级销量的IP比比皆是，几乎每一个都足以单独拿出来洋洋洒洒写上万字。</p><div class='vg_insert_img'><figure contenteditable='false'><img style='width: 650px;' src='http://img01.vgtime.com/game/cover/2017/05/24/170524184406592.jpg' class=''><figcaption contenteditable='true' class=''>那些年，被EA收购的开发商</figcaption></figure></div><p><span style='background-color: initial; letter-spacing: 1.3px;'>　　EA收购这些工作室的目的不尽相同，一种是因为研发实力和地理位置而被看中，被改组成地区的开发中心，承担全球合作开发的任务；而那些知名工作室都拥有良好的IP，进入EA后不仅维持原有IP的强势，部分还能开发出新的经典IP，成就了自己，更成就了EA。</span><br></p><p>　　前文提到的EA Sports，旗下的大多数作品就是来源于一笔收购。1991年，EA斥资1100万美元买下了同样成立于1983年的加拿大厂商Distinctive Software，随后将之改组为EA加拿大分部。EA加拿大在虚拟赛场上的出色表现，堪称体育游戏界的翘楚。</p><p>　　在总部的支持下，EA加拿大又联手小型开发商Pioneer Productions，推出了知名的《极品飞车》系列，让其名声攀上了顶峰。如今的EA加拿大工作室不仅是EA旗下资历最老，同时也是规模最大的工作室，超过1300名员工的规模要比很多厂商的总人数还多。</p><p>　　1992年9月，EA以3500万美元收购Origin，这是EA第一次以占有IP为目的发起的收购。</p><div class='vg_insert_img'><figure contenteditable='false'><img style='width:600px;' src='http://img01.vgtime.com/game/cover/2017/05/24/170524184440421.jpg' class=''><figcaption contenteditable='true' class=''>Origin：We create worlds</figcaption></figure></div><p><span style='background-color: initial; letter-spacing: 1.3px;'>　　后来的GDC终身成就奖得主 —— 理查德·盖瑞特所创造的《创世纪》系列已经经历了十多年的历史并来到了第七作，另外他们在1990年创造的新游戏《银河飞将》也有十分出色的表现。</span><br></p><p>　　在进入EA阵营之后，Origin在一段时间内维持了他们的高水准作品，并且在霍金斯的社交游戏理念启发下打造了《网络创世纪》（Ultima Online），该游戏首次定义提出了“MMORPG”的概念，成为了同类型游戏的鼻祖之一。</p><div class='vg_insert_img'><figure contenteditable='false'><img style='width:600px;' src='http://img01.vgtime.com/game/cover/2017/05/24/170524184552971.jpg' class=''><figcaption contenteditable='true' class=''>《网络创世纪》开创了MMORPG的新纪元</figcaption></figure></div><p><span style='background-color: initial; letter-spacing: 1.3px;'>　　食髓知味的EA，从1995年到2000年，接连收购了几家拥有超人气IP的顶级开发商，包括牛蛙、MAXIS、WestWood、Tiburon和Dreamworks。</span><br></p><p>　　在《上帝也疯狂》中，牛蛙证明了自己在经营类游戏的创意和能力，这一点EA作为他们的发行商最清楚不过。EA先是将牛蛙的创世人彼得·莫利纽克斯挖到旗下担任副总裁，这使之后鲸吞牛蛙变得更加轻松。</p><p>　　“当有人提供一个可投入400万美元进行开发，并且花费1000万美元进行市场推广的开发环境，我想已经无需更多比较，”莫利纽克斯在谈到收购时不无得意地说，“EA表现出了足够的诚意，这与其说是收购倒不如说是合并，我们可以安心地发行自己的作品了。”</p><p><span style='background-color: initial; letter-spacing: 1.3px;'>　　不过和Origin相似，这种蜜月期维持了仅仅数年。莫利纽克斯在EA旗下交出了《主题医院》和《地下城守护者》两款经典名作，但是当1997年《地下城守护者》发行没多久，他突然离开了自己苦心经营的牛蛙并创立了狮头工作室（Lionhead），曾经的溢美之词也就此烟消云散。</span><br></p><p>　　有人辞官归故里，有人连夜赶科场。同样是1997年，又一位后来的GDC终身成就奖得主 —— “模拟之父”威尔·赖特以及他的Maxis工作室被纳入了EA旗下。他们不仅带来了成名已久的《模拟城市》系列，在2000年更是从宏观入微，从模拟城市到模拟“人生”。《模拟人生》以其十足的可玩性和类型丰富的资料片，在之后十多年成为了游戏史上累计销量最高的IP之一。</p><div class='vg_insert_img'><figure contenteditable='false'><img style='width:600px;' src='http://img01.vgtime.com/game/cover/2017/05/24/170524184654312.jpg' class=''><figcaption contenteditable='true' class=''>威尔·赖特为EA打造的《模拟人生》系列，令两者都攀上了巅峰</figcaption></figure></div><p><span style='background-color: initial; letter-spacing: 1.3px;'>　　1998年，EA从维真互动娱乐公司手中以1.225亿美元收购了Westwood Interactive（也就是我们俗称的“西木”），将《命令与征服》收归账下，随后发行的《命令与征服：红色警戒2》以及《命令与征服：尤里的复仇》将西木推向了又一个巅峰；同样是在1998年被EA收购的Tiburon或许在国内玩家中知名度不及其他几家大牌开发商，在加盟EA后，他们顺利拿到了NFL的官方授权，由其打造的《麦登橄榄球》系列不但在橄榄球游戏中一枝独秀，在全美的销量大战中也堪称种子选手。</span><br></p><div class='vg_insert_img'><figure contenteditable='false'><img style='width: 450px;' src='http://img01.vgtime.com/game/cover/2017/05/24/170524184743938.jpg' class='vg_insert_img_onfocus'><figcaption contenteditable='true' class='vg_insert_img_notice'></figcaption></figure></div><p><span style='background-color: initial; letter-spacing: 1.3px;'>　　2000年，EA从微软和梦工厂手中买下他们联合创办的Dreamworks Interactive，连带将《荣誉勋章》也收归囊中，至此EA在“枪车球”三大游戏类型的收购中达到了圆满。</span><br></p><p>　　不过，在我们讲述EA在21世纪的起起伏伏之前，我们先将时间拨回一点。</p><p>　　1999年，EA收购了Kesmai。之所以要提到这所名不见经传的MMORPG厂商，是因为Kesmai是EA收购的公司中存活时间最短的之一。</p><p>　　从1999年被收购到2001年被废弃，Kesami在EA旗下只存活了两年时间，成为了EA大变动的见证者和受害者。</p>","contentPage":2,"cover":null,"detailType":1,"disadvantageList":null,"editor":"政宗","game":null,"games":[],"images":null,"isFavorited":false,"isLiked":false,"isQuestion":false,"isShort":false,"isSolve":false,"isVideo":false,"likeNum":85,"news":[],"originalPost":null,"parentSource":null,"postId":598218,"programList":[],"publishDate":1496629217,"relatedGame":null,"remark":null,"reviewScore":0.0,"shareNum":6,"shareUrl":"http://new.vgtime.com/topic/598218.jhtml","text":null,"thumbnail":{"height":0,"url":"http://img01.vgtime.com/game/cover/2017/06/05/170605102001601.jpg","width":0},"timeLineType":1003,"title":"写稿佬讲古：从艺术家到商人 EA三十五周年回顾","user":{"androidGold":0,"area":null,"avatarUrl":"http://img01.vgtime.com/article/web/161104113159350.jpg","awardCount":0,"bandCode":null,"copperAward":0,"couponCount":0,"demonValue":0,"email":null,"followCount":0,"followerCount":0,"followerDate":null,"gender":0,"goldAward":0,"heroValue":0,"inviteCode":null,"inviteCount":0,"iosgold":0,"isHighlight":false,"isPerfect":false,"isSynced":false,"isTourist":false,"level":0,"master":null,"mobile":null,"myCollectNum":0,"myScoreNum":0,"myTimeLineNum":0,"name":"80后写稿佬","password":null,"relation":1,"silverAward":0,"sinaId":null,"status":0,"tencentId":null,"token":null,"userId":60127,"vgExp":0,"vgNextLevelExp":0,"vgpoint":0,"wechatId":null},"videoList":[],"voteList":[]}
`;
    setArticleDetail(d, "1");
}

function setArticleDetail2(json: string): void {
    const articleDetail = JSON.parse(json) as ArticleDetail;
    const user = articleDetail.user;
    $(".vgapp_user_box > img").attr("src", user.avatarUrl);
    $(".vgapp_ub_info > .name").text(user.name);
    const publishDate = new Date(articleDetail.publishDate * 1000);
    $(".vgapp_ub_info > .time").text(`${publishDate.getFullYear()}-${publishDate.getMonth() + 1}-${publishDate.getDate()} ${publishDate.getHours()}:${publishDate.getMinutes()}`);
    $(".vgapp_article_long > h1").text(articleDetail.title);
    $(".vgapp_article_long > .vgapp_article_editer > span").text(`作者：${articleDetail.author} 编辑：${articleDetail.editor}`);
    const anchor = articleDetail.anchor;
    const vgAnchor = $(".vg_anchor");
    if (anchor && anchor.length > 0) {
        for (let temp of anchor) {
            let li = $(document.createElement("li"));
            li.text(temp.title);
            li.click(() => {
                // TODO
            });
            vgAnchor.append(li);
        }
    }
    $(".vgapp_article_long > article").html(articleDetail.content);
    const games = articleDetail.games;
    const vgappGame = $(".vgapp_game");
    if (games && games.length > 0) {
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
    } else {
        vgappGame.remove();
    }
    const news = articleDetail.news;
    const vgappAlist = $(".vgapp_alist");
    if (news && news.length > 0) {
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
    } else {
        vgappAlist.remove();
    }
    const comments = articleDetail.comments;
    if (comments && comments.length > 0) {
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
                        <span class="replay">${comment.commentNum === 0 ? "评论" : comment.commentNum}</span>
                        <span class="praise">${comment.likeNum === 0 ? "点赞" : comment.likeNum}</span>
                    </div>
                </div>
                <div class="vgapp_ci_content">
                    ${comment.remark}
                </div>
            </div>`;
            vgappCommentMore.before(vgappCommentItem);
        }
    } else {
        $(".vgapp_comment > h2").remove();
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