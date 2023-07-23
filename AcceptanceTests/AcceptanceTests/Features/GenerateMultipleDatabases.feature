Feature: GenerateMultipleDatabases

As an user
I want to be able to generate multiple databases with access data
So that more than one database is generated on MS SQL server at once

Background:
	Given I am logged as an administrator
	And I am on the MS SQL Database Generator form

Scenario: Added multiple database entries
	When I enter "TIKPP_" as database prefix in database prefix field
	And I enter "DB" as database sufix in database sufix field
	And I enter "5" in first team number field
	And I enter "10" in last team number field
	And I click Add entries button
	Then I should see entries added on form

Scenario: Add empty entry
	When I click Add entries button
	Then I should see error message that "Empty entry cannot be added!"

Scenario: Add incomplete entry
	When I enter "TIKPP_" as database prefix in database prefix field
	And I enter "DB" as database sufix in database sufix field
	And I click Add entries button
	Then I should see error message that "Entry is incomplete!" with fields that are empty

Scenario: First team number is greater than last team number
	When I enter "TIKPP_" as database prefix in database prefix field
	And I enter "DB" as database sufix in database sufix field
	And I enter "10" in first team number field
	And I enter "5" in last team number field
	And I click Add entries button
	Then I should see error message that "First and last team numbers must be integers, with first number being smaller than the last number!"

Scenario: Generated databases on the MS SQL server based on entries
	When I enter "TIKPP_" as database prefix in database prefix field
	And I enter "DB" as database sufix in database sufix field
	And I enter "5" in first team number field
	And I enter "10" in last team number field
	And I click Add entries button
	And I click Generate databases button
	Then I should see message that "Databases are successfully generated on MS SQL Server"

