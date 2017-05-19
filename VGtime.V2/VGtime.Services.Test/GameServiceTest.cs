using System;
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

        [Fact]
        public async Task TestGetScoreListAsync()
        {
            const int gameId = 2235;

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                await _gameService.GetScoreListAsync(gameId, page: 0);
            });
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                await _gameService.GetScoreListAsync(gameId, pageSize: 0);
            });

            var result = await _gameService.GetScoreListAsync(gameId);
            Assert.Equal(result.Retcode, 200);
        }

        [Fact]
        public async Task TestGetStrategyMenuListAsync()
        {
            var result = await _gameService.GetStrategyMenuListAsync(2235);
            Assert.Equal(result.Retcode, 200);
        }
    }
}