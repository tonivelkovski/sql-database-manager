Feature: Single email sending

As an user
I want to be able to send single email with database data to team of my choice
So that team I choose receives email from application.

Background:
	Given I am logged as an administrator
	And I am on the list of data on the server form

Scenario: Email cannot be sent if the team is not selected
	When I click on the Send e-mail button
	Then I should see error message that "user must select team to send e-mail"

Scenario: Information about selected team is correct and displayed
	When I click on the desired team
	And I should click on the Send e-mail button
	Then I should see that fields are filled with data

Scenario: Information about the sender, recipient and content of the email can be edited
	When I click on the desired team
	And I should click on the Send e-mail button
	Then I should be able to edit From, To, BCC, Subject, Message fields

Scenario: Send an email to the entered email address of the team members
	When I click on the desired team
	And I should click on the Send e-mail button
	And I enter "teammail@student.foi.hr" into To field
	And I click on Send button
	Then Application sends email and close Send email form

Scenario: Email is not in correct format
	When I click on the desired team
	And I should click on the Send e-mail button
	And I enter "noreply_pi.foi.hr" to From field
	And I enter "teammail.com" to To field
	And I enter "tvelkovsk20foi.hr" to BCC field
	And I click on Send button
	Then I should see the error message that "Došlo je do pogreške: The specified string is not in the form required for an e-mail address."