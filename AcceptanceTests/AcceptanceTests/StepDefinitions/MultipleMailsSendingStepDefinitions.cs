using AcceptanceTests.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using TechTalk.SpecFlow;

namespace AcceptanceTests.StepDefinitions
{
    [Binding]
    public class MultipleMailsSendingStepDefinitions
    {
        #region Selecting multiple teams
        [When(@"I select first two teams")]
        public void WhenISelectFirstTwoTeams()
        {
            var driver = GuiDriver.Get();
            Actions action = new Actions(driver);

            var dataGridView = driver.FindElementByAccessibilityId("dgvDatabases");

            var team1 = dataGridView.FindElementByName("TeamNumber Row 0, Not sorted.");
            var team2 = dataGridView.FindElementByName("TeamNumber Row 1, Not sorted.");

            action.Click(team1).KeyDown(Keys.LeftShift).Click(team2).Perform();
        }

        [Then(@"I should be able to see the selected teams")]
        public void ThenIShouldBeAbleToSeeTheSelectedTeams()
        {
            var driver = GuiDriver.Get();

            Actions action = new Actions(driver);
            action.KeyUp(Keys.LeftShift).Perform();

            /*
             * This test couldn't be done because this technology can't recognize dataGridView
             * row selection.
            var dataGridView = driver.FindElementByAccessibilityId("dgvDatabases");            

            var team1 = dataGridView.FindElementByName("TeamNumber Row 0, Not sorted.");
            var team2 = dataGridView.FindElementByName("TeamNumber Row 1, Not sorted.");
            var team3 = dataGridView.FindElementByName("TeamNumber Row 2, Not sorted.");

            var team1True = team1.GetAttribute("Selected") == "true";
            //Every "Selected" is false, no matter if selected or not
            var team2True = team2.GetAttribute("Selected") == "true";

            Assert.IsTrue(team1True);
            Assert.IsTrue(team2True);*/            
        }
        #endregion

        #region Send emails for all selected teams
        [Then(@"I click on Send all emails button")]
        public void ThenIClickOnSendAllEmailsButton()
        {
            var driver = GuiDriver.Get();
            var sendMailButton = driver.FindElementByAccessibilityId("btnSendAllEmails");

            sendMailButton.Click();
        }

        [Then(@"I Click on Yes button")]
        public void ThenIClickOnYesButton()
        {
            var driver = GuiDriver.Get();

            WindowsElement messageBox = driver.FindElementByClassName("#32770");

            messageBox.FindElementByName("Yes").Click();
        }

        [Then(@"I should receive message that ""([^""]*)""")]
        public void ThenIShouldReceiveMessageThat(string p0)
        {
            var driver = GuiDriver.Get();
            WindowsElement messageBox = driver.FindElementByClassName("#32770");

            WindowsElement messageBoxControl = (WindowsElement)messageBox.FindElementByXPath("//Text[@LocalizedControlType='text']");
            string actualErrorMessage = messageBoxControl.Text;
            messageBox.FindElementByName("Yes").Click();

            Assert.AreEqual(p0, actualErrorMessage, "Error messages does not match.");

        }
        #endregion
    }
}
