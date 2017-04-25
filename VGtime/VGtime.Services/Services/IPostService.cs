using System.Threading.Tasks;
using VGtime.Models;

namespace VGtime.Services
{
    public interface IPostService
    {
        Task<ResultBase<CommentList>> GetCommentListAsync(int postId, int type);

        Task<ResultBase<PostDetail>> GetDetailAsync(int postId, int type);

        Task<ResultBase<PostStatus>> GetDetailStatusAsync(int postId, int type);

        Task<ResultBase<HeadPicList>> GetHeadPicAsync();

        Task<ResultBase<PushList>> GetListAsync();

        Task<ResultBase<TopicList>> GetListByTagAsync(int tags);
    }
}