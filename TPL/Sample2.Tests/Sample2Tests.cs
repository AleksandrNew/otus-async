using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sample2.Tests
{
    [TestClass]
    public class Sample2Tests
    {
        [TestMethod]
        public async Task CanGetDate()
        {
            var mockSomeService = new MockSomeService();

            var data = await mockSomeService.GetDataAsync();

            Assert.AreEqual(data.Count(), 4);
        }
    }
}
