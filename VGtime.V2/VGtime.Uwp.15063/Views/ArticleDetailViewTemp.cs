using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using VGtime.Models.Article;

//namespace VGtime.Uwp.Views
//{
//    public partial class ArticleDetailView
//    {
//        private Windows.UI.Xaml.Controls.Image iv_title_like;
//        private Windows.UI.Xaml.Controls.Image iv_title_collect;
//        private dynamic x;
//        private int l = 1;
//        ArticleDetail i;
//        private dynamic z;
//        private dynamic w;
//        private dynamic y;
//        private List<ArticleDetailIndex> r;
//        private StackPanel ll_page_index_new;


//        private void a(ArticleDetail paramArticleDetailBean, bool paramBoolean)
//        {
//            label42:
//            StringBuilder localStringBuffer;
//            label318:
//            label434:
//            label566:
//            String str;
//            if (paramArticleDetailBean.IsLiked)
//            {
//                this.iv_title_like.Source = (this.x.resourceId);
//                if (!paramArticleDetailBean.IsFavorited)
//                {
//                    goto label735;
//                }
//                this.iv_title_collect.Source = (this.z.resourceId);
//                this.l = paramArticleDetailBean.ContentPage;
//                if (this.l > 1)
//                {
//                    goto label752;
//                }
//                this.ll_page_index_new.Visibility =Visibility.Collapsed;
//                this.q.a(this.r);
//                this.q.notifyDataSetChanged();
//                localStringBuffer = new StringBuilder();
                
//                localObject1 = ArticleTemplates.User_Box;
//                localObject2 = ArticleTemplates.User_Box_UP_BOX;
//                if ((paramArticleDetailBean.User == null) || (g() == null) ||
//                    (paramArticleDetailBean.User.UserId != g().UserId))
//                {
//                    goto label934;
//                }
//                localObject2 =
//                    ((String) localObject1).Replace("vgapp_user_id",
//                        Convert.ToString(paramArticleDetailBean.User.UserId))
//                    .Replace("vgapp_user_avatar", paramArticleDetailBean.User.AvatarUrl);
//                if (paramArticleDetailBean.User.Name != null)
//                {
//                    goto label922;
//                }
//                localObject1 = "未知";
//                localObject1 =
//                    ((String) localObject2).Replace("vgapp_user_name", (CharSequence) localObject1)
//                    .Replace("vgapp_publish_date", StringUtils.longToDate(paramArticleDetailBean.PublishDate))
//                    .Replace("vgapp_up_box", "");
//                localStringBuffer.Append((String) localObject1); 
//                localObject1 = ArticleTemplates.Article_SOURCE;
//                if (paramArticleDetailBean.ParentSource != null)
//                {
//                    localObject2 =
//                        ((String) localObject1).Replace("vgapp_source_id",
//                            Convert.ToString(paramArticleDetailBean.ParentSource.PostId))
//                        .Replace("vgapp_source_type",
//                            Convert.ToString(paramArticleDetailBean.ParentSource.DetailType));
//                    if (paramArticleDetailBean.ParentSource.Title != null)
//                    {
//                        goto label1107;
//                    }
//                    localObject1 = "";
//                    localStringBuffer.Append(
//                        ((String) localObject2).Replace("vgapp_source_title", (CharSequence) localObject1)
//                        .Replace("vgapp_source_comment_count",
//                            Convert.ToString(paramArticleDetailBean.ParentSource.CommentNum)));
//                }
//                str = ArticleTemplates.Article;
//                if (!paramArticleDetailBean.IsShort)
//                {
//                    goto label1563;
//                }
//                localObject2 = ArticleTemplates.Article_Short;
//                if (paramArticleDetailBean.Text != null)
//                {
//                    goto label1119;
//                }
//            }
//            int i1;
//            label735:
//            label752:
//            label771:
//            label815:
//            label837:
//            label922:
//            label934:
//            label974:
//            label1107:
//            label1119:
//            for (Object localObject1 = "";;
//                localObject1 = paramArticleDetailBean.Text.Replace("[\\n\\r]", "<br>"))
//            {
//                localObject1 = ((String) localObject2).Replace("vgapp_short_content", (CharSequence) localObject1);
//                if (paramArticleDetailBean.Images == null)
//                {
//                    goto label1506;
//                }
//                localObject1 = ((String) localObject1).Replace("vgapp_pic_count",
//                    Convert.ToString(paramArticleDetailBean.Images.Length));
//                localObject2 = new StringBuilder();
//                i1 = 0;
//                while (i1 < paramArticleDetailBean.Images.Length)
//                {
//                    ((StringBuilder) localObject2).Append("<li><img src=\"")
//                        .Append(paramArticleDetailBean.Images[i1].Url)
//                        .Append("\"></li>\n");
//                    i1 += 1;
//                }
//                this.iv_title_like.Source = (this.w.resourceId);
//                break;
//                this.iv_title_collect.Source = (this.y.resourceId);
//                goto label42;
//                this.ll_page_index_new.Visibility = Visibility.Visible;
//                this.r.clear();
//                i1 = 1;
//                if (i1 < paramArticleDetailBean.ContentPage + 1)
//                {
//                    if (i1 != this.k)
//                    {
//                        goto label815;
//                    }
//                    this.r.Add(new ArticleDetailIndex{Index = i1,IsPressed=true});
//                }
//                for (;;)
//                {
//                    i1 += 1;
//                    goto label771;
//                    break;
//                    this.r.Add(new ArticleDetailIndex { Index = i1, IsPressed = false });
//                }
//                localObject1 =
//                    ((String) localObject1).Replace("vgapp_ad_href", this.i.Ad.Url)
//                    .Replace("vgapp_ad_postid", Convert.ToString((this.i.Ad.Id)))
//                    .Replace("vgapp_ad_channelid", Convert.ToString(this.i.Ad.ChannelId))
//                    .Replace("vgapp_ad_pic", this.i.Ad.AppPic);
//                localStringBuffer.Append((String) localObject1);
//                goto label318;
//                localObject1 = paramArticleDetailBean.User.Name;
//                goto label434;
//                switch (paramArticleDetailBean.User.Relation)
//                {
//                    default:
//                        i1 = 1;
//                        localObject2 = ((String) localObject2).Replace("vgapp_relation_type", Convert.ToString(i1));
//                        localObject3 =
//                            ((String) localObject1).Replace("vgapp_user_id",
//                                Convert.ToString(paramArticleDetailBean.User.UserId))
//                            .Replace("vgapp_user_avatar", paramArticleDetailBean.User.AvatarUrl);
//                        if (paramArticleDetailBean.User.Name != null)
//                        {
//                            break;
//                        }
//                }
//                for (localObject1 = "未知";; localObject1 = paramArticleDetailBean.User.Name)
//                {
//                    localObject1 =
//                        ((String) localObject3).Replace("vgapp_user_name", (CharSequence) localObject1)
//                        .Replace("vgapp_publish_date", StringUtils.longToDate(paramArticleDetailBean.PublishDate))
//                        .Replace("vgapp_up_box", (CharSequence) localObject2);
//                    localStringBuffer.Append((String) localObject1);
//                    break;
//                    i1 = 1;
//                    goto label974;
//                    i1 = 2;
//                    goto label974;
//                    i1 = 3;
//                    goto label974;
//                }
//                localObject1 = paramArticleDetailBean.ParentSource.Title;
//                goto label566;
//            }
//            localObject1 = ((String) localObject1).Replace("vgapp_pic_list", (CharSequence) localObject2);
//            Object localObject2 = ArticleTemplates.Article_Ques;
//            label1198:
//            label1210:
//            label1274:
//            Object localObject4;
//            if (paramArticleDetailBean.IsQuestion)
//            {
//                localObject2 = ((String) localObject2).Replace("vgapp_question_count",
//                    Convert.ToString(paramArticleDetailBean.CommentNum));
//                if (paramArticleDetailBean.IsSolve)
//                {
//                    localObject2 = ((String) localObject2).Replace("vgapp_article_resolvetype", "resolve");
//                    localObject1 = ((String) localObject1).Replace("vgapp_short_ques", (CharSequence) localObject2);
                    
//                    localObject1 =
//                        str.Replace("vgapp_article_short", (CharSequence) localObject1)
//                            .Replace("vgapp_article_long", "");
//                    this.f = b((String) localObject1);
//                    localObject2 = a((String) localObject1);
//                    localObject3 = ArticleTemplates.Article_Related_Game;
//                    if ((paramArticleDetailBean.Games == null) || (paramArticleDetailBean.Games.Length == 0))
//                    {
//                        goto label3443;
//                    }
//                    localObject4 = new StringBuilder();
//                    i1 = 0;
//                    label1305:
//                    if (i1 >= paramArticleDetailBean.Games.Length)
//                    {
//                        goto label3113;
//                    }
//                    str = ArticleTemplates.Article_Related_Game_Item.Replace("vgapp_related_game_id",
//                        Convert.ToString(paramArticleDetailBean.Games[i1].Id));
//                    if (paramArticleDetailBean.Games[i1].Name != null)
//                    {
//                        goto label2947;
//                    }
//                    localObject1 = "";
//                    label1354:
//                    str = str.Replace("vgapp_related_game_name", (CharSequence) localObject1);
//                    if (paramArticleDetailBean.Games[i1].Platform != null)
//                    {
//                        goto label2961;
//                    }
//                    localObject1 = "";
//                    label1383:
//                    str = str.Replace("vgapp_related_game_platform", (CharSequence) localObject1);
//                    if (paramArticleDetailBean.Games[i1].Cover != null)
//                    {
//                        goto label2975;
//                    }
//                    localObject1 = "";
//                    label1412:
//                    str = str.Replace("vgapp_related_game_thumbnail", (CharSequence) localObject1);
//                    if (paramArticleDetailBean.Games[i1].Score > 0.0F)
//                    {
//                        goto label2989;
//                    }
//                    localObject1 = "";
//                    label1443:
//                    localObject1 = str.Replace("vgapp_related_game_score", (CharSequence) localObject1);
//                    if (paramArticleDetailBean.Games[i1].Score > 0.0F)
//                    {
//                        goto label3006;
//                    }
//                    localObject1 =
//                        ((String) localObject1).Replace("vgapp_related_game_bgcolor", "#FFFFFF")
//                        .Replace("vgapp_related_game_opacity", "0");
//                }
//            }
//            label1506:
//            label1563:
//            Object localObject5;
//            for (;;)
//            {
//                ((StringBuilder) localObject4).Append((String) localObject1);
//                i1 += 1;
//                goto label1305;
//                localObject1 = ((String) localObject1).Replace("vgapp_pic_count", "0").Replace("vgapp_pic_list", "");
//                break;
//                localObject2 = ((String) localObject2).Replace("vgapp_article_resolvetype", "unresolve");
//                goto label1198;
//                localObject1 = ((String) localObject1).Replace("vgapp_short_ques", "");
//                goto label1210;
//                localObject5 = ArticleTemplates.Article_Long;
//                localObject2 = ArticleTemplates.Article_Ques;
//                localObject1 = localObject2;
//                if (paramArticleDetailBean.IsQuestion)
//                {
//                    localObject1 = ((String) localObject2).Replace("vgapp_question_count",
//                        Convert.ToString(paramArticleDetailBean.CommentNum));
//                    if (!paramArticleDetailBean.IsSolve)
//                    {
//                        goto label1765;
//                    }
//                }
//                label1765:
//                for (localObject1 = ((String) localObject1).Replace("vgapp_article_resolvetype", "resolve");;
//                    localObject1 = ((String) localObject1).Replace("vgapp_article_resolvetype", "unresolve"))
//                {
//                    localObject3 = ArticleTemplates.Article_Anchor;
//                    localObject2 = localObject3;
//                    if (paramArticleDetailBean.Anchor == null)
//                    {
//                        goto label1793;
//                    }
//                    localObject2 = localObject3;
//                    if (paramArticleDetailBean.Anchor.Length == 0)
//                    {
//                        goto label1793;
//                    }
//                    localObject2 = new StringBuilder();
//                    i1 = 0;
//                    while (i1 < paramArticleDetailBean.Anchor.Length)
//                    {
//                        ((StringBuilder) localObject2).Append("<li data-page=\"" +
//                                                             paramArticleDetailBean.Anchor[i1].Page +
//                                                             "\" data-currentPage=\"" + this.k + "\" data-num=\"" +
//                                                             paramArticleDetailBean.Anchor[i1].Num + "\">" +
//                                                             paramArticleDetailBean.Anchor[i1].Title +
//                                                             "</li>\n");
//                        i1 += 1;
//                    }
//                }
//                localObject2 = ((String) localObject3).Replace("vgapp_anchor_list", (CharSequence) localObject2);
//                label1793:
//                localObject4 = ArticleTemplates.Article_Long_Author_Editor;
//                if ((this.h == 3) || (this.h == 6))
//                {
//                    localObject3 = "";
//                    if (paramArticleDetailBean.Title != null)
//                    {
//                        goto label2209;
//                    }
//                    localObject4 = "";
//                    label1832:
//                    localObject3 =
//                        ((String) localObject5).Replace("vgapp_long_title", (CharSequence) localObject4)
//                        .Replace("vgapp_long_author_editor", (CharSequence) localObject3);
//                    if (!paramArticleDetailBean.IsQuestion)
//                    {
//                        goto label2218;
//                    }
//                    label1859:
//                    localObject1 = ((String) localObject3).Replace("vgapp_long_ques", (CharSequence) localObject1);
//                    if ((paramArticleDetailBean.Anchor == null) || (paramArticleDetailBean.Anchor.Length == 0))
//                    {
//                        goto label2226;
//                    }
//                    label1886:
//                    localObject2 = ((String) localObject1).Replace("vgapp_long_anchor", (CharSequence) localObject2);
//                    if (paramArticleDetailBean.Content != null)
//                    {
//                        goto label2234;
//                    }
//                    localObject1 = "";
//                    label1910:
//                    localObject1 = ((String) localObject2).Replace("vgapp_long_content", (CharSequence) localObject1);
//                    this.f = b((String) localObject1);
//                    localObject1 = a((String) localObject1);
//                    localObject2 = localObject1;
//                    if (paramArticleDetailBean.AblumList == null)
//                    {
//                        goto label2257;
//                    }
//                    localObject2 = localObject1;
//                    if (paramArticleDetailBean.AblumList.Length == 0)
//                    {
//                        goto label2257;
//                    }
//                    i1 = 0;
//                    label1963:
//                    localObject2 = localObject1;
//                    if (i1 >= paramArticleDetailBean.AblumList.Length)
//                    {
//                        goto label2257;
//                    }
//                    localObject3 = ArticleTemplates.Article_Album.Replace("vgapp_album_id",
//                        Convert.ToString(paramArticleDetailBean.AblumList[i1].PostId));
//                    if (paramArticleDetailBean.AblumList[i1].Cover != null)
//                    {
//                        goto label2243;
//                    }
//                }
//                label2111:
//                label2181:
//                label2209:
//                label2218:
//                label2226:
//                label2234:
//                label2243:
//                for (localObject2 = "";; localObject2 = paramArticleDetailBean.AblumList[i1].Cover)
//                {
//                    localObject2 =
//                        ((String) localObject3).Replace("vgapp_album_thumbnail", (CharSequence) localObject2)
//                        .Replace("vgapp_album_count",
//                            Convert.ToString(paramArticleDetailBean.AblumList[i1].ImgCount));
//                    localObject1 =
//                        ((String) localObject1).Replace(
//                            "ablumid:" + paramArticleDetailBean.AblumList[i1].PostId + ";",
//                            (CharSequence) localObject2);
//                    i1 += 1;
//                    goto label1963;
//                    if (TextUtils.isEmpty(paramArticleDetailBean.Author))
//                    {
//                        localObject3 = "";
//                        localObject4 = ((String) localObject4).Replace("vgapp_long_author", (CharSequence) localObject3);
//                        if (!TextUtils.isEmpty(paramArticleDetailBean.Editor))
//                        {
//                            goto label2181;
//                        }
//                    }
//                    for (localObject3 = "";; localObject3 = "编辑：" + paramArticleDetailBean.Editor)
//                    {
//                        localObject3 = ((String) localObject4).Replace("vgapp_long_editor", (CharSequence) localObject3);
//                        break;
//                        localObject3 = "作者：" + paramArticleDetailBean.Author;
//                        goto label2111;
//                    }
//                    localObject4 = paramArticleDetailBean.Title;
//                    goto label1832;
//                    localObject1 = "";
//                    goto label1859;
//                    localObject2 = "";
//                    goto label1886;
//                    localObject1 = paramArticleDetailBean.Content;
//                    goto label1910;
//                }
//                label2257:
//                localObject1 = ArticleTemplates.Article_Eval;
//                if (paramArticleDetailBean.ReviewScore > 0.0F)
//                {
//                    localObject1 = ((String) localObject1).Replace("vgapp_eval_score",
//                        Convert.ToString(paramArticleDetailBean.ReviewScore));
//                    if (!TextUtils.isEmpty(paramArticleDetailBean.AdvantageList))
//                    {
//                        localObject3 = JSON.parseArray(paramArticleDetailBean.AdvantageList,
//                            ArticleDetailAdvantageBean.class)
//                        ;
//                        localObject4 = new StringBuilder();
//                        i1 = 0;
//                        while (i1 < ((List) localObject3).size())
//                        {
//                            ((StringBuilder) localObject4).Append("<li>")
//                                .Append(((ArticleDetailAdvantage) ((List) localObject3).get(i1)).Merit)
//                                .Append("</li>");
//                            i1 += 1;
//                        }
//                        localObject1 = ((String) localObject1).Replace("vgapp_eval_advantage_list",
//                            ((StringBuilder) localObject4).toString());
//                    }
//                    while (!TextUtils.isEmpty(paramArticleDetailBean.DisadvantageList))
//                    {
//                        localObject3 = JSON.parseArray(paramArticleDetailBean.DisadvantageList,
//                            ArticleDetailDisadvantageBean.class)
//                        ;
//                        localObject4 = new StringBuilder();
//                        i1 = 0;
//                        for (;;)
//                        {
//                            if (i1 < ((List) localObject3).size())
//                            {
//                                ((StringBuilder) localObject4).Append("<li>")
//                                    .Append(((ArticleDetailDisadvantage) ((List) localObject3).get(i1)).Defect)
//                                    .Append("</li>");
//                                i1 += 1;
//                                continue;
//                                localObject1 = ((String) localObject1).Replace("vgapp_eval_advantage_list", "");
//                                break;
//                            }
//                        }
//                        localObject1 = ((String) localObject1).Replace("vgapp_eval_disadvantage_list",
//                            ((StringBuilder) localObject4).toString());
//                        localObject2 = ((String) localObject2).Replace("vgapp_eval", (CharSequence) localObject1);
//                        Logs.loge("vgapp_eval", (String) localObject1);
//                        label2520:
//                        localObject1 = localObject2;
//                        if (paramArticleDetailBean.VoteList == null)
//                        {
//                             goto label2724;
//                        }
//                        localObject1 = localObject2;
//                        if (paramArticleDetailBean.VoteList.Length == 0)
//                        {
//                             goto label2724;
//                        }
//                        i1 = 0;
//                        label2545:
//                        localObject1 = localObject2;
//                        if (i1 >= paramArticleDetailBean.VoteList.Length)
//                        {
//                             goto label2724;
//                        }
//                        localObject3 = ArticleTemplates.Article_Vote.Replace("vgapp_vote_id",
//                            Convert.ToString(paramArticleDetailBean.VoteList[i1].PostId));
//                        if (paramArticleDetailBean.VoteList[i1].Name != null)
//                        {
//                             goto label2710;
//                        }
//                    }
//                }
//                label2710:
//                for (localObject1 = "";; localObject1 = paramArticleDetailBean.VoteList[i1].Name)
//                {
//                    localObject1 =
//                        ((String) localObject3).Replace("vgapp_vote_title", (CharSequence) localObject1)
//                        .Replace("vgapp_vote_person_count",
//                            Convert.ToString(paramArticleDetailBean.VoteList[i1].UserCount));
//                    localObject2 =
//                        ((String) localObject2).Replace(
//                            "voteid:" + paramArticleDetailBean.VoteList[i1].PostId + ";",
//                            (CharSequence) localObject1);
//                    i1 += 1;
//                    goto label2545;
//                    localObject1 = ((String) localObject1).Replace("vgapp_eval_disadvantage_list", "");
//                    break;
//                    localObject2 = ((String) localObject2).Replace("vgapp_eval", "");
//                    goto label2520;
//                }
//                label2724:
//                localObject2 = localObject1;
//                if (paramArticleDetailBean.ProgramList != null)
//                {
//                    localObject2 = localObject1;
//                    if (paramArticleDetailBean.ProgramList.Length != 0)
//                    {
//                        i1 = 0;
//                        localObject2 = localObject1;
//                        if (i1 < paramArticleDetailBean.ProgramList.Length)
//                        {
//                            localObject3 = ArticleTemplates.Article_Program.Replace("vgapp_vlist_id",
//                                Convert.ToString(paramArticleDetailBean.ProgramList[i1].PostId));
//                            if (paramArticleDetailBean.ProgramList[i1].Name == null)
//                            {
//                            }
//                            for (localObject2 = "";;
//                                localObject2 = paramArticleDetailBean.ProgramList[i1].Name)
//                            {
//                                localObject2 =
//                                    ((String) localObject3).Replace("vgapp_vlist_title", (CharSequence) localObject2)
//                                    .Replace("vgapp_vlist_count",
//                                        Convert.ToString(paramArticleDetailBean.ProgramList[i1].VideoCount));
//                                localObject1 =
//                                    ((String) localObject1).Replace(
//                                        "vlistid:" + paramArticleDetailBean.ProgramList[i1].PostId + ";",
//                                        (CharSequence) localObject2);
//                                i1 += 1;
//                                break;
//                            }
//                        }
//                    }
//                }
               
//                localObject2 = str.Replace("vgapp_article_short", "")
//                    .Replace("vgapp_article_long", (CharSequence) localObject2);
//                goto label1274;
//                label2947:
//                localObject1 = paramArticleDetailBean.Games[i1].Name;
//                goto label1354;
//                label2961:
//                localObject1 = paramArticleDetailBean.Games[i1].Platform;
//                goto label1383;
//                label2975:
//                localObject1 = paramArticleDetailBean.Games[i1].Cover;
//                goto label1412;
//                label2989:
//                localObject1 = Convert.ToString(paramArticleDetailBean.Games[i1].Score);
//                goto label1443;
//                label3006:
//                if (paramArticleDetailBean.Games[i1].Score <= 6.0F)
//                {
//                    localObject1 =
//                        ((String) localObject1).Replace("vgapp_related_game_bgcolor", "#ec4c54")
//                        .Replace("vgapp_related_game_opacity", "0.8");
//                }
//                else if (paramArticleDetailBean.Games[i1].Score <= 7.0F)
//                {
//                    localObject1 =
//                        ((String) localObject1).Replace("vgapp_related_game_bgcolor", "#96b229")
//                        .Replace("vgapp_related_game_opacity", "0.8");
//                }
//                else
//                {
//                    localObject1 =
//                        ((String) localObject1).Replace("vgapp_related_game_bgcolor", "#42c47a")
//                        .Replace("vgapp_related_game_opacity", "0.8");
//                }
//            }
//            label3113:
//            Object localObject3 = ((String) localObject3).Replace("vgapp_game_list", (CharSequence) localObject4);
//            localObject1 = ((String) localObject2).Replace("vgapp_game", (CharSequence) localObject3);
          
//            localObject3 = ArticleTemplates.Article_Related_News;
//            if ((paramArticleDetailBean.News != null) && (paramArticleDetailBean.News.Length != 0))
//            {
//                localObject4 = new StringBuilder();
//                i1 = 0;
//                label3195:
//                if (i1 < paramArticleDetailBean.News.Length)
//                {
//                    str = ArticleTemplates.Article_Related_News_Item;
//                    if (paramArticleDetailBean.News[i1].User.AvatarUrl == null)
//                    {
//                        localObject2 = "";
//                        label3229:
//                        str = str.Replace("vgapp_user_avatar", (CharSequence) localObject2);
//                        if (paramArticleDetailBean.News[i1].User.Name != null)
//                        {
//                            goto label3476;
//                        }
//                        localObject2 = "";
//                        label3261:
//                        str = str.Replace("vgapp_user_name", (CharSequence) localObject2)
//                            .Replace("vgapp_publish_date",
//                                StringUtils.longToDate(paramArticleDetailBean.News[i1].PublishDate));
//                        if (paramArticleDetailBean.News[i1].Category != null)
//                        {
//                            goto label3493;
//                        }
//                        localObject2 = "";
//                        label3308:
//                        str = str.Replace("vgapp_article_category", (CharSequence) localObject2);
//                        if (paramArticleDetailBean.News[i1].Title != null)
//                        {
//                            goto label3507;
//                        }
//                        localObject2 = "";
//                        label3337:
//                        str = str.Replace("vgapp_article_title", (CharSequence) localObject2);
//                        if (paramArticleDetailBean.News[i1].Cover != null)
//                        {
//                             goto label3521;
//                        }
//                    }
//                    label3443:
//                    label3476:
//                    label3493:
//                    label3507:
//                    label3521:
//                    for (localObject2 = "";; localObject2 = paramArticleDetailBean.News[i1].Cover)
//                    {
//                        ((StringBuilder) localObject4).Append(
//                            str.Replace("vgapp_article_thumbnail", (CharSequence) localObject2)
//                                .Replace("vgapp_article_comment_num",
//                                    Convert.ToString(paramArticleDetailBean.News[i1].CommentNum))
//                                .Replace("vgapp_news_item_postid",
//                                    Convert.ToString(paramArticleDetailBean.News[i1].PostId))
//                                .Replace("vgapp_news_item_detailtype",
//                                    Convert.ToString(paramArticleDetailBean.News[i1].DetailType)));
//                        i1 += 1;
//                        goto label3195;
//                        localObject1 = ((String) localObject2).Replace("vgapp_game", "");
//                        break;
//                        localObject2 = paramArticleDetailBean.News[i1].User.AvatarUrl;
//                        goto label3229;
//                        localObject2 = paramArticleDetailBean.News[i1].User.Name;
//                        goto label3261;
//                        localObject2 = paramArticleDetailBean.News[i1].Category;
//                        goto label3308;
//                        localObject2 = paramArticleDetailBean.News[i1].Title;
//                        goto label3337;
//                    }
//                }
//                localObject2 = ((String) localObject3).Replace("vgapp_news_list", (CharSequence) localObject4);
//                localObject1 = ((String) localObject1).Replace("vgapp_alist", (CharSequence) localObject2);
//                Logs.loge("article_related_news", "" + (String) localObject2);
//                localObject2 = localObject1;
//                if (!NetUtil.isWifiOpen())
//                {
//                    localObject2 = c((String) localObject1);
//                    Logs.loge("article", "" + (String) localObject2);
//                }
//                localStringBuffer.Append((String) localObject2);
//                localObject1 = ArticleTemplates.Article_HOT_COMMENTS;
//                str = ArticleTemplates.Article_HOT_COMMENTS_LIST;
//                localObject4 =
//                    ((String) localObject1).Replace("vgapp_hot_comment_postid",
//                        Convert.ToString(paramArticleDetailBean.PostId))
//                    .Replace("vgapp_hot_comment_detailtype", Convert.ToString(paramArticleDetailBean.DetailType));
//                if ((paramArticleDetailBean.Comments == null) || (paramArticleDetailBean.Comments.Length == 0))
//                {
//                    goto label4533;
//                }
//                localObject5 = new StringBuilder();
//                i1 = 0;
//                label3705:
//                if (i1 >= paramArticleDetailBean.Comments.length)
//                {
//                     goto label4157;
//                }
//                if (!paramArticleDetailBean.Comments[i1].IsLiked)
//                {
//                     goto label4050;
//                }
//                localObject1 = ArticleTemplates.Article_HOT_COMMENTS_ITEM_LIKED;
//                label3731:
                
//                if (paramArticleDetailBean.Comments[i1].User.AvatarUrl != null)
//                {
//                    goto label4058;
//                }
//                localObject3 = "";
//                label3785:
//                localObject3 = ((String) localObject1).Replace("vgapp_user_avatar", (CharSequence) localObject3);
//                if (paramArticleDetailBean.Comments[i1].User.Name != null)
//                {
//                    goto label4075;
//                }
//                localObject1 = "";
//                label3817:
//                localObject3 =
//                    ((String) localObject3).Replace("vgapp_user_name", (CharSequence) localObject1)
//                    .replace("vgapp_publish_date",
//                        StringUtils.longToDate(paramArticleDetailBean.Comments[i1].PublishDate));
//                if (paramArticleDetailBean.Comments[i1].CommentNum != 0)
//                {
//                    goto label4092;
//                }
//                localObject1 = "评论";
//                label3864:
//                localObject3 = ((String) localObject3).Replace("vgapp_hot_comment_reply_num",
//                    (CharSequence) localObject1);
//                if (paramArticleDetailBean.Comments[i1].LikeNum != 0)
//                {
//                    goto label4109;
//                }
//                localObject1 = "点赞";
//                label3893:
//                localObject3 = ((String) localObject3).Replace("vgapp_hot_comment_praise", (CharSequence) localObject1);
//                if (paramArticleDetailBean.Comments[i1].Remark != null)
//                {
//                    goto label4126;
//                }
//                localObject1 = "";
//                label3922:
//                localObject3 =
//                    ((String) localObject3).Replace("vgapp_hot_comment_content", (CharSequence) localObject1)
//                    .Replace("vgapp_hot_comment_item_postid",
//                        Convert.ToString(paramArticleDetailBean.Comments[i1].PostId))
//                    .Replace("vgapp_hot_comment_item_detailtype",
//                        Convert.ToString(paramArticleDetailBean.Comments[i1].DetailType));
//                if (paramArticleDetailBean.Comments[i1].User.Name != null)
//                {
//                    goto label4140;
//                }
//            }
//            label4050:
//            label4058:
//            label4075:
//            label4092:
//            label4109:
//            label4126:
//            label4140:
//            for (localObject1 = "";; localObject1 = paramArticleDetailBean.Comments[i1].User.Name)
//            {
//                ((StringBuilder) localObject5).Append(
//                    ((String) localObject3).replace("vgapp_username", (CharSequence) localObject1)
//                    .replace("vgapp_userid",
//                        Convert.ToString(paramArticleDetailBean.Comments[i1].User.UserId)));
//                i1 += 1;
//                goto label3705;
//                localObject1 = ((String) localObject1).Replace("vgapp_alist", "");
//                break;
//                localObject1 = ArticleTemplates.Article_HOT_COMMENTS_ITEM;
//                goto label3731;
//                localObject3 = paramArticleDetailBean.Comments()[i1].User.AvatarUrl;
//                goto label3785;
//                localObject1 = paramArticleDetailBean.Comments()[i1].User.Name;
//                goto label3817;
//                localObject1 = Convert.ToString(paramArticleDetailBean.Comments[i1].CommentNum);
//                goto label3864;
//                localObject1 = Convert.ToString(paramArticleDetailBean.Comments[i1].LikeNum);
//                goto label3893;
//                localObject1 = paramArticleDetailBean.Comments[i1].Remark;
//                goto label3922;
//            }
//            label4157:
//            paramArticleDetailBean =
//                str.Replace("vgapp_comment_list", (CharSequence) localObject5)
//                    .Replace("vgapp_hot_comment_num", Convert.ToString(paramArticleDetailBean.Comments.Length));
//            paramArticleDetailBean = ((String) localObject4).Replace("vgapp_comment_hot_list", paramArticleDetailBean);
            
//            localStringBuffer.Append(paramArticleDetailBean);
         
//            paramArticleDetailBean =
//                localStringBuffer.ToString()
//                    .replaceAll("[\\t\\n\\r]", "")
//                    .replaceAll("'", "&apos;")
//                    .Replace("%", "vg_app_percent_replace_android_andy_gu");
           
//            this.myWebView.loadUrl("javascript:JSAddContent('" + paramArticleDetailBean + "');");
//            paramArticleDetailBean = ArticleTemplates.Article_FONT_STYLE;
//            switch (BaseApplication.a("KEY_FONT_SIZE", 2))
//            {
//                case 2:
//                default:
//                    paramArticleDetailBean =
//                        paramArticleDetailBean.Replace("vgapp_title_font_size", "22")
//                            .Replace("vgapp_content_font_size", "16")
//                            .Replace("vgapp_editor_font_size", "12");
//                    label4417:
//                    this.myWebView.loadUrl("javascript:JSFontSize('" + paramArticleDetailBean + "');");
//                    if (paramBoolean)
//                    {
                        
//                        this.myWebView.loadUrl("javascript:JSAnchorScroll('" + this.n + "');");
//                        label4519:
//                        if (!NetUtil.isWifiOpen())
//                        {
//                            goto label4715;
//                        }
//                        if (this.f != null)
//                        {
//                            goto label4680;
//                        }
//                    }
//                    break;
//            }
//            for (;;)
//            {
//                return;
//                label4533:
//                paramArticleDetailBean = "";
//                break;
//                paramArticleDetailBean =
//                    paramArticleDetailBean.Replace("vgapp_title_font_size", "18")
//                        .Replace("vgapp_content_font_size", "12")
//                        .Replace("vgapp_editor_font_size", "8");
//                goto label4417;
//                paramArticleDetailBean =
//                    paramArticleDetailBean.Replace("vgapp_title_font_size", "20")
//                        .replace("vgapp_content_font_size", "14")
//                        .replace("vgapp_editor_font_size", "10");
//                goto label4417;
//                paramArticleDetailBean =
//                    paramArticleDetailBean.Replace("vgapp_title_font_size", "24")
//                        .replace("vgapp_content_font_size", "18")
//                        .replace("vgapp_editor_font_size", "14");
//                goto label4417;
//                paramArticleDetailBean =
//                    paramArticleDetailBean.replace("vgapp_title_font_size", "26")
//                        .replace("vgapp_content_font_size", "20")
//                        .replace("vgapp_editor_font_size", "16");
//                goto label4417;
//                this.myWebView.scrollTo(0, 0);
//                goto label4519;
//                label4680:
//                i1 = 0;
//                while (i1 < this.f.size())
//                {
//                    downloadImg((String) this.f.get(i1));
//                    i1 += 1;
//                }
//                continue;
//                label4715:
//                if (!BaseApplication.a("KEY_ONLY_WIFI_LOAD_IMAGE", false))
//                {
//                    if ((this.f != null) && (this.f.size() > 20))
//                    {
//                        DialogUtils.showConfirmDialog(this, "您正在使用手机网络，前方多图，是否依然显示图片？",
//                            new MaterialDialog.SingleButtonCallback()
//                        new MaterialDialog.SingleButtonCallback
//                        {
//                            public void onClick(@NonNull MaterialDialog paramAnonymousMaterialDialog,
//                            @NonNull DialogAction paramAnonymousDialogAction)
//                            {
//                            if (ArticleDetailActivity.this.f == null) {
//                        }
//                        for (;;)
//                        {
//                            return;
//                            int i = 0;
//                            while (i < ArticleDetailActivity.
//                            this.f.size())
//                            {
//                                ArticleDetailActivity.
//                                this.downloadImg((String) ArticleDetailActivity.
//                                this.f.get(i))
//                                ;
//                                i += 1;
//                            }
//                        }
//                        }
//                        }
//                        ,
//                        new MaterialDialog.SingleButtonCallback()
//                        {
//                            public void onClick(@NonNull MaterialDialog paramAnonymousMaterialDialog,
//                            @NonNull DialogAction paramAnonymousDialogAction)
//                            {
//                            paramAnonymousMaterialDialog.dismiss();
//                        }
//                        }
//                        )
//                        ;
//                        return;
//                    }
//                    if (this.f != null)
//                    {
//                        i1 = 0;
//                        while (i1 < this.f.size())
//                        {
//                            downloadImg((String) this.f.get(i1));
//                            i1 += 1;
//                        }
//                    }
//                }
//            }
//        }
//    }
//}