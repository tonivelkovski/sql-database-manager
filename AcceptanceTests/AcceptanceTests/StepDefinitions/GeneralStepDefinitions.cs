using AcceptanceTests.Support;
using System.Linq;
using TechTalk.SpecFlow;

namespace AcceptanceTests.StepDefinitions
{
    [Binding]
    public class GeneralStepDefinitions
    {
        [Given(@"I am logged as an administrator")]
        public void GivenIAmLoggedAsAnAdministrator()
        {
            var driver = GuiDriver.GetOrCreate();

            // Get inputs
            var txtDatabaseServer = driver.FindElementByAccessibilityId("txtDatabaseServer");
            var txtUsername = driver.FindElementByAccessibilityId("txtUsername");
            var txtPassword = driver.FindElementByAccessibilityId("txtPassword");

            // Type login credentials
            txtDatabaseServer.SendKeys(@"localhost,1433");
            txtUsername.SendKeys(@"sa");
            txtPassword.SendKeys(@"mojaJakaL=Z!NKA");

            // Click login button
            var btnLogin = driver.FindElementByAccessibilityId("btnPrijava");
            btnLogin.Click();

            // Switch to the initial form
            driver.SwitchTo().Window(driver.WindowHandles.First());
        }

        [AfterScenario]
        public void CloseApplication()
        {
            GuiDriver.Dispose();
        }
    }
}
