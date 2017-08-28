using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BingoWallpaper.Services.Tests
{
    public class BingServiceTest
    {
        private readonly IBingService _bingService;

        public BingServiceTest()
        {
            _bingService = new BingService();
        }

        [Fact]
        public async Task TestGetAsync()
        {
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                await _bingService.GetAsync(0, 0, "zh-CN");
            });
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await _bingService.GetAsync(0, 1, null);
            });

            var result = await _bingService.GetAsync(0, 10, "zh-CN");
            Assert.True(result.Images.Any());
        }
    }
}