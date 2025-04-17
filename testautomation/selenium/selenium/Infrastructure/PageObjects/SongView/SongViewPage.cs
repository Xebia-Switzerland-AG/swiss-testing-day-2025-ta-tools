using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using selenium.Infrastructure.Models;

namespace selenium.Infrastructure.PageObjects.SongViewer
{
    public class SongViewPage : BasePage
    {
        public readonly By TitleText = By.CssSelector("[data-test-id='songTitle']");
        public readonly By ArtistText = By.CssSelector("[data-test-id='songArtist']");
        public readonly By GenreText = By.CssSelector(".song-genre");
        
        // TODO Incorrect
        public readonly By AlbumText = By.CssSelector("songAlbum");
        public readonly By AlbumImageUrl= By.CssSelector("songAlbumImg");
        public readonly By YoutubeIdText = By.CssSelector("songYoutube");
        public readonly By TabText = By.CssSelector("songTab");
        public readonly By LyricsText = By.CssSelector("songLyrics");

        public SongViewPage(ChromeDriver driver) : base(driver) {}

        public void VerifySong(Song song)
        {
            GetTextFromElement(TitleText).Should().Be(song.title);
            GetTextFromElement(ArtistText).Should().Be(song.artist);
            GetTextFromElement(GenreText).Should().Be(song.genre);
            // GetTextFromElement(AlbumText).Should().Be(song.album);
            // GetTextFromElement(AlbumImageUrl).Should().Be(song.album_url);
            // GetTextFromElement(YoutubeIdText).Should().Be(song.youtube_id);
            // GetTextFromElement(TabText).Should().Be(song.tab);
            // GetTextFromElement(LyricsText).Should().Be(song.lyrics);
            Thread.Sleep(5000);
        }
    }
}
