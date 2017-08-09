using System.Threading.Tasks;
using Xunit;

namespace VGtime.Services.Tests
{
    public class InitServiceTest
    {
        private readonly IInitService _initService;

        public InitServiceTest()
        {
            _initService = new InitService();
        }

        [Fact]
        public async Task TestAdAsync()
        {
        }

        [Fact]
        public async Task TestStartpicAsync()
        {
            var result = await _initService.StartpicAsync();
            Assert.True(result.Retcode == Constants.SuccessCode);
        }
    }
}