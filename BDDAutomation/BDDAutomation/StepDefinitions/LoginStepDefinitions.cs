using OpenQA.Selenium;
using TechTalk.SpecFlow;
using BDDAutomation.PageObjects;

namespace BDDAutomation.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {

        private readonly IWebDriver _webDriver;

        //Page Object for login pageobjects
        private readonly LoginPageObjects loginpage;


        public LoginStepDefinitions(ScenarioContext scenarioContext)
        {
            _webDriver = scenarioContext["WEB_DRIVER"] as IWebDriver;
            loginpage = new LoginPageObjects(_webDriver);
        }




        [Given(@"I have navigated to the Concept Evolution wesbite")]
        public void GivenIHaveNavigatedToTheConceptEvolutionWesbite()
        {
            // Navigate to the Concept Evaluation Site
            //_webDriver.Url = $"https://stageconcept.dwp-estates-integrator.co.uk/DWPStagedEvo/!System/Security/Login.aspx?";
            _webDriver.Url = $"https://stageconcept.dwp-estates-integrator.co.uk/DWPStagedEvo/!System/Security/Login.aspx?ReturnUrl=%2fDWPStagedEvo%2f!System%2fDefault.aspx";

        }

        [Then(@"the ""([^""]*)"" enters a email and password on the Signin page")]
        public void ThenTheEntersAEmailAndPasswordOnTheSigninPage(string userName)
        {
           //Enter login creds for the provided username
            loginpage.EnterLoginCred(userName);
        }

        [Then(@"the user should be signedin to the application")]
        public void ThenTheUserShouldBeSignedinToTheApplication()
        {
            loginpage.VerifyLogOutIsPresent();
        }



    }
}
