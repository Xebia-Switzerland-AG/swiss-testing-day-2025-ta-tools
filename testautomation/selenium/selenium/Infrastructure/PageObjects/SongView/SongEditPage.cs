using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using selenium.Infrastructure.Models;

namespace selenium.Infrastructure.PageObjects.SongViewer
{
    public class SongEditPage : BasePage
    {
        public readonly By TitleInput = By.Id("sngTitle");
        public readonly By ArtistInput = By.Id("sngArtist");
        public readonly By GenreInput = By.Id("sngGenre");
        public readonly By AlbumInput = By.Id("sngAlbum");
        public readonly By AlbumImageUrlInput = By.Id("sngAlbumImg");
        public readonly By YoutubeIdInput = By.Id("sngYoutube");
        public readonly By TabTextarea = By.Id("sngTab");
        public readonly By LyricsTextarea = By.Id("sngLyrics");
        public readonly By CreateSongButton = By.Id("sngBtn");

        public SongEditPage(ChromeDriver driver) : base(driver) {}

        public void CreateSong(Song song)
        {
            ClearAndSendTextToElement(TitleInput, song.title);
            ClearAndSendTextToElement(ArtistInput, song.artist);
            ClearAndSendTextToElement(GenreInput, song.genre);
            ClearAndSendTextToElement(AlbumInput, song.album);
            ClearAndSendTextToElement(AlbumImageUrlInput, song.album_url);
            ClearAndSendTextToElement(YoutubeIdInput, song.youtube_id);
            ClearAndSendTextToElement(TabTextarea, song.tab);
            ClearAndSendTextToElement(LyricsTextarea, song.lyrics);
            ClickOnElement(CreateSongButton);
            Thread.Sleep(3000);
        }
    }
}
