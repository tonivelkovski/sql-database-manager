using AcceptanceTests.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using System.Linq;
using TechTalk.SpecFlow;

namespace AcceptanceTests.StepDefinitions
{
    [Binding]
    public class UserLoginStepDefinitions
    {

        #region Login form display

        [When(@"I launch the application")]
        public void WhenILaunchTheApplication()
        {
            GuiDriver.GetOrCreate();
        }

        [Then(@"I should see the login form")]
        public void ThenIShouldSeeTheLoginForm()
        {
            var driver = GuiDriver.Get();

            var form = driver.FindElementByAccessibilityId("FrmPrijava");

            Assert.IsNotNull(form);
            Assert.IsTrue(driver.Title == "Prijava administratora");
        }

        #endregion

        #region Invalid credentials

        [Given(@"I am on the login form")]
        public void GivenIAmOnTheLoginForm()
        {
            GuiDriver.GetOrCreate();
        }

        [When(@"I enter server address (.*), username (.*) and password (.*)")]
        public void WhenIEnterServerAddressUsernameAndPassword(string serverAddress, string username, string password)
        {
            var driver = GuiDriver.Get();
            var txtDatabaseServer = driver.FindElementByAccessibilityId("txtDatabaseServer");
            var txtUsername = driver.FindElementByAccessibilityId("txtUsername");
            var txtPassword = driver.FindElementByAccessibilityId("txtPassword");

            txtDatabaseServer.SendKeys(serverAddress);
            txtUsername.SendKeys(username);
            txtPassword.SendKeys(password);
        }

        [When(@"I click on the Prijava button")]
        public void WhenIClickOnThePrijavaButton()
        {
            var driver = GuiDriver.Get();
            var btnLogin = driver.FindElementByAccessibilityId("btnPrijava");

            Assert.IsNotNull(btnLogin);

            btnLogin.Click();
        }

        [Then(@"I should see (.*) error message")]
        public void ThenIShouldSeeErrorMessage(string expectedErrorMessage)
        {
            var driver = GuiDriver.Get();

            // Wait for the message box to appear
            WindowsElement messageBox = driver.FindElementByClassName("#32770");

            // Get the text of the message box
            WindowsElement messageBoxText = (WindowsElement)messageBox.FindElementByXPath("//Text[@LocalizedControlType='text']");
            string actualErrorMessage = messageBoxText.Text;
            messageBox.FindElementByName("OK").Click();

            Assert.AreEqual(expectedErrorMessage, actualErrorMessage);
        }

        #endregion

        #region Valid credentials

        [When(@"I enter server address localhost,1433 with username sa and password mojaJakaL=Z!NKA")]
        public void WhenIEnterServerAddressLocalhostWithUsernameSaAndPasswordMojaJakaLZNKA()
        {
            var driver = GuiDriver.Get();
            var txtDatabaseServer = driver.FindElementByAccessibilityId("txtDatabaseServer");
            var txtUsername = driver.FindElementByAccessibilityId("txtUsername");
            var txtPassword = driver.FindElementByAccessibilityId("txtPassword");

            txtDatabaseServer.SendKeys(@"localhost,1433");
            txtUsername.SendKeys(@"sa");
            txtPassword.SendKeys(@"mojaJakaL=Z!NKA");
        }

        [Then(@"I should be redirected to the initial form")]
        public void ThenIShouldBeRedirectedToTheInitialForm()
        {
            var driver = GuiDriver.Get();

            driver.SwitchTo().Window(driver.WindowHandles.First());

            Assert.AreEqual("Glavna forma", driver.Title);
        }

        [Then(@"I should see my username, along with current server address")]
        public void ThenIShouldSeeMyUsernameAlongWithCurrentServerAddress()
        {
            var driver = GuiDriver.Get();

            var statusBar = driver.FindElementByAccessibilityId("statusStrip1");
            var statusBarElements = statusBar.FindElementsByXPath("//*");

            Assert.AreEqual("localhost,1433", statusBarElements[2].Text);
            Assert.AreEqual("sa", statusBarElements[4].Text);
        }

        #endregion
    }
}
