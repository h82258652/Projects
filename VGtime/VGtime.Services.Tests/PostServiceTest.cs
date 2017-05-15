using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace VGtime.Services.Tests
{
    public class PostServiceTest
    {
        private readonly IPostService _postService;

        public PostServiceTest()
        {
            _postService = new PostService();
        }

        [Fact]
        public async Task TestGetAdAsync()
        {
            var result = await _postService.GetAdAsync();
            Assert.Equal(result.ErrorCode, HttpStatusCode.OK);
        }

        [Fact]
        public async Task TestGetCommentListAsync()
        {
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                await _postService.GetCommentListAsync(556162, 1, page: 0);
            });
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                await _postService.GetCommentListAsync(556162, 1, pageSize: 0);
            });

            var result = await _postService.GetCommentListAsync(556162, 1);
            Assert.Equal(result.ErrorCode, HttpStatusCode.OK);
        }

        [Fact]
        public async Task TestGetDetailAsync()
        {
            var result = await _postService.GetDetailAsync(552341, 1);
            Assert.Equal(result.ErrorCode, HttpStatusCode.OK);
        }

        [Fact]
        public async Task TestGetDetailStatusAsync()
        {
            var result = await _postService.GetDetailStatusAsync(552341, 1);
            Assert.Equal(result.ErrorCode, HttpStatusCode.OK);
        }

        [Fact]
        public async Task TestGetGameAblumListAsync()
        {
            var result = await _postService.GetGameAblumListAsync(3504);
            Assert.Equal(result.ErrorCode, HttpStatusCode.OK);
        }

        [Fact]
        public async Task TestGetGameDetailAsync()
        {
            var result = await _postService.GetGameDetailAsync(2235);
            Assert.Equal(result.ErrorCode, HttpStatusCode.OK);
        }

        [Fact]
        public async Task TestGetHeadPicAsync()
        {
            var result = await _postService.GetHeadPicAsync();
            Assert.Equal(result.ErrorCode, HttpStatusCode.OK);
        }

        [Fact]
        public async Task TestGetHotwordAsync()
        {
            var result = await _postService.GetHotwordAsync();
            Assert.Equal(result.ErrorCode, HttpStatusCode.OK);
        }

        [Fact]
        public async Task TestGetListAsync()
        {
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                await _postService.GetListAsync(0);
            });

            var result = await _postService.GetListAsync();
            Assert.Equal(result.ErrorCode, HttpStatusCode.OK);
        }

        [Fact]
        public async Task TestGetListByTagAsync()
        {
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                await _postService.GetListByTagAsync(1, page: 0);
            });
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                await _postService.GetListByTagAsync(1, pageSize: 0);
            });

            {
                var result = await _postService.GetListByTagAsync(4);
                Assert.Equal(result.ErrorCode, HttpStatusCode.OK);
            }
            {
                var result = await _postService.GetListByTagAsync(2);
                Assert.Equal(result.ErrorCode, HttpStatusCode.OK);
            }
            {
                var result = await _postService.GetListByTagAsync(3);
                Assert.Equal(result.ErrorCode, HttpStatusCode.OK);
            }
        }

        [Fact]
        public async Task TestGetMessageIsReadAsync()
        {
            var result = await _postService.GetMessageIsReadAsync(169953, 2);
            Assert.Equal(result.ErrorCode, HttpStatusCode.OK);
        }

        [Fact]
        public async Task TestGetRelationListAsync()
        {
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                await _postService.GetRelationListAsync(2235, 1, page: 0);
            });
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                await _postService.GetRelationListAsync(2235, 1, pageSize: 0);
            });

            var result = await _postService.GetRelationListAsync(2235, 1);
            Assert.Equal(result.ErrorCode, HttpStatusCode.OK);
        }

        [Fact]
        public async Task TestGetScoreListAsync()
        {
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                await _postService.GetScoreListAsync(2235, page: 0);
            });
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                await _postService.GetScoreListAsync(2235, pageSize: 0);
            });

            var result = await _postService.GetScoreListAsync(2235);
            Assert.Equal(result.ErrorCode, HttpStatusCode.OK);
        }

        [Fact]
        public async Task TestGetStartPicAsync()
        {
            var result = await _postService.GetStartPicAsync();
            Assert.Equal(result.ErrorCode, HttpStatusCode.OK);
        }

        [Fact]
        public async Task TestGetStrategyMenuListAsync()
        {
            var result = await _postService.GetStrategyMenuListAsync(10079);
            Assert.Equal(result.ErrorCode, HttpStatusCode.OK);
        }

        [Fact]
        public async Task TestGetUserInfoAsync()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await _postService.GetUserInfoAsync(169953, null);
            });

            var result = await _postService.GetUserInfoAsync(169953, "FF8080815C074CF2015C0A0DAA5F00000CD4");
            Assert.Equal(result.ErrorCode, HttpStatusCode.OK);
        }

        [Fact]
        public async Task TestGetVersionAsync()
        {
            var result = await _postService.GetVersionAsync();
            Assert.Equal(result.ErrorCode, HttpStatusCode.OK);
        }

        [Fact]
        public async Task TestLoginAsync()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await _postService.LoginAsync(null, "842053625");
            });
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await _postService.LoginAsync("842053625@qq.com", null);
            });

            var result = await _postService.LoginAsync("842053625@qq.com", "842053625");
            Assert.Equal(result.ErrorCode, HttpStatusCode.OK);
        }

        [Fact]
        public async Task TestSearchAsync()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await _postService.SearchAsync(null, 2, 2);
            });
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                await _postService.SearchAsync("高达", 2, 2, page: 0);
            });
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                await _postService.SearchAsync("高达", 2, 2, pageSize: 0);
            });

            {
                var result = await _postService.SearchAsync("高达", 2, typeTag: 2);
                Assert.Equal(result.ErrorCode, HttpStatusCode.OK);
            }
            {
                var result = await _postService.SearchAsync("高达", 2, typeTag: 3);
                Assert.Equal(result.ErrorCode, HttpStatusCode.OK);
            }
        }

        [Fact]
        public async Task TestSearchGameAsync()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await _postService.SearchGameAsync(null, 2, 4);
            });
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                await _postService.SearchGameAsync("高达", 2, 4, page: 0);
            });
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                await _postService.SearchGameAsync("高达", 2, 4, pageSize: 0);
            });

            var result = await _postService.SearchGameAsync("高达", 2, 4);
            Assert.Equal(result.ErrorCode, HttpStatusCode.OK);
        }

        [Fact]
        public async Task TestSearchUserAsync()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await _postService.SearchUserAsync(null, 1);
            });
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                await _postService.SearchUserAsync("高达", 1, page: 0);
            });
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                await _postService.SearchUserAsync("高达", 1, pageSize: 0);
            });

            var result = await _postService.SearchUserAsync("高达", 1);
            Assert.Equal(result.ErrorCode, HttpStatusCode.OK);
        }
    }
}