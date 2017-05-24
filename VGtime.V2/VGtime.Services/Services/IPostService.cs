using System.Threading.Tasks;
using VGtime.Models;
using VGtime.Models.Timeline;

namespace VGtime.Services
{
    public interface IPostService
    {
        Task<ServerBase<CommentList>> GetCommentListAsync(int postId, int type, int? userId = null, int page = 1, int pageSize = 20);

        Task<ServerBase<PostDetail>> GetDetailAsync(int postId, int type, int? userId = null, int page = 1);

        Task<ServerBase<PostStatus>> GetDetailStatusAsync(int postId, int type, int? userId = null);

        Task<ServerBase<SearchList<TimeLineBase>>> SearchArticleAsync(string text, int? userId = null, int page = 1, int pageSize = 20);

        Task<ServerBase<SearchList<TimeLineBase>>> SearchForumAsync(string text, int? userId = null, int page = 1, int pageSize = 20);
    }
}