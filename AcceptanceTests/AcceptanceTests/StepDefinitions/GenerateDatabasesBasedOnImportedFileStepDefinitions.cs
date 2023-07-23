using AcceptanceTests.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using System;
using TechTalk.SpecFlow;

namespace AcceptanceTests.StepDefinitions
{
    [Binding]
    public class GenerateDatabasesBasedOnImportedFileStepDefinitions
    {
        [When(@"I click on Add entries button")]
        public void WhenIClickOnAddEntriesButton()
        {
            var driver = GuiDriver.Get();
            var btnAddEntries = driver.FindElementByAccessibilityId("btnAddEntriesFromFile");
            btnAddEntries.Click();
        }

        [When(@"I click on Browse file\.\.\. button")]
        public void WhenIClickOnBrowseFile_Button()
        {
            var driver = GuiDriver.Get();
            var btnBrowse = driver.FindElementByAccessibilityId("btnBrowse");
            btnBrowse.Click();
        }

        [When(@"I click on Open button")]
        public void WhenIClickOnOpenButton()
        {
            var driver = GuiDriver.Get();
            var btnOpen = driver.FindElementByAccessibilityId("1");
            btnOpen.Click();
        }

        [Then(@"I should see error message ""([^""]*)""")]
        public void ThenIShouldSeeErrorMessage(string p0)
        {
            var driver = GuiDriver.Get();
            WindowsElement messageBox = driver.FindElementByClassName("#32770");

            WindowsElement messageBoxControl = (WindowsElement)messageBox.FindElementByXPath("//Text[@LocalizedControlType='text']");
            string actualErrorMessage = messageBoxControl.Text;            

            Assert.AreEqual(p0, actualErrorMessage, "Error messages does not match.");
        }
    }
}
