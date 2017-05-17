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
    }
}