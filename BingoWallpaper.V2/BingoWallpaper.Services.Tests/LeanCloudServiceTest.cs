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
            await _leanCloudService.GetArchiveAsync(objectId);
        }

        [Fact]
        public async Task TestGetArchivesAsync()
        {
        }

        [Theory]
        [InlineData("559d0e88e4b03bd51879a0de")]
        public async Task TestGetImageAsync(string objectId)
        {
            await _leanCloudService.GetImageAsync(objectId);
        }

        [Fact]
        public async Task TestGetImagesAsync()
        {
        }
    }
}