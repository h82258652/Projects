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
        public async Task TestGetCommentListAsync()
        {
            var result = await _postService.GetCommentListAsync(552341, 1);
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
        public async Task TestGetHeadPicAsync()
        {
            var result = await _postService.GetHeadPicAsync();
            Assert.AreEqual(result.ErrorCode, HttpStatusCode.OK);
        }

        [Test]
        public async Task TestGetListAsync()
        {
            var result = await _postService.GetListAsync();
            Assert.AreEqual(result.ErrorCode, HttpStatusCode.OK);
        }

        [Test]
        public async Task TestGetListByTagAsync()
        {
            var result = await _postService.GetListByTagAsync(1);
            Assert.AreEqual(result.ErrorCode, HttpStatusCode.OK);
        }
    }
}