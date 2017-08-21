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
            var result = await _bingService.GetAsync(0, 10, "en-US");
            Assert.True(result.Images.Any());
        }
    }
}