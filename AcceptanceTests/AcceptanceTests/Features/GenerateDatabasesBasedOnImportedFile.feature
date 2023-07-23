Feature: Generate databases based on imported file

As an user
I want to be able to import .csv file with databases data
So that databases are added as entry and can be generated

Background:
	Given I am logged as an administrator
	And I am on the MS SQL Database Generator form

Scenario: Add empty entry
	When I click on Add entries button
	Then I should see error message that "Empty entry cannot be added!"
	
Scenario: Add no file
	When I click on Browse file... button
	And I click on Open button
	Then I should see error message "You didn't select any file."

