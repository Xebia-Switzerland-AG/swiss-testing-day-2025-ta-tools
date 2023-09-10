using selenium.Infrastructure;
using static System.Net.Mime.MediaTypeNames;

namespace selenium
{
    [TestClass]
    public class CreateSongTest
    {
        public BaseApplication app { get; private set; }

        [TestInitialize]
        public void SetUpApplicationBase()
        {
            app = new BaseApplication();
        }

        [TestMethod]
        public void CreateNewSong()
        {
            // Arrange
            Assert.IsTrue(true);
        }

        [TestCleanup]
        public void ApplicationCleanUp()
        {
            app.Dispose();
        }
    }
}