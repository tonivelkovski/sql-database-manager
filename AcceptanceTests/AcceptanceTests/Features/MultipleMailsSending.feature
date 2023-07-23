Feature: Multiple mails sending

As an user
I want to be able to select more than one team
So that I can send mail to them.

Background:
	Given I am logged as an administrator
	And I am on the list of data on the server form

Scenario: Selecting multiple teams
	When I select first two teams 
	Then I should be able to see the selected teams

Scenario: Send emails for all selected teams
	When I select first two teams 
	Then I should be able to see the selected teams
	And I click on Send all emails button
	And I Click on Yes button
	Then I should receive message that "Mails are successfully sent to selected teams."

