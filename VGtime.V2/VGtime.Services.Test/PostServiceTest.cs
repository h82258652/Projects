using System;
using System.Threading.Tasks;
using Xunit;

namespace VGtime.Services.Test
{
    public class PostServiceTest
    {
        private readonly IPostService _postService;

        public PostServiceTest()
        {
            _postService = new PostService();
        }

        [Fact]
        public async Task TestGetCommentListAsync()
        {
            const int postId = 556162;
            const int type = 1;

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                await _postService.GetCommentListAsync(postId, type, page: 0);
            });
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                await _postService.GetCommentListAsync(postId, type, pageSize: 0);
            });

            var result = await _postService.GetCommentListAsync(postId, type);
            Assert.Equal(result.Retcode, Constants.SuccessCode);
        }

        [Fact]
        public async Task TestGetDetailAsync()
        {
            const int postId = 556162;
            const int type = 1;

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                await _postService.GetDetailAsync(postId, type, page: 0);
            });

            var result = await _postService.GetDetailAsync(postId, type);
            Assert.Equal(result.Retcode, Constants.SuccessCode);
        }

        [Fact]
        public async Task TestGetDetailStatusAsync()
        {
            const int postId = 556162;
            const int type = 1;

            var result = await _postService.GetDetailStatusAsync(postId, type);
            Assert.Equal(result.Retcode, Constants.SuccessCode);
        }

        [Fact]
        public async Task TestSearchArticleAsync()
        {
            const string text = "高达";

            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await _postService.SearchArticleAsync(null);
            });
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                await _postService.SearchArticleAsync(text, page: 0);
            });
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                await _postService.SearchArticleAsync(text, pageSize: 0);
            });

            var result = await _postService.SearchArticleAsync(text);
            Assert.Equal(result.Retcode, Constants.SuccessCode);
        }

        [Fact]
        public async Task TestSearchForumAsync()
        {
            const string text = "高达";

            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await _postService.SearchForumAsync(null);
            });
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                await _postService.SearchForumAsync(text, page: 0);
            });
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                await _postService.SearchForumAsync(text, pageSize: 0);
            });

            var result = await _postService.SearchForumAsync(text);
            Assert.Equal(result.Retcode, Constants.SuccessCode);
        }
    }
}