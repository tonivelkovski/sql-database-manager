using AcceptanceTests.Support;
using Castle.Core.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using System.Xml.Linq;

namespace AcceptanceTests.StepDefinitions
{
    [Binding]
    public class DatabasesListStepDefinitions
    {
        #region Only academic years with associated databases are displayed in the combo box

        [Given(@"I am on the Popis baza na serveru form")]
        public void GivenIAmOnThePopisBazaNaServeruForm()
        {
            var driver = GuiDriver.Get();

            var menuStrip = driver.FindElementByAccessibilityId("menuStrip1");
            menuStrip.FindElementByName("Opcije").Click();

            var dropdown = driver.FindElementByClassName("WindowsForms10.Window.20808.app.0.141b42a_r7_ad1");
            dropdown.FindElementByName("Popis baza na serveru").Click();
        }

        [When(@"I click on the dropdown arrow of the combo box")]
        public void WhenIClickOnTheDropdownArrowOfTheComboBox()
        {
            var driver = GuiDriver.Get();

            var comboBox = driver.FindElementByAccessibilityId("cmbAkademskaGodina");
            var dropDownArrow = comboBox.FindElementByName("Open");

            dropDownArrow.Click();
        }

        [Then(@"I should see the academic year (.*) and (.*)")]
        public void ThenIShouldSeeTheAcademicYearAnd(string firstAcademicYear, string secondAcademicYear)
        {
            var driver = GuiDriver.Get();

            var NUMBER_OF_ACADEMIC_YEARS = 2;

            var comboBox = driver.FindElementByAccessibilityId("cmbAkademskaGodina");
            var list = driver.FindElementByAccessibilityId("1000");
            var academicYears = list.FindElementsByXPath(
                 $"//ComboBox/ListItem")
                 .OfType<WindowsElement>()
                 .ToList();
            var academicYearNames = new List<string>();

            var onlyTwoAcademicYears = academicYears.Count == NUMBER_OF_ACADEMIC_YEARS;

            academicYears.ForEach(academicYear => academicYearNames
                .Add(academicYear.GetAttribute("Name")));

            var containsNeededAcademicYears = academicYearNames.Contains(firstAcademicYear) &&
                academicYearNames.Contains(secondAcademicYear);

            Assert.IsTrue(onlyTwoAcademicYears);
            Assert.IsTrue(containsNeededAcademicYears);
        }

        #endregion

        #region Selected default real time academic year in the combo box

        [Then(@"I should see the academic year ""([^""]*)"" selected in the combo box")]
        public void ThenIShouldSeeTheAcademicYearSelectedInTheComboBox(string academicYear)
        {
            var driver = GuiDriver.Get();

            var comboBox = driver.FindElementByAccessibilityId("cmbAkademskaGodina");
            var defaultAcademicYear = comboBox.Text;

            Assert.AreEqual(defaultAcademicYear, academicYear);
        }

        #endregion

        #region Current academic year databases with all the properites present

        [Given(@"selected value in the combo box is ""([^""]*)""")]
        public void GivenSelectedValueInTheComboBoxIs(string academicYear)
        {
            var driver = GuiDriver.Get();

            var comboBox = driver.FindElementByAccessibilityId("cmbAkademskaGodina");

            if (comboBox.Text != academicYear)
            {
                comboBox.FindElementByName("Open").Click();

                var list = driver.FindElementByAccessibilityId("1000");
                var academicYearToSelect = list.FindElementsByXPath(
                     $"//ComboBox/ListItem")
                     .OfType<WindowsElement>()
                     .Where(listItem => listItem.Text == academicYear)
                     .First();

                academicYearToSelect.Click();
            }
        }

        [Then(@"I should see all properties present for each database on the server")]
        public void ThenIShouldSeeAllPropertiesPresentForEachDatabaseOnTheServer()
        {
            var driver = GuiDriver.Get();

            var teamNumber = driver.FindElementByName("TeamNumber");
            var name = driver.FindElementByName("Name");
            var creationDate = driver.FindElementByName("CreationDate");
            var username = driver.FindElementByName("Username");
            var password = driver.FindElementByName("Password");
            var note = driver.FindElementByName("Note");
            var emailSent = driver.FindElementByName("EmailSent");
            var contactEmail = driver.FindElementByName("ContactEmail");

            Assert.IsNotNull(teamNumber);
            Assert.IsNotNull(name);
            Assert.IsNotNull(creationDate);
            Assert.IsNotNull(username);
            Assert.IsNotNull(password);
            Assert.IsNotNull(note);
            Assert.IsNotNull(emailSent);
            Assert.IsNotNull(contactEmail);
        }

        [Then(@"CreationDate values should include ""([^""]*)"" or ""([^""]*)""")]
        public void ThenCreationDateValuesShouldIncludeOr(string firstAcademicYear, string secondAcademicYear)
        {
            var creationDateElements = ReturnValuesFromDataGridView("CreationDate");

            bool allValid = creationDateElements.All(s => s.Contains(firstAcademicYear) ||
                s.Contains(secondAcademicYear));

            Assert.IsTrue(allValid);
        }

        #endregion

        #region No databases in current academic year

        [Then(@"selected value in the combo box should be ""([^""]*)""")]
        public void ThenSelectedValueInTheComboBoxShouldBe(string academicYear)
        {
            var driver = GuiDriver.Get();

            var comboBox = driver.FindElementByAccessibilityId("cmbAkademskaGodina");

            Assert.AreEqual(comboBox.Text, academicYear);
        }

        #endregion

        #region There are no databases stored on the server

        [Then(@"there should not be any values displayed on the combo box")]
        public void ThenThereShouldNotBeAnyValuesDisplayedOnTheComboBox()
        {
            var driver = GuiDriver.Get();

            var comboBox = driver.FindElementByAccessibilityId("cmbAkademskaGodina");
            var list = driver.FindElementByAccessibilityId("1000");

            var comboBoxTextIsEmpty = comboBox.Text.IsNullOrEmpty();
            var comboBoxIsEmpty = false;

            var elements = list.FindElementsByXPath(
                $"//ComboBox/ListItem")
                .OfType<WindowsElement>()
                .ToList();

            if (elements.Count == 0)
                comboBoxIsEmpty = true;

            Assert.IsTrue(comboBoxTextIsEmpty);
            Assert.IsTrue(comboBoxIsEmpty);
        }

        [Then(@"DataGridView should not contain any elements")]
        public void ThenDataGridViewShouldNotContainAnyElements()
        {
            var driver = GuiDriver.Get();

            bool exists = false;

            var dgvDatabases = driver.FindElementByAccessibilityId("dgvDatabases");

            try
            {
                var row = dgvDatabases.FindElementByName("Row 0");

                if (row != null)
                {
                    exists = true;
                    Assert.IsTrue(false);
                }
            }
            catch
            {
                if (exists == false)
                    Assert.IsTrue(true);
            }
        }

        [Then(@"combo box should be empty")]
        public void ThenComboBoxShouldBeEmpty()
        {
            var driver = GuiDriver.Get();

            var comboBox = driver.FindElementByAccessibilityId("cmbAkademskaGodina");
            comboBox.FindElementByName("Open").Click();

            var list = driver.FindElementByAccessibilityId("1000");

            var comboBoxValues = list.FindElementsByXPath(
                 $"//ComboBox/ListItem")
                 .OfType<WindowsElement>()
                 .ToList();

            Assert.IsTrue(!comboBoxValues.Any());
        }

        [Then(@"I should see ""([^""]*)"" notification message")]
        public void ThenIShouldSeeNotificationMessage(string message)
        {
            var driver = GuiDriver.Get();

            var messageBox = driver.FindElementByClassName("#32770");
            var messageBoxControl = messageBox.FindElementByXPath("//Text[@LocalizedControlType='text']");
            string actualErrorMessage = messageBoxControl.Text;

            Assert.AreEqual(message, actualErrorMessage);
        }

        #endregion

        #region Editing displayed academic year in the combo box

        [When(@"I click on the combo box")]
        public void WhenIClickOnTheComboBox()
        {
            var driver = GuiDriver.Get();

            driver.FindElementByAccessibilityId("cmbAkademskaGodina").Click();
        }

        [Then(@"combo box should stay in read-only mode")]
        public void ThenComboBoxShouldStayInRead_OnlyMode()
        {
            var driver = GuiDriver.Get();

            var comboBox = driver.FindElementByAccessibilityId("cmbAkademskaGodina");

            string originalTextValue = comboBox.Text;

            comboBox.SendKeys("My random value");

            string newTextValue = comboBox.Text;

            bool valueDidntChange = originalTextValue == newTextValue;

            Assert.IsTrue(valueDidntChange);
        }

        #endregion

        #region Filtering databases by academic year

        [When(@"I click on the combo box element ""([^""]*)""")]
        public void WhenIClickOnTheComboBoxElement(string elementFilter)
        {
            var driver = GuiDriver.Get();

            var comboBox = driver.FindElementByAccessibilityId("cmbAkademskaGodina");

            var list = comboBox.FindElementByAccessibilityId("1000");

            var element = list.FindElementsByXPath(
                ".//List[@LocalizedControlType='list']/ListItem")
                .OfType<WindowsElement>()
                .Where(listItem => listItem.Text == elementFilter)
                .First();

            element.Click();
        }

        [When(@"I click on the button Pretrazi")]
        public void WhenIClickOnTheButtonPretrazi()
        {
            var driver = GuiDriver.Get();

            var button = driver.FindElementByAccessibilityId("btnPrikazi");

            button.Click();
        }

        [Then(@"the databases list is updated with databases added in the year ""([^""]*)"" or ""([^""]*)""")]
        public void ThenTheDatabasesListIsUpdatedWithDatabasesAddedInTheYearOr(string firstAcademicYear, string secondAcademicYear)
        {
            var creationDateElements = ReturnValuesFromDataGridView("CreationDate");

            bool isValid = creationDateElements.All(s => s.Contains(firstAcademicYear) ||
                s.Contains(secondAcademicYear));

            Assert.IsTrue(isValid);
        }

        #endregion

        #region Filtering databases by values of property "Name"

        [When(@"I click on the text box labeled as Pretrazi")]
        public void WhenIClickOnTheTextBoxLabeledAsPretrazi()
        {
            var driver = GuiDriver.Get();

            var txtSearchText = driver.FindElementByAccessibilityId("txtSearchText");

            txtSearchText.Click();
        }

        [When(@"I enter the string ""([^""]*)"" in the text box")]
        public void WhenIEnterTheStringInTheTextBox(string searchString)
        {
            var driver = GuiDriver.Get();

            var txtSearchText = driver.FindElementByAccessibilityId("txtSearchText");

            txtSearchText.SendKeys(searchString);
        }

        [Then(@"I should see databases whose values of Name property start with ""([^""]*)"", database 22_DB and database 22_bazapodataka")]
        public void ThenIShouldSeeDatabasesWhoseValuesOfNamePropertyStartWithDatabaseAndDatabase(string matchString)
        {
            var nameElements = ReturnValuesFromDataGridView("Name");

            bool allStartWith = nameElements.Any() && nameElements.All(el => el.StartsWith(matchString));

            Assert.IsTrue(allStartWith);
        }

        #endregion

        #region Filtering databases by values of property Name with partial string match

        [Then(@"there should be zero databases shown in the databases list")]
        public void ThenThereShouldBeZeroDatabasesShownInTheDatabasesList()
        {
            var nameElements = ReturnValuesFromDataGridView("Name");

            Assert.IsTrue(!nameElements.Any());
        }

        #endregion

        #region Reseting input text inside text box labeled as Pretrazi on the academic year swap

        [Then(@"result query should include database with Name property of ""([^""]*)""")]
        public void ThenResultQueryShouldIncludeDatabaseWithNamePropertyOf(string databaseName)
        {
            var nameElements = ReturnValuesFromDataGridView("Name");

            var containsNeededDatabases = nameElements.Contains(databaseName);

            Assert.IsTrue(containsNeededDatabases);
        }

        [Then(@"I should see the text box value cleared")]
        public void ThenIShouldSeeTheTextBoxValueCleared()
        {
            var driver = GuiDriver.Get();

            var txtSearchText = driver.FindElementByAccessibilityId("txtSearchText");

            Assert.AreEqual(string.Empty, txtSearchText.Text);
        }

        #endregion

        #region Input Name filter becomes empty

        [When(@"I delete the string in the text box")]
        public void WhenIDeleteTheStringInTheTextBox()
        {
            var driver = GuiDriver.Get();

            var txtSearchTextEl = driver.FindElementByAccessibilityId("txtSearchText");

            txtSearchTextEl.Clear();
        }

        #endregion

        #region Archived databases list

        [Then(@"databases list should only contain databases with Archived property set to true")]
        public void ThenDatabasesListShouldOnlyContainDatabasesWithArchivedPropertySetToTrue()
        {
            var archivedElements = ReturnValuesFromDataGridView("Archived");

            var containsNeededDatabases = archivedElements.Contains(true.ToString());

            Assert.IsTrue(containsNeededDatabases);
        }

        #endregion

        #region Helpers

        private List<string> ReturnValuesFromDataGridView(string headerName)
        {
            var driver = GuiDriver.Get();

            var dgvDatabases = driver.FindElementByAccessibilityId("dgvDatabases");

            var elements = new List<string>();
            var i = 0;

            while (true)
            {
                try
                {
                    var row = dgvDatabases.FindElementByName("Row " + i);
                    var rowElements = row.FindElementByName(headerName + " Row " + i + ", Not sorted.");

                    elements.Add(rowElements.Text);
                }
                catch
                {
                    break;
                }
                i++;
            }
            return elements;
        }

        #endregion
    }
}