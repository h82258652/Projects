using System.Threading.Tasks;
using VGtime.Models;

namespace VGtime.Services
{
    public interface IPostService
    {
        Task<ServerBase<CommentList>> GetCommentListAsync(int postId, int type, int? userId = null, int page = 1, int pageSize = 20);

        Task<ServerBase<PostDetail>> GetDetailAsync(int postId, int type, int? userId = null, int page = 1);

        Task<ServerBase<PostStatus>> GetDetailStatusAsync(int postId, int type, int? userId = null);
    }
}