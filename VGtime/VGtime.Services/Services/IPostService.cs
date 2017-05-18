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

        Task<ResultBase<AblumList<GameAlbum>>> GetGameAblumListAsync(int gameId);

        Task<ResultBase<GameData>> GetGameDetailAsync(int gameId);

        Task<ResultBase<HeadPicList>> GetHeadPicAsync();

        Task<ResultBase<KeywordList>> GetHotwordAsync();

        Task<ResultBase<PushList>> GetListAsync(int page = 1);

        Task<ResultBase<TopicList>> GetListByTagAsync(int tags, int page = 1, int pageSize = 20);

        Task<ResultBase<bool>> GetMessageIsReadAsync(int userId, int type);

        Task<ResultBase<AblumList<Post>>> GetRelationListAsync(int gameId, int type, int page = 1, int pageSize = 20);

        Task<ResultBase<GameList>> GetScoreListAsync(int gameId, int page = 1, int pageSize = 20);

        Task<ResultBase<StartPicture>> GetStartPicAsync();

        Task<ResultBase<StrategyList>> GetStrategyMenuListAsync(int gameId);

        Task<ResultBase<VersionData>> GetVersionAsync();

        Task<ResultBase<SearchList<Post>>> SearchAsync(string text, int type, int? typeTag = null, int page = 1, int pageSize = 20);

        Task<ResultBase<SearchList<Game>>> SearchGameAsync(string text, int type, int contentType, int page = 1, int pageSize = 20);
    }
}