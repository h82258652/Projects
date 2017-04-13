using System.Threading.Tasks;
using NUnit.Framework;

namespace U148.Services.Tests
{
    [TestFixture]
    public class UserServiceTest
    {
        private readonly TaskCompletionSource<string> _tokenTcs = new TaskCompletionSource<string>();

        private IUserService _userService;

        [SetUp]
        public void SetUp()
        {
            _userService = new UserService();
        }

        [Test]
        [Order(1)]
        public async Task TestGetFavoritesAsync()
        {
            var token = await _tokenTcs.Task;
            var result = await _userService.GetFavoritesAsync(token);
            Assert.AreEqual(result.ErrorCode, 0);
        }

        [Test]
        [Order(0)]
        public async Task TestLoginAsync()
        {
            var result = await _userService.LoginAsync("842053625@qq.com", "842053625");
            Assert.AreEqual(result.ErrorCode, 0);
            _tokenTcs.SetResult(result.Data.Token);
        }
    }
}