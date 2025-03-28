using FluentAssertions;
using OpenQA.Selenium;
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

            app.resetDB().GetAwaiter().GetResult();
        }

        [TestMethod]
        public void CreateNewSong()
        {
            // Arrange
            var song = new Song
            {
                title = "Schatteboxe",
                artist = "Zuerich West",
                genre = "Mundart",
                album = "Love",
                album_url = "https://zueriwest.ch/wp-content/uploads/2017/02/Disko_Love.png",
                youtube_id = "TNW1sCFdDhI",
                tab = "test",
                lyrics = "\nD Sunne schynt duer d Storen uf mys Pult\nU malt es chlyses Vieregg druf us Gold\nEh chasch es mitnaeh wes der gfallt\nDe chasch es ha\nDu muesch mer nuet erklaere wed wosch ga\nEh d Stadt isch violett u d Schaette laeng\nI weiss nume nid was soell i jetz mit daem?\nWed nomau muesch ueberlege, ueberleisch\nAber mir muesch nuet erklaere we de geisch\nI probieres z akzeptiere so wies isch\nU grad alles wirdi sicher nid vermisse\nI chume geng no nid ganz drus\nWas du fuer eini bisch aber chasch sicher si\nDass i das gaern wett wuesse\nD Sunne schynt duer d Storen yy uf ds Pult\nU malt es chlyses Vieregg druf us Gold\nEh d Stadt isch violett u d Schaette laeng\nI weiss nume nid was soell i jetz mit daem?\nI schatteboxe gaege d Waend\n\nI probieres z akzeptiere wes so isch\nU grad alles wirdi sicher nid vermisse\nI chume geng no nid ganz drus\nWas du fuer eini bisch aber chasch sicher si\nDass i das gaern wett wuesse\nD Sunne schynt duer d Storen uf mys Pult\nU malt es chlyses Vieregg druf us Gold\nD Stadt isch violett u d Schaette laeng\nI weiss nume nid was soell i jetz mit daem?\nI schatteboxe gaege d Waend\nSchatteboxe gaege d Waend"
            };

            // Act
            home.ClickCreateNewSong();
            view.CreateSong(song);
            home.SearchSong(song);

            // Assert
            home.AssertSongIsVisible(song);
        }

        [TestMethod]
        [Ignore] //Same Test as above only without the PageObjectModel
        public void CreateNewSongNoPageObjects()
        {
            // Arrange
            var song = new Song
            {
                title = "Schatteboxe",
                artist = "Zuerich West",
                genre = "Mundart",
                album = "Love",
                album_url = "https://zueriwest.ch/wp-content/uploads/2017/02/Disko_Love.png",
                youtube_id = "TNW1sCFdDhI",
                tab = "test",
                lyrics = "\nD Sunne schynt duer d Storen uf mys Pult\nU malt es chlyses Vieregg druf us Gold\nEh chasch es mitnaeh wes der gfallt\nDe chasch es ha\nDu muesch mer nuet erklaere wed wosch ga\nEh d Stadt isch violett u d Schaette laeng\nI weiss nume nid was soell i jetz mit daem?\nWed nomau muesch ueberlege, ueberleisch\nAber mir muesch nuet erklaere we de geisch\nI probieres z akzeptiere so wies isch\nU grad alles wirdi sicher nid vermisse\nI chume geng no nid ganz drus\nWas du fuer eini bisch aber chasch sicher si\nDass i das gaern wett wuesse\nD Sunne schynt duer d Storen yy uf ds Pult\nU malt es chlyses Vieregg druf us Gold\nEh d Stadt isch violett u d Schaette laeng\nI weiss nume nid was soell i jetz mit daem?\nI schatteboxe gaege d Waend\n\nI probieres z akzeptiere wes so isch\nU grad alles wirdi sicher nid vermisse\nI chume geng no nid ganz drus\nWas du fuer eini bisch aber chasch sicher si\nDass i das gaern wett wuesse\nD Sunne schynt duer d Storen uf mys Pult\nU malt es chlyses Vieregg druf us Gold\nD Stadt isch violett u d Schaette laeng\nI weiss nume nid was soell i jetz mit daem?\nI schatteboxe gaege d Waend\nSchatteboxe gaege d Waend"
            };

            // Act
            home.ClickOnElement(By.CssSelector("a[href='#/songs/create'] div:first-child"));
            view.ClearAndSendTextToElement(By.Id("sngTitle"), song.title);
            view.ClearAndSendTextToElement(By.Id("sngArtist"), song.artist);
            view.ClearAndSendTextToElement(By.Id("sngGenre"), song.genre);
            view.ClearAndSendTextToElement(By.Id("sngAlbum"), song.album);
            view.ClearAndSendTextToElement(By.Id("sngAlbumImg"), song.album_url);
            view.ClearAndSendTextToElement(By.Id("sngYoutube"), song.youtube_id);
            view.ClearAndSendTextToElement(By.Id("sngTab"), song.tab);
            view.ClearAndSendTextToElement(By.Id("sngLyrics"), song.lyrics);
            view.ClickOnElement(By.Id("sngBtn"));
            Thread.Sleep(1000);
            view.SendTextToElement(By.XPath("//input[@data-test-id='search-bar']"), song.title);
            Thread.Sleep(1000);

            // Assert
            home.GetTextFromElement(By.CssSelector("[data-test-id='songTitle']")).Should().Be(song.title);
            home.GetTextFromElement(By.CssSelector("[data-test-id='songArtist']")).Should().Be(song.artist);
            home.GetTextFromElement(By.CssSelector("[data-test-id='songGenre']")).Should().Be(song.genre);
        }

        [TestCleanup]
        public void ApplicationCleanUp()
        {
            app.resetDB().GetAwaiter().GetResult();
            app.Dispose();
        }
    }
}