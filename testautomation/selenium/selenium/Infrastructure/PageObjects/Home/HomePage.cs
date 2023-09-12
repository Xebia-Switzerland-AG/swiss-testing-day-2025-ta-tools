using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using selenium.Infrastructure.Models;

namespace selenium.Infrastructure.PageObjects.Home
{
    public class HomePage : BasePage
    {
        // Locators
        public readonly By CreateNewSongButton = By.CssSelector("a[href='#/songs/create'] div:first-child");
        public readonly By SearchField = By.XPath("//input[@data-test-id='search-bar']");
        public readonly By SongTitle = By.CssSelector("[data-test-id='songTitle']");
        public readonly By SongArtist = By.CssSelector("[data-test-id='songArtist']");
        public readonly By SongGenre = By.CssSelector("[data-test-id='songGenre']");

        public HomePage(ChromeDriver driver) : base(driver) { }

        public void ClickCreateNewSong()
        {
            ClickOnElement(CreateNewSongButton);
        }

        public void SearchSong(Song song)
        {
            SendTextToElement(SearchField, song.title);
            Thread.Sleep(1000);
        }

        public void AssertSongIsVisible(Song song)
        {
            GetTextFromElement(SongTitle).Should().Be(song.title);
            GetTextFromElement(SongArtist).Should().Be(song.artist);
            GetTextFromElement(SongGenre).Should().Be(song.genre);
        }
    }
}
