using AcceptanceTests.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using TechTalk.SpecFlow;

namespace AcceptanceTests.StepDefinitions
{
    [Binding]
    public class EmailPreferencesStepDefinitions
    {

        #region Email preferences form display

        [Given(@"I am on the settings form")]
        public void GivenIAmOnTheSettingsForm()
        {
            var driver = GuiDriver.Get();

            var menuStrip = driver.FindElementByAccessibilityId("menuStrip1");
            menuStrip.FindElementByName("Opcije").Click();

            var dropdown = driver.FindElementByClassName("WindowsForms10.Window.20808.app.0.141b42a_r7_ad1");
            dropdown.FindElementByName("Postavke").Click();
        }

        [Then(@"I should see the application settings")]
        public void ThenIShouldSeeTheApplicationSettings()
        {
            var driver = GuiDriver.Get();

            var settingsForm = driver.FindElementByAccessibilityId("FrmPostavke");

            Assert.AreEqual("Postavke", settingsForm.Text);
        }

        [Then(@"I should see the email section")]
        public void ThenIShouldSeeTheEmailSection()
        {
            var driver = GuiDriver.Get();

            var settingsForm = driver.FindElementByAccessibilityId("FrmPostavke");
            var emailGrouping = settingsForm.FindElementByAccessibilityId("gbEmail");

            // Section name
            Assert.AreEqual("Email", emailGrouping.Text);
            // Section fields must be read-only
            AssertAllEmailSectionElementsAreVisible(emailGrouping, true);
            // Only "Uredi" button can be seen
            emailGrouping.FindElementByAccessibilityId("btnUredi");
            Assert.ThrowsException<WebDriverException>(() => emailGrouping.FindElementByAccessibilityId("btnOdustani"));
            Assert.ThrowsException<WebDriverException>(() => emailGrouping.FindElementByAccessibilityId("btnSpremi"));
        }

        #endregion

        #region Available edit mode

        [When(@"I click on the Uredi button")]
        public void GivenIClickOnTheUrediButton()
        {
            var driver = GuiDriver.Get();

            var settingsForm = driver.FindElementByAccessibilityId("FrmPostavke");
            var emailGrouping = settingsForm.FindElementByAccessibilityId("gbEmail");
            var btnUredi = emailGrouping.FindElementByAccessibilityId("btnUredi");

            btnUredi.Click();
        }

        [Then(@"I should be able to edit all email settings")]
        public void ThenIShouldBeAbleToEditAllEmailSettings()
        {
            var driver = GuiDriver.Get();

            var settingsForm = driver.FindElementByAccessibilityId("FrmPostavke");
            var emailGrouping = settingsForm.FindElementByAccessibilityId("gbEmail");

            AssertAllEmailSectionElementsAreVisible(emailGrouping, false);
        }

        [Then(@"I should see Spremi and Odustani buttons")]
        public void ThenIShouldSeeSpremiAndOdustaniButtons()
        {
            var driver = GuiDriver.Get();

            var settingsForm = driver.FindElementByAccessibilityId("FrmPostavke");
            var emailGrouping = settingsForm.FindElementByAccessibilityId("gbEmail");

            emailGrouping.FindElementByAccessibilityId("btnSpremi");
            emailGrouping.FindElementByAccessibilityId("btnOdustani");
            Assert.ThrowsException<WebDriverException>(() => emailGrouping.FindElementByAccessibilityId("btnUredi"));
        }

        #endregion

        #region Exit edit mode

        [Then(@"I should be able to exit edit mode")]
        public void ThenIShouldBeAbleToExitEditMode()
        {
            var driver = GuiDriver.Get();
            var settingsForm = driver.FindElementByAccessibilityId("FrmPostavke");
            var emailGrouping = settingsForm.FindElementByAccessibilityId("gbEmail");

            var btnOdustani = emailGrouping.FindElementByAccessibilityId("btnOdustani");
            btnOdustani.Click();

            // Section fields must be read-only
            AssertAllEmailSectionElementsAreVisible(emailGrouping, true);
            // Only "Uredi" button can be seen
            emailGrouping.FindElementByAccessibilityId("btnUredi");
            Assert.ThrowsException<WebDriverException>(() => emailGrouping.FindElementByAccessibilityId("btnOdustani"));
            Assert.ThrowsException<WebDriverException>(() => emailGrouping.FindElementByAccessibilityId("btnSpremi"));
        }

        #endregion

        #region Invalid email host

        [When(@"I clear the email host data")]
        public void GivenIClearTheEmailHostData()
        {
            var driver = GuiDriver.Get();
            var settingsForm = driver.FindElementByAccessibilityId("FrmPostavke");
            var emailGrouping = settingsForm.FindElementByAccessibilityId("gbEmail");
            var host = emailGrouping.FindElementByAccessibilityId("txtEmailHost");

            host.Clear();
        }

        [When(@"I click on the Spremi button")]
        public void GivenIClickOnTheSpremiButton()
        {
            var driver = GuiDriver.Get();

            var settingsForm = driver.FindElementByAccessibilityId("FrmPostavke");
            var emailGrouping = settingsForm.FindElementByAccessibilityId("gbEmail");
            var btnSpremi = emailGrouping.FindElementByAccessibilityId("btnSpremi");

            btnSpremi.Click();
        }

        [Then(@"I should see the error message that all fields must have a default value")]
        public void ThenIShouldSeeTheErrorMessageThatAllFieldsMustHaveADefaultValue()
        {
            var driver = GuiDriver.Get();

            WindowsElement messageBox = driver.FindElementByClassName("#32770");
            WindowsElement messageBoxControl = (WindowsElement)messageBox.FindElementByXPath("//Text[@LocalizedControlType='text']");
            string actualErrorMessage = messageBoxControl.Text;
            messageBox.FindElementByName("OK").Click();

            Assert.AreEqual("Sva su polja obavezna", actualErrorMessage);
        }

        #endregion

        #region Invalid email sender
        [When(@"I change the default email sender to ""([^""]*)""")]
        public void WhenIChangeTheDefaultEmailSenderTo(string senderEmail)
        {
            var driver = GuiDriver.Get();
            var settingsForm = driver.FindElementByAccessibilityId("FrmPostavke");
            var emailGrouping = settingsForm.FindElementByAccessibilityId("gbEmail");
            var sender = emailGrouping.FindElementByAccessibilityId("txtEmailSender");

            sender.Clear();
            sender.SendKeys(senderEmail);
        }

        [Then(@"I should see the error message saying that the sender email address is not valid")]
        public void ThenIShouldSeeTheErrorMessageSayingThatTheSenderEmailAddressIsNotValid()
        {
            var driver = GuiDriver.Get();

            WindowsElement messageBox = driver.FindElementByClassName("#32770");
            WindowsElement messageBoxControl = (WindowsElement)messageBox.FindElementByXPath("//Text[@LocalizedControlType='text']");
            string actualErrorMessage = messageBoxControl.Text;
            messageBox.FindElementByName("OK").Click();

            Assert.AreEqual("Neva�e�a email adresa po�iljatelja", actualErrorMessage);
        }

        #endregion

        #region Invalid BCC emails

        [When(@"I change the default BCC emails to ""([^""]*)""")]
        public void WhenIChangeTheDefaultBCCEmailsTo(string bccEmails)
        {
            var driver = GuiDriver.Get();
            var settingsForm = driver.FindElementByAccessibilityId("FrmPostavke");
            var emailGrouping = settingsForm.FindElementByAccessibilityId("gbEmail");
            var bcc = emailGrouping.FindElementByAccessibilityId("txtEmailBCC");

            bcc.Clear();
            bcc.SendKeys(bccEmails);
        }

        [Then(@"I should see the error message saying that the BCC emails field contains invalid email address\(es\)")]
        public void ThenIShouldSeeTheErrorMessageSayingThatTheBCCEmailsFieldContainsInvalidEmailAddressEs()
        {
            var driver = GuiDriver.Get();

            WindowsElement messageBox = driver.FindElementByClassName("#32770");
            WindowsElement messageBoxControl = (WindowsElement)messageBox.FindElementByXPath("//Text[@LocalizedControlType='text']");
            string actualErrorMessage = messageBoxControl.Text;
            messageBox.FindElementByName("OK").Click();

            Assert.AreEqual("Neva�e�a/e BCC email adresa/e", actualErrorMessage);
        }

        #endregion

        #region Invalid email subject

        [When(@"I clear the default email subject")]
        public void WhenIClearTheDefaultEmailSubject()
        {
            var driver = GuiDriver.Get();
            var settingsForm = driver.FindElementByAccessibilityId("FrmPostavke");
            var emailGrouping = settingsForm.FindElementByAccessibilityId("gbEmail");
            var subject = emailGrouping.FindElementByAccessibilityId("txtEmailSubject");

            subject.Clear();
        }

        #endregion

        #region Invalid email display name

        [When(@"I clear the default email display name")]
        public void WhenIClearTheDefaultEmailDisplayName()
        {
            var driver = GuiDriver.Get();
            var settingsForm = driver.FindElementByAccessibilityId("FrmPostavke");
            var emailGrouping = settingsForm.FindElementByAccessibilityId("gbEmail");
            var displayName = emailGrouping.FindElementByAccessibilityId("txtEmailDisplayName");

            displayName.Clear();
        }

        #endregion

        #region Successful update

        [When(@"I change the default email subject to Baza podataka za projekt iz TIKPP-a")]
        public void WhenIChangeTheDefaultEmailSubjectToBazaPodatakaZaProjektIzTIKPP_A()
        {
            var driver = GuiDriver.Get();
            var settingsForm = driver.FindElementByAccessibilityId("FrmPostavke");
            var emailGrouping = settingsForm.FindElementByAccessibilityId("gbEmail");
            var subject = emailGrouping.FindElementByAccessibilityId("txtEmailSubject");

            subject.Clear();
            subject.SendKeys(@"Baza podataka za projekt iz TIKPP-a");
        }

        [Then(@"I should see the newly updated email defaults")]
        public void ThenIShouldSeeTheNewlyUpdatedEmailDefaults()
        {
            var driver = GuiDriver.Get();
            var settingsForm = driver.FindElementByAccessibilityId("FrmPostavke");
            var emailGrouping = settingsForm.FindElementByAccessibilityId("gbEmail");

            var sender = emailGrouping.FindElementByAccessibilityId("txtEmailSender");
            var bcc = emailGrouping.FindElementByAccessibilityId("txtEmailBCC");
            var subject = emailGrouping.FindElementByAccessibilityId("txtEmailSubject");

            Assert.AreEqual("tikpp@foi.hr", sender.Text);
            Assert.AreEqual("ttomasic20@student.foi.hr,dskrlac20@student.foi.hr,tvelkovsk20@student.foi.hr", bcc.Text);
            Assert.AreEqual("Baza podataka za projekt iz TIKPP-a", subject.Text);
        }

        #endregion

        private void AssertAllEmailSectionElementsAreVisible(AppiumWebElement emailGrouping, bool isReadOnly)
        {
            var host = emailGrouping.FindElementByAccessibilityId("txtEmailHost");
            var sender = emailGrouping.FindElementByAccessibilityId("txtEmailSender");
            var bcc = emailGrouping.FindElementByAccessibilityId("txtEmailBCC");
            var subject = emailGrouping.FindElementByAccessibilityId("txtEmailSubject");
            var displayName = emailGrouping.FindElementByAccessibilityId("txtEmailDisplayName");

            Assert.AreEqual(isReadOnly, CheckIsReadOnly(host));
            Assert.AreEqual(isReadOnly, CheckIsReadOnly(sender));
            Assert.AreEqual(isReadOnly, CheckIsReadOnly(bcc));
            Assert.AreEqual(isReadOnly, CheckIsReadOnly(subject));
            Assert.AreEqual(isReadOnly, CheckIsReadOnly(displayName));
        }

        private bool CheckIsReadOnly(AppiumWebElement el)
        {
            try { el.Clear(); }
            catch (WebDriverException) { return true; }
            return false;
        }
    }
}
