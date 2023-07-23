Feature: Email Preferences

	As an MS SQL Server administrator
	I want to be able to change my email preferences
	So that I always have good default email settings when sending email(s)

	Background: 
		Given I am logged as an administrator
		And I am on the settings form

	Scenario: Email preferences form display
		Then I should see the application settings
		And I should see the email section

	Scenario: Available edit mode
		When I click on the Uredi button
		Then I should be able to edit all email settings
		And I should see Spremi and Odustani buttons
		
	Scenario: Exit edit mode
		When I click on the Uredi button
		Then I should be able to exit edit mode

	Scenario: Invalid email host
		When I click on the Uredi button
		And I clear the email host data
		And I click on the Spremi button
		Then I should see the error message that all fields must have a default value

	Scenario: Invalid email sender
		When I click on the Uredi button
		And I change the default email sender to "ttomasiccvfoi.hr"
		And I click on the Spremi button
		Then I should see the error message saying that the sender email address is not valid

	Scenario: Invalid BCC emails
		When I click on the Uredi button
		And I change the default BCC emails to "ttomasic20@student.foi.hr;mmijac@foi.hr"
		And I click on the Spremi button
		Then I should see the error message saying that the BCC emails field contains invalid email address(es)

	Scenario: Invalid email subject
		When I click on the Uredi button
		And I clear the default email subject
		And I click on the Spremi button
		Then I should see the error message that all fields must have a default value

	Scenario: Invalid email display name
		When I click on the Uredi button
		And I clear the default email display name
		And I click on the Spremi button
		Then I should see the error message that all fields must have a default value

	Scenario: Successful update
		When I click on the Uredi button
		And I change the default email sender to "tikpp@foi.hr"
		And I change the default BCC emails to "ttomasic20@student.foi.hr,dskrlac20@student.foi.hr,tvelkovsk20@student.foi.hr"
		And I change the default email subject to Baza podataka za projekt iz TIKPP-a
		And I click on the Spremi button
		Then I should see the newly updated email defaults
		And I should be able to edit all email settings
		And I should see Spremi and Odustani buttons