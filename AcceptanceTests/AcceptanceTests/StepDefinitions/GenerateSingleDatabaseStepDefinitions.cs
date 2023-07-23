using AcceptanceTests.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using System;
using TechTalk.SpecFlow;

namespace AcceptanceTests.StepDefinitions
{
    [Binding]
    public class GenerateSingleDatabaseStepDefinitions
    {
        [Given(@"I am on the MS SQL Database Generator form")]
        public void GivenIAmOnTheMSSQLDatabaseGeneratorForm()
        {
            var driver = GuiDriver.Get();
            var menuStrip = driver.FindElementByAccessibilityId("menuStrip1");
            menuStrip.FindElementByName("Opcije").Click();

            var dropdown = driver.FindElementByClassName("WindowsForms10.Window.20808.app.0.141b42a_r7_ad1");
            dropdown.FindElementByName("Generiranje baza za studente").Click();

            var dgvDatabases = driver.FindElementByAccessibilityId("dgvDatabases");
            dgvDatabases.Clear();
        }

        [When(@"I uncheck Auto-generate entries checkbox")]
        public void WhenIUncheckAuto_GenerateEntriesCheckbox()
        {
            var driver = GuiDriver.Get();
            var checkboxCheck = driver.FindElementByAccessibilityId("chkSuggestNames");
            if (checkboxCheck.Selected)
            {
                checkboxCheck.Click();
            }
        }

        [When(@"I enter ""([^""]*)"" as team number in the Team number field")]
        public void WhenIEnterAsTeamNumberInTheTeamNumberField(string p0)
        {
            var driver = GuiDriver.Get();
            var txtTeamNumber = driver.FindElementByAccessibilityId("txtTeamNumber");
            txtTeamNumber.SendKeys(p0);
        }

        [When(@"I enter ""([^""]*)"" as database name in the Database name field")]
        public void WhenIEnterAsDatabaseNameInTheDatabaseNameField(string p0)
        {
            var driver = GuiDriver.Get();
            var txtDatabaseName = driver.FindElementByAccessibilityId("txtDatabaseName");
            txtDatabaseName.SendKeys(p0);
        }

        [When(@"I enter ""([^""]*)"" as username in the Username field")]
        public void WhenIEnterAsUsernameInTheUsernameField(string p0)
        {
            var driver = GuiDriver.Get();
            var txtUsername = driver.FindElementByAccessibilityId("txtUsername");
            txtUsername.SendKeys(p0);                
        }

        [When(@"I enter ""([^""]*)"" as password in the User password field")]
        public void WhenIEnterAsPasswordInTheUserPasswordField(string p0)
        {
            var driver = GuiDriver.Get();
            var txtUserPassword = driver.FindElementByAccessibilityId("txtUserPassword");
            txtUserPassword.SendKeys(p0);                
        }

        [When(@"I click Add entry button")]
        public void WhenIClickAddEntryButton()
        {
            var driver = GuiDriver.Get();
            var btnAddDatabase = driver.FindElementByAccessibilityId("btnAddDatabase");
            btnAddDatabase.Click();
        }

        [Then(@"I should see added entry on form")]
        public void ThenIShouldSeeAddedEntryOnForm()
        {                     
            var driver = GuiDriver.Get();
            var dgvDatabases = driver.FindElementByAccessibilityId("dgvDatabases");
            var addedEntry1 = dgvDatabases.FindElementByName("Team Row 0, Not sorted.");
           
            if (addedEntry1 != null)
            {
            }
            else
            {
                Assert.Fail("Entry was not added!");
            } 
        }

        [When(@"I check Auto-generate entries checkbox")]
        public void WhenICheckAuto_GenerateEntriesCheckbox()
        {
            var driver = GuiDriver.Get();
            var checkboxCheck = driver.FindElementByAccessibilityId("chkSuggestNames");
            if (checkboxCheck.Selected == false)
            {
                checkboxCheck.Click();
            }
        }

        [When(@"I select first entry")]
        public void WhenISelectFirstEntry()
        {
            var driver = GuiDriver.Get();
            var dgvDatabases = driver.FindElementByAccessibilityId("dgvDatabases");
            var addedEntry = dgvDatabases.FindElementByName("Team Row 0, Not sorted.");
            addedEntry.Click();            
        }

        [When(@"I click delete button")]
        public void WhenIClickDeleteButton()
        {
            var driver = GuiDriver.Get();
            var btnDelete = driver.FindElementByAccessibilityId("btnDeleteDatabase");
            btnDelete.Click();
        }

        [Then(@"I should see form withot deleted entry")]
        public void ThenIShouldSeeFormWithotDeletedEntry()
        {
            var driver = GuiDriver.Get();
            var dgvDatabases = driver.FindElementByAccessibilityId("dgvDatabases");
            try
            {
                var addedEntry = dgvDatabases.FindElementByName("Team Row 0, Not sorted.");
            }catch(WebDriverException)
            {
                return;
            }
            Assert.Fail("The deleted entry was found in the form.");
        }

        [Then(@"I should see error message that ""([^""]*)"" with fields that are empty")]
        public void ThenIShouldSeeErrorMessageThatWithFieldsThatAreEmpty(string p0)
        {
            var driver = GuiDriver.Get();
            WindowsElement messageBox = driver.FindElementByClassName("#32770");           

            WindowsElement messageBoxControl = (WindowsElement)messageBox.FindElementByXPath("//Text[@LocalizedControlType='text']");
            string actualErrorMessage = messageBoxControl.Text;            
            messageBox.FindElementByName("OK").Click();

            Assert.AreEqual(p0, actualErrorMessage, "Error messages does not match.");
        }

        [When(@"I click generate database button")]
        public void WhenIClickGenerateDatabaseButton()
        {
            var driver = GuiDriver.Get();
            var btnGenerateDatabases = driver.FindElementByAccessibilityId("btnGenerateDatabases");
            btnGenerateDatabases.Click();
        }

        [Then(@"I should see message that ""([^""]*)""")]
        public void ThenIShouldSeeMessageThat(string p0)
        {
            var driver = GuiDriver.Get();
            WindowsElement messageBox = driver.FindElementByClassName("#32770");

            WindowsElement messageBoxControl = (WindowsElement)messageBox.FindElementByXPath("//Text[@LocalizedControlType='text']");
            string actualErrorMessage = messageBoxControl.Text;
            messageBox.FindElementByName("Yes").Click();
            messageBox.FindElementByName("OK").Click();

            Assert.AreEqual(p0, actualErrorMessage, "Error messages does not match.");
        }
    }
}
