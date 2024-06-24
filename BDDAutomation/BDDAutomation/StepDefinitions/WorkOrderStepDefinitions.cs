using OpenQA.Selenium;
using TechTalk.SpecFlow;
using BDDAutomation.PageObjects;

namespace BDDAutomation.StepDefinitions
{
    [Binding]
    public class WorkOrderStepDefinitions
    {

        private readonly IWebDriver _webDriver;

        //Page Object for Work order pageobjects
        private readonly WorkOrderPageObjects workorderpage;


        public WorkOrderStepDefinitions(ScenarioContext scenarioContext)
        {
            _webDriver = scenarioContext["WEB_DRIVER"] as IWebDriver;
            workorderpage = new WorkOrderPageObjects(_webDriver);

        }

        [Then(@"the user selects ""([^""]*)"" to create work order")]
        public void ThenTheUserSelectsToCreateWorkOrder(string menuItem)
        {
            //Select the menu item
            workorderpage.SelectMenuItem(menuItem);
        }

        [Then(@"the user enters ""([^""]*)""""([^""]*)""""([^""]*)""""([^""]*)""""([^""]*)""""([^""]*)""""([^""]*)""""([^""]*)""""([^""]*)""""([^""]*)""""([^""]*)""""([^""]*)"" information")]
        public void ThenTheUserEntersInformation(string ReporterFirstPart, string Reporter, string Postcode, string Building, string LocationFirstPart, string Location, string ContractFirstPart, string Contract, string ProblemFirstPart, string ProblemType, string SourceFirstPart, string Source)
        {
            //Enter work order information
            workorderpage.CreateWorkOrder(ReporterFirstPart,Reporter, Postcode, Building, LocationFirstPart, Location, ContractFirstPart, Contract, ProblemFirstPart, ProblemType, SourceFirstPart, Source);
        }


        [Then(@"the user clicks save and notes the WOID")]
        public void ThenTheUserClicksSaveAndNotesTheWOID()
        {
            //Cature WOID
            workorderpage.captureWOID();

        }

    }
}
