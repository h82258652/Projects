using System.Net;
using System.Threading.Tasks;
using NUnit.Framework;

namespace VGtime.Services.Tests
{
    [TestFixture]
    public class TempServiceTest
    {
        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public async Task TestGetDetailAsync()
        {
            var tempService = new TempService();
            var result = await tempService.GetDetailAsync(552341, 1);
            Assert.AreEqual(result.ErrorCode, HttpStatusCode.OK);
        }

        [Test]
        public async Task TestGetDetailStatusAsync()
        {
            var tempService = new TempService();
            var result = await tempService.GetDetailStatusAsync(552341, 1);
            Assert.AreEqual(result.ErrorCode, HttpStatusCode.OK);
        }

        [Test]
        public async Task TestGetHeadPicAsync()
        {
            var tempService = new TempService();
            var result = await tempService.GetHeadPicAsync();
            Assert.AreEqual(result.ErrorCode, HttpStatusCode.OK);
        }

        [Test]
        public async Task TestGetListAsync()
        {
            var tempService = new TempService();
            var result = await tempService.GetListAsync();
            Assert.AreEqual(result.ErrorCode, HttpStatusCode.OK);
        }

        [Test]
        public async Task TestGetListByTagAsync()
        {
            var tempService = new TempService();
            var result = await tempService.GetListByTagAsync(1);
            Assert.AreEqual(result.ErrorCode, HttpStatusCode.OK);
        }

        [Test]
        public async Task TestGetC()
        {
            var tempService = new TempService();
            var result = await tempService.GetC(552341);
            Assert.AreEqual(result.ErrorCode, HttpStatusCode.OK);
        }
    }
}