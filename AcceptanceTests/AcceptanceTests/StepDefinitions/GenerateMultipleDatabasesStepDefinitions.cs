using AcceptanceTests.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;

namespace AcceptanceTests.StepDefinitions
{
    [Binding]
    public class GenerateMultipleDatabasesStepDefinitions
    {
        [When(@"I enter ""([^""]*)"" as database prefix in database prefix field")]
        public void WhenIEnterAsDatabasePrefixInDatabasePrefixField(string p0)
        {
            var driver = GuiDriver.Get();
            var txtPrefix = driver.FindElementByAccessibilityId("txtDatabasePrefix");
            txtPrefix.SendKeys(p0);
        }

        [When(@"I enter ""([^""]*)"" as database sufix in database sufix field")]
        public void WhenIEnterAsDatabaseSufixInDatabaseSufixField(string dB)
        {
            var driver = GuiDriver.Get();
            var txtSufix = driver.FindElementByAccessibilityId("txtDatabaseSufix");
            txtSufix.SendKeys(dB);
        }

        [When(@"I enter ""([^""]*)"" in first team number field")]
        public void WhenIEnterInFirstTeamNumberField(string p0)
        {
            var driver = GuiDriver.Get();
            var txtFirstNumber = driver.FindElementByAccessibilityId("txtFirstTeamNumber");
            txtFirstNumber.SendKeys(p0);
        }

        [When(@"I enter ""([^""]*)"" in last team number field")]
        public void WhenIEnterInLastTeamNumberField(string p0)
        {
            var driver = GuiDriver.Get();
            var txtLastNumber = driver.FindElementByAccessibilityId("txtLastTeamNumber");
            txtLastNumber.SendKeys(p0);
        }

        [When(@"I click Add entries button")]
        public void WhenIClickAddEntriesButton()
        {
            var driver = GuiDriver.Get();
            var btnAddEntries = driver.FindElementByAccessibilityId("btnAddMultipleDatabases");
            btnAddEntries.Click();
        }

        [Then(@"I should see entries added on form")]
        public void ThenIShouldSeeEntriesAddedOnForm()
        {
            var driver = GuiDriver.Get();
            var dgvDatabases = driver.FindElementByAccessibilityId("dgvDatabases");
            var addedEntry1 = dgvDatabases.FindElementByName("Team Row 0, Not sorted.");
            var addedEntry2 = dgvDatabases.FindElementByName("Team Row 1, Not sorted.");
            var addedEntry3 = dgvDatabases.FindElementByName("Team Row 2, Not sorted.");
            var addedEntry4 = dgvDatabases.FindElementByName("Team Row 3, Not sorted.");
            var addedEntry5 = dgvDatabases.FindElementByName("Team Row 4, Not sorted.");
            var addedEntry6 = dgvDatabases.FindElementByName("Team Row 5, Not sorted.");

            if (addedEntry1 != null || addedEntry2 != null || addedEntry3 != null ||
                addedEntry5 != null || addedEntry4 != null || addedEntry6 != null)
            {
            }
            else
            {
                Assert.Fail("Entries were not added!");
            }
        }

        [When(@"I click Generate databases button")]
        public void WhenIClickGenerateDatabasesButton()
        {
            var driver = GuiDriver.Get();
            var btnGenerateDatabases = driver.FindElementByAccessibilityId("btnGenerateDatabases");
            btnGenerateDatabases.Click();
        }
    }
}
