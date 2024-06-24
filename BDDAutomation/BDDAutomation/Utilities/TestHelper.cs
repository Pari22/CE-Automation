using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow;

namespace BDDAutomation.Utilities
{
    public static class TestHelper
    {
        ///// <summary>
        ///// Finds element based on By type
        ///// </summary>
        ///// <param name="by"></param>
        ///// <returns></returns>
        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }

        public static bool IsElementPresent(this IWebDriver driver, By by)
        {
            System.Threading.Thread.Sleep(5000);
            try
            {
                bool isElementDisplayed = driver.FindElement(by).Displayed;
                return true;

            }
            catch (NoSuchElementException)
            {
                return false;
            }

        }

        public static IWebElement WaitUntilElementIsClickable(this IWebDriver driver, By by)
        {
            //IWebDriver _driver;
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(20));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException), typeof(StaleElementReferenceException));
            IWebElement element = wait.Until(ExpectedConditions.ElementToBeClickable(by));
            return wait.Until(_driver => _driver.FindElement(by));
        }

        public static bool WaitForElementToDisappear(IWebDriver driver, string elementxpath)
        {
            bool elementDisappear = WaitForElementToBeInvisibleXpath(driver, 60, elementxpath);
            return elementDisappear;
        }

        private static bool WaitForElementToBeInvisibleXpath(IWebDriver driver, int timeToWait, string id)
        {
            //IWebDriver _driver;
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(timeToWait));
            bool element = wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(id)));
            return element;
        }
       
    }
}
