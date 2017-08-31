using System.Threading.Tasks;
using Xunit;

namespace BingoWallpaper.Services.Tests
{
    public class LeanCloudServiceTest
    {
        private readonly ILeanCloudService _leanCloudService;

        public LeanCloudServiceTest()
        {
            _leanCloudService = new LeanCloudService();
        }

        [Theory]
        [InlineData("599beb0b570c350060983bd9")]
        public async Task TestGetArchiveAsync(string objectId)
        {
            var archive = await _leanCloudService.GetArchiveAsync(objectId);
        }

        [Fact]
        public async Task TestGetArchivesAsync()
        {
            await _leanCloudService.GetArchivesAsync(null);
        }

        [Theory]
        [InlineData("559d0e88e4b03bd51879a0de")]
        public async Task TestGetImageAsync(string objectId)
        {
            var image = await _leanCloudService.GetImageAsync(objectId);
        }

        [Fact]
        public async Task TestGetImagesAsync()
        {
            await _leanCloudService.GetImagesAsync(null);
        }
    }
}