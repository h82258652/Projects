using System.Threading.Tasks;
using VGtime.Models;

namespace VGtime.Services
{
    public interface IPostService
    {
        Task<ResultBase<AdData>> GetAdAsync();

        Task<ResultBase<CommentList>> GetCommentListAsync(int postId, int type, int page = 1, int pageSize = 20);

        Task<ResultBase<PostDetail>> GetDetailAsync(int postId, int type);

        Task<ResultBase<PostStatusData>> GetDetailStatusAsync(int postId, int type);

        Task<ResultBase<HeadPicList>> GetHeadPicAsync();

        Task<ResultBase<KeywordList>> GetHotwordAsync();

        Task<ResultBase<PushList>> GetListAsync(int page = 1);

        Task<ResultBase<TopicList>> GetListByTagAsync(int tags, int page = 1, int pageSize = 20);

        Task<ResultBase<StartPicture>> GetStartPicAsync();

        Task<ResultBase<VersionData>> GetVersionAsync();

        Task<ResultBase<SearchList>> SearchAsync(string text, int type, int typeTag);
    }
}