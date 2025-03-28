using OpenQA.Selenium.Chrome;
using selenium.Infrastructure.PageObjects.Home;
using selenium.Infrastructure.PageObjects.SongViewer;

namespace selenium.Infrastructure
{
    public class BaseApplication : IDisposable
    {
        private readonly ChromeDriver _driver;
        public HomePage Home;
        public SongViewPage SongView;

        public BaseApplication() 
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized");
            _driver = new ChromeDriver(options);
            _driver.Navigate().GoToUrl("http://localhost:8080/");

            Home = new HomePage(_driver);
            SongView = new SongViewPage(_driver);
        }

        public async Task resetDB()
        {
            using var client = new HttpClient();
            try
            {
                HttpResponseMessage response = await client.GetAsync("http://localhost:8081/reset");
                response.EnsureSuccessStatusCode();
                Console.WriteLine("✅ Datenbank-Reset erfolgreich");
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Fehler beim Reset der Datenbank: " + ex.Message);
            }
        }

        public void Dispose()
        {
            _driver.Dispose();
        }
    }
}
