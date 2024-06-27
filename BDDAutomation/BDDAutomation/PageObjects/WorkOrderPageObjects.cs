using OpenQA.Selenium;
using Xunit;
using BDDAutomation.Utilities;

namespace BDDAutomation.PageObjects
{
    public class WorkOrderPageObjects
    {
        //The Selenium web driver to automate the browser
        private readonly IWebDriver _driver;

        //The default wait time in seconds for wait.Until
        public const int DefaultWaitInSeconds = 5;

        public WorkOrderPageObjects(IWebDriver driver)
        {
            _driver = driver;
        }
        private IWebElement workorderManagment => TestHelper.WaitUntilElementIsClickable(_driver, By.XPath("//a[@title='Work Order Management']"));
        private IWebElement ReporterDD => TestHelper.WaitUntilElementIsClickable(_driver, By.Id("ctl00_ctl00_contentPlaceHolderRoot_TaskSelectorsPlaceHolder_ctl00_autoCompleteReporter_comboBox_Input"));
        private IWebElement BuildingDD => TestHelper.WaitUntilElementIsClickable(_driver, By.Id("ctl00_ctl00_contentPlaceHolderRoot_TaskSelectorsPlaceHolder_ctl00_autoCompleteBuilding_comboBox_Input"));
        private IWebElement LocationDD => TestHelper.WaitUntilElementIsClickable(_driver, By.Id("ctl00_ctl00_contentPlaceHolderRoot_TaskSelectorsPlaceHolder_ctl00_autoCompleteLocation_comboBox_Input"));
        private IWebElement ContractDD => TestHelper.WaitUntilElementIsClickable(_driver, By.Id("ctl00_ctl00_contentPlaceHolderRoot_TaskSelectorsPlaceHolder_ctl00_autoCompleteContract_comboBox_Input"));
        private IWebElement ProblemTypeDD => TestHelper.WaitUntilElementIsClickable(_driver, By.Id("ctl00_ctl00_contentPlaceHolderRoot_TaskSelectorsPlaceHolder_ctl00_autoCompleteProblem_comboBox_Input"));
        private IWebElement SourceDD => TestHelper.WaitUntilElementIsClickable(_driver, By.Id("ctl00_ctl00_contentPlaceHolderRoot_contentPlaceHolder_F_TASKSEditor_ctl00_autoCompleteCallerSource_comboBox_Input"));
        private IWebElement SaveBtn => TestHelper.WaitUntilElementIsClickable(_driver, By.XPath("//span[text()='Save']"));
        private IWebElement newBtn => TestHelper.WaitUntilElementIsClickable(_driver, By.XPath("//span[text()='New']"));
        private IWebElement workorders => TestHelper.WaitUntilElementIsClickable(_driver, By.XPath("(//a[@title='Work Orders'])[2]"));
        private IWebElement workorderID => TestHelper.WaitUntilElementIsClickable(_driver, By.XPath("(//td[@style='width:100%;' and contains(text(),'MFR')])[1]"));
        private IWebElement duplicateOrder => TestHelper.WaitUntilElementIsClickable(_driver, By.XPath("//input[@value='Save Work Order']"));
        private IList<IWebElement> ReporterDD1 => _driver.FindElements(By.XPath("//ul/li"));
        private IList<IWebElement> BuildingDD1 => _driver.FindElements(By.XPath("//ul/li"));
        private IList<IWebElement> LocationDD1 => _driver.FindElements(By.XPath("//ul/li"));
        private IList<IWebElement> ContractDD1 => _driver.FindElements(By.XPath("//ul/li"));
        private IList<IWebElement> ProblemDD1 => _driver.FindElements(By.XPath("//ul/li"));
        private IList<IWebElement> SourceDD1 => _driver.FindElements(By.XPath("//ul/li"));

        public void SelectMenuItem(string menuItem)
        {
            switch (menuItem)
            {
                case "Work Order Management":
                    workorderManagment.Click();
                    workorders.Click();
                    break;
                case "Modules":
                    break;
                case "Facilities":
                    break;
                default:
                    throw new Exception($" {menuItem} not found.");

            }
        }

        public void CreateWorkOrder(string ReporterFirstPart, string Reporter, string Postcode, string Building, string LocationFirstPart, string Location, string ContractFirstPart, string Contract, string ProblemFirstPart, string ProblemType, string SourceFirstPart, string Source)
        {
            //New button is out of view port so use JS executor to scroll to the element before click
            Thread.Sleep(3000);
            IJavaScriptExecutor executor = (IJavaScriptExecutor)_driver;
            executor.ExecuteScript("arguments[0].scrollIntoView(true);", newBtn);

            //Click New button to fill in work order information
            newBtn.Click();

            //Verify new WO opens in new window and enter information
            var browserTabs = _driver.WindowHandles;
            _driver.SwitchTo().Window(browserTabs[1]);
            _driver.Manage().Window.Maximize();

            //Verify control is on new window
            Assert.True(_driver.Title.Contains("New Entity"), "New WO opened in new tab doesnt contain New Entity in the page title");

            //Enter Source info
            SourceDD.SendKeys(SourceFirstPart);
            waitaBit();
            SourceDD.SendKeys(Keys.Space + Keys.ArrowDown);
            for (int i = 0; i < SourceDD1.Count; i++)
            {
                waitaBit();
                if (SourceDD1[i].Text.Trim().Equals(Source))
                {
                    SourceDD1[i].Click();
                    waitaBit();
                }

            }

            //Enter reporter info
            ReporterDD.SendKeys(ReporterFirstPart);
            for (int i = 0; i < ReporterDD1.Count; i++)
            {
                waitaBit();
                if (ReporterDD1[i].Text.Trim().Equals(Reporter))
                {
                    ReporterDD1[i].Click();
                    waitaBit();
                }

            }
            waitaBit();

            //Enter Building info
            BuildingDD.SendKeys(Postcode);
            for (int i = 0; i < BuildingDD1.Count; i++)
            {
                waitaBit();
                if (BuildingDD1[i].Text.Trim().Equals(Building))
                {
                    BuildingDD1[i].Click();
                    waitaBit();
                }
            }
            waitaBit();

            //Enter Location info
            LocationDD.SendKeys("*" + LocationFirstPart);
            for (int i = 0; i < LocationDD1.Count; i++)
            {
                waitaBit();
                if (LocationDD1[i].Text.Trim().Equals(Location))
                {
                    LocationDD1[i].Click();
                    waitaBit();
                }

            }
            waitaBit();

            //Enter Contract info
            ContractDD.SendKeys(ContractFirstPart);
            for (int i = 0; i < ContractDD1.Count; i++)
            {
                waitaBit();
                if (ContractDD1[i].Text.Trim().Equals(Contract))
                {
                    ContractDD1[i].Click();
                    waitaBit();
                }
            }
            waitaBit();

            //Enter Problem info
            ProblemTypeDD.SendKeys(ProblemFirstPart);
            for (int i = 0; i < ProblemDD1.Count; i++)
            {
                waitaBit();
                if (ProblemDD1[i].Text.Trim().Equals(ProblemType))
                {
                    ProblemDD1[i].Click();
                    waitaBit();
                }

            }
            waitaBit();

            //Save Work Order
            SaveWOID();

            //Note Work Order ID

            //close the window handle
            _driver.Close();
            //switch back to Main window handle
            _driver.SwitchTo().Window(browserTabs[0]);

        }

        public void SaveWOID()
        {
            waitaBit();
            Thread.Sleep(1000);

            //Save button is out of view port so use JS executor to scroll to the element before click
            IJavaScriptExecutor executor1 = (IJavaScriptExecutor)_driver;
            executor1.ExecuteScript("arguments[0].scrollIntoView(true);", SaveBtn);
            SaveBtn.Click();

            if (duplicateOrder.Displayed)
            {
                duplicateOrder.Click();
            }
            //Wait until processing spinner diappears
            TestHelper.WaitForElementToDisappear(_driver, "//span[text()='Processing']");
        }

        public void captureWOID()
        {
            waitaBit();

            _driver.Navigate().Refresh();
            Assert.True(workorderID.Displayed,"WorkOrder ID is not present in the list");
            string WOID = workorderID.Text.Trim();
            Thread.Sleep(1000);
            Console.WriteLine("WOID is:" + WOID);

        }

        public void waitaBit()
        {
            Thread.Sleep(1000);
        }


    }
}
