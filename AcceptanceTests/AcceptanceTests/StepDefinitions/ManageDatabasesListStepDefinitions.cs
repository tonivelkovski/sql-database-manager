using AcceptanceTests.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows;
using TechTalk.SpecFlow;

namespace AcceptanceTests.StepDefinitions
{
    [Binding]
    public class ManageDatabasesListStepDefinitions
    {
        #region Database properties values modification disabled
        [When(@"I click-double-click on the database with the Name property set to baza_podataka in the DataGridView")]
        public void WhenIClick_Double_ClickOnTheDatabaseWithTheNamePropertySetToBaza_PodatakaInTheDataGridView()
        {
            var driver = GuiDriver.Get();

            var actions = new Actions(driver);
            var dgvDatabases = driver.FindElementByAccessibilityId("dgvDatabases");
            var element = dgvDatabases.FindElementByAccessibilityId("4226987408");

            actions.Click(element).DoubleClick().Perform();
        }

        [Then(@"the value should not be editable")]
        public void ThenTheValueShouldNotBeEditable()
        {
            var driver = GuiDriver.Get();

            var dgvDatabases = driver.FindElementByAccessibilityId("dgvDatabases");
            var element = dgvDatabases.FindElementByAccessibilityId("4241429416");

            var originalTextValue = element.Text;

            element.SendKeys("My random value");

            var newTextValue = element.Text;

            bool valueDidntChange = originalTextValue == newTextValue;

            Assert.IsTrue(valueDidntChange);
        }

        #endregion

        #region Single database can be selected

        [When(@"I click on the row number ""([^""]*)"" in the DataGridView")]
        public void WhenIClickOnTheRowNumberInTheDataGridView(string row)
        {
            var driver = GuiDriver.Get();

            driver.FindElementByName("Row " + row).Click();
        }

        #region DataGridRow rows selection implementation - explanation

        /*
        Becasue the selection pattern of rows or cells in DataGridView is not supported 
        so any property or method that is already implemented cannot be used, apropos to 
        that problem selecting rows is checked by the color of the selected row in DataGridView. 
        Because we are fetching the rectangle shape of the selected element color would not 
        always be 100% correct in all scenarios, it would give approximately the correct 
        RGB value of blue color. 9 tests where performed and following values where measured:

            Measurement1: R = 15, G =,106 B = 178;
            Measurement2: R = 16, G =,125 B = 212;
            Measurement3: R = 33, G =,115 B = 175;
            Measurement4: R = 45, G =,140 B = 208;
            Measurement5: R = 38, G =,135 B = 206;
            Measurement6: R = 16, G =,126 B = 213;
            Measurement7: R = 19, G =,127 B = 213;
            Measurement8: R = 19, G =,127 B = 213;
            Measurement1: R = 20, G =,12/ B = 213;

        So blue color would be considered as:
            R: 0-60
            G: 100-150
            B: 150-250
         */

        #endregion

        [Then(@"the row ""([^""]*)"" in the DataGridView should be marked as selected")]
        public void ThenTheRowInTheDataGridViewShouldBeMarkedAsSelected(string row)
        {
            var driver = GuiDriver.Get();

            var selectedRow = driver.FindElementByName("Row " + row);

            var rgb = GetColorOfRows(new List<AppiumWebElement> { selectedRow }.ToList()).First();

            bool isValid = IsColorInRange(rgb);

            Assert.IsTrue(isValid);
        }
        #endregion

        # region Multiple databases can be selected

        [When(@"I click on the ""([^""]*)"" row and on the ""([^""]*)"" row in the DataGridView")]
        public void WhenIClickOnTheRowAndOnTheRowInTheDataGridView(string row1, string row2)
        {
            var driver = GuiDriver.Get();

            var actions = new Actions(driver);

            var clickedRow1 = driver.FindElementByName("Row " + row1);
            var clickedRow2 = driver.FindElementByName("Row " + row2);

            actions.Click(clickedRow1).KeyDown(Keys.Shift).Click(clickedRow2).Perform();
        }

        [Then(@"both row ""([^""]*)"" and row ""([^""]*)"" should be marked as selected")]
        public void ThenBothRowAndRowShouldBeMarkedAsSelected(string row1, string row2)
        {
            var driver = GuiDriver.Get();

            var selectedRow1 = driver.FindElementByName("Row " + row1);
            var selectedRow2 = driver.FindElementByName("Row " + row2);

            var rgbs = GetColorOfRows(new List<AppiumWebElement> { selectedRow1, selectedRow2 }.ToList());

            foreach (var rgb in rgbs)
            {
                bool isValid = IsColorInRange(rgb);
                Assert.IsTrue(isValid);
            }
        }

        #endregion

        #region Selected database is deleted

        [When(@"I click on the database record with the Name property set to the ""([^""]*)"" in the DataGridView")]
        public void WhenIClickOnTheDatabaseRecordWithTheNamePropertySetToTheInTheDataGridView(string namePropertyValue)
        {
            var driver = GuiDriver.Get();

            var dgvValues = ReturnValuesFromDataGridView("Name");

            int index = dgvValues.IndexOf(namePropertyValue);

            driver.FindElementByName("Row " + index).Click();
        }

        [When(@"I click on the button Delete database")]
        public void WhenIClickOnTheButtonDeleteDatabase()
        {
            var driver = GuiDriver.Get();

            driver.FindElementByAccessibilityId("btnDelete").Click();
        }

        [When(@"I select ""([^""]*)"" in the message box question")]
        public void WhenISelectInTheMessageBoxQuestion(string option)
        {
            var driver = GuiDriver.Get();

            var messageBox = driver.FindElementByClassName("#32770");
            var button = messageBox.FindElementByName(option);

            button.Click();
        }

        [Then(@"database with the Name property set to the ""([^""]*)"" should be deleted")]
        public void ThenDatabaseWithTheNamePropertySetToTheShouldBeDeleted(string namePropertyValue)
        {
            var driver = GuiDriver.Get();

            var dgvValues = ReturnValuesFromDataGridView("Name");

            string foundValue = dgvValues.Find(item => item == namePropertyValue);

            Assert.IsNull(foundValue);
        }

        #endregion

        #region Selected database is not deleted

        [Then(@"database with the Name property set to the ""([^""]*)"" should not be deleted")]
        public void ThenDatabaseWithTheNamePropertySetToTheShouldNotBeDeleted(string namePropertyValue)
        {
            var driver = GuiDriver.Get();

            var dgvValues = ReturnValuesFromDataGridView("Name");

            string foundValue = dgvValues.Find(item => item == namePropertyValue);

            Assert.IsNotNull(foundValue);
        }

        #endregion

        #region Selected databases are deleted

        [When(@"I select the database record with the Name property set to the ""([^""]*)"" and database with the Name property set to the ""([^""]*)"" in the DataGridView")]
        public void WhenISelectTheDatabaseRecordWithTheNamePropertySetToTheAndDatabaseWithTheNamePropertySetToTheInTheDataGridView(string nameValue1, string nameValue2)
        {
            var driver = GuiDriver.Get();

            var actions = new Actions(driver);

            var dgvValues = ReturnValuesFromDataGridView("Name");

            int index1 = dgvValues.IndexOf(nameValue1);
            int index2 = dgvValues.IndexOf(nameValue2);

            var row1 = driver.FindElementByName("Row " + index1);
            var row2 = driver.FindElementByName("Row " + index2);

            actions.Click(row1).KeyDown(Keys.Shift).Click(row2).Perform();
        }

        [Then(@"database with the Name property set to the ""([^""]*)"" and database with the Name property set to the ""([^""]*)"" should be deleted")]
        public void ThenDatabaseWithTheNamePropertySetToTheAndDatabaseWithTheNamePropertySetToTheShouldBeDeleted(string namePropertyValue1, string namePropertyValue2)
        {
            var driver = GuiDriver.Get();

            var dgvValues = ReturnValuesFromDataGridView("Name");

            string foundValue1 = dgvValues.Find(item => item == namePropertyValue1);
            string foundValue2 = dgvValues.Find(item => item == namePropertyValue2);

            Assert.IsNull(foundValue1);
            Assert.IsNull(foundValue2);
        }

        #endregion

        #region Selected databases are not deleted

        [Then(@"database with the Name property set to the ""([^""]*)"" and database with the Name property set to the ""([^""]*)"" should not be deleted")]
        public void ThenDatabaseWithTheNamePropertySetToTheAndDatabaseWithTheNamePropertySetToTheShouldNotBeDeleted(string namePropertyValue1, string namePropertyValue2)
        {
            var driver = GuiDriver.Get();

            var dgvValues = ReturnValuesFromDataGridView("Name");

            string foundValue1 = dgvValues.Find(item => item == namePropertyValue1);
            string foundValue2 = dgvValues.Find(item => item == namePropertyValue2);

            Assert.IsNotNull(foundValue1);
            Assert.IsNotNull(foundValue2);
        }

        #endregion

        #region Selected databases are archived

        [When(@"I click on the button Archive database")]
        public void WhenIClickOnTheButtonArchiveDatabase()
        {
            var driver = GuiDriver.Get();

            var btnArchiveDatabase = driver.FindElementByAccessibilityId("btnArchive");

            btnArchiveDatabase.Click();
        }

        [Then(@"database with the Name property set to the ""([^""]*)"" should be archived")]
        public void ThenDatabaseWithTheNamePropertySetToTheShouldBeArchived(string nameValue)
        {
            var driver = GuiDriver.Get();

            var dgvValues = ReturnValuesFromDataGridView("Name");

            var foundValue = dgvValues.Find(item => item == nameValue);

            Assert.IsNull(foundValue);
        }

        #endregion

        #region Selected databases are not archived

        [Then(@"database with the Name property set to the ""([^""]*)"" and database with the Name property set to the ""([^""]*)"" should not be archived")]
        public void ThenDatabaseWithTheNamePropertySetToTheAndDatabaseWithTheNamePropertySetToTheShouldNotBeArchived(string namePropertyValue1, string namePropertyValue2)
        {
            var driver = GuiDriver.Get();

            var dgvValues = ReturnValuesFromDataGridView("Name");

            string foundValue1 = dgvValues.Find(item => item == namePropertyValue1);
            string foundValue2 = dgvValues.Find(item => item == namePropertyValue2);

            Assert.IsNotNull(foundValue1);
            Assert.IsNotNull(foundValue2);
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

        private bool IsColorInRange((int R, int G, int B) color)
        {
            bool rInRange = color.R >= 0 && color.R <= 60;
            bool gInRange = color.G >= 100 && color.G <= 150;
            bool bInRange = color.B >= 150 && color.B <= 250;

            return rInRange && gInRange && bInRange;
        }

        private List<(int, int, int)> GetColorOfRows(List<AppiumWebElement> rows)
        {
            var colorList = new List<(int, int, int)>();

            foreach (var row in rows)
            {
                var rect = GetRectangle(row);
                var bitmap = new Bitmap((int)rect.Width, (int)rect.Height);
                var graphics = Graphics.FromImage(bitmap);
                graphics.CopyFromScreen((int)rect.Left, (int)rect.Top, 0, 0, bitmap.Size);
                colorList.Add(GetAverageColor(bitmap));
            }

            return colorList;
        }

        private Rect GetRectangle(AppiumWebElement element)
        {
            var rect = element.GetAttribute("BoundingRectangle");

            string[] parts = rect.Split(' ');

            int left = int.Parse(parts[0].Substring(5));
            int top = int.Parse(parts[1].Substring(4));
            int width = int.Parse(parts[2].Substring(6));
            int height = int.Parse(parts[3].Substring(7));

            Rect rectangle = new Rect(left, top, width, height);

            return rectangle;
        }

        private (int, int, int) GetAverageColor(Bitmap bitmap)
        {
            var red = 0;
            var green = 0;
            var blue = 0;
            var count = 0;

            for (var x = 0; x < bitmap.Width; x++)
            {
                for (var y = 0; y < bitmap.Height; y++)
                {
                    var pixel = bitmap.GetPixel(x, y);
                    red += pixel.R;
                    green += pixel.G;
                    blue += pixel.B;
                    count++;
                }
            }

            return (red / count, green / count, blue / count);
        }

        #endregion

    }
}