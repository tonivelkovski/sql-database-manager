Feature: Generate single database

As an user
I want to be able to generate one database with access data
So that it is generated on MS SQL server

Background:
	Given I am logged as an administrator
	And I am on the MS SQL Database Generator form

Scenario: Adding database entries by manually filling database data fields
	When I uncheck Auto-generate entries checkbox
	And I enter "TIKPP_01" as team number in the Team number field
	And I enter "TIKPP_01_DB" as database name in the Database name field
	And I enter "TIKPP_01_User" as username in the Username field
	And I enter "p4ssw0rd" as password in the User password field
	And I click Add entry button
	Then I should see added entry on form

Scenario: Adding database entries by auto-generating database data
	When I check Auto-generate entries checkbox
	And I enter "TIKPP_01" as team number in the Team number field
	And I click Add entry button
	Then I should see added entry on form

Scenario: Deleting database entries from list
	When I check Auto-generate entries checkbox
	And I enter "TIKPP_01" as team number in the Team number field
	And I click Add entry button
	And I select first entry
	And I click delete button
	Then I should see form withot deleted entry

Scenario: Add empty entry
	When I click Add entry button
	Then I should see error message that "Empty entry cannot be added!"

Scenario: Add incomplete entry
	When I uncheck Auto-generate entries checkbox
	And I enter "TIKPP_01" as team number in the Team number field
	And I enter "TIKPP_01_DB" as database name in the Database name field
	And I enter "p4ssw0rd" as password in the User password field
	And I click Add entry button
	Then I should see error message that "Entry is incomplete!" with fields that are empty

Scenario: Generated database on the MS SQL server by manually adding database data entries
	When I uncheck Auto-generate entries checkbox
	And I enter "TIKPP_01" as team number in the Team number field
	And I enter "TIKPP_01_DB" as database name in the Database name field
	And I enter "TIKPP_01_User" as username in the Username field
	And I enter "p4ssw0rd" as password in the User password field
	And I click Add entry button
	And I click generate database button
	Then I should see message that "Database successfully generated on MS SQL Server"

Scenario: Generated database on the MS SQL server by auto-generating database data entries
	When I check Auto-generate entries checkbox
	And I enter "TIKPP_01" as team number in the Team number field
	And I click Add entry button
	And I click generate database button
	Then I should see message that "Database successfully generated on MS SQL Server"

Scenario: Generated database that exists on MS SQL Server
	When I check Auto-generate entries checkbox
	And I enter "TIKPP_01" as team number in the Team number field
	And I click Add entry button
	And I click generate database button
	Then I should see error message that "Database already exists on MS SQL Server" 
