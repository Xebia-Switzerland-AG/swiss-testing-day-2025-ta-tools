using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace selenium.Infrastructure.PageObjects.Home
{
    public class HomePage : BasePage
    {
        // Locators
        public readonly By CreateNewSongButton = By.CssSelector("a[href='#/songs/create'] div:first-child");

        public HomePage(ChromeDriver driver) : base(driver) { }

        public void GoHome()
        {
            throw new NotImplementedException();
        }

        public void ClickCreateNewSong()
        {
            ClickElement(CreateNewSongButton);
        }

        public void ViewSong(Models.Song song)
        {
            throw new NotImplementedException();
        }
    }
}
