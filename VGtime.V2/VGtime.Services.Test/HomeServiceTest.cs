using System;
using System.Threading.Tasks;
using Xunit;

namespace VGtime.Services.Test
{
    public class HomeServiceTest
    {
        private readonly IHomeService _homeService;

        public HomeServiceTest()
        {
            _homeService = new HomeService();
        }

        [Fact]
        public async Task TestGetHeadpicAsync()
        {
            var result = await _homeService.GetHeadpicAsync();
            Assert.Equal(result.Retcode, Constants.SuccessCode);
        }

        [Fact]
        public async Task TestGetListByTagAsync()
        {
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
             {
                 await _homeService.GetListByTagAsync(1, page: 0);
             });
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                await _homeService.GetListByTagAsync(1, pageSize: 0);
            });

            {
                var result = await _homeService.GetListByTagAsync(4);
                Assert.Equal(result.Retcode, Constants.SuccessCode);
            }
            {
                var result = await _homeService.GetListByTagAsync(2);
                Assert.Equal(result.Retcode, Constants.SuccessCode);
            }
            {
                var result = await _homeService.GetListByTagAsync(3);
                Assert.Equal(result.Retcode, Constants.SuccessCode);
            }
        }

        [Fact]
        public async Task TestGetVglistAsync()
        {
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                await _homeService.GetVglistAsync(page: 0);
            });
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                await _homeService.GetVglistAsync(pageSize: 0);
            });

            var result = await _homeService.GetVglistAsync();
            Assert.Equal(result.Retcode, Constants.SuccessCode);
        }
    }
}