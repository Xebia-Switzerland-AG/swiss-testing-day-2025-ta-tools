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

        public void ClickOnElement(By element)
        {
            _driver.FindElement(element).Click();
        }

        public void SendTextToElement(By element, string value)
        {
            _driver.FindElement(element).SendKeys(value);
        }

        public String GetTextFromElement(By element)
        {
            return _driver.FindElement(element).Text;
        }

        public void ClearElement(By element)
        {
            SendTextToElement(element, Keys.Control + "a" + Keys.Backspace);
            _driver.FindElement(element).Clear();
        }

        public void ClearAndSendTextToElement(By element, string value)
        {
            ClearElement(element);
            SendTextToElement(element, value);
        }
    }
}
