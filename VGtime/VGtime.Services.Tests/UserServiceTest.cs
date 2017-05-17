using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace VGtime.Services.Tests
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
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await _userService.GetUserInfoAsync(169953, null);
            });

            var result = await _userService.GetUserInfoAsync(169953, "FF8080815C074CF2015C0A0DAA5F00000CD4");
            Assert.Equal(result.ErrorCode, HttpStatusCode.OK);
        }

        [Fact]
        public async Task TestLoginAsync()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await _userService.LoginAsync(null, "842053625");
            });
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await _userService.LoginAsync("842053625@qq.com", null);
            });

            var result = await _userService.LoginAsync("842053625@qq.com", "842053625");
            Assert.Equal(result.ErrorCode, HttpStatusCode.OK);
        }

        [Fact]
        public async Task TestSearchUserAsync()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await _userService.SearchUserAsync(null);
            });
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                await _userService.SearchUserAsync("高达", page: 0);
            });
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                await _userService.SearchUserAsync("高达", pageSize: 0);
            });

            var result = await _userService.SearchUserAsync("高达");
            Assert.Equal(result.ErrorCode, HttpStatusCode.OK);
        }
    }
}