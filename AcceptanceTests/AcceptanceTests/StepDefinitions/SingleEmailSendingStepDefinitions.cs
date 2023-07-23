using AcceptanceTests.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using System.Linq;
using TechTalk.SpecFlow;


namespace AcceptanceTests.StepDefinitions
{
    [Binding]
    public class SingleEmailSendingStepDefinitions
    {

        #region Email cannot be sent if the team is not selected

        [Given(@"I am on the list of data on the server form")]
        public void GivenIAmOnTheListOfDataOnTheServerForm()
        {
            var driver = GuiDriver.Get();
            var menuStrip = driver.FindElementByAccessibilityId("menuStrip1");
            menuStrip.FindElementByName("Opcije").Click();

            var dropdown = driver.FindElementByClassName("WindowsForms10.Window.20808.app.0.141b42a_r7_ad1");
            dropdown.FindElementByName("Popis baza na serveru").Click();        
        }

        [When(@"I click on the Send e-mail button")]
        public void WhenIClickOnTheSendE_MailButton()
        {
            var driver = GuiDriver.Get();      
            driver.SwitchTo().Window(driver.WindowHandles.First());

            var dataGrid = driver.FindElementByAccessibilityId("dgvDatabases");

            if (dataGrid.FindElementByAccessibilityId("NoItemsMessage") != null)
            {
                var btnSendEmail = driver.FindElementByName("Send e-mail");
                btnSendEmail.Click();
            }
            else
            {
            }               
        }

        [Then(@"I should see error message that ""([^""]*)""")]
        public void ThenIShouldSeeErrorMessageThat(string p0)
        {
            var driver = GuiDriver.Get();

            WindowsElement messageBox = driver.FindElementByClassName("#32770");
            WindowsElement messageBoxControl = (WindowsElement)messageBox.FindElementByXPath("//Text[@LocalizedControlType='text']");
            string actualErrorMessage = messageBoxControl.Text;
            messageBox.FindElementByName("OK").Click();

            Assert.AreEqual(p0, actualErrorMessage);
        }

        #endregion

        #region Information about selected team is correct and displayed

        [When(@"I click on the desired team")]
        public void WhenIClickOnTheDesiredTeam()
        {
            var driver = GuiDriver.Get();
            var selectTeam = driver.FindElementByName("TeamNumber Row 0, Not sorted.");

            selectTeam.Click();
        }

        [When(@"I should click on the Send e-mail button")]
        public void ThenIShouldClickOnTheSendE_MailButton()
        {
            var driver = GuiDriver.Get();
            var btnSendEmail = driver.FindElementByName("Send e-mail");
            btnSendEmail.Click();
        }

        [Then(@"I should see that fields are filled with data")]
        public void ThenIShouldSeeThatFieldsAreFilledWithData()
        {
            var driver = GuiDriver.Get();

            var txtFrom = driver.FindElementByAccessibilityId("txtFrom");
            string fromValue = txtFrom.Text.Trim();

            var txtBcc = driver.FindElementByAccessibilityId("txtBcc");
            string bccValue = txtBcc.Text.Trim();

            var txtSubject = driver.FindElementByAccessibilityId("txtSubject");
            string subjectValue = txtSubject.Text.Trim();

            var txtMessage = driver.FindElementByAccessibilityId("txtMessage");
            string messageValue = txtMessage.Text.Trim();

            var frmClose = driver.FindElementByAccessibilityId("FrmSendEmail").FindElementByAccessibilityId("Close");
            frmClose.Click();

            Assert.IsFalse(string.IsNullOrEmpty(fromValue), "Textbox is empty");
            Assert.IsFalse(string.IsNullOrEmpty(bccValue), "Textbox is empty");
            Assert.IsFalse(string.IsNullOrEmpty(subjectValue), "Textbox is empty");
            Assert.IsFalse(string.IsNullOrEmpty(messageValue), "Textbox is empty");
        }

        #endregion

        #region Information about the sender, recipient and content of the email can be edited

        [Then(@"I should be able to edit From, To, BCC, Subject, Message fields")]
        public void ThenIShouldBeAbleToEditFromToBCCSubjectMessageFields()
        {
            var driver = GuiDriver.Get();
            driver.SwitchTo().Window(driver.WindowHandles.First());

            var txtFrom = driver.FindElementByAccessibilityId("txtFrom");
            txtFrom.SendKeys("pero@gmail.com");
            string editedFromValue = txtFrom.Text.Trim();

            var txtTo = driver.FindElementByAccessibilityId("txtTo");
            txtTo.SendKeys("ttomasic20@student.foi.hr");
            string editedToValue = txtTo.Text.Trim();

            var txtBcc = driver.FindElementByAccessibilityId("txtBcc");
            txtBcc.SendKeys("tvelkovsk20@student.foi.hr");
            string editedBccValue = txtBcc.Text.Trim();

            var txtSubject = driver.FindElementByAccessibilityId("txtSubject");
            txtSubject.SendKeys("Novi naslov mail-a");
            string editedSubjectValue = txtSubject.Text.Trim();

            var txtMessage = driver.FindElementByAccessibilityId("txtMessage");
            txtMessage.SendKeys("Ovo je nova ureðena poruka u tijelu mail-a.");
            string editedMessageValue = txtMessage.Text.Trim();

            var frmClose = driver.FindElementByAccessibilityId("FrmSendEmail").FindElementByAccessibilityId("Close");
            frmClose.Click();

            Assert.IsNotNull(editedFromValue);
            Assert.IsNotNull(editedToValue);
            Assert.IsNotNull(editedBccValue);
            Assert.IsNotNull(editedSubjectValue);
            Assert.IsNotNull(editedMessageValue);            
        }

        #endregion

        #region Send an email to the entered email address of the team members.

        [When(@"I enter ""([^""]*)"" into To field")]
        public void ThenIEnterIntoToField(string p0)
        {
            var driver = GuiDriver.Get();
            driver.SwitchTo().Window(driver.WindowHandles.First());

            var txtTo = driver.FindElementByAccessibilityId("txtTo");
            txtTo.SendKeys(p0);           
        }

        [When(@"I click on Send button")]
        public void ThenIClickOnSendButton()
        {
            var driver = GuiDriver.Get();
            driver.SwitchTo().Window(driver.WindowHandles.First());

            var sendButton = driver.FindElementByAccessibilityId("btnSend");
            sendButton.Click();
        }

        [Then(@"Application sends email and close Send email form")]
        public void ThenApplicationSendsEmailAndCloseSendEmailForm()
        {
            var driver = GuiDriver.Get();

            WindowsElement messageBox = driver.FindElementByClassName("#32770");
            if (messageBox.Displayed)
            {
                WindowsElement messageBoxControl = (WindowsElement)messageBox.FindElementByXPath("//Text[@LocalizedControlType='text']");
                string actualErrorMessage = messageBoxControl.Text;
                messageBox.FindElementByName("OK").Click();

                Assert.Fail("Email sending failed with message: " + actualErrorMessage.Trim());
            }
            else
            {
            }
        }
        #endregion

        #region Email is not in correct format

        [When(@"I enter ""([^""]*)"" to From field")]
        public void ThenIEnterToFromField(string p0)
        {
            var driver = GuiDriver.Get();
            driver.SwitchTo().Window(driver.WindowHandles.First());

            var txtFrom = driver.FindElementByAccessibilityId("txtFrom");
            txtFrom.SendKeys(p0);
        }

        [When(@"I enter ""([^""]*)"" to To field")]
        public void ThenIEnterToToField(string p0)
        {
            var driver = GuiDriver.Get();
            driver.SwitchTo().Window(driver.WindowHandles.First());

            var txtTo = driver.FindElementByAccessibilityId("txtTo");
            txtTo.SendKeys(p0);
        }

        [When(@"I enter ""([^""]*)"" to BCC field")]
        public void ThenIEnterToBCCField(string p0)
        {
            var driver = GuiDriver.Get();
            driver.SwitchTo().Window(driver.WindowHandles.First());

            var txtBcc = driver.FindElementByAccessibilityId("txtBcc");
            txtBcc.SendKeys(p0);
        }

        [Then(@"I should see the error message that ""([^""]*)""")]
        public void ThenIShouldSeeTheErrorMessageThat(string p0)
        {
            var driver = GuiDriver.Get();

            WindowsElement messageBox = driver.FindElementByClassName("#32770");
                 
            WindowsElement messageBoxControl = (WindowsElement)messageBox.FindElementByXPath("//Text[@LocalizedControlType='text']");
            string actualErrorMessage = messageBoxControl.Text;
            messageBox.FindElementByName("OK").Click();

            Assert.AreEqual(p0, actualErrorMessage, "Error messages does not match.");
        }
        #endregion

    }
}
