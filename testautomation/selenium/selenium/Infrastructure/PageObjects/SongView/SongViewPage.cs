using OpenQA.Selenium.Chrome;

namespace selenium.Infrastructure.PageObjects.SongViewer
{
    public class SongViewPage : BasePage
    {
        public SongViewPage(ChromeDriver driver) : base(driver) {}

        internal void AssertSongVisible(Models.Song song)
        {
            throw new NotImplementedException();
        }

        internal void CreateSong(Models.Song song)
        {
            throw new NotImplementedException();
        }
    }
}
