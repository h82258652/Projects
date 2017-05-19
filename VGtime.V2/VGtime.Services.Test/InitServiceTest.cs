using System;
using System.Threading.Tasks;
using Xunit;

namespace VGtime.Services.Test
{
    public class InitServiceTest
    {
        private readonly IInitService _initService;

        public InitServiceTest()
        {
            _initService = new InitService();
        }

        [Fact]
        public async Task GetHotwordAsync()
        {
            var result = await _initService.GetHotwordAsync();
            Assert.Equal(result.Retcode, 200);
        }

        [Fact]
        public async Task GetAsync()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await _initService.GetStartpicAsync(null);
            });

            var result = await _initService.GetStartpicAsync("2.0.8");
            Assert.Equal(result.Retcode, 200);
        }
    }
}