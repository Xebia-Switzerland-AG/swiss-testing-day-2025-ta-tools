using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selenium.Infrastructure
{
    public class BaseApplication : IDisposable
    {
        private readonly ChromeDriver _driver;

        public BaseApplication() 
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized");
            _driver = new ChromeDriver(options);
            _driver.Navigate().GoToUrl("http://localhost:8080/");
        }
        public void Dispose()
        {
            _driver.Dispose();
        }
    }
}
