using System;
using System.Net;
using System.Threading.Tasks;
using NUnit.Framework;

namespace VGtime.Services.Tests
{
    [TestFixture]
    public class PostServiceTest
    {
        private IPostService _postService;

        [SetUp]
        public void SetUp()
        {
            _postService = new PostService();
        }

        [Test]
        public async Task TestGetAdAsync()
        {
            var result = await _postService.GetAdAsync();
            Assert.AreEqual(result.ErrorCode, HttpStatusCode.OK);
        }

        [Test]
        public async Task TestGetCommentListAsync()
        {
            Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                await _postService.GetCommentListAsync(556162, 1, page: 0);
            });
            Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                await _postService.GetCommentListAsync(556162, 1, pageSize: 0);
            });

            var result = await _postService.GetCommentListAsync(556162, 1);
            Assert.AreEqual(result.ErrorCode, HttpStatusCode.OK);
        }

        [Test]
        public async Task TestGetDetailAsync()
        {
            var result = await _postService.GetDetailAsync(552341, 1);
            Assert.AreEqual(result.ErrorCode, HttpStatusCode.OK);
        }

        [Test]
        public async Task TestGetDetailStatusAsync()
        {
            var result = await _postService.GetDetailStatusAsync(552341, 1);
            Assert.AreEqual(result.ErrorCode, HttpStatusCode.OK);
        }

        [Test]
        public async Task TestGetGameAblumListAsync()
        {
            var result = await _postService.GetGameAblumListAsync(3504);
            Assert.AreEqual(result.ErrorCode, HttpStatusCode.OK);
        }

        [Test]
        public async Task TestGetGameDetailAsync()
        {
            var result = await _postService.GetGameDetailAsync(2613);
            Assert.AreEqual(result.ErrorCode, HttpStatusCode.OK);
        }

        [Test]
        public async Task TestGetHeadPicAsync()
        {
            var result = await _postService.GetHeadPicAsync();
            Assert.AreEqual(result.ErrorCode, HttpStatusCode.OK);
        }

        [Test]
        public async Task TestGetHotwordAsync()
        {
            var result = await _postService.GetHotwordAsync();
            Assert.AreEqual(result.ErrorCode, HttpStatusCode.OK);
        }

        [Test]
        public async Task TestGetListAsync()
        {
            Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                await _postService.GetListAsync(0);
            });

            var result = await _postService.GetListAsync();
            Assert.AreEqual(result.ErrorCode, HttpStatusCode.OK);
        }

        [Test]
        public async Task TestGetListByTagAsync()
        {
            Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                await _postService.GetListByTagAsync(1, page: 0);
            });
            Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                await _postService.GetListByTagAsync(1, pageSize: 0);
            });

            {
                var result = await _postService.GetListByTagAsync(4);
                Assert.AreEqual(result.ErrorCode, HttpStatusCode.OK);
            }
            {
                var result = await _postService.GetListByTagAsync(2);
                Assert.AreEqual(result.ErrorCode, HttpStatusCode.OK);
            }
            {
                var result = await _postService.GetListByTagAsync(3);
                Assert.AreEqual(result.ErrorCode, HttpStatusCode.OK);
            }
        }

        [Test]
        public async Task TestGetStartPicAsync()
        {
            var result = await _postService.GetStartPicAsync();
            Assert.AreEqual(result.ErrorCode, HttpStatusCode.OK);
        }

        [Test]
        public async Task TestGetStrategyMenuListAsync()
        {
            var result = await _postService.GetStrategyMenuListAsync(10079);
            Assert.AreEqual(result.ErrorCode, HttpStatusCode.OK);
        }

        [Test]
        public async Task TestGetVersionAsync()
        {
            var result = await _postService.GetVersionAsync();
            Assert.AreEqual(result.ErrorCode, HttpStatusCode.OK);
        }

        [Test]
        public async Task TestSearchAsync()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await _postService.SearchAsync(null, 2, 2);
            });
            Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                await _postService.SearchAsync("高达", 2, 2, page: 0);
            });
            Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                await _postService.SearchAsync("高达", 2, 2, pageSize: 0);
            });

            {
                var result = await _postService.SearchAsync("高达", 2, typeTag: 2);
                Assert.AreEqual(result.ErrorCode, HttpStatusCode.OK);
            }
            {
                var result = await _postService.SearchAsync("高达", 2, typeTag: 3);
                Assert.AreEqual(result.ErrorCode, HttpStatusCode.OK);
            }
        }

        [Test]
        public async Task TestSearchGameAsync()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await _postService.SearchGameAsync(null, 2, 4);
            });
            Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                await _postService.SearchGameAsync("高达", 2, 4, page: 0);
            });
            Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                await _postService.SearchGameAsync("高达", 2, 4, pageSize: 0);
            });

            var result = await _postService.SearchGameAsync("高达", 2, 4);
            Assert.AreEqual(result.ErrorCode, HttpStatusCode.OK);
        }

        [Test]
        public async Task TestSearchUserAsync()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await _postService.SearchUserAsync(null, 1);
            });
            Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                await _postService.SearchUserAsync("高达", 1, page: 0);
            });
            Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                await _postService.SearchUserAsync("高达", 1, pageSize: 0);
            });

            var result = await _postService.SearchUserAsync("高达", 1);
            Assert.AreEqual(result.ErrorCode, HttpStatusCode.OK);
        }
    }
}