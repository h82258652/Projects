using System.Threading.Tasks;
using VGtime.Models;

namespace VGtime.Services
{
    public interface IPostService
    {
        Task<ResultBase<object>> GetAdAsync();

        Task<ResultBase<CommentList>> GetCommentListAsync(int postId, int type, int page = 1, int pageSize = 20);

        Task<ResultBase<PostDetail>> GetDetailAsync(int postId, int type);

        Task<ResultBase<PostStatus>> GetDetailStatusAsync(int postId, int type);

        Task<ResultBase<HeadPicList>> GetHeadPicAsync();

        Task<ResultBase<KeywordList>> GetHotwordAsync();

        Task<ResultBase<PushList>> GetListAsync(int page = 1);

        Task<ResultBase<TopicList>> GetListByTagAsync(int tags, int page = 1, int pageSize = 20);

        Task<ResultBase<object>> GetStartPicAsync();

        Task<ResultBase<object>> GetVersionAsync();
    }
}