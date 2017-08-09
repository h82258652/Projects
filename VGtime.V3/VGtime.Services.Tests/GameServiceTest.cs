using System.Threading.Tasks;
using Xunit;

namespace VGtime.Services.Tests
{
    public class GameServiceTest
    {
        private readonly IGameService _gameService;

        public GameServiceTest()
        {
            _gameService = new GameService();
        }


        [Fact]
        public async Task TestAblumlistAsync()
        {
            var result = await _gameService.AblumlistAsync(100);
            Assert.True(result.Retcode == Constants.SuccessCode);
        }
    }
}