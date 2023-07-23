Feature: DatabasesList

As a user
I want to be able to see databases filtered by specific academic year 
or filtered by Name of the team for which the database is created
so I can manage databases in an organized and more efficient way.

Background:
	Given I am logged as an administrator
	And I am on the Popis baza na serveru form

Scenario: Only academic years with associated databases are displayed in the combo box
	When I click on the dropdown arrow of the combo box
	Then I should see the academic year 2021/2022 and 2022/2023

Scenario: Selected default real time academic year in the combo box
	Then I should see the academic year "2022/2023" selected in the combo box

Scenario: Current academic year databases with all the properites present
	And selected value in the combo box is "2022/2023"
	Then I should see all properties present for each database on the server
	And CreationDate values should include "2022" or "2023"

Scenario: No databases in current academic year
	Then selected value in the combo box should be "2021/2022"
	
Scenario: There are no databases stored on the server
	When I click on the dropdown arrow of the combo box
	Then there should not be any values displayed on the combo box
	Then DataGridView should not contain any elements
	And combo box should be empty
	And I should see "There are no stored databases on the server" notification message

Scenario: Editing displayed academic year in the combo box
	And selected value in the combo box is "2022/2023"
	When I click on the combo box
	Then combo box should stay in read-only mode

Scenario: Filtering databases by academic year
	And selected value in the combo box is "2022/2023"
	When I click on the dropdown arrow of the combo box
	And I click on the combo box element "2021/2022"
	And I click on the button Pretrazi
	Then the databases list is updated with databases added in the year "2021" or "2022"

Scenario: Filtering databases by values of property "Name"
	And selected value in the combo box is "2022/2023"
	When I click on the text box labeled as Pretrazi
	And I enter the string "22" in the text box
	Then I should see databases whose values of Name property start with "22", database 22_DB and database 22_bazapodataka

Scenario: Filtering databases by values of property Name with partial string match
	And selected value in the combo box is "2022/2023"
	When I click on the text box labeled as Pretrazi
	And I enter the string "baya_podataka" in the text box
	Then there should be zero databases shown in the databases list

Scenario: Reseting input text inside text box labeled as Pretrazi on the academic year swap
	And selected value in the combo box is "2022/2023"
	When I click on the text box labeled as Pretrazi
	And I enter the string "baya1" in the text box
	And I click on the dropdown arrow of the combo box
	And I click on the combo box element "2021/2022"
	And I click on the button Pretrazi
	Then result query should include database with Name property of "DatabaseA"
	And I should see the text box value cleared

Scenario: Input Name filter becomes empty
	And selected value in the combo box is "2022/2023"
	When I click on the text box labeled as Pretrazi
	And I enter the string "a" in the text box
	And I delete the string in the text box
	Then result query should include database with Name property of "22_DB"

Scenario: Archived databases list
	When I click on the dropdown arrow of the combo box
	And I click on the combo box element "Archive"
	And I click on the button Pretrazi
	Then databases list should only contain databases with Archived property set to true