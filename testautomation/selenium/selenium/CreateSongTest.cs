using selenium.Infrastructure;
using selenium.Infrastructure.Models;
using selenium.Infrastructure.PageObjects.Home;
using selenium.Infrastructure.PageObjects.SongViewer;

namespace selenium
{
    [TestClass]
    public class CreateSongTest
    {
        public BaseApplication app { get; private set; }
        public HomePage home { get; private set; }
        public SongViewPage view { get; private set; }


        [TestInitialize]
        public void SetUpApplicationBase()
        {
            app = new BaseApplication();
            home = app.Home;
            view = app.SongView;
        }

        [TestMethod]
        public void CreateNewSong()
        {
            // Arrange
            var song = new Song
            {
                title = "Bohemian Rhapsody",
                artist = "Queen",
                genre = "Rock",
                album = "A Night at the Opera",
                album_url = "https://example.com/album/night-at-the-opera",
                youtube_id = "ABC123XYZ",
                tab = "https://example.com/tab/bohemian-rhapsody",
                lyrics = "Is this the real life? Is this just fantasy?"
            };

            // Act
            home.ClickCreateNewSong();
            view.CreateSong(song);
            app.GoHome();
            home.ViewSong(song);

            // Assert
            view.AssertSongVisible(song);
        }

        [TestCleanup]
        public void ApplicationCleanUp()
        {
            app.Dispose();
        }
    }
}