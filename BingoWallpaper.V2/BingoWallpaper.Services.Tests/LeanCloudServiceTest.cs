using System.Linq;
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
            Assert.True(archive.ErrorCode == 0);
        }

        [Fact]
        public async Task TestGetArchivesAsync()
        {
            {
                var archives = await _leanCloudService.GetArchivesAsync(new[]
                {
                    "599beb0b570c350060983bd9"
                });
                Assert.True(archives.ErrorCode == 0);
            }

            {
                var archives = await _leanCloudService.GetArchivesAsync();
                Assert.True(archives.ErrorCode == 0);
            }
        }

        [Theory]
        [InlineData("559d0e88e4b03bd51879a0de")]
        public async Task TestGetImageAsync(string objectId)
        {
            var image = await _leanCloudService.GetImageAsync(objectId);
            Assert.True(image.ErrorCode == 0);
        }

        [Fact]
        public async Task TestGetImagesAsync()
        {
            var images = await _leanCloudService.GetImagesAsync(new[]
            {
                "559d0e88e4b03bd51879a0de"
            });
            Assert.True(images.ErrorCode == 0);
        }

        [Theory]
        [InlineData("599beb0b570c350060983bd9")]
        public async Task TestGetWallpaperAsync(string objectId)
        {
            var wallpaper = await _leanCloudService.GetWallpaperAsync(objectId);
            Assert.NotNull(wallpaper);
        }

        [Fact]
        public async Task TestGetWallpapersAsync()
        {
            {
                var wallpapers = await _leanCloudService.GetWallpapersAsync(new[]
                {
                    "599beb0b570c350060983bd9"
                });
                Assert.True(wallpapers.Any());
            }

            {
                var wallpapers = await _leanCloudService.GetWallpapersAsync();
                Assert.True(wallpapers.Any());
            }
        }
    }
}