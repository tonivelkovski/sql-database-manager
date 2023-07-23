Feature: User Login

	As an user
	I want to be able to connect to the MS SQL Server instance using administrator account
	So that I can manage bulk database operations - create, delete, send email, etc.

	Scenario: Login form display
		When I launch the application
		Then I should see the login form

	Scenario Template: Invalid credentials
		Given I am on the login form
		When I enter server address <serverAddress>, username <username> and password <password>
		And I click on the Prijava button
		Then I should see <errorMessage> error message

		Examples:
		| serverAddress  | username | password             | errorMessage                     |
		|                |          |                      | Sva su polja obavezna.           |
		| localhost,1433 | sa       |                      | Sva su polja obavezna.           |
		| localhost,     | sa       | mojaJakaL=Z!NKA      | Nevažeći format adrese servera.  |
		| localhost,3000 | sa       | mojaJakaL=Z!NKA      | Server nije pronađen.            |
		| localhost,1433 | timmy    | mojaJakaL=Z!NKA      | Nevažeće vjerodajnice.           |
		| localhost,1433 | tin      | jakaL=Z!NKA          | Nevažeće vjerodajnice.           |
		| localhost,1433 | tin      | n3pr0b0jn0-wxhz-xycz | Nemate administratorske ovlasti. |

	Scenario: Valid credentials
		Given I am on the login form
		When I enter server address localhost,1433 with username sa and password mojaJakaL=Z!NKA
		And I click on the Prijava button
		Then I should be redirected to the initial form
		And I should see my username, along with current server address