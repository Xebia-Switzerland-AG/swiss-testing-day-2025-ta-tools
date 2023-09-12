using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace selenium.Infrastructure.PageObjects
{
    public abstract class BasePage
    {
        protected ChromeDriver _driver;

        protected BasePage(ChromeDriver driver)
        {
            _driver = driver;
        }

        public void ClickElement(By element)
        {
            _driver.FindElement(element).Click();
        }

        public bool IsElementVisible(By element)
        {
            return _driver.FindElement(element).Displayed;
        }
    }
}
