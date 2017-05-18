using System.Threading.Tasks;
using Xunit;

namespace VGtime.Services.Test
{
    public class GameServiceTest
    {
        private readonly IGameService _gameService;

        public GameServiceTest()
        {
            _gameService = new GameService();
        }

        [Fact]
        public async Task TestGetAlbumListAsync()
        {
            var result = await _gameService.GetAlbumListAsync(2235);
            Assert.Equal(result.Retcode, 200);
        }

        [Fact]
        public async Task TestGetDetailAsync()
        {
            var result = await _gameService.GetDetailAsync(2235);
            Assert.Equal(result.Retcode, 200);
        }
    }
}