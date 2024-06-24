using OpenQA.Selenium;
using Xunit;
using BDDAutomation.Utilities;


namespace BDDAutomation.PageObjects
{
    public class LoginPageObjects
    {
        //The Selenium web driver to automate the browser
        private readonly IWebDriver _driver;

        //The default wait time in seconds for wait.Until
        public const int DefaultWaitInSeconds = 5;

        public LoginPageObjects(IWebDriver driver)
        {
            _driver = driver;
        }
        private IWebElement userNameTxtBox => TestHelper.WaitUntilElementIsClickable(_driver, By.Id("ctl00_contentPlaceHolder_loginControl_UserName"));
        private IWebElement passwordTxtBox => TestHelper.WaitUntilElementIsClickable(_driver, By.Id("ctl00_contentPlaceHolder_loginControl_Password"));
        private IWebElement loginBtn => TestHelper.WaitUntilElementIsClickable(_driver, By.Id("ctl00_contentPlaceHolder_loginControl_LoginButton"));


        /// <summary>
        /// Log into Concept Evolution Site
        /// <paramref name="username"/>
        /// <paramref name="password"/>
        /// </summary>
        public void EnterLoginCred(string userName)
        {
            //enter username
            userNameTxtBox.SendKeys(userName);

            //enter password
            passwordTxtBox.SendKeys("Winter2024");
          
            //click login Btn
            loginBtn.Click();

        }

        public void VerifyLogOutIsPresent()
        {
            Assert.True(TestHelper.IsElementPresent(_driver, By.Id("ctl00_LogInOut")));
        }
    }
}
