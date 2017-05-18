using System;
using System.Threading.Tasks;
using Xunit;

namespace VGtime.Services.Test
{
    public class UserServiceTest
    {
        private readonly IUserService _userService;

        public UserServiceTest()
        {
            _userService = new UserService();
        }

        [Fact]
        public async Task TestGetUserInfoAsync()
        {
            const int userId = 169953;
            const string token = "FF8080815C074CF2015C0A0DAA5F00000CD4";

            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await _userService.GetUserInfoAsync(userId, null);
            });

            var result = await _userService.GetUserInfoAsync(userId, token);
            Assert.Equal(result.Retcode, 200);
        }

        [Fact]
        public async Task TestLoginAsync()
        {
            const string account = "842053625@qq.com";
            const string password = "842053625";

            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await _userService.LoginAsync(null, password);
            });
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await _userService.LoginAsync(account, null);
            });

            var result = await _userService.LoginAsync(account, password);
            Assert.Equal(result.Retcode, 200);
        }
    }
}