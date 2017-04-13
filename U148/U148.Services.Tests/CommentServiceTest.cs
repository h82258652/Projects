using System.Threading.Tasks;
using NUnit.Framework;

namespace U148.Services.Tests
{
    [TestFixture]
    public class CommentServiceTest
    {
        private ICommentService _commentService;

        [SetUp]
        public void SetUp()
        {
            _commentService = new CommentService();
        }

        [Test]
        public async Task TestGetCommentsAsync()
        {
            var result = await _commentService.GetCommentsAsync(141135);
            Assert.AreEqual(result.ErrorCode, 0);
        }
    }
}